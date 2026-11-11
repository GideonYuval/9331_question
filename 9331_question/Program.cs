using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9331_question
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test 1: DiffSeconds and Diff methods
            Console.WriteLine("Test 1: DiffSeconds and Diff");
            Time t1 = new Time(2, 3, 4); // 4 hrs, 3 min, 2 sec
            Time t2 = new Time(3, 5, 5); // 5 hrs, 5 min, 3 sec
            Console.WriteLine($"Runner 1: {t1} (Expected: 04:03:02)");
            Console.WriteLine($"Runner 2: {t2} (Expected: 05:05:03)");

            int diffInSeconds = DiffSeconds(t1, t2);
            Console.WriteLine($"Difference in seconds: {diffInSeconds} (Expected: 3721 seconds)");

            Time t3 = Diff(t1, t2);
            Console.WriteLine($"Difference as Time object: {t3} (Expected: 01:02:01)");

            // Test 2: FirstLast
            Console.WriteLine("\nTest 2: FirstLast");
            Queue<Time> runnersQueue = new Queue<Time>();
            runnersQueue.Insert(new Time(0, 0, 1)); // Fastest runner: 1 hour
            runnersQueue.Insert(new Time(30, 0, 1)); // 1 hour, 30 seconds
            runnersQueue.Insert(new Time(0, 1, 2)); // 2 hours, 1 minute
            Console.WriteLine($"Time difference between fastest and slowest: {FirstLast(runnersQueue)} (Expected: 01:01:00)");

            // Test 3: PrintSmallestDiff
            Console.WriteLine("\nTest 3: PrintSmallestDiff");
            runnersQueue.Insert(new Time(15, 59, 1)); // 1:59:15 (added after 3rd runner)
            Console.WriteLine("Expected: Smallest time difference is between runners at indices 3 and 4.");
            PrintSmallestDiff(runnersQueue); // Should identify the smallest time difference and print indices

            // Test 4: Edge case - single runner in the queue
            Console.WriteLine("\nTest 4: Edge case - Single Runner");
            Queue<Time> singleRunnerQueue = new Queue<Time>();
            singleRunnerQueue.Insert(new Time(0, 0, 1)); // Only runner: 1 hour
            Console.WriteLine($"FirstLast with single runner: {FirstLast(singleRunnerQueue)} (Expected: 00:00:00)");

            Console.WriteLine("\nAll tests completed.");
        }




        static Time FirstLast(Queue<Time> q)
        {
            return null;
        }

        static void PrintSmallestDiff(Queue<Time> q)
        {
            
        }



        //return time diff in secs of 2 runners
        static int DiffSeconds(Time first, Time second)
        {
            return Math.Abs((second.GetSeconds() + second.GetMinutes() * 60 + second.GetHours() * 3600) -
                (first.GetSeconds() + first.GetMinutes() * 60 + first.GetHours() * 3600));
        }

        static Time Diff(Time first, Time second)
        {
            int secdiff = DiffSeconds(first, second);
            int hours = secdiff / 3600;
            secdiff -= hours * 3600;
            int minutes = secdiff / 60;
            secdiff -= minutes * 60;
            int seconds = secdiff;
            return new Time(seconds, minutes, hours);
        }
    }

    public class Time
    {
        int seconds;
        int minutes;
        int hours;

        public Time(int seconds, int minutes, int hours)
        {
            if (seconds < 0 || seconds >= 60 || minutes < 0 || minutes >= 60 || hours < 0)
                throw new ArgumentException("Invalid time values.");
            this.seconds = seconds;
            this.minutes = minutes;
            this.hours = hours;
        }
        public int GetSeconds() { return seconds; }
        public int GetMinutes() { return minutes; }
        public int GetHours() { return hours; }

        public override string ToString()
        {
            return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }

    }
}
