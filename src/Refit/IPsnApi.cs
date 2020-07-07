using System;
using System.Threading.Tasks;
using Refit;

namespace TrackMyGames.Refit
{
    public interface IPsnApi
    {
        [Post("/api/v1/oauth/token")]
        Task<GetTokenResponse> GetToken([Header("Meta-Cookie")] string npsso, [Body(BodySerializationMethod.UrlEncoded)] GetTokenRequest request);

        [Get("/api/v1/oauth/authorize")]
        Task<ApiResponse<string>> Authorize([Header("Meta-Cookie")] string npsso, AuthorizeRequest request);
    }

    public class GetTokenRequest
    {
        [AliasAs("grant_type")]
        public string GrantType { get; set; }

        [AliasAs("scope")]
        public string Scope { get; set; }

        [AliasAs("client_id")]
        public string ClientId { get; set; }

        [AliasAs("client_secret")]
        public string ClientSecret { get; set; }
    }

    public class GetTokenResponse
    {
        public string AccessToken { get; set; }

        public string TokenType { get; set; }

        public int ExpiresIn { get; set; }

        public string Scope { get; set; }

        public string IdToken { get; set; }

        public string AccountUuid { get; set; }
    }

    public class AuthorizeRequest
    {
        [AliasAs("response_type")]
        public string ResponseType { get; set; }

        [AliasAs("scope")]
        public string Scope { get; set; }

        [AliasAs("client_id")]
        public string ClientId { get; set; }

        [AliasAs("redirect_uri")]
        public string RedirectUri { get; set; }

        [AliasAs("prompt")]
        public string Prompt { get; set; }
    }
}