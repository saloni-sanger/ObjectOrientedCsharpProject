using System.Collections.Generic;

using PA5;

namespace PA5Tests;

[TestClass]
public class TriWorkoutTest
{
    [TestMethod]
    public void ReturnsCorrectPercentOfGoalForRunning()
    {
        //setup
        TriWorkout t = new("running", 16.0, 2.0); //16 minutes, 2 miles, Pace: 8 min/mile
        double targetValue = 80.0; //should be displayed if pace performed is 10 min/mile
        //execution
        t.setPerformedDistance(2.0);
        t.setPerformedTime(20.0);
        //verification
        Assert.AreEqual(targetValue, t.PercentOfGoal);
    }

    [TestMethod]
    public void ReturnsCorrectPercentOfGoalForCycling()
    {
        //setup
        TriWorkout t = new("cycling", 1.0, 5.0); //1 hour, 5 miles, Pace: 5 mi/hr
        double targetValue = 80.0; //should be displayed if pace performed is 4 mi/hr
        //execution
        t.setPerformedDistance(4.0);
        t.setPerformedTime(1.0);
        //verification
        Assert.AreEqual(targetValue, t.PercentOfGoal);
    }

    [TestMethod] //works
    public void ReturnsCorrectPercentOfGoalForSwimming()
    {
        //setup
        TriWorkout t = new("swimming", 240.0, 200.0); //240 seconds, 200 yards Pace: 120 seconds/100yard
        double targetValue = 80.0;
        //execution
        t.setPerformedDistance(200.0);
        t.setPerformedTime(300.0);
        //verification
        Assert.AreEqual(targetValue, t.PercentOfGoal);
    }


    [TestMethod]
    public void ReturnsCorrectScore()
    {
        //setup
        TriWorkout t = new("running", 16.0, 2.0);
        double targetValue = 32.0;
        //execution
        t.setPerformedDistance(2.0);
        t.setPerformedTime(20.0);
        //verification
        Assert.AreEqual(targetValue, t.Score);
    }


    [TestMethod]
    public void ValidAfterSettingTimeAndDistanceOnce()
    {
        //setup
        TriWorkout t = new("running", 16.0, 2.0);
        bool targetValue = false;
        //execution
        t.setPerformedDistance(2.0);
        t.setPerformedTime(20.0);
        //verification
        Assert.AreEqual(targetValue, t.Invalid);
    }


    [TestMethod]
    public void InvalidAfterSettingOnlyTimeTwice()
    {
        //setup
        TriWorkout t = new("running", 16.0, 2.0);
        bool targetValue = true;
        //execution
        t.setPerformedDistance(2.0);
        t.setPerformedTime(20.0);
        t.setPerformedTime(20.0);
        //verification
        Assert.AreEqual(targetValue, t.Invalid);
    }


    [TestMethod]
    public void InvalidAfterSettingOnlyDistanceTwice()
    {
        //setup
        TriWorkout t = new("running", 16.0, 2.0);
        bool targetValue = true;
        //execution
        t.setPerformedDistance(2.0);
        t.setPerformedDistance(2.0);
        t.setPerformedTime(20.0);
        //verification
        Assert.AreEqual(targetValue, t.Invalid);
    }

    [TestMethod]
    public void InvalidAfterSettingBothTimeAndDistanceTwice()
    {
        //setup
        TriWorkout t = new("running", 16.0, 2.0);
        bool targetValue = true;
        //execution
        t.setPerformedDistance(2.0);
        t.setPerformedDistance(2.0);
        t.setPerformedTime(20.0);
        t.setPerformedTime(20.0);
        //verification
        Assert.AreEqual(targetValue, t.Invalid);
    }

    [TestMethod]
    public void CompleteIfBothTimeAndDistanceHaveBeenSet()
    {
        //setup
        TriWorkout t = new("running", 16.0, 2.0);
        bool targetValue = true;
        //execution
        t.setPerformedDistance(2.0);
        t.setPerformedTime(20.0);
        //verification
        Assert.AreEqual(targetValue, t.isComplete());
    }

    [TestMethod]
    public void NotCompleteIfOnlyTimeHasBeenSet()
    {
        //setup
        TriWorkout t = new("running", 16.0, 2.0);
        bool targetValue = false;
        //execution
        t.setPerformedTime(20.0);
        //verification
        Assert.AreEqual(targetValue, t.isComplete());
    }

    [TestMethod]
    public void NotCompleteIfOnlyDistanceHasBeenSet()
    {
        //setup
        TriWorkout t = new("running", 16.0, 2.0);
        bool targetValue = false;
        //execution
        t.setPerformedDistance(2.0);
        //verification
        Assert.AreEqual(targetValue, t.isComplete());
    }


}

