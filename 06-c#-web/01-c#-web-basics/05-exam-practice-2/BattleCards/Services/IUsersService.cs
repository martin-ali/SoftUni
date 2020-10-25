namespace BattleCards.Services
{
    public interface IUsersService
    {
        void Create(string username, string email, string password);

        bool UsernameIsTaken(string username);

        bool EmailIsTaken(string email);

        string GetUserId(string username, string password);
    }
}