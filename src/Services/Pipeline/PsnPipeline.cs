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

        public PsnPipeline(IGamesRepository gamesRepository, IPsnTrophyCollectionRepository collectionRepository)
        {
            _gamesRepository = gamesRepository;
            _collectionRepository = collectionRepository;
        }

        public async Task ProcessUpdate(GetTrophyTitlesResponse trophyResponse)
        {
            if (trophyResponse.TrophyTitles == null)
            {
                return;
            }

            foreach (var title in trophyResponse.TrophyTitles)
            {
                var collection = await EnsureCollectionExists(title);
                var game = await EnsureGameExists(title);

                if (collection.GameId == null)
                {
                    await _collectionRepository.LinkGameAsync(collection.Id, game.Id);
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
    }
}