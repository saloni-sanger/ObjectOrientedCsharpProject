using System;
using PA5;
namespace PA5Tests;


[TestClass]
public class WeightMonitorTest
{
    [TestMethod]
    public void WritesMessageIfWeightPerformedGreaterThanTarget()
    {
        string targetValue = "This SessionLog has at least one Workout where the performed weight is greater than the target weight.\n";
        CoachedAthlete c = new();
        StringWriter sw = new();
        WeightMonitor w = new(sw);
        c.Subscribe(w);
        SessionLog s = new();
        FitSet f = new FitSet("crunches", "core", 0, 20);
        s.addWorkout(f);
        s.justDoIt(1, 10, 20);
        c.AddSessionLog(s);
        Assert.AreEqual(sw.ToString(), targetValue);
    }

    [TestMethod]
    public void DoesNotWriteMessageIfWeightPerformedNotGreaterThanTarget()
    {
        CoachedAthlete c = new();
        StringWriter sw = new();
        WeightMonitor w = new(sw);
        c.Subscribe(w);
        SessionLog s = new();
        FitSet f = new FitSet("crunches", "core", 0, 20);
        s.addWorkout(f);
        s.justDoIt(1, 0, 20);
        c.AddSessionLog(s);
        Assert.AreEqual(sw.ToString(), "");
    }
}