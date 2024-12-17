using Tanki_ASP.NET.Game.Interfaces;

namespace Tanki_ASP.NET.Models
{
    public class GameModel
    {
        public int TankTop { get; set; }
        public int TankLeft { get; set; }
        public GameFieldModel GameFieldModel { get; private set; }
        public GameFightFieldModel GameFightFieldModel { get; private set; }
        public void MoveTank(int deltaTop, int deltaLeft)
        {
            TankTop += deltaTop;
            TankLeft += deltaLeft;
        }

        public GameModel(IGameTanks game)
        {
            GameFieldModel = new GameFieldModel(game);
            GameFightFieldModel = new GameFightFieldModel(game);
        }
    }
}
