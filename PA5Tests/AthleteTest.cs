using System;
using PA5;
namespace PA5Tests;


[TestClass]
public class AthleteTest
{
    [TestMethod]
    public void CorrectlyAddsAndReportsSessionLogs()
    {
        string targetValue = "crunches\tGoal Weight: 0\tGoal Reps: 20\n\n";
        Athlete a = new();
        SessionLog s = new();
        FitSet crunches = new FitSet("crunches", "core", 0, 20);
        s.addWorkout(crunches);
        a.AddSessionLog(s);
        Assert.AreEqual(a.Report(), targetValue);
    }
}

