namespace Git.Controllers
{
    using Git.Common;
    using Git.Services;
    using Git.ViewModels.Users;
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        // Maybe use nameof?
        [HttpPost]
        public HttpResponse Register(UserInputModel input)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var usernameIsValid = string.IsNullOrWhiteSpace(input.Username) == false
                && input.Username.Length >= Constants.UsernameMinLength
                && input.Username.Length <= Constants.UsernameМaxLength;
            if (usernameIsValid == false)
            {
                return this.Error(Messages.WrongLength("Username", Constants.UsernameMinLength, Constants.UsernameМaxLength));
            }

            if (this.usersService.IsUsernameAvailable(input.Username) == false)
            {
                return this.Error(Messages.Taken("Username"));
            }

            if (string.IsNullOrWhiteSpace(input.Email))
            {
                return this.Error(Messages.Invalid("Email"));
            }

            if (this.usersService.IsEmailAvailable(input.Email) == false)
            {
                return this.Error(Messages.Taken("Email"));
            }

            var passwordIsValid = string.IsNullOrWhiteSpace(input.Password) == false
                && input.Password.Length >= Constants.PasswordMinLength
                && input.Password.Length <= Constants.PasswordМaxLength;
            if (passwordIsValid == false)
            {
                return this.Error(Messages.WrongLength("Password", Constants.PasswordMinLength, Constants.PasswordМaxLength));
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Error(Messages.DoNotMatch("Passwords"));
            }

            this.usersService.CreateUser(input.Username, input.Email, input.Password);

            return this.Redirect("/Users/Login");
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
                return this.Error(Messages.Invalid("Username or password"));
            }

            this.SignIn(userId);

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse Logout()
        {
            if (this.IsUserSignedIn())
            {
                this.SignOut();
            }

            return this.Redirect("/");
        }
    }
}