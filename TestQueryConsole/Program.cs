using System;
using System.Collections.Generic;
using System.Linq;
using DataService;
using DataService.Objects;
using DataService.Services;
using Microsoft.EntityFrameworkCore;

namespace TestQueryConsole
{
    class Program
    {


        static void Main(string[] args)
        {
            using var ctx = new ImdbContext();


            Title getFullTitle()
            {
                using var ctx = new ImdbContext();

                var query = ctx.title
                    .Include(x => x.Akases)
                    .FirstOrDefault();
               

                return query;


            }

            getFullTitle();




        }
    }
}