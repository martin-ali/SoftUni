using BattleCards.Common;
using BattleCards.Services;
using SIS.HTTP;
using SIS.MvcFramework;

namespace BattleCards.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        // Getting a controller makes it crash?
        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(string username, string email, string password, string confirmPassword)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var usernameIsValid = string.IsNullOrWhiteSpace(username) == false
                && username.Length >= Constants.UsernameMinLength
                && username.Length <= Constants.UsernameМaxLength;
            if (usernameIsValid == false)
            {
                return this.Error(Messages.WrongLength("Username", Constants.UsernameMinLength, Constants.UsernameМaxLength));
            }

            if (this.usersService.UsernameIsTaken(username))
            {
                return this.Error(Messages.Taken("Username"));
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                return this.Error(Messages.Invalid("Email"));
            }

            if (this.usersService.EmailIsTaken(email))
            {
                return this.Error(Messages.Taken("Email"));
            }

            var passwordIsValid = string.IsNullOrWhiteSpace(password) == false
                && password.Length >= Constants.PasswordMinLength
                && password.Length <= Constants.PasswordМaxLength;
            if (passwordIsValid == false)
            {
                return this.Error(Messages.WrongLength("Password", Constants.PasswordMinLength, Constants.PasswordМaxLength));
            }

            if (password != confirmPassword)
            {
                return this.Error("Passwords don't match");
            }

            this.usersService.Create(username, email, password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var userId = this.usersService.GetUserId(username, password);
            if (userId == null)
            {
                return this.Error("Invalid username or password");
            }

            this.SignIn(userId);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse Logout()
        {
            if (this.IsUserLoggedIn())
            {
                this.SignOut();
            }

            return this.Redirect("/");
        }
    }
}