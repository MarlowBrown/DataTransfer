using DataTransfer.Models;

namespace DataTransfer;

public class MySession
{

    private const string CountriesKey = "countries";
    
    private ISession session { get; set; }

    public MySession(ISession session)
    {
        this.session = session;
    }

    public List<Country> GetCountries() => session.GetObject<List<Country>>(CountriesKey) ?? new List<Country>();

    public void SetCountries(List<Country> countries)
    {
        session.SetObject(CountriesKey, countries);
    }
    
}