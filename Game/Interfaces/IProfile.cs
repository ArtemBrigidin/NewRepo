namespace Tanki_ASP.NET.Game.Interfaces
{
    public interface IProfile
    {
        bool ValidateProfile(string username, string password);
        void AddProfile(string username, string login, string password);
    }
}
