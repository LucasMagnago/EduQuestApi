﻿using EduQuest.Domain.Security.Tokens;

namespace EduQuest.Api.Token
{
    public class HttpContextTokenValue : ITokenProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextTokenValue(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string TokenOnRequest()
        {
            var authorization = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

            return authorization.Replace("Bearer ", string.Empty);
        }
    }
}
