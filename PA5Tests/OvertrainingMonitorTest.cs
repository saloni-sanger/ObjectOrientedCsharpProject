using System;
using PA5;
namespace PA5Tests;


[TestClass]
public class OvertrainingMonitorTest
{
    [TestMethod]
    public void WritesMessageIfCombinedDistanceGreaterThanTarget()
    {
        string targetValue = "The combined performed distances of this SessionLog's TriWorkouts is greater then the specified target distance.\n";
        CoachedAthlete c = new();
        StringWriter sw = new();
        OvertrainingMonitor o = new(sw, 2.0);
        c.Subscribe(o);
        SessionLog s = new();
        TriWorkout t = new("running", 16.0, 2.0);
        s.addWorkout(t);
        s.justDoIt(1, 16.0, 3.0);
        c.AddSessionLog(s);
        Assert.AreEqual(sw.ToString(), targetValue);
    }

    [TestMethod]
    public void DoesNotWriteMessageIfCombinedDistanceNotGreaterThanTarget()
    {
        CoachedAthlete c = new();
        StringWriter sw = new();
        OvertrainingMonitor o = new(sw, 2.0);
        c.Subscribe(o);
        SessionLog s = new();
        TriWorkout t = new("running", 16.0, 2.0);
        s.addWorkout(t);
        s.justDoIt(1, 16.0, 2.0);
        c.AddSessionLog(s);
        Assert.AreEqual(sw.ToString(), "");
    }
}
