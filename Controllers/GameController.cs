using Microsoft.AspNetCore.Mvc;
using Tanki_ASP.NET.Game;
using Tanki_ASP.NET.Game.Interfaces;
using Tanki_ASP.NET.Models;

namespace Tanki_ASP.NET.Controllers
{
    public class GameController(IGameManager _gameManager) : Controller
    {
        public IActionResult Lobby()
        {
            return View("Lobby");
        }

        public IActionResult Game()
        {
            var game = _gameManager.GetGameTanks(null);
            var dataModel = new GameModel(game);
            return View(dataModel);
        }
    }
}