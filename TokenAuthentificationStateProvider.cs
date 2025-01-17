

namespace MAgistrFront
{
    using MAgistrFront.Infrastructure;
    using MAgistrFront.Pages;
    using Microsoft.AspNetCore.Components.Authorization;
    using System.Net.Http.Headers;
    using System.Security.Claims;
    using System.Text.Json;


    public class TokenAuthentificationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;

        public TokenAuthentificationStateProvider(ILocalStorageService localStorage)
        {
            _localStorageService = localStorage;
        }
        public  override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            AuthenticationState CreateAnonymous() {
                var anonymusIdentiy = new ClaimsIdentity();
                var anonymousPrincipal = new ClaimsPrincipal(anonymusIdentiy);
                return new AuthenticationState(anonymousPrincipal);
            }
            
                var token = await _localStorageService.GetAsync<SecurityToken>(nameof(SecurityToken));
            if(token == null)
            {
                return CreateAnonymous();
            }

            else if (string .IsNullOrEmpty(token.AccessToken)|| token.ExpiredOn<DateTime.Now)
            {
                return CreateAnonymous();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Country,"Rus"),
                new Claim(ClaimTypes.Name,token.UserName),
                new Claim(ClaimTypes.Expired,token.ExpiredOn.ToLongDateString()),
                new Claim(ClaimTypes.Role,"Admin"),
                new Claim("Dk","DK"),

            };
            var Identiy = new ClaimsIdentity(claims,"Token");
            var Principal = new ClaimsPrincipal(Identiy);
            return new AuthenticationState(Principal);



        }
        public void MakeUserAnonymous()
        {
            _localStorageService.RemoveAsync(nameof(SecurityToken));
            var anonymusIdentiy = new ClaimsIdentity();
            var anonymousPrincipal = new ClaimsPrincipal(anonymusIdentiy);
             var authState = Task.FromResult(new AuthenticationState(anonymousPrincipal));
            NotifyAuthenticationStateChanged(authState);
        }

    }

    
    //public class CustomAuthStateProvider : AuthenticationStateProvider
    //{
    //    private readonly HttpClient _httpClient;

    //    public CustomAuthStateProvider(HttpClient httpClient)
    //    {
    //        _httpClient = httpClient;
    //    }

    //    public async Task Login(string token)
    //    {
    //        var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt"));
    //        var authState = Task.FromResult(new AuthenticationState(authenticatedUser));

    //        NotifyAuthenticationStateChanged(authState);
    //        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
    //    }

    //    public void Logout()
    //    {
    //        var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
    //        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymousUser)));
    //        _httpClient.DefaultRequestHeaders.Authorization = null;
    //    }

    //    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    //    {
    //        var token = ""; // Получите токен из хранилища или другого источника (например, из LocalStorage)

    //        var authenticatedUser = string.IsNullOrEmpty(token)
    //            ? new ClaimsPrincipal(new ClaimsIdentity())
    //            : new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt"));

    //        return Task.FromResult(new AuthenticationState(authenticatedUser));
    //    }

    //    private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    //    {
    //        var payload = jwt.Split('.')[1];
    //        var jsonBytes = ParseBase64WithoutPadding(payload);
    //        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
    //        return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
    //    }

    //    private byte[] ParseBase64WithoutPadding(string base64)
    //    {
    //        switch (base64.Length % 4)
    //        {
    //            case 2: base64 += "=="; break;
    //            case 3: base64 += "="; break;
    //        }
    //        return Convert.FromBase64String(base64);
    //    }
    //}
}
