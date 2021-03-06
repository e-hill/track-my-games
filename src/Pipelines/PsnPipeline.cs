using System.Linq;
using System.Threading.Tasks;
using TrackMyGames.Models;
using TrackMyGames.Refit;
using TrackMyGames.Repositories.Psn;

namespace TrackMyGames.Pipelines
{
    public class PsnPipeline : IPsnPipeline
    {
        private readonly IPsnGamesRepository _gamesRepository;
        private readonly IPsnTrophyCollectionRepository _collectionRepository;
        private readonly IPsnTrophyRepository _trophyRepository;
        private readonly IPsnTrophyGroupRepository _trophyGroupRepository;
        private readonly IPsnUserProgressRepository _userProgressRepository;

        public PsnPipeline(IPsnGamesRepository gamesRepository, IPsnTrophyCollectionRepository collectionRepository, IPsnTrophyRepository trophyRepository, IPsnTrophyGroupRepository trophyGroupRepository, IPsnUserProgressRepository userProgressRepository)
        {
            _trophyRepository = trophyRepository;
            _trophyGroupRepository = trophyGroupRepository;
            _gamesRepository = gamesRepository;
            _collectionRepository = collectionRepository;
            _userProgressRepository = userProgressRepository;
        }

        public async Task<PsnTrophyCollection> ProcessCollectionUpdate(GetTrophyTitlesResponse.TrophyTitlesDetails trophyTitle)
        {
            var collection = await EnsureCollectionExists(trophyTitle);
            var game = await EnsurePsnGameExists(trophyTitle);

            if (collection.GameId == null)
            {
                await _collectionRepository.LinkGameAsync(collection.Id, game.Id);
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
                await EnsurePsnUserProgressExists(trophyResponse.FromUser, trophy.Id);
            }
        }

        public async Task ProcessTrophyWithGroupUpdate(GetTrophiesResponse.TrophiesResponse trophyResponse, string psnId, int collectionId, int groupId)
        {
            var trophy = await EnsureTrophyExists(trophyResponse, collectionId);

            if (trophy.CollectionId == null)
            {
                await _trophyRepository.LinkCollectionAsync(trophy.Id, collectionId);
            }

            if (trophy.GroupId == null)
            {
                await _trophyRepository.LinkGroupAsync(trophy.Id, groupId);
            }

            if (trophyResponse.FromUser != null)
            {
                await EnsurePsnUserProgressExists(trophyResponse.FromUser, trophy.Id);
            }
        }

        public async Task<PsnTrophyGroup> ProcessTrophyGroupUpdate(GetTrophyGroupsResponse.TrophyGroupsDetails trophyGroupResponse, string psnId, int collectionId)
        {
            var trophyGroup = await EnsureTrophyGroupExists(trophyGroupResponse, collectionId);

            if (trophyGroup.CollectionId == null)
            {
                await _trophyGroupRepository.LinkCollectionAsync(trophyGroup.Id, collectionId);
            }

            return trophyGroup;
        }

        private async Task<PsnTrophyCollection> EnsureCollectionExists(GetTrophyTitlesResponse.TrophyTitlesDetails title)
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

        private async Task<PsnGame> EnsurePsnGameExists(GetTrophyTitlesResponse.TrophyTitlesDetails title)
        {
            PsnGame game = null;

            var games = await _gamesRepository.GetGamesByNameAsync(title.TrophyTitleName);

            if (!games.Any())
            {
                var newGame = new PsnGame
                {
                    Name = title.TrophyTitleName,
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

        private async Task<PsnTrophyGroup> EnsureTrophyGroupExists(GetTrophyGroupsResponse.TrophyGroupsDetails trophyGroupResponse, int collectionId)
        {
            var trophyGroup = await _trophyGroupRepository.GetTrophyGroupAsync(trophyGroupResponse.TrophyGroupId, collectionId);

            if (trophyGroup == null)
            {
                var newTrophyGroup = new PsnTrophyGroup
                {
                    Name = trophyGroupResponse.TrophyGroupName,
                    Detail = trophyGroupResponse.TrophyGroupDetail,
                    IconUrl = trophyGroupResponse.TrophyGroupIconUrl,
                    SmallIconUrl = trophyGroupResponse.TrophyGroupSmallIconUrl,
                    PsnId = trophyGroupResponse.TrophyGroupId,
                };

                trophyGroup = await _trophyGroupRepository.AddAsync(newTrophyGroup);
            }

            return trophyGroup;
        }

        private async Task<PsnTrophyProgress> EnsurePsnUserProgressExists(GetTrophiesResponse.TrophiesResponse.FromUserDetails fromUser, int trophyId)
        {
            var userProgress = await _userProgressRepository.GetUserProgressAsync(trophyId, fromUser.OnlineId);

            if (userProgress == null)
            {
                var newUserProgress = new PsnTrophyProgress
                {
                    Earned = fromUser.Earned,
                    EarnedDate = fromUser.EarnedDate,
                    OnlineId = fromUser.OnlineId,
                };

                userProgress = await _userProgressRepository.AddAsync(newUserProgress, trophyId);
            }
            else if (fromUser.Earned != userProgress.Earned || fromUser.EarnedDate != userProgress.EarnedDate)
            {
                userProgress.Earned = fromUser.Earned;
                userProgress.EarnedDate = fromUser.EarnedDate;

                await _userProgressRepository.UpdateAsync(userProgress);
            }

            return userProgress;
        }
    }
}