using DataTransfer.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataTransfer.Controllers;

public class FavoritesController : Controller
{

    [HttpGet]
    public ViewResult Index()
    {
        var session = new CountriesSession(HttpContext.Session);
        var model = new CountriesViewModel()
        {
            ActiveCategory = session.GetActiveCategory(),
            ActiveGame = session.GetActiveGame(),
            Countries = session.GetCountries()
        };
        return View(model);
    }

    [HttpPost]
    public RedirectToActionResult Delete()
    {
        var session = new CountriesSession(HttpContext.Session);
        var cookies = new CountryCookies(Response.Cookies);
        
        session.RemoveCountries();
        cookies.RemoveMyCountries();

        return RedirectToAction("Index", "Home",
            new
            {
                ActiveGame = session.GetActiveGame(),
                ActiveCategory = session.GetActiveCategory()
            });
    }
    
}