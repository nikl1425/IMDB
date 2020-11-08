using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataService.Objects;

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
            var x = ctx.title_search
                .Where(s => s.Id.Equals(titleid));
            return x.ToList();
        }

        public Title getTitle(string id)
        {
            using var ctx = new ImdbContext();
            var query = ctx.title.Find(id);
            return query;
        }
        
        public Title getTitleEpisode()
    }
}