namespace WeddingPlanner.Data
{
    using WeddingsPlanner.Data;
    public static class Utility
    {
        public static void InitDB()
        {
            var context = new UnitOfWork();
        }
    }

}
