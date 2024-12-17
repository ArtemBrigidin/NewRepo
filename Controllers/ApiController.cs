using Microsoft.AspNetCore.Mvc;
using Tanki_ASP.NET.Game.Interfaces;
using Tanki_ASP.NET.Controllers;
using Tanki_ASP.NET.Models;
using Tanki_ASP.NET.Game;

namespace AspNetCore.Controllers
{
    public class ApiController : Controller
    {
        private readonly IProfile _profile;
        private readonly IGameManager _gameManager;

        public ApiController(IProfile profile, IGameManager gameManager)
        {
            _profile = profile;
            _gameManager = gameManager;
        }

        [HttpGet]
        public IActionResult Login(string login, string password)
        {
            if (_profile.ValidateProfile(login, password))
            {
                return RedirectToAction("Lobby", "Game");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public IActionResult Registration(string username, string login, string password)
        {
            try
            {
                _profile.AddProfile(username, login, password);
                return RedirectToAction("Login", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ошибка регистрации: " + ex.Message;
                return View("Registration");
            }
        }

        public IActionResult Failure()
        {
            return View();
        }

        [HttpPost]
        [Route(nameof(StartGame))]
        public IActionResult StartGame()
        {
            var gameTanks = _gameManager.GetGameTanks(null);
            gameTanks.StartGame();
            var gameModel = new GameModel(gameTanks);
            Console.Clear();
            return PartialView("GameField", gameModel.GameFieldModel);
        }
    }
}
