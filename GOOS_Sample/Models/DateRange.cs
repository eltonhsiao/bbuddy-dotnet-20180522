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
            {
                return 0;
            }

            var overlappingStart = Start;
            var overlappingEnd = End;

            if (Start.ToString("yyyyMM") == End.ToString("yyyyMM"))
            {
            }
            else if (Start.ToString("yyyyMM") == another.Start.ToString("yyyyMM"))
            {
                overlappingEnd = another.End;
            }
            else if (End.ToString("yyyyMM") == another.Start.ToString("yyyyMM"))
            {
                overlappingStart = another.Start;
            }
            else
            {
                overlappingStart = another.Start;
                overlappingEnd = another.End;
            }

            return (overlappingEnd - overlappingStart).Days + 1;
        }
    }
}