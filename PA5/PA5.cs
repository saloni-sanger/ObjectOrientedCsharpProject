//Console.WriteLine("");
using System;
using PA5;
//Console.WriteLine("");
namespace PA5
{
    public class PA5
    {
        static void Main(string[] args)
        {
            athlete();
            firstCoached();
            secondCoached();
        }

        static void athlete()
        {
            Console.WriteLine("I am going to create an Athlete, give it 2 SessionLogs, and print it's report to the console.");
            Athlete a = new Athlete();
            SessionLog one = new SessionLog();
            FitSet crunches = new("crunches", "core", 0, 20);
            FitSet squats = new("squat", "legs", 15, 12);
            FitSet lunges = new("lunge", "legs", 0, 20);
            one.addWorkout(crunches);
            one.addWorkout(squats);
            one.addWorkout(lunges);
            SessionLog two = new SessionLog();
            TriWorkout running = new("running", 16.0, 2.0);
            HIIT burpees = new("burpees", 15, 60, 60);
            TriWorkout walking = new("running", 32.0, 2.0);
            two.addWorkout(running);
            two.addWorkout(burpees);
            two.addWorkout(walking);
            a.AddSessionLog(one);
            a.AddSessionLog(two);
            Console.WriteLine(a.Report());
        }

        static void firstCoached()
        {
            Console.WriteLine("Let's create 2 coached athletes.");
            Console.WriteLine("The first coached athlete's monitors will write to the console.");
            Console.WriteLine("It's monitors will be for Repetitions and Weight.");
            Console.WriteLine("We will trigger the RepetitionMonitor, but not the WeightMonitor.");
            CoachedAthlete c = new CoachedAthlete();
            RepetitionMonitor rMon = new RepetitionMonitor(Console.Out);
            WeightMonitor wMon = new WeightMonitor(Console.Out);
            c.Subscribe(rMon);
            c.Subscribe(wMon);
            SessionLog one = new SessionLog();
            FitSet crunches = new("crunches", "core", 0, 20);
            FitSet squats = new("squat", "legs", 15, 12);
            FitSet lunges = new("lunge", "legs", 0, 20);
            one.addWorkout(crunches);
            one.addWorkout(squats);
            one.addWorkout(lunges);
            one.justDoIt(1, 0, 30); //reps higher than target
            one.justDoIt(2, 15, 12);
            one.justDoIt(3, 0, 20);
            c.AddSessionLog(one);
        }

        static void secondCoached()
        {
            Console.WriteLine("The second coached athlete's monitors will write to a StringWriter, which will be displayed at the end.");
            Console.WriteLine("It will use the Overtraining and Repetition Monitors.");
            Console.WriteLine("We will trigger the OvertrainingMonitor, but not the RepetitionMonitor.");
            CoachedAthlete c = new CoachedAthlete();
            StringWriter sw = new StringWriter();
            OvertrainingMonitor oMon = new OvertrainingMonitor(sw, 4.0);
            RepetitionMonitor rMon = new RepetitionMonitor(sw);
            c.Subscribe(oMon);
            c.Subscribe(rMon);
            SessionLog two = new SessionLog();
            TriWorkout running = new("running", 16.0, 2.0);
            HIIT burpees = new("burpees", 15, 60, 60);
            TriWorkout walking = new("running", 32.0, 2.0);
            two.addWorkout(running);
            two.addWorkout(burpees);
            two.addWorkout(walking);
            two.justDoIt(1, 16.0, 3.0); //extra mile
            two.justDoIt(2, 15, 60, 60);
            two.justDoIt(3, 32.0, 2.0);
            c.AddSessionLog(two);
            Console.WriteLine(sw.ToString());
        }
    }
}