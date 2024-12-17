namespace Tanki_ASP.NET.Game.Interfaces
{
    public interface IGameManager
    {
        IGameTanks GetGameTanks(IGameCredentials? credentials);
        void InitGameTanks(IGameCredentials? credentials);
    }
}
