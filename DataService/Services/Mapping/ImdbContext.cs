using System.Linq;
using DataService.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace DataService
{
    public class ImdbContext : DbContext
    {
        PostgresSQL_Connect_String myConnection = new PostgresSQL_Connect_String();

        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            optionsBuilder.UseNpgsql(myConnection.ToString());
        }

        public DbSet<Genre> genre { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Title_Genre> title_genre { get; set; }
        public DbSet<Akas_Type> akas_type { get; set; }
        public DbSet<Akas_Akas_Type> akas_akas_type { get; set; }
        public DbSet<Person_known_title> PersonKnownTitles { get; set; }

        public DbSet<Person_Profession> PersonProfessions { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Rating> rating { get; set; }
        public DbSet<Title_Rating> title_rating { get; set; }
        public DbSet<Search_History> search_history { get; set; }
        public DbSet<Person_Bookmark> person_bookmarks { get; set; }
        public DbSet<Person_Bookmark_list> person_bookmark_list { get; set; }
        public DbSet<Akas_Attribute> akas_attributes { get; set; }
        public DbSet<Akas> akas { get; set; }
        public DbSet<Title_Person> TitlePersons { get; set; }
        public DbSet<Title_Bookmark> title_bookmarks { get; set; }
        public DbSet<Title_Bookmark_List> title_bookmark_list { get; set; }
        public DbSet<Title_Episode> title_episode { get; set; }
        public DbSet<Title_Search> title_search { get; set; }
        public DbSet<Type> type { get; set; }
        public DbSet<Person_Rating> PersonRatings { get; set; }
        public DbSet<Title> title { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //genre
            modelBuilder.Entity<Genre>().ToTable("genre");
            modelBuilder.Entity<Genre>().Property(x => x.Id).HasColumnName("genre_id");
            modelBuilder.Entity<Genre>().Property(x => x.Name).HasColumnName("genre_name");
            
            //genre
            modelBuilder.Entity<Person_Rating>().ToTable("person_rating");
            modelBuilder.Entity<Person_Rating>().Property(x => x.Id).HasColumnName("person_id");
            modelBuilder.Entity<Person_Rating>().Property(x => x.PersonRating).HasColumnName("person_rating");
            
            //Title_genre
            modelBuilder.Entity<Title_Genre>().ToTable("title_genre");
            modelBuilder.Entity<Title_Genre>().Property(x => x.Id).HasColumnName("title_genre_id");
            modelBuilder.Entity<Title_Genre>().Property(x => x.GenreId).HasColumnName("genre_id");
            modelBuilder.Entity<Title_Genre>().Property(x => x.TitleId).HasColumnName("title_id");
            
            modelBuilder.Entity<Title_Person>().ToTable("title_person");
            modelBuilder.Entity<Title_Person>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<Title_Person>().Property(x => x.PersonId).HasColumnName("person_id");
            modelBuilder.Entity<Title_Person>().Property(x => x.TitleId).HasColumnName("title_id");
            modelBuilder.Entity<Title_Person>().Property(x => x.Ordering).HasColumnName("ordering");
            modelBuilder.Entity<Title_Person>().Property(x => x.Category).HasColumnName("category");
            modelBuilder.Entity<Title_Person>().Property(x => x.Job).HasColumnName("job");
            modelBuilder.Entity<Title_Person>().Property(x => x.Character).HasColumnName("character");
            
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<User>().Property(x => x.Surname).HasColumnName("surname");
            modelBuilder.Entity<User>().Property(x => x.Last_Name).HasColumnName("last_name");
            modelBuilder.Entity<User>().Property(x => x.Age).HasColumnName("age");
            modelBuilder.Entity<User>().Property(x => x.Email).HasColumnName("email");
            
            //Title_bookmark
            modelBuilder.Entity<Title_Bookmark>().ToTable("title_booksmarks");
            modelBuilder.Entity<Title_Bookmark>().Property(x => x.Id).HasColumnName("bookmark_id");
            modelBuilder.Entity<Title_Bookmark>().Property(x => x.ListId).HasColumnName("list_id");
            modelBuilder.Entity<Title_Bookmark>().Property(x => x.TitleId).HasColumnName("title_id");
            
            //Title_bookmark_list
            modelBuilder.Entity<Title_Bookmark_List>().ToTable("title_bookmark_list");
            modelBuilder.Entity<Title_Bookmark_List>().Property(x => x.Id).HasColumnName("list_id");
            modelBuilder.Entity<Title_Bookmark_List>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<Title_Bookmark_List>().Property(x => x.ListName).HasColumnName("list_name");
            
            //Title_episode
            modelBuilder.Entity<Title_Episode>().ToTable("title_episodes");
            modelBuilder.Entity<Title_Episode>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<Title_Episode>().Property(x => x.TitleId).HasColumnName("title_id");
            modelBuilder.Entity<Title_Episode>().Property(x => x.ParentId).HasColumnName("parent_id");
            modelBuilder.Entity<Title_Episode>().Property(x => x.SeasonNumber).HasColumnName("season_number");
            modelBuilder.Entity<Title_Episode>().Property(x => x.EpisodeNumber).HasColumnName("episode_number");
            
            //Title_Search
            modelBuilder.Entity<Title_Search>().ToTable("title_search");
            modelBuilder.Entity<Title_Search>().Property(x => x.Id).HasColumnName("title_id");
            modelBuilder.Entity<Title_Search>().Property(x => x.Word).HasColumnName("word");
            modelBuilder.Entity<Title_Search>().Property(x => x.Field).HasColumnName("field");
            modelBuilder.Entity<Title_Search>().Property(x => x.Lexeme).HasColumnName("lexeme");
            
            // Title
            modelBuilder.Entity<Title>().ToTable("title");
            modelBuilder.Entity<Title>().Property(x => x.Id).HasColumnName("title_id");
            modelBuilder.Entity<Title>().Property(x => x.TypeId).HasColumnName("type_id");
            modelBuilder.Entity<Title>().Property(x => x.PrimaryTitle).HasColumnName("primary_title");
            modelBuilder.Entity<Title>().Property(x => x.OriginalTitle).HasColumnName("original_title");
            modelBuilder.Entity<Title>().Property(x => x.IsAdult).HasColumnName("is_adult");
            modelBuilder.Entity<Title>().Property(x => x.StartYear).HasColumnName("start_year");
            modelBuilder.Entity<Title>().Property(x => x.EndYear).HasColumnName("end_year");
            modelBuilder.Entity<Title>().Property(x => x.RunTimeMinutes).HasColumnName("runtimeminutes");
            modelBuilder.Entity<Title>().HasMany(x => x.PersonKnownTitles).WithOne(c => c.title)
                .HasForeignKey(v => v.TitleId);
            
            //Type
            modelBuilder.Entity<Type>().ToTable("type");
            modelBuilder.Entity<Type>().Property(x => x.Id).HasColumnName("type_id");
            modelBuilder.Entity<Type>().Property(x => x.TypeName).HasColumnName("type_name");
            
            //User
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<User>().Property(x => x.Surname).HasColumnName("surname");
            modelBuilder.Entity<User>().Property(x => x.Last_Name).HasColumnName("last_name");
            modelBuilder.Entity<User>().Property(x => x.Age).HasColumnName("age");
            modelBuilder.Entity<User>().Property(x => x.Email).HasColumnName("email");
            
            //Rating
            modelBuilder.Entity<Rating>().ToTable("rating");
            modelBuilder.Entity<Rating>().Property(x => x.Id).HasColumnName("rating_id");
            modelBuilder.Entity<Rating>().Property(x => x.User_Id).HasColumnName("user_id");
            modelBuilder.Entity<Rating>().Property(x => x.Title_Id).HasColumnName("title_id");
            modelBuilder.Entity<Rating>().Property(x => x.Rating_).HasColumnName("rating");
            modelBuilder.Entity<Rating>().HasKey(r => new {r.User_Id});
            
            //Person
            modelBuilder.Entity<Person>().ToTable("person");
            modelBuilder.Entity<Person>().Property(x => x.Id).HasColumnName("person_id");
            modelBuilder.Entity<Person>().Property(x => x.Name).HasColumnName("primary_name");
            modelBuilder.Entity<Person>().Property(x => x.BirthYear).HasColumnName("birth_year");
            modelBuilder.Entity<Person>().Property(x => x.DeathYear).HasColumnName("death_year");
            modelBuilder.Entity<Person>().HasMany(c => c.PersonKnownTitles).WithOne(v => v.person)
                .HasForeignKey(x => x.Id);


            modelBuilder.Entity<Person_Bookmark>().ToTable("person_bookmarks");
            modelBuilder.Entity<Person_Bookmark>().Property(x => x.Id).HasColumnName("bookmark_id");
            modelBuilder.Entity<Person_Bookmark>().Property(x => x.List_Id).HasColumnName("list_id");
            modelBuilder.Entity<Person_Bookmark>().Property(x => x.Person_Id).HasColumnName("person_id");

            modelBuilder.Entity<Person_Bookmark_list>().ToTable("person_bookmark_list");
            modelBuilder.Entity<Person_Bookmark_list>().Property(x => x.Id).HasColumnName("list_id");
            modelBuilder.Entity<Person_Bookmark_list>().Property(x => x.User_Id).HasColumnName("user_id");
            modelBuilder.Entity<Person_Bookmark_list>().Property(x => x.List_Name).HasColumnName("list_name");

            modelBuilder.Entity<Search_History>().ToTable("search_history");
            modelBuilder.Entity<Search_History>().Property(x => x.Id).HasColumnName("search_id");
            modelBuilder.Entity<Search_History>().Property(x => x.User_Id).HasColumnName("user_id");
            modelBuilder.Entity<Search_History>().Property(x => x.Search_Name).HasColumnName("search_name");
            modelBuilder.Entity<Search_History>().Property(x => x.Timestamp).HasColumnName("timestamp");
            
            //Akas_type
            modelBuilder.Entity<Akas_Type>().ToTable("akas_type");
            modelBuilder.Entity<Akas_Type>().Property(x => x.Id).HasColumnName("type_id");
            modelBuilder.Entity<Akas_Type>().Property(x => x.Name).HasColumnName("type_name");
            
            //Akas_Akas_type
            modelBuilder.Entity<Akas_Akas_Type>().ToTable("akas_akas_type");
            modelBuilder.Entity<Akas_Akas_Type>().Property(x => x.Id).HasColumnName("akas_akas_type_id");
            modelBuilder.Entity<Akas_Akas_Type>().Property(x => x.AkasAkasId).HasColumnName("akas_akas_id");
            modelBuilder.Entity<Akas_Akas_Type>().Property(x => x.AkasTypeId).HasColumnName("akas_type_id");
            
            //Akas_Attribute
            modelBuilder.Entity<Akas_Attribute>().ToTable("akas_attribute");
            modelBuilder.Entity<Akas_Attribute>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<Akas_Attribute>().Property(x => x.TitleId).HasColumnName("title_id");
            modelBuilder.Entity<Akas_Attribute>().Property(x => x.AttributeName).HasColumnName("attribute_name");
            
            //Akas
            modelBuilder.Entity<Akas>().ToTable("akas");
            modelBuilder.Entity<Akas>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<Akas>().Property(x => x.TitleId).HasColumnName("title_id");
            modelBuilder.Entity<Akas>().Property(x => x.Ordering).HasColumnName("ordering");
            modelBuilder.Entity<Akas>().Property(x => x.AkasName).HasColumnName("akas_name");
            modelBuilder.Entity<Akas>().Property(x => x.Region).HasColumnName("region");
            modelBuilder.Entity<Akas>().Property(x => x.Language).HasColumnName("language");
            modelBuilder.Entity<Akas>().Property(x => x.Type).HasColumnName("type");
            modelBuilder.Entity<Akas>().Property(x => x.IsOriginalTitle).HasColumnName("is_original_title");
            
            
            //Person_title_id
            modelBuilder.Entity<Person_known_title>().ToTable("person_known_title");
            modelBuilder.Entity<Person_known_title>().Property(x => x.Id).HasColumnName("person_id");
            modelBuilder.Entity<Person_known_title>().Property(x => x.TitleId).HasColumnName("title_id");
            
            //FIKS RELATIONER I DB FØRST
            modelBuilder.Entity<Person_known_title>().HasKey(c => new {c.Id, TitleName = c.TitleId});
            modelBuilder.Entity<Person_known_title>().HasOne(c => c.person).WithMany(v => v.PersonKnownTitles)
                .HasForeignKey(x => x.Id);
            modelBuilder.Entity<Person_known_title>().HasOne(c => c.title).WithMany(v => v.PersonKnownTitles)
                .HasForeignKey(x => x.TitleId);
            



            //Person_profession
            modelBuilder.Entity<Person_Profession>().ToTable("person_profession");
            modelBuilder.Entity<Person_Profession>().Property(x => x.Id).HasColumnName("person_profession_id");
            modelBuilder.Entity<Person_Profession>().Property(x => x.PersonId).HasColumnName("person_id");
            modelBuilder.Entity<Person_Profession>().Property(x => x.ProfessionId).HasColumnName("profession_id");
            
            //Profession
            modelBuilder.Entity<Profession>().ToTable("profession");
            modelBuilder.Entity<Profession>().Property(x => x.Id).HasColumnName("profession_id");
            modelBuilder.Entity<Profession>().Property(x => x.ProfessionName).HasColumnName("profession_name");
            

            //Title_Rating
            //title_rating
            modelBuilder.Entity<Title_Rating>().ToTable("title_rating");
            modelBuilder.Entity<Title_Rating>().Property(x => x.Id).HasColumnName("title_rating_id");
            modelBuilder.Entity<Title_Rating>().Property(x => x.Title_Id).HasColumnName("title_id");
            modelBuilder.Entity<Title_Rating>().Property(x => x.Average_Rating).HasColumnName("average_rating");
            modelBuilder.Entity<Title_Rating>().Property(x => x.Num_Votes).HasColumnName("num_votes");
            
           
            
            base.OnModelCreating(modelBuilder);
        }
    }
}