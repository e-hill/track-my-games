using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using Refit;

namespace TrackMyGames.Refit
{
    public static class ApiResponseUtilities
    {
        public static string GetAccessTokenFromResponse(ApiResponse<string> response)
        {
            if (response.StatusCode != HttpStatusCode.Redirect)
            {
                throw new InvalidOperationException($"Cannot get access token from '{response.StatusCode}' response.");
            }

            var location = response.Headers.GetValues("Location").Single();
            var accessTokenMatcher = new Regex("access_token=(\\w{8}-\\w{4}-\\w{4}-\\w{4}-\\w{12})");
            var match = accessTokenMatcher.Match(location);

            if (!match.Success || match.Groups.Count < 2)
            {
                return string.Empty;
            }

            return match.Groups[1].Value;
        }
    }
}