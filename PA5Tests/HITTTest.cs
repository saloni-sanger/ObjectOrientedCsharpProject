using System.Collections.Generic;

using PA5;

namespace PA5Tests;

[TestClass]
public class HIITTest
{
    [TestMethod]
    public void ReturnsCorrectPercentOfGoal()
    {
        //setup
        HIIT h = new("burpees", 15, 60, 60); //15 reps 60 seconds, 60 seconds rest
        double targetValue = 80.0;
        //execution
        h.setPerformedReps(15);
        h.setPerformedTime(33);
        h.setPerformedRest(60);
        //verification
        Assert.AreEqual(targetValue, h.PercentOfGoal);
    }

    [TestMethod]
    public void ReturnsCorrectScore()
    {
        //setup
        HIIT h = new("burpees", 15, 60, 60); //15 reps 60 seconds, 60 seconds rest
        double targetValue = 74.0;
        //execution
        h.setPerformedReps(20);
        h.setPerformedTime(60);
        h.setPerformedRest(60);
        //verification
        Assert.AreEqual(targetValue, h.Score);
    }

    [TestMethod]
    public void ValidAfterSettingTimeAndRestAndRepsOnce()
    {
        //setup
        HIIT h = new("burpees", 15, 60, 60);
        bool targetValue = false;
        //execution
        h.setPerformedReps(15);
        h.setPerformedTime(60);
        h.setPerformedRest(60);
        //verification
        Assert.AreEqual(targetValue, h.Invalid);
    }

    [TestMethod]
    public void InvalidAfterSettingOnlyTimeTwice()
    {
        //setup
        HIIT h = new("burpees", 15, 60, 60);
        bool targetValue = true;
        //execution
        h.setPerformedReps(15);
        h.setPerformedTime(60);
        h.setPerformedRest(60);
        h.setPerformedTime(70);
        //verification
        Assert.AreEqual(targetValue, h.Invalid);
    }

    [TestMethod]
    public void InvalidAfterSettingOnlyRepsTwice()
    {
        //setup
        HIIT h = new("burpees", 15, 60, 60);
        bool targetValue = true;
        //execution
        h.setPerformedReps(15);
        h.setPerformedTime(60);
        h.setPerformedRest(60);
        h.setPerformedReps(10);
        //verification
        Assert.AreEqual(targetValue, h.Invalid);
    }

    [TestMethod]
    public void InvalidAfterSettingOnlyRestTwice()
    {
        //setup
        HIIT h = new("burpees", 15, 60, 60);
        bool targetValue = true;
        //execution
        h.setPerformedReps(15);
        h.setPerformedTime(60);
        h.setPerformedRest(60);
        h.setPerformedRest(70);
        //verification
        Assert.AreEqual(targetValue, h.Invalid);
    }

    [TestMethod]
    public void InvalidAfterSettingTimeAndRepsAndRestTwice()
    {
        //setup
        HIIT h = new("burpees", 15, 60, 60);
        bool targetValue = true;
        //execution
        h.setPerformedReps(15);
        h.setPerformedTime(60);
        h.setPerformedRest(60);
        h.setPerformedReps(10);
        h.setPerformedTime(50);
        h.setPerformedRest(70);
        //verification
        Assert.AreEqual(targetValue, h.Invalid);
    }

    [TestMethod]
    public void CompleteIfRepsAndTimeAndRestHaveBeenSet()
    {
        //setup
        HIIT h = new("burpees", 15, 60, 60);
        bool targetValue = true;
        //execution
        h.setPerformedReps(15);
        h.setPerformedTime(60);
        h.setPerformedRest(60);
        //verification
        Assert.AreEqual(targetValue, h.isComplete());
    }

    [TestMethod]
    public void NotCompleteIfOnlyRepsHaveBeenSet()
    {
        //setup
        HIIT h = new("burpees", 15, 60, 60);
        bool targetValue = false;
        //execution
        h.setPerformedReps(15);
        //verification
        Assert.AreEqual(targetValue, h.isComplete());
    }

    [TestMethod]
    public void NotCompleteIfOnlyTimeHaveBeenSet()
    {
        //setup
        HIIT h = new("burpees", 15, 60, 60);
        bool targetValue = false;
        //execution
        h.setPerformedTime(60);
        //verification
        Assert.AreEqual(targetValue, h.isComplete());
    }

    [TestMethod]
    public void NotCompleteIfOnlyRestHaveBeenSet()
    {
        //setup
        HIIT h = new("burpees", 15, 60, 60);
        bool targetValue = false;
        //execution
        h.setPerformedRest(60);
        //verification
        Assert.AreEqual(targetValue, h.isComplete());
    }
}

