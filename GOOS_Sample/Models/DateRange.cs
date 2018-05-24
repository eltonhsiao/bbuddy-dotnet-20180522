using System;

namespace GOOS_Sample.Models
{
    public class DateRange
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int OverlappingDays(DateRange another)
        {
            if (Start > another.End || End < another.Start)
                return 0;

            var overlappingStart = Start > another.Start ? Start : another.Start;
            var overlappingEnd = End < another.End ? End : another.End;

            return (overlappingEnd - overlappingStart).Days + 1;
        }

        public int DayCount()
        {
            return DateTime.DaysInMonth(Start.Year, Start.Month);
        }
    }
}