using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JobScheduler
{
    class Scheduler
    {
        private static Scheduler _instance = null;
        private readonly static object myObj = new object();

        private List<Timer> timers = new List<Timer>();

        // Thread safe singleton
        public static Scheduler Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (myObj)
                    {
                        if (_instance == null) _instance = new Scheduler();
                    }
                }

                return _instance;
            }
        }

        // The method that schedules tasks
        public void ScheduleTask(int year,int month, int day,int hour, int min, int sec, int millisec, double intervalInHour, Action task)
        {
            DateTime now = DateTime.Now;
            DateTime firstRun = new DateTime(year, month, day, hour, min, sec, millisec);

            if (now > firstRun)
            {
                firstRun = firstRun.AddDays(1);
            }

            TimeSpan timeToGo = firstRun - now;
            if (timeToGo <= TimeSpan.Zero)
            {
                timeToGo = TimeSpan.Zero;
            }

            var timer = new Timer(x => 
            {
                task.Invoke();

            }, null, timeToGo, TimeSpan.FromHours(intervalInHour));

            timers.Add(timer);

        }
    }
}
