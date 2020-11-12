namespace DataService
{
    public class PostgresSQL_Connect_String
    {
        private string host = "localhost";
        private string db = "imdb";
        private string UserId = "postgres";
        private string pwd = "Flintholm2020";

        public override string ToString()
        {
            return $"host={host};db={db};uid={UserId};pwd={pwd}";
        }
    }
}