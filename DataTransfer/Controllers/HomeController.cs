using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DataTransfer.Models;

namespace DataTransfer.Controllers;

public class HomeController : Controller
{
    public IActionResult Index(string activeGame = "all", string activeCategory = "all")
    {
        CountryViewModel viewModel = new CountryViewModel()
        {
            ActiveGame = activeGame,
            ActiveCategory = activeCategory,
            Games = Country.AllGames(),
            Categories = Country.AllTypes()
        };
        
        // get teams
        List<Country> query = Country.AllCountries;

        if (activeGame != "all")
        {
            query = query.Where(x => x.Game.ToLower() == activeGame.ToLower()).ToList();
        }

        if (activeCategory != "all")
        {
            query = query.Where(x => x.SportAndType.ToLower() == activeCategory.ToLower()).ToList();
        }

        viewModel.Countries = query;
        
        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}