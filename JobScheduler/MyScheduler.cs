using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobScheduler
{
    public static class MyScheduler
    {
        public static void IntervalInSeconds(int year, int month, int day, int hour, int min, int sec, int milisec, double interval, Action task)
        {
            interval = interval / 3600;
            Scheduler.Instance.ScheduleTask(year, month, day, hour, min, sec, milisec, interval, task);
        }

        public static void IntervalInMinutes(int year, int month, int day, int hour, int min, int sec, int milisec, double interval, Action task)
        {
            interval = interval / 60;
            Scheduler.Instance.ScheduleTask(year, month, day, hour, min, sec, milisec, interval, task);
        }

        public static void IntervalInHours(int year, int month, int day, int hour, int min, int sec, int milisec, double interval, Action task)
        {
            Scheduler.Instance.ScheduleTask(year, month, day, hour, min, sec, milisec, interval, task);
        }

        public static void IntervalInDays(int year, int month, int day, int hour, int min, int sec, int milisec, double interval, Action task)
        {
            interval = interval * 24;
            Scheduler.Instance.ScheduleTask(year, month, day, hour, min, sec, milisec, interval, task);
        }

        public static void IntervalInWeeks(int year, int month, int day, int hour, int min, int sec, int milisec, double interval, Action task)
        {
            interval = interval * 24 * 7;
            Scheduler.Instance.ScheduleTask(year, month, day, hour, min, sec, milisec, interval, task);
        }

    }
}
