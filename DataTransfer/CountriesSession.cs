using DataTransfer.Models;

namespace DataTransfer;

public class CountriesSession
{
    private const string CountriesKey = "mycountries";
    private const string CountKey = "countrycount";
    private const string GameKey = "game";
    private const string CategoryKey = "category";
    
    private ISession session { get; set; }

    public CountriesSession(ISession session)
    {
        this.session = session;
    }

    public void SetCountries(List<Country> countries)
    {
        session.SetObject(CountriesKey, countries);
        session.SetInt32(CountKey, countries.Count);
    }
    
    public List<Country> GetCountries() => session.GetObject<List<Country>>(CountriesKey) ?? new List<Country>();
    public int? GetCountryCount() => session.GetInt32(CountKey);

    public void SetActiveGame(string game) => session.SetString(GameKey, game);
    public string GetActiveGame() => session.GetString(GameKey);

    public void SetActiveCategory(string category) => session.SetString(CategoryKey, category);
    public string GetActiveCategory() => session.GetString(CategoryKey);

    public void RemoveCountries()
    {
        session.Remove(CountriesKey);
        session.Remove(CountKey);
    }

}