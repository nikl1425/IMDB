using System;
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
            Title getTitlePersonName(string id)
            {
                using var ctx = new ImdbContext();
                var query = ctx.title
                    .Include(x => x.TitlePersons)
                    .ThenInclude(x => x.Person)
                    .FirstOrDefault(x => x.Id == id);
                return query;
            }

            getTitlePersonName("tt0098286");
        }
    }
}