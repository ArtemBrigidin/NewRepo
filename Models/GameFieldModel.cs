using Tanki_ASP.NET.Game.Interfaces;
using Tanki_ASP.NET.Models.Enums;

namespace Tanki_ASP.NET.Models
{
	public class GameFieldModel
	{
        public int FieldWidth { get; private set; }
        public int FieldHeight { get; private set; }

        public CellTile[][] Map { get; private set; }

        public GameFieldModel(IGameTanks game)
        {
            FieldHeight = game.GameField.FieldHeight;
            FieldWidth = game.GameField.FieldWidth;

            Map = game.GameField.Map.Select(x => x.Select(y => y.ToCellTile()).ToArray()).ToArray();

        }
	}
}