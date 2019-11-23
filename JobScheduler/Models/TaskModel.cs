using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobScheduler.Models
{
    class TaskModel
    {
        public int Id { get; set; }
        public string TaskName{ get; set; }
        public string Message{ get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int MilliSeconds { get; set; }
        public string Intervaltype { get; set; }
        public double Interval { get; set; }

        public enum IntervalType
        {
            WEEKLY, DAILY, HOURLY, MINUTELY, SECONDLY
        }
    }
}
