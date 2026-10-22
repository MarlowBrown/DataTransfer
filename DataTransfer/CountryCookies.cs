using DataTransfer.Models;

namespace DataTransfer;

public class CountryCookies
{

    private const string MyCountries = "mycountries";
    private const string Delimiter = "-";
    
    private IRequestCookieCollection _requestCookies { get; set; }
    private IResponseCookies _responseCookies { get; set; }

    public CountryCookies(IRequestCookieCollection cookies)
    {
        _requestCookies = cookies;
    }

    public CountryCookies(IResponseCookies cookies)
    {
        _responseCookies = cookies;
    }

    public void SetMyCountries(List<Country> countries)
    {
        List<string> names = countries.Select(x => x.Name).ToList();
        string idsString = String.Join(Delimiter, names);
        CookieOptions options = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(30)
        };
        RemoveMyCountries();
        _responseCookies.Append(MyCountries, idsString, options);
    }

    public string[] GetMyCountryIds()
    {
        string cookie = _requestCookies[MyCountries];
        if (string.IsNullOrEmpty(cookie))
        {
            return new string[] { };
        }

        return cookie.Split(Delimiter);
    }

    public void RemoveMyCountries()
    {
        _responseCookies.Delete(MyCountries);
    }

}