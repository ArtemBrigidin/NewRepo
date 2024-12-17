using Microsoft.AspNetCore.Mvc;
using Tanki_ASP.NET.Game;
using Tanki_ASP.NET.Game.Interfaces;

namespace Tanki_ASP.NET.Controllers
{
	[ApiController]
	[Route("api/Game")]
	public class GameApiController : ControllerBase
	{
		private readonly IGameManager _gameManager;

		// Конструктор для внедрения зависимостей
		public GameApiController(IGameManager gameManager)
		{
			_gameManager = gameManager;
		}

		// Метод для перемещения танка
		[HttpPost("move")]
		public IActionResult Move([FromBody] TankMovementRequest request)
		{
			if (request == null)
			{
				return BadRequest(new { success = false, message = "Invalid move data" });
			}

			// Логика перемещения танка
			var newTop = 0;
			var newLeft = 0;

			// В зависимости от направления обновляем координаты
			switch (request.Direction)
			{
				case "Up":
					newTop -= 10; // Например, сдвиг на 10 пикселей вверх
					break;
				case "Down":
					newTop += 10; // Сдвиг на 10 пикселей вниз
					break;
				case "Left":
					newLeft -= 10; // Сдвиг на 10 пикселей влево
					break;
				case "Right":
					newLeft += 10; // Сдвиг на 10 пикселей вправо
					break;
				default:
					return BadRequest(new { success = false, message = "Invalid direction" });
			}
			Console.WriteLine($"Direction: {request.Direction}, Top: {newTop}, Left: {newLeft}");

			// Возвращаем новые координаты танка
			return Ok(new
			{
				success = true,
				newTop,
				newLeft,
				message = "Tank moved successfully"
			});
		}
	}
}
