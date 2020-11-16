using System.Collections.Generic;
using DataService.Objects;

namespace DataService.Services
{
    public interface ITitleDataService
    {
        Genre GetGenre(int id);
        IList<Title_Search> TitleSearches(string titleid);
        Title getTitle(string id);
        Title getTitleEpisode(string id);
        Title getTitleGenreName(string id);
        IList<Title_Person> getTitlePersons(string id);
        Title getTitlePersonName(string id);

        List<Genre> GetGenres();

        List<Title_Genre> getGenreTitles(int id);

        public IList<Title> GetTitles();

        IList<Title_Genre> GetTitleGenres(string id);

        public List<Akas> GetTitleAkas(string id);

        public Akas GetAkas(int id);

        public Title_Episode GetTitleEpisode(string id);

        public IList<Title_Episode> GetMoreTitleEpisode(string id);
    }
}