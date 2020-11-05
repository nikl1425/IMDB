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
    }
}