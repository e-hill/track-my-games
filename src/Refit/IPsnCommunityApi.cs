using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace TrackMyGames.Refit
{
    public interface IPsnCommunityApi
    {
        [Get("/trophy/v1/trophyTitles")]
        Task<GetTrophyTitlesResponse> GetTrophyTitles([Header("Authorization")] string accessToken, GetTrophyTitlesRequest request);
    }

    public class GetTrophyTitlesRequest
    {
        [AliasAs("fields")]
        public string Fields { get; set; }

        [AliasAs("platform")]
        public string Platform { get; set; }

        [AliasAs("limit")]
        public int? Limit { get; set; }

        [AliasAs("offset")]
        public int Offset { get; set; }

        [AliasAs("npLanguage")]
        public string NpLanguage { get; set; } = "en";
    }

    public class GetTrophyTitlesResponse
    {
        public int TotalResults { get; set; }

        public int Offset { get; set; }

        public int Limit { get; set; }

        public IEnumerable<TrophyTitlesResponse> TrophyTitles { get; set; }

        public class TrophyTitlesResponse
        {
            public string NpCommunicationId { get; set; }

            public string TrophyTitleName { get; set; }

            public string TrophyTitleDetail { get; set; }

            public string TrophyTitleIconUrl { get; set; }

            public string TrophyTitleSmallIconUrl { get; set; }

            public string TrophyTitlePlatfrom { get; set; }

            public bool HasTrophyGroups { get; set; }

            public TrophiesCountResponse DefinedTrophies { get; set; }

            public class TrophiesCountResponse
            {
                public int Bronze { get; set; }

                public int Silver { get; set; }

                public int Gold { get; set; }

                public int Platinum { get; set; }
            }

            public FromUserResponse FromUser { get; set; }

            public class FromUserResponse
            {
                public string OnlineId { get; set; }

                public int Progress { get; set; }

                public TrophiesCountResponse EarnedTrophies { get; set; }

                public bool HiddenFlag { get; set; }

                public DateTime LastUpdateDate { get; set; }
            }
        }
    }
}