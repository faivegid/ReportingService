using System;

namespace ReportingService.Modela.Domain
{
    public class ActivityValue
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime InsertedTimeStamp { get; set; }

        public ActivityValue(int value)
        {
            Value = value;
            InsertedTimeStamp = DateTime.Now;
        }
    }
}
