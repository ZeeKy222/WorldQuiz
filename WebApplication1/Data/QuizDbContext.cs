using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class QuizDbContext(DbContextOptions<QuizDbContext> options) : DbContext(options)
{
    public DbSet<Country> Countries => Set<Country>();

    public static IReadOnlyList<Country> SeedCountries { get; } =
    [
        new Country { Id = 1, Name = "France", Continent = "Europe", Code = "fr" },
        new Country { Id = 2, Name = "Italy", Continent = "Europe", Code = "it" },
        new Country { Id = 3, Name = "Germany", Continent = "Europe", Code = "de" },
        new Country { Id = 4, Name = "Greece", Continent = "Europe", Code = "gr" },
        new Country { Id = 5, Name = "Spain", Continent = "Europe", Code = "es" },
        new Country { Id = 6, Name = "Portugal", Continent = "Europe", Code = "pt" },
        new Country { Id = 7, Name = "United Kingdom", Continent = "Europe", Code = "gb" },
        new Country { Id = 8, Name = "Ireland", Continent = "Europe", Code = "ie" },
        new Country { Id = 9, Name = "Netherlands", Continent = "Europe", Code = "nl" },
        new Country { Id = 10, Name = "Belgium", Continent = "Europe", Code = "be" },
        new Country { Id = 11, Name = "Switzerland", Continent = "Europe", Code = "ch" },
        new Country { Id = 12, Name = "Austria", Continent = "Europe", Code = "at" },
        new Country { Id = 13, Name = "Poland", Continent = "Europe", Code = "pl" },
        new Country { Id = 14, Name = "Czech Republic", Continent = "Europe", Code = "cz" },
        new Country { Id = 15, Name = "Hungary", Continent = "Europe", Code = "hu" },
        new Country { Id = 16, Name = "Romania", Continent = "Europe", Code = "ro" },
        new Country { Id = 17, Name = "Bulgaria", Continent = "Europe", Code = "bg" },
        new Country { Id = 18, Name = "Croatia", Continent = "Europe", Code = "hr" },
        new Country { Id = 19, Name = "Serbia", Continent = "Europe", Code = "rs" },
        new Country { Id = 20, Name = "Norway", Continent = "Europe", Code = "no" },
        new Country { Id = 21, Name = "Sweden", Continent = "Europe", Code = "se" },
        new Country { Id = 22, Name = "Finland", Continent = "Europe", Code = "fi" },
        new Country { Id = 23, Name = "Denmark", Continent = "Europe", Code = "dk" },
        new Country { Id = 24, Name = "Iceland", Continent = "Europe", Code = "is" },

        new Country { Id = 25, Name = "Japan", Continent = "Asia", Code = "jp" },
        new Country { Id = 26, Name = "India", Continent = "Asia", Code = "in" },
        new Country { Id = 27, Name = "China", Continent = "Asia", Code = "cn" },
        new Country { Id = 28, Name = "Thailand", Continent = "Asia", Code = "th" },
        new Country { Id = 29, Name = "South Korea", Continent = "Asia", Code = "kr" },
        new Country { Id = 30, Name = "Vietnam", Continent = "Asia", Code = "vn" },
        new Country { Id = 31, Name = "Indonesia", Continent = "Asia", Code = "id" },
        new Country { Id = 32, Name = "Malaysia", Continent = "Asia", Code = "my" },
        new Country { Id = 33, Name = "Philippines", Continent = "Asia", Code = "ph" },
        new Country { Id = 34, Name = "Singapore", Continent = "Asia", Code = "sg" },
        new Country { Id = 35, Name = "Nepal", Continent = "Asia", Code = "np" },
        new Country { Id = 36, Name = "Bhutan", Continent = "Asia", Code = "bt" },
        new Country { Id = 37, Name = "Bangladesh", Continent = "Asia", Code = "bd" },
        new Country { Id = 38, Name = "Pakistan", Continent = "Asia", Code = "pk" },
        new Country { Id = 39, Name = "Sri Lanka", Continent = "Asia", Code = "lk" },
        new Country { Id = 40, Name = "Iran", Continent = "Asia", Code = "ir" },
        new Country { Id = 41, Name = "Iraq", Continent = "Asia", Code = "iq" },
        new Country { Id = 42, Name = "Israel", Continent = "Asia", Code = "il" },
        new Country { Id = 43, Name = "Saudi Arabia", Continent = "Asia", Code = "sa" },
        new Country { Id = 44, Name = "Jordan", Continent = "Asia", Code = "jo" },
        new Country { Id = 45, Name = "Turkey", Continent = "Asia", Code = "tr" },
        new Country { Id = 46, Name = "Mongolia", Continent = "Asia", Code = "mn" },
        new Country { Id = 47, Name = "Kazakhstan", Continent = "Asia", Code = "kz" },
        new Country { Id = 48, Name = "Uzbekistan", Continent = "Asia", Code = "uz" },

        new Country { Id = 49, Name = "Egypt", Continent = "Africa", Code = "eg" },
        new Country { Id = 50, Name = "Kenya", Continent = "Africa", Code = "ke" },
        new Country { Id = 51, Name = "Morocco", Continent = "Africa", Code = "ma" },
        new Country { Id = 52, Name = "South Africa", Continent = "Africa", Code = "za" },
        new Country { Id = 53, Name = "Nigeria", Continent = "Africa", Code = "ng" },
        new Country { Id = 54, Name = "Ghana", Continent = "Africa", Code = "gh" },
        new Country { Id = 55, Name = "Ethiopia", Continent = "Africa", Code = "et" },
        new Country { Id = 56, Name = "Tanzania", Continent = "Africa", Code = "tz" },
        new Country { Id = 57, Name = "Uganda", Continent = "Africa", Code = "ug" },
        new Country { Id = 58, Name = "Rwanda", Continent = "Africa", Code = "rw" },
        new Country { Id = 59, Name = "Algeria", Continent = "Africa", Code = "dz" },
        new Country { Id = 60, Name = "Tunisia", Continent = "Africa", Code = "tn" },
        new Country { Id = 61, Name = "Libya", Continent = "Africa", Code = "ly" },
        new Country { Id = 62, Name = "Sudan", Continent = "Africa", Code = "sd" },
        new Country { Id = 63, Name = "Senegal", Continent = "Africa", Code = "sn" },
        new Country { Id = 64, Name = "Mali", Continent = "Africa", Code = "ml" },
        new Country { Id = 65, Name = "Niger", Continent = "Africa", Code = "ne" },
        new Country { Id = 66, Name = "Zimbabwe", Continent = "Africa", Code = "zw" },
        new Country { Id = 67, Name = "Zambia", Continent = "Africa", Code = "zm" },
        new Country { Id = 68, Name = "Botswana", Continent = "Africa", Code = "bw" },
        new Country { Id = 69, Name = "Namibia", Continent = "Africa", Code = "na" },
        new Country { Id = 70, Name = "Angola", Continent = "Africa", Code = "ao" },
        new Country { Id = 71, Name = "Mozambique", Continent = "Africa", Code = "mz" },
        new Country { Id = 72, Name = "Madagascar", Continent = "Africa", Code = "mg" },

        new Country { Id = 73, Name = "Canada", Continent = "North America", Code = "ca" },
        new Country { Id = 74, Name = "United States", Continent = "North America", Code = "us" },
        new Country { Id = 75, Name = "Mexico", Continent = "North America", Code = "mx" },
        new Country { Id = 76, Name = "Cuba", Continent = "North America", Code = "cu" },
        new Country { Id = 77, Name = "Guatemala", Continent = "North America", Code = "gt" },
        new Country { Id = 78, Name = "Belize", Continent = "North America", Code = "bz" },
        new Country { Id = 79, Name = "Honduras", Continent = "North America", Code = "hn" },
        new Country { Id = 80, Name = "El Salvador", Continent = "North America", Code = "sv" },
        new Country { Id = 81, Name = "Nicaragua", Continent = "North America", Code = "ni" },
        new Country { Id = 82, Name = "Costa Rica", Continent = "North America", Code = "cr" },
        new Country { Id = 83, Name = "Panama", Continent = "North America", Code = "pa" },
        new Country { Id = 84, Name = "Jamaica", Continent = "North America", Code = "jm" },
        new Country { Id = 85, Name = "Haiti", Continent = "North America", Code = "ht" },
        new Country { Id = 86, Name = "Dominican Republic", Continent = "North America", Code = "do" },
        new Country { Id = 87, Name = "Bahamas", Continent = "North America", Code = "bs" },
        new Country { Id = 88, Name = "Barbados", Continent = "North America", Code = "bb" },
        new Country { Id = 89, Name = "Trinidad and Tobago", Continent = "North America", Code = "tt" },
        new Country { Id = 90, Name = "Greenland", Continent = "North America", Code = "gl" },
        new Country { Id = 91, Name = "Puerto Rico", Continent = "North America", Code = "pr" },
        new Country { Id = 92, Name = "Saint Lucia", Continent = "North America", Code = "lc" },
        new Country { Id = 93, Name = "Dominica", Continent = "North America", Code = "dm" },
        new Country { Id = 94, Name = "Grenada", Continent = "North America", Code = "gd" },
        new Country { Id = 95, Name = "Antigua and Barbuda", Continent = "North America", Code = "ag" },
        new Country { Id = 96, Name = "Saint Kitts and Nevis", Continent = "North America", Code = "kn" },

        new Country { Id = 97, Name = "Brazil", Continent = "South America", Code = "br" },
        new Country { Id = 98, Name = "Argentina", Continent = "South America", Code = "ar" },
        new Country { Id = 99, Name = "Chile", Continent = "South America", Code = "cl" },
        new Country { Id = 100, Name = "Peru", Continent = "South America", Code = "pe" },
        new Country { Id = 101, Name = "Colombia", Continent = "South America", Code = "co" },
        new Country { Id = 102, Name = "Venezuela", Continent = "South America", Code = "ve" },
        new Country { Id = 103, Name = "Ecuador", Continent = "South America", Code = "ec" },
        new Country { Id = 104, Name = "Bolivia", Continent = "South America", Code = "bo" },
        new Country { Id = 105, Name = "Paraguay", Continent = "South America", Code = "py" },
        new Country { Id = 106, Name = "Uruguay", Continent = "South America", Code = "uy" },
        new Country { Id = 107, Name = "Guyana", Continent = "South America", Code = "gy" },
        new Country { Id = 108, Name = "Suriname", Continent = "South America", Code = "sr" },
        new Country { Id = 109, Name = "French Guiana", Continent = "South America", Code = "gf" },
        new Country { Id = 110, Name = "Falkland Islands", Continent = "South America", Code = "fk" },
        new Country { Id = 111, Name = "South Georgia and South Sandwich Islands", Continent = "South America", Code = "gs" },
        new Country { Id = 112, Name = "Aruba", Continent = "South America", Code = "aw" },
        new Country { Id = 113, Name = "Curacao", Continent = "South America", Code = "cw" },
        new Country { Id = 114, Name = "Bonaire", Continent = "South America", Code = "bq" },
        new Country { Id = 115, Name = "Sint Maarten", Continent = "South America", Code = "sx" },
        new Country { Id = 116, Name = "Saint Martin", Continent = "South America", Code = "mf" },
        new Country { Id = 117, Name = "Martinique", Continent = "South America", Code = "mq" },
        new Country { Id = 118, Name = "Guadeloupe", Continent = "South America", Code = "gp" },
        new Country { Id = 119, Name = "Montserrat", Continent = "South America", Code = "ms" },
        new Country { Id = 120, Name = "British Virgin Islands", Continent = "South America", Code = "vg" },

        new Country { Id = 121, Name = "Australia", Continent = "Australia", Code = "au" },
        new Country { Id = 122, Name = "New Zealand", Continent = "Australia", Code = "nz" },
        new Country { Id = 123, Name = "Fiji", Continent = "Australia", Code = "fj" },
        new Country { Id = 124, Name = "Papua New Guinea", Continent = "Australia", Code = "pg" },
        new Country { Id = 125, Name = "Samoa", Continent = "Australia", Code = "ws" },
        new Country { Id = 126, Name = "Tonga", Continent = "Australia", Code = "to" },
        new Country { Id = 127, Name = "Vanuatu", Continent = "Australia", Code = "vu" },
        new Country { Id = 128, Name = "Solomon Islands", Continent = "Australia", Code = "sb" },
        new Country { Id = 129, Name = "Kiribati", Continent = "Australia", Code = "ki" },
        new Country { Id = 130, Name = "Tuvalu", Continent = "Australia", Code = "tv" },
        new Country { Id = 131, Name = "Nauru", Continent = "Australia", Code = "nr" },
        new Country { Id = 132, Name = "Palau", Continent = "Australia", Code = "pw" },
        new Country { Id = 133, Name = "Marshall Islands", Continent = "Australia", Code = "mh" },
        new Country { Id = 134, Name = "Micronesia", Continent = "Australia", Code = "fm" },
        new Country { Id = 135, Name = "Timor-Leste", Continent = "Australia", Code = "tl" },
        new Country { Id = 136, Name = "New Caledonia", Continent = "Australia", Code = "nc" },
        new Country { Id = 137, Name = "French Polynesia", Continent = "Australia", Code = "pf" },
        new Country { Id = 138, Name = "Guam", Continent = "Australia", Code = "gu" },
        new Country { Id = 139, Name = "Northern Mariana Islands", Continent = "Australia", Code = "mp" },
        new Country { Id = 140, Name = "American Samoa", Continent = "Australia", Code = "as" },
        new Country { Id = 141, Name = "Christmas Island", Continent = "Australia", Code = "cx" },
        new Country { Id = 142, Name = "Cocos Islands", Continent = "Australia", Code = "cc" },
        new Country { Id = 143, Name = "Norfolk Island", Continent = "Australia", Code = "nf" },
        new Country { Id = 144, Name = "Niue", Continent = "Australia", Code = "nu" }
    ];

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>().HasData(SeedCountries);
    }

    public static async Task SeedMissingCountriesAsync(QuizDbContext database)
    {
        var existingCodes = (await database.Countries
            .Select(country => country.Code)
            .ToListAsync())
            .ToHashSet();
        var missingCountries = SeedCountries
            .Where(country => !existingCodes.Contains(country.Code))
            .Select(country => new Country
            {
                Name = country.Name,
                Continent = country.Continent,
                Code = country.Code
            })
            .ToList();

        if (missingCountries.Count > 0)
        {
            database.Countries.AddRange(missingCountries);
            await database.SaveChangesAsync();
        }
    }
}
