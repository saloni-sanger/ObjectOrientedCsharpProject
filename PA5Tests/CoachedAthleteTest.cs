using System;
using PA5;
namespace PA5Tests;


[TestClass]
public class CoachedAthleteTest
{
    [TestMethod]
    public void MessageCorrectlyWrittenByObserver()
    {
        string targetValue = "This SessionLog has at least one Workout where the performed reps are greater than the target reps.\n";
        CoachedAthlete c = new();
        StringWriter sw = new();
        RepetitionMonitor r = new(sw);
        c.Subscribe(r);
        SessionLog s = new();
        FitSet f = new FitSet("crunches", "core", 0, 20);
        s.addWorkout(f);
        s.justDoIt(1, 0, 30);
        c.AddSessionLog(s);
        Assert.AreEqual(sw.ToString(), targetValue);
    }
}

