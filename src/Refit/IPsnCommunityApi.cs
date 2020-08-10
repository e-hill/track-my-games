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

        [Get("/trophy/v1/trophyTitles/{psnId}/trophyGroups")]
        Task<GetTrophyTitlesResponse> GetTrophyGroups([Header("Authorization")] string accessToken, string psnId, GetTrophyTitlesRequest request);

        [Get("/trophy/v1/trophyTitles/{psnId}/trophyGroups/default/trophies")]
        Task<GetTrophiesResponse> GetTrophies([Header("Authorization")] string accessToken, string psnId, GetTrophiesRequest request);

        [Get("/trophy/v1/trophyTitles/{psnId}/trophyGroups/{groupId}/trophies")]
        Task<GetTrophyTitlesResponse> GetTrophyTitlesByGroup([Header("Authorization")] string accessToken, string psnId, string groupId, GetTrophiesRequest request);
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

        public IEnumerable<TrophyTitlesDetails> TrophyTitles { get; set; }

        public class TrophyTitlesDetails
        {
            public string NpCommunicationId { get; set; }

            public string TrophyTitleName { get; set; }

            public string TrophyTitleDetail { get; set; }

            public string TrophyTitleIconUrl { get; set; }

            public string TrophyTitleSmallIconUrl { get; set; }

            public string TrophyTitlePlatfrom { get; set; }

            public bool HasTrophyGroups { get; set; }

            public TrophiesCount DefinedTrophies { get; set; }

            public class TrophiesCount
            {
                public int Bronze { get; set; }

                public int Silver { get; set; }

                public int Gold { get; set; }

                public int Platinum { get; set; }
            }

            public FromUserDetails FromUser { get; set; }

            public class FromUserDetails
            {
                public string OnlineId { get; set; }

                public int Progress { get; set; }

                public TrophiesCount EarnedTrophies { get; set; }

                public bool HiddenFlag { get; set; }

                public DateTime LastUpdateDate { get; set; }
            }
        }
    }

    public class GetTrophyGroupsRequest
    {
        [AliasAs("fields")]
        public string Fields { get; set; }

        [AliasAs("npLanguage")]
        public string NpLanguage { get; set; } = "en";
    }

    public class GetTrophyGroupsResponse
    {
        public TrophiesCount DefinedTrophies { get; set; }

        public class TrophiesCount
        {
            public int Bronze { get; set; }

            public int Silver { get; set; }

            public int Gold { get; set; }

            public int Platinum { get; set; }
        }

        public TrophyGroupsDetails TrophyGroups { get; set; }

        public class TrophyGroupsDetails
        {
            public TrophiesCount DefinedTrophies { get; set; }

            public FromUserDetails FromUser { get; set; }

            public class FromUserDetails
            {
                public TrophiesCount EarnedTrophies { get; set; }

                public bool HiddenFlag { get; set; }

                public DateTime LastUpdateDate { get; set; }

                public string OnlineId { get; set; }

                public int Progress { get; set; }
            }

            public string TrophyGroupDetail { get; set; }

            public string TrophyGroupIconUrl { get; set; }

            public string TrophyGroupId { get; set; }

            public string TrophyGroupName { get; set; }

            public string TrophyGroupSmallIconUrl { get; set; }
        }

        public string TrophyTitleDetail { get; set; }

        public string TrophyTitleIconUrl { get; set; }

        public string TrophyTitleName { get; set; }

        public string TrophyTitlePlatfrom { get; set; }
    }

    public class GetTrophiesRequest
    {
        [AliasAs("fields")]
        public string Fields { get; set; }

        [AliasAs("visibleType")]
        public int VisibleType { get; set; }

        [AliasAs("npLanguage")]
        public string NpLanguage { get; set; } = "en";
    }

    public class GetTrophiesResponse
    {
        public IEnumerable<TrophiesResponse> Trophies { get; set; }

        public class TrophiesResponse
        {
            public FromUserDetails FromUser { get; set; }

            public class FromUserDetails
            {
                public bool Earned { get; set; }

                public DateTime? EarnedDate { get; set; }

                public string OnlineId { get; set; }
            }

            public string TrophyDetail { get; set; }

            public float TrophyEarnedRate { get; set; }

            public bool TrophyHidden { get; set; }

            public string TrophyIconUrl { get; set; }

            public int TrophyId { get; set; }

            public string TrophyName { get; set; }

            public int TrophyRare { get; set; }

            public string TrophySmallIconUrl { get; set; }

            public string TrophyType { get; set; }
        }
    }
}