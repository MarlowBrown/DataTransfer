namespace DataTransfer.Models;

public class Country
{
    public string Name { get; set; }
    public string Game { get; set; }
    public string SportAndType { get; set; }
    public string LogoName => $"{Name}.png";

    public static List<Country> AllCountries = new List<Country>()
    {
        new Country()
        {
            Name = "Canada",
            Game = "Winter Olympics",
            SportAndType = "Curling-Indoor"
        },
        new Country()
        {
            Name = "Sweden",
            Game = "Winter Olympics",
            SportAndType = "Curling-Indoor"
        },
        new Country()
        {
            Name = "Great Britain",
            Game = "Winter Olympics",
            SportAndType = "Curling-Indoor"
        },
        new Country()
        {
            Name = "Jamaica",
            Game = "Winter Olympics",
            SportAndType = "Bobsleigh-Outdoor"
        },
        new Country()
        {
            Name = "Italy",
            Game = "Winter Olympics",
            SportAndType = "Bobsleigh-Outdoor"
        },
        new Country()
        {
            Name = "Japan",
            Game = "Winter Olympics",
            SportAndType = "Bobsleigh-Outdoor"
        },
        new Country()
        {
            Name = "Germany",
            Game = "Summer Olympics",
            SportAndType = "Diving-Indoor"
        },
        new Country()
        {
            Name = "China",
            Game = "Summer Olympics",
            SportAndType = "Diving-Indoor"
        },
        new Country()
        {
            Name = "Mexico",
            Game = "Summer Olympics",
            SportAndType = "Diving-Indoor"
        },
        new Country()
        {
            Name = "Brazil",
            Game = "Summer Olympics",
            SportAndType = "Road Cycling-Outdoor"
        },
        new Country()
        {
            Name = "Netherlands",
            Game = "Summer Olympics",
            SportAndType = "Cycling-Outdoor"
        },
        new Country()
        {
            Name = "USA",
            Game = "Summer Olympics",
            SportAndType = "Road Cycling-Outdoor"
        },
        new Country()
        {
            Name = "Thailand",
            Game = "Paralympics",
            SportAndType = "Archery-Indoor"
        },
        new Country()
        {
            Name = "Uruguay",
            Game = "Paralympics",
            SportAndType = "Archery-Indoor"
        },
        new Country()
        {
            Name = "Ukraine",
            Game = "Paralympics",
            SportAndType = "Archery-Indoor"
        },
        new Country()
        {
            Name = "Austria",
            Game = "Paralympics",
            SportAndType = "Canoe Sprint-Outdoor"
        },
        new Country()
        {
            Name = "Pakistan",
            Game = "Paralympics",
            SportAndType = "Canoe Sprint-Outdoor"
        },
        new Country()
        {
            Name = "Zimbabwe",
            Game = "Paralympics",
            SportAndType = "Canoe Sprint-Outdoor"
        },
        new Country()
        {
            Name = "France",
            Game = "Youth Olympic Games",
            SportAndType = "Breakdancing-Indoor"
        },
        new Country()
        {
            Name = "Cyprus",
            Game = "Youth Olympic Games",
            SportAndType = "Breakdancing-Indoor"
        },
        new Country()
        {
            Name = "Russia",
            Game = "Youth Olympic Games",
            SportAndType = "Breakdancing-Indoor"
        },
        new Country()
        {
            Name = "Finland",
            Game = "Youth Olympic Games",
            SportAndType = "Skateboarding-Outdoor"
        },
        new Country()
        {
            Name = "Slovakia",
            Game = "Youth Olympic Games",
            SportAndType = "Skateboarding-Outdoor"
        },
        new Country()
        {
            Name = "Portugal",
            Game = "Youth Olympic Games",
            SportAndType = "Skateboarding-Outdoor"
        }
    };
    
    public static List<string> AllGames()
    {
        HashSet<string> allGames = AllCountries.Select(x => x.Game).ToHashSet();
        return allGames.ToList();
    }

    public static List<string> AllTypes()
    {
        HashSet<string> allTypes = AllCountries.Select(x => x.SportAndType).ToHashSet();
        return allTypes.ToList();
    }
}