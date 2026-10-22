namespace DataTransfer.Models;

public class CountriesViewModel : CountryViewModel
{
    public List<Country> Countries { get; set; }
    
    private List<string> games;
    public List<string> Games
    {
        get => games;
        set
        {
            games = value;
            games.Insert(0, "all");
        }
    }

    private List<string> categories;
    public List<string> Categories
    {
        get => categories;
        set
        {
            categories = value;
            categories.Insert(0, "all");
        }
    }

    public string CheckActiveGame(string game) => game.ToLower() == ActiveGame.ToLower() ? "active" : "";
    public string CheckActiveCategory(string category) =>
        category.ToLower() == ActiveCategory.ToLower() ? "active" : "";
}