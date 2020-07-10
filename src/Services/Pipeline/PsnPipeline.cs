using System.Linq;
using System.Threading.Tasks;
using TrackMyGames.Models;
using TrackMyGames.Refit;
using TrackMyGames.Repositories;

namespace TrackMyGames.Services.Pipeline
{
    public class PsnPipeline : IPsnPipeline
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly IPsnTrophyCollectionRepository _collectionRepository;
        private readonly IPsnTrophyRepository _trophyRepository;

        public PsnPipeline(IGamesRepository gamesRepository, IPsnTrophyCollectionRepository collectionRepository, IPsnTrophyRepository trophyRepository)
        {
            _trophyRepository = trophyRepository;
            _gamesRepository = gamesRepository;
            _collectionRepository = collectionRepository;
        }

        public async Task ProcessTitlesUpdate(GetTrophyTitlesResponse trophyTitlesResponse)
        {
            if (trophyTitlesResponse.TrophyTitles == null)
            {
                return;
            }

            foreach (var title in trophyTitlesResponse.TrophyTitles)
            {
                var collection = await EnsureCollectionExists(title);
                var game = await EnsureGameExists(title);

                if (collection.GameId == null)
                {
                    await _collectionRepository.LinkGameAsync(collection.Id, game.Id);
                }
            }
        }

        public async Task ProcessTrophiesUpdate(GetTrophiesResponse trophiesResponse, string psnId)
        {
            if (trophiesResponse.Trophies == null)
            {
                return;
            }

            var collection = await _collectionRepository.GetByPsnIdAsync(psnId);

            foreach (var trophyResponse in trophiesResponse.Trophies)
            {
                var trophy = await EnsureTrophyExists(trophyResponse, collection.Id);

                if (trophy.CollectionId == null)
                {
                    await _trophyRepository.LinkCollectionAsync(trophy.Id, collection.Id);
                }
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
    }
}