using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataService.Objects;
using Microsoft.EntityFrameworkCore;

namespace DataService.Services
{
    public class TitleDataService
    {
        public TitleDataService()
        {
            using var ctx = new ImdbContext();
        }

        public Genre GetGenre(int id)
        {
            using var ctx = new ImdbContext();
            return ctx.genre.Find(id);
        }

        public IList<Title_Search> TitleSearches(string titleid)
        {
            using var ctx = new ImdbContext();
            var query = ctx.title_search
                .Where(s => s.Id.Equals(titleid));
            return query.ToList();
        }

        public Title getTitle(string id)
        {
            using var ctx = new ImdbContext();
            var query = ctx.title.Find(id);
            return query;
        }

        public Title getTitleEpisode(string id)
        {
            using var ctx = new ImdbContext();
            var query = ctx.title.Where(x => x.Id == id)
                .Include(x => x.TitleEpisode).FirstOrDefault();
            return query;
        }

        public Title getTitleGenreName(string id)
        {
            using var ctx = new ImdbContext();

            // Denne title har 3 genre derfor er den udvalgt.

            var query = ctx.title
                .Include(x => x.TitleGenres)
                .ThenInclude(o => o.Genre)
                .AsSingleQuery()
                .FirstOrDefault(o => o.Id == id);

            return query;
        }


        public IList<Title_Person> getTitlePersons(string id)
        {
            using var ctx = new ImdbContext();

            var query = ctx.TitlePersons
                .Where(x => x.TitleId == id)
                .ToList();
            return query;
        }

        public Title getTitlePersonName(string id)
        {
            using var ctx = new ImdbContext();

            var query = ctx.title
                .Include(x => x.TitlePersons)
                .ThenInclude(x => x.Persons)
                .FirstOrDefault(x => x.Id == id);
            return query;
        }
    }
}