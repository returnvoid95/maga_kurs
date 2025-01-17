
using MAgistrFront.Infrastructure;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace MAgistrFront.Pages
{
    public class LoginViewModel : ComponentBase
    {

         public LoginModel loginModel = new LoginModel();
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public ILocalStorageService LocalStorageService { get; set; }
        public LoginViewModel()
        {
            LoginData = new LoginModel();
        }
        public LoginModel LoginData { get; set; }

        public async Task HandleLogin()
        {

            var Token = new SecurityToken
            {
                AccessToken = loginModel.Password,
                UserName = loginModel.Username,
                ExpiredOn = DateTime.UtcNow.AddDays(1)
            };

            await LocalStorageService.SetAsync(nameof(SecurityToken), Token);
            NavigationManager.NavigateTo("/",true);
            //var response = await Http.PostAsJsonAsync("https://localhost:7019/registration/login", loginModel);
            //if (response.IsSuccessStatusCode)
            //{
            //    var token = await response.Content.ReadAsStringAsync();
            //    await AuthStateProvider.Login(token);
            //    // Перенаправление или другое действие после успешного входа
            //}
        }


    }

    public class SecurityToken
    {
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public DateTime ExpiredOn { get; set; }
    }
    public class LoginModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Сликом длиный Email")]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
