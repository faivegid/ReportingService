using System.Collections.Generic;

namespace ReportingService.Modela.Domain
{
    public class Activity
    {
        public string Id { get; set; }
        public List<ActivityValue> Values { get; set; }

        public Activity(string id, int value)
        {
            Id = id;
            Values = new List<ActivityValue>();
            Values.Add(new ActivityValue(value));
        }

        public void AddValue(int value)
        {
            Values.Add(new ActivityValue(value));
        }
    }
}
