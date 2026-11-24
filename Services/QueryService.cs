using LAB5.Models;

namespace LAB5.Services
{
    public class QueryService
    {

        public List<Club> Query1(List<Club> clubs)
        {
            return clubs
                .OrderBy(c => c.Name)
                .ToList();
        }

        public int Query2(
            List<Club> clubs,
            List<Country> countries)
        {
            return clubs
                .Join(
                    countries,
                    c => c.CountryId,
                    country => country.Id,
                    (c, country) => c)
                .Count();
        }

        public List<string> Query3(
            List<Club> clubs,
            List<Country> countries,
            List<Achievement> achievements)
        {
            return clubs
                .Join(
                    countries,
                    c => c.CountryId,
                    country => country.Id,
                    (c, country) => new
                    {
                        Club = c,
                        Country = country
                    })
                .Join(
                    achievements,
                    x => x.Club.Id,
                    a => a.ClubId,
                    (x, a) => new
                    {
                        x.Club,
                        x.Country,
                        Achievement = a
                    })
                .Where(x =>
                    x.Achievement.Gold > 0
                    && x.Achievement.Cup == 0)
                .Select(x =>
                    x.Club.Name + " | " + x.Country.Name)
                .ToList();
        }

        public int Query4(
            List<Club> clubs,
            List<Country> countries,
            List<Achievement> achievements)
        {
            return clubs
                .Join(
                    countries,
                    c => c.CountryId,
                    country => country.Id,
                    (c, country) => new
                    {
                        Club = c,
                        Country = country
                    })
                .Join(
                    achievements,
                    x => x.Club.Id,
                    a => a.ClubId,
                    (x, a) => new
                    {
                        x.Country,
                        Achievement = a
                    })
                .Where(x =>
                    x.Achievement.Gold > 0
                    && x.Achievement.Cup == 0)
                .OrderByDescending(x => x.Achievement.Gold)
                .ThenByDescending(x => x.Country.Id)
                .Select(x => x.Country.Id)
                .FirstOrDefault();
        }
    }
}