using Tanki_ASP.NET.Game.Enums;

namespace Tanki_ASP.NET.Models.Enums
{
    public static class CellTileExtension
    {
        public static Dictionary<GameCellTile, CellTile> _convertDictionary =
            new Dictionary<GameCellTile, CellTile>()
        {
            {GameCellTile.Brick, CellTile.Brick },
            {GameCellTile.EnemyBase, CellTile.EnemyBase },
            {GameCellTile.FriendlyBase, CellTile.FriendlyBase },
            {GameCellTile.BadRock, CellTile.BadRock },
            {GameCellTile.Empty, CellTile.Empty },
            {GameCellTile.Tank, CellTile.Tank }
        };

        public static CellTile ToCellTile(this GameCellTile source)
        {
            return _convertDictionary[source];
        }
    }
}
