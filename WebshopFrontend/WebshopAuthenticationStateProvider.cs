using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text.Json;
using System.Text;
using WebshopCore.Dtos;

namespace WebshopFrontend
{
    public class WebshopAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WebshopAuthenticationStateProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var client = _httpClientFactory.CreateClient("WebshopBackendAPI");

            try
            {
                var response = await client.GetAsync("account/AuthenticatedUser");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var user = JsonSerializer.Deserialize<WebshopUserDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (user != null && !string.IsNullOrEmpty(user.Id))
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.Id),
                            new Claim(ClaimTypes.Name, user.UserName)
                        };

                        var identity = new ClaimsIdentity(claims, IdentityConstants.ApplicationScheme);
                        var userPrincipal = new ClaimsPrincipal(identity);
                        return new AuthenticationState(userPrincipal);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching user: {ex.Message}");
            }

            return new AuthenticationState(new ClaimsPrincipal()); //not authenticated
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var client = _httpClientFactory.CreateClient("WebshopBackendAPI");

            try
            {
                var json = JsonSerializer.Serialize(new { Email = email, Password = password });
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("account/login?useCookies=true", content);

                if (response.IsSuccessStatusCode)
                {
                    Task<AuthenticationState> authState = GetAuthenticationStateAsync();
                    NotifyAuthenticationStateChanged(authState);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging in: {ex.Message}");
            }
            return false;
        }

        public async Task LogoutAsync()
        {
            var client = _httpClientFactory.CreateClient("WebshopBackendAPI");

            try
            {
                var response = await client.PostAsync("account/logout", null);
                if (response.IsSuccessStatusCode)
                {
                    Task<AuthenticationState> authState = GetAuthenticationStateAsync();
                    NotifyAuthenticationStateChanged(authState);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging out: {ex.Message}");
            }
        }
    }
}
