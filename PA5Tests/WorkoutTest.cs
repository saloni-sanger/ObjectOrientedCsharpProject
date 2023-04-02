
using PA5;
using System;
namespace PA5Tests
{
    class DummyWorkout : Workout
    {
        public override double PercentOfGoal
        {
            get { return 100; }
        }

        public override double Score
        {
            get { return 0; }
        }

        public override bool isComplete()
        {
            return false;
        }
    }

    [TestClass]
    public class WorkoutTest
    {
        [TestMethod]
        public void WorkoutReturnsCorrectPercentOfGoal()
        {
            Workout w = new DummyWorkout();
            double targetValue = 100;
            Assert.AreEqual(targetValue, w.PercentOfGoal);
        }

        [TestMethod]
        public void WorkoutReturnsCorrectScore()
        {
            Workout w = new DummyWorkout();
            double targetValue = 0;
            Assert.AreEqual(targetValue, w.Score);
        }

        [TestMethod]
        public void WorkoutReturnsCorrectCompletionStatus()
        {
            Workout w = new DummyWorkout();
            bool targetValue = false;
            Assert.AreEqual(targetValue, w.isComplete());
        }
    }
}