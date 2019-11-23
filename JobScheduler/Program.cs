using JobScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Xml;

namespace JobScheduler
{
    class Program
    {
        public static void Main()
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(@"C:\Users\Keke\Source\Repos\JobSchedulerConsoleApp\JobScheduler\SchedulerConfig.xml");

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/tasks/task");

            List<TaskModel> scheduledTasks = new List<TaskModel>();

            foreach(XmlNode node in nodes)
            {
                TaskModel task = new TaskModel();

                task.Id = Convert.ToInt32(node.Attributes["id"].Value);
                task.TaskName = node.SelectSingleNode("taskname").InnerText;
                task.Message = node.SelectSingleNode("message").InnerText;
                task.Year = Convert.ToInt32(node.SelectSingleNode("year").InnerText.Trim());
                task.Month = Convert.ToInt32(node.SelectSingleNode("month").InnerText.Trim());
                task.Day = Convert.ToInt32(node.SelectSingleNode("day").InnerText.Trim());
                task.Hour = Convert.ToInt32(node.SelectSingleNode("hour").InnerText.Trim());
                task.Minutes = Convert.ToInt32(node.SelectSingleNode("minutes").InnerText.Trim());
                task.Seconds = Convert.ToInt32(node.SelectSingleNode("seconds").InnerText.Trim());
                task.MilliSeconds = Convert.ToInt32(node.SelectSingleNode("miliseconds").InnerText.Trim());
                task.Intervaltype = node.SelectSingleNode("intervalType").InnerText.Trim();
                task.Interval = Convert.ToDouble(node.SelectSingleNode("interval").InnerText.Trim());

                scheduledTasks.Add(task);
            }


            foreach(var task in scheduledTasks)
            {
                DateTime scheduledDate = new DateTime(task.Year, task.Month, task.Day, task.Hour, task.Minutes, task.Seconds, task.MilliSeconds);

                string currentIntervalType = task.Intervaltype;

                // Ne qofte se ne xml eshte konfiguruar tipi i intervalit psh. "DAY" psh do te ekzekutohet Intevali ditor 
                //ne baze te vleres qe kemi plotesuar
                switch (currentIntervalType)
                {
                    case "WEEK":
                    {
                        MyScheduler.IntervalInWeeks(task.Year, task.Month, task.Day, task.Hour, task.Minutes, task.Seconds, task.MilliSeconds, task.Interval, () =>
                        {
                            Console.WriteLine($"{task.TaskName}: {task.Message} /// scheduled at {scheduledDate}");
                        });
                        break;
                    }
                    case "DAY":
                    {
                        MyScheduler.IntervalInDays(task.Year, task.Month, task.Day, task.Hour, task.Minutes, task.Seconds, task.MilliSeconds, task.Interval, () =>
                        {
                            Console.WriteLine($"{task.TaskName}: {task.Message} /// scheduled at {scheduledDate}");
                        });
                        break;
                    }
                    case "HOUR":
                    {
                        MyScheduler.IntervalInHours(task.Year, task.Month, task.Day, task.Hour, task.Minutes, task.Seconds, task.MilliSeconds, task.Interval, () =>
                        {
                            Console.WriteLine($"{task.TaskName}: {task.Message} /// scheduled at {scheduledDate}");
                        });
                        break;
                    }
                    case "MINUTE":
                    {
                        MyScheduler.IntervalInMinutes(task.Year, task.Month, task.Day, task.Hour, task.Minutes, task.Seconds, task.MilliSeconds, task.Interval, () =>
                        {
                            Console.WriteLine($"{task.TaskName}: {task.Message} /// scheduled at {scheduledDate}");
                        });
                        break;
                    }
                    case "SECOND":
                    {
                        MyScheduler.IntervalInSeconds(task.Year, task.Month, task.Day, task.Hour, task.Minutes, task.Seconds, task.MilliSeconds, task.Interval, () =>
                        {
                            Console.WriteLine($"{task.TaskName}: {task.Message} /// scheduled at {scheduledDate}");
                        });
                        break;
                    }

                    default:
                    {
                        MyScheduler.IntervalInSeconds(task.Year, task.Month, task.Day, task.Hour, task.Minutes, task.Seconds, task.MilliSeconds, task.Interval, () =>
                        {
                            Console.WriteLine($"{ task.TaskName}: {task.Message} /// scheduled at {scheduledDate}");
                        });
                        break;
                    }
                }
            }
           

            Console.ReadKey();

       
        }

    }
}
