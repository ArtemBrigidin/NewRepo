using Tanki_ASP.NET.Game.Enums;

namespace Tanki_ASP.NET.Game
{
    public class GameField
    {
        public int FieldWidth => 15;
        public int FieldHeight => 15;

        public GameCellTile[][] Map { get; private set; }
        public (int Top, int Left) TankPosition { get; private set; }

        public GameField()
        {
            Map = InitializeMap();
            GenerateMap();
        }

        private void GenerateMap()
        {
            GenerateBrickCells(60);  // 60% клеток с кирпичами
            GenerateBadRock();       // Генерация "плохих" камней

            Map[FieldHeight / 2][^1] = GameCellTile.FriendlyBase; // Дружеская база
            Map[FieldHeight / 2][0] = GameCellTile.EnemyBase;     // Вражеская база

            TankPosition = (FieldHeight / 2, FieldWidth - 1);  // Начальная позиция танка
            Map[TankPosition.Top][TankPosition.Left] = GameCellTile.Tank;  // Позиция танка
        }

        private void GenerateBadRock()
        {
            for (int row = 2; row < FieldHeight - 2; row += 2)
            {
                for (int column = 2; column < FieldWidth - 2; column += 2)
                {
                    Map[row][column] = GameCellTile.BadRock;
                }
            }
        }

        private void GenerateBrickCells(int fillPercent)
        {
            Random random = new Random();

            for (int row = 0; row < FieldHeight; row++)
            {
                for (int column = 0; column < FieldWidth; column++)
                {
                    int randomValue = random.Next(0, 100);
                    if (randomValue <= fillPercent)
                    {
                        Map[row][column] = GameCellTile.Brick;
                    }
                }
            }
        }

        private GameCellTile[][] InitializeMap()
        {
            GameCellTile[][] map = new GameCellTile[FieldHeight][];

            for (int i = 0; i < FieldHeight; i++)
            {
                map[i] = new GameCellTile[FieldWidth];
                Array.Fill(map[i], GameCellTile.Empty);  // Заполнение пустыми клетками
            }

            return map;
        }

        public void MoveTank(int deltaTop, int deltaLeft)
        {
            int newTop = TankPosition.Top + deltaTop;
            int newLeft = TankPosition.Left + deltaLeft;

            if (newTop >= 0 && newTop < FieldHeight && newLeft >= 0 && newLeft < FieldWidth)
            {
                // Если танк на кирпиче, ломаем его
                if (Map[newTop][newLeft] == GameCellTile.Brick)
                {
                    Map[newTop][newLeft] = GameCellTile.Empty; // Ломаем кирпич
                }

                TankPosition = (newTop, newLeft);
                Map[TankPosition.Top][TankPosition.Left] = GameCellTile.Tank; // Обновляем позицию танка
            }
        }
    }
}
