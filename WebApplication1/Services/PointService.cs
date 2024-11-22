namespace WebApplication1.Services
{
    public class PointService : IPointService
    {
        public long GetDailyPoints(DateTime dateTime)
        {
            var seasonDay = GetSeasonDay(dateTime);
            var points = CalculateDailyPoints(seasonDay);
            return points;
        }

        private long CalculateDailyPoints(int seasonDay)
        {
            if (seasonDay == 1) return 2;
            if (seasonDay == 2) return 3;

            var prevPrevDay = 2L;
            var prevDay = 3L;

            for(int i = 3; i <= seasonDay; i++)
            {
                var temp = prevDay;
                prevDay = (long)(temp * 0.6 + prevPrevDay);
                prevPrevDay = temp;
            }
            return prevDay;
        }

        private int GetSeasonDay(DateTime date)
        {
            var seasonsStart = new Dictionary<int, DateTime>
            {
                { 0, new DateTime(date.Month < 3 ? date.Year - 1 : date.Year, 12, 1) },
                { 1, new DateTime(date.Year, 3, 1) },
                { 2, new DateTime(date.Year, 6, 1) },
                { 3, new DateTime(date.Year, 9, 1) }
            };

            var season = seasonsStart
                .OrderByDescending(x => x.Value)
                .FirstOrDefault(x => date >= x.Value);

            return (date - season.Value).Days + 1;
        }
    }
}
