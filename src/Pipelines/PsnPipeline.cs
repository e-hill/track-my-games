using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackMyGames.Models;
using TrackMyGames.Refit;
using TrackMyGames.Repositories;

namespace TrackMyGames.Pipelines
{
    public class PsnPipeline : IPsnPipeline
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly IGoalsRepository _goalsRepository;
        private readonly IPsnTrophyCollectionRepository _collectionRepository;
        private readonly IPsnTrophyRepository _trophyRepository;
        private readonly IPsnUserRepository _userRepository;
        private readonly IPsnUserProgressRepository _userProgressRepository;

        public PsnPipeline(IGamesRepository gamesRepository, IGoalsRepository goalsRepository, IPsnTrophyCollectionRepository collectionRepository, IPsnTrophyRepository trophyRepository, IPsnUserRepository userRepository, IPsnUserProgressRepository userProgressRepository)
        {
            _trophyRepository = trophyRepository;
            _gamesRepository = gamesRepository;
            _goalsRepository = goalsRepository;
            _collectionRepository = collectionRepository;
            _userRepository = userRepository;
            _userProgressRepository = userProgressRepository;
        }

        public async Task<PsnTrophyCollection> ProcessCollectionUpdate(GetTrophyTitlesResponse.TrophyTitlesResponse trophyTitle)
        {
            var collection = await EnsureCollectionExists(trophyTitle);
            var game = await EnsureGameExists(trophyTitle);

            if (collection.GameId == null)
            {
                await _collectionRepository.LinkGameAsync(collection.Id, game.Id);
            }

            var goal = await EnsurePsnTrophyGoalExists(game.Goals);

            if (goal.GameId == null)
            {
                await _goalsRepository.LinkGameAsync(goal.Id, game.Id);
            }

            return collection;
        }

        public async Task ProcessTrophyUpdate(GetTrophiesResponse.TrophiesResponse trophyResponse, string psnId, int collectionId)
        {
            var trophy = await EnsureTrophyExists(trophyResponse, collectionId);

            if (trophy.CollectionId == null)
            {
                await _trophyRepository.LinkCollectionAsync(trophy.Id, collectionId);
            }

            if (trophyResponse.FromUser != null)
            {
                var user = await EnsurePsnUserExists(trophyResponse.FromUser.OnlineId);
                var userProgress = await EnsurePsnUserProgressExists(trophy.Id, user.Id);

                userProgress.Earned = trophyResponse.FromUser.Earned;
                userProgress.EarnedDate = trophyResponse.FromUser.EarnedDate;

                await _userProgressRepository.UpdateAsync(userProgress);
            }
        }

        private async Task<PsnTrophyCollection> EnsureCollectionExists(GetTrophyTitlesResponse.TrophyTitlesResponse title)
        {
            var collection = await _collectionRepository.GetByPsnIdAsync(title.NpCommunicationId);

            if (collection == null)
            {
                var newCollection = new PsnTrophyCollection
                {
                    PsnId = title.NpCommunicationId,
                    Name = title.TrophyTitleName,
                    Detail = title.TrophyTitleDetail,
                    Platform = title.TrophyTitlePlatfrom,
                    IconUrl = title.TrophyTitleIconUrl,
                    SmallIconUrl = title.TrophyTitleSmallIconUrl
                };

                collection = await _collectionRepository.AddAsync(newCollection);
            }

            return collection;
        }

        private async Task<Game> EnsureGameExists(GetTrophyTitlesResponse.TrophyTitlesResponse title)
        {
            Game game = null;

            var games = await _gamesRepository.GetGamesByNameAsync(title.TrophyTitleName);

            if (!games.Any())
            {
                var newGame = new Game
                {
                    Name = title.TrophyTitleName,
                    ReleaseDate = "",
                    System = title.TrophyTitlePlatfrom,
                };

                game = await _gamesRepository.AddGameAsync(newGame);
            }
            else
            {
                game = games.First();
            }

            return game;
        }

        private async Task<PsnTrophy> EnsureTrophyExists(GetTrophiesResponse.TrophiesResponse trophyResponse, int collectionId)
        {
            var trophy = await _trophyRepository.GetTrophyAsync(trophyResponse.TrophyId, collectionId);

            if (trophy == null)
            {
                var newTrophy = new PsnTrophy
                {
                    Name = trophyResponse.TrophyName,
                    Detail = trophyResponse.TrophyDetail,
                    Type = trophyResponse.TrophyType,
                    IconUrl = trophyResponse.TrophyIconUrl,
                    SmallIconUrl = trophyResponse.TrophySmallIconUrl,
                    Hidden = trophyResponse.TrophyHidden,
                    Rare = trophyResponse.TrophyRare,
                    EarnedRate = trophyResponse.TrophyEarnedRate,
                    PsnId = trophyResponse.TrophyId,
                };

                trophy = await _trophyRepository.AddAsync(newTrophy);
            }

            return trophy;
        }

        private async Task<Goal> EnsurePsnTrophyGoalExists(IEnumerable<Goal> goals)
        {
            var goal = goals.SingleOrDefault(x => x.Name == Goal.PsnTrophiesName);

            if (goal == null)
            {
                var newGoal = new Goal
                {
                    Name = Goal.PsnTrophiesName
                };

                goal = await _goalsRepository.AddAsync(newGoal);
            }

            return goal;
        }

        private async Task<PsnUser> EnsurePsnUserExists(string onlineId)
        {
            var user = await _userRepository.GetUserAsync(onlineId);

            if (user == null)
            {
                var newUser = new PsnUser
                {
                    OnlineId = onlineId
                };

                user = await _userRepository.AddAsync(newUser);
            }

            return user;
        }

        private async Task<PsnUserProgress> EnsurePsnUserProgressExists(int trophyId, int userId)
        {
            var userProgress = await _userProgressRepository.GetUserProgressAsync(trophyId, userId);

            if (userProgress == null)
            {
                userProgress = await _userProgressRepository.AddAsync(trophyId, userId);
            }

            return userProgress;
        }
    }
}