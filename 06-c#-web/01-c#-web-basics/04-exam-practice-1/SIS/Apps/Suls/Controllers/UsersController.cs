using System.ComponentModel.DataAnnotations;
using Suls.Services;
using Suls.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Suls.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var userId = this.usersService.GetUserId(username, password);
            if (userId == null)
            {
                return this.Error("Invalid username or password");
            }

            this.SignIn(userId);
            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserInputModel input)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            // Username validation
            var usernameIsValid = string.IsNullOrWhiteSpace(input.Username) == false
                && input.Username.Length >= 5
                && input.Username.Length <= 20;
            if (usernameIsValid == false)
            {
                return this.Error("Username should be between 5 and 20 characters");
            }

            if (this.usersService.IsUsernameAvailable(input.Username) == false)
            {
                return this.Error("Username is taken");
            }

            // Email validation
            var emailIsValid = string.IsNullOrWhiteSpace(input.Email) == false
                && new EmailAddressAttribute().IsValid(input.Email);
            if (emailIsValid == false)
            {
                return this.Error("Invalid email");
            }

            if (this.usersService.IsEmailAvailable(input.Email) == false)
            {
                return this.Error("Email is taken");
            }

            // Password validation
            var passwordIsValid = string.IsNullOrWhiteSpace(input.Password) == false
                && input.Password.Length >= 6
                && input.Password.Length <= 20;
            if (passwordIsValid == false)
            {
                return this.Error("Password should be between 6 and 20 characters");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Error("Passwords do not match");
            }

            this.usersService.CreateUser(input.Username, input.Email, input.Password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (this.IsUserSignedIn() == false)
            {
                return this.Redirect("/");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}