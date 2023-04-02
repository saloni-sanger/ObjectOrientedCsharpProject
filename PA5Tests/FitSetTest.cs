using System;
using System.Collections.Generic;
using PA5;
namespace PA5Tests;


[TestClass]
public class FitSetTest
{
    [TestMethod]
    public void ReturnsCorrectPercentOfRepGoal()
    {
        //setup
        FitSet f = new("crunches", "core", 0, 20);
        double targetValue = 75.0;
        //execution
        f.setPerformedWeight(0);
        f.setPerformedReps(15);
        //verification
        Assert.AreEqual(targetValue, f.PercentOfGoal);
    }

    [TestMethod]
    public void ReturnsCorrectScore()
    {
        //setup
        FitSet f = new("squats", "legs", 20, 12);
        int targetValue = 32;
        //execution
        f.setPerformedWeight(20);
        f.setPerformedReps(12);
        //verification
        Assert.AreEqual(targetValue, f.Score);
    }

    [TestMethod]
    public void ValidAfterSettingWeightAndRepsOnce()
    {
        //setup
        FitSet f = new("squats", "legs", 20, 12);
        bool targetValue = false;
        //execution
        f.setPerformedWeight(20);
        f.setPerformedReps(12);
        //verification
        Assert.AreEqual(targetValue, f.Invalid);
    }

    [TestMethod]
    public void InvalidAfterSettingOnlyRepsTwice()
    {
        //setup
        FitSet f = new("squats", "legs", 20, 12);
        bool targetValue = true;
        //execution
        f.setPerformedWeight(20);
        f.setPerformedReps(12);
        f.setPerformedReps(15);
        //verification
        Assert.AreEqual(targetValue, f.Invalid);
    }


    [TestMethod]
    public void InvalidAfterSettingOnlyWeightTwice()
    {
        //setup
        FitSet f = new("squats", "legs", 20, 12);
        bool targetValue = true;
        //execution
        f.setPerformedReps(12);
        f.setPerformedWeight(20);
        f.setPerformedWeight(10);
        //verification
        Assert.AreEqual(targetValue, f.Invalid);
    }

    [TestMethod]
    public void InvalidAfterSettingBothRepsAndWeightTwice()
    {
        //setup
        FitSet f = new("squats", "legs", 20, 12);
        bool targetValue = true;
        //execution
        f.setPerformedReps(12);
        f.setPerformedReps(10);
        f.setPerformedWeight(20);
        f.setPerformedWeight(10);
        //verification
        Assert.AreEqual(targetValue, f.Invalid);
    }

    [TestMethod]
    public void CompleteIfBothRepsAndWeightHaveBeenSet()
    {
        //setup
        FitSet f = new("squats", "legs", 20, 12);
        bool targetValue = true;
        //execution
        f.setPerformedReps(12);
        f.setPerformedWeight(20);
        //verification
        Assert.AreEqual(targetValue, f.isComplete());
    }

    [TestMethod]
    public void NotCompleteIfOnlyRepsHasBeenSet()
    {
        //setup
        FitSet f = new("squats", "legs", 20, 12);
        bool targetValue = false;
        //execution
        f.setPerformedReps(10);
        //verification
        Assert.AreEqual(targetValue, f.isComplete());
    }

    [TestMethod]
    public void NotCompleteIfOnlyWeightHasBeenSet()
    {
        //setup
        FitSet f = new("squats", "legs", 20, 12);
        bool targetValue = false;
        //execution
        f.setPerformedWeight(21);
        //verification
        Assert.AreEqual(targetValue, f.isComplete());
    }

}

