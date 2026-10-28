using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DataTransfer.Models;

namespace DataTransfer.Controllers;

public class HomeController : Controller
{
    public IActionResult Index(CountryViewModel model)
    {
        var session = new CountriesSession(HttpContext.Session);
        session.SetActiveGame(model.ActiveGame);
        session.SetActiveCategory(model.ActiveCategory);

        int? count = session.GetCountryCount();
        if (count == null)
        {
            var cookies = new CountryCookies(Request.Cookies);
            string[] ids = cookies.GetMyCountryIds();

            List<Country> myCountries = new List<Country>();
            if (ids.Length > 0)
            {
                myCountries = Country.AllCountries.Where(x => ids.Contains(x.Name)).ToList();
            }
            session.SetCountries(myCountries);
        }
        
        CountriesViewModel viewModel = new CountriesViewModel()
        {
            ActiveGame = model.ActiveGame,
            ActiveCategory = model.ActiveCategory,
            Games = Country.AllGames(),
            Categories = Country.AllTypes()
        };
        
        // get teams
        List<Country> query = Country.AllCountries;

        if (model.ActiveGame != "all")
        {
            query = query.Where(x => x.Game.ToLower() == model.ActiveGame.ToLower()).ToList();
        }

        if (model.ActiveCategory != "all")
        {
            query = query.Where(x => x.SportAndType.ToLower() == model.ActiveCategory.ToLower()).ToList();
        }

        viewModel.Countries = query;
        
        return View(viewModel);
    }

    [HttpGet]
    public ViewResult Details(string id)
    {
        var session = new CountriesSession(HttpContext.Session);
        var model = new CountryViewModel()
        {
            Country = Country.AllCountries.First(t => t.Name == id),
            ActiveCategory = session.GetActiveCategory(),
            ActiveGame = session.GetActiveGame()
        };
        return View(model);
    }

    [HttpPost]
    public RedirectToActionResult Add(CountryViewModel model)
    {
        var session = new CountriesSession(HttpContext.Session);
        var countries = session.GetCountries();
        countries.Add(model.Country);
        session.SetCountries(countries);

        var cookies = new CountryCookies(Response.Cookies);
        cookies.SetMyCountries(countries);
        
        return RedirectToAction("Index", new
        {
            ActiveGame = session.GetActiveGame(),
            ActiveCategory = session.GetActiveCategory()
        });
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