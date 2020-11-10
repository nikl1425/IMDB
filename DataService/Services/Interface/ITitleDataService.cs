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

        List<Genre> getGenreTitles(int id);
    }
}