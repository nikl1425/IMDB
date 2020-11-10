using System;
using System.Collections.Generic;
using System.Linq;
using DataService;
using DataService.Objects;
using Microsoft.EntityFrameworkCore;

namespace TestQueryConsole
{
    class Program
    {


        static void Main(string[] args)
        {
            using var ctx = new ImdbContext();

           


            Genre getGenreTitles(int id)
            {
                var query = ctx.genre
                    .Where(x => x.Id == id)
                    .Include(x => x.TitleGenres)
                    .ThenInclude(x => x.Title)
                    .FirstOrDefault();
                return query;
            }

            getGenreTitles(1);


        }
    }
}