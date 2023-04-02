
using PA5;
using System;
namespace PA5Tests
{
    [TestClass]
    public class SessionLogTest
    {
        [TestMethod]
        public void JustDoItIsCorrectlySettingFitSetVariables()
        {
            //setup
            SessionLog s = new SessionLog();
            FitSet f = new("crunches", "core", 0, 20);
            uint targetValue = 20;
            //execution
            s.addWorkout(f);
            s.justDoIt(1, 0, 20);
            //verification
            Assert.AreEqual(targetValue, f.performedReps);
        }

        [TestMethod]
        public void JustDoItIsCorrectlySettingTriWorkoutVariables()
        {
            //setup
            SessionLog s = new SessionLog();
            TriWorkout t = new("running", 16.0, 2.0);
            double targetValue = 16.0;
            //execution
            s.addWorkout(t);
            s.justDoIt(1, 16.0, 2.0);
            //verification
            Assert.AreEqual(targetValue, t.performedTime);
        }

        [TestMethod]
        public void JustDoItIsCorrectlySettingHIITVariables()
        {
            //setup
            SessionLog s = new SessionLog();
            HIIT h = new("burpees", 15, 60, 60);
            int targetValue = 15;
            //execution
            s.addWorkout(h);
            s.justDoIt(1, 15, 60, 60);
            //verification
            Assert.AreEqual(targetValue, h.performedReps);
        }

        [TestMethod]
        public void RemoveCorrectlyRemoves()
        {
            //setup
            SessionLog s = new SessionLog();
            FitSet f = new("crunches", "core", 0, 20);
            TriWorkout t = new("running", 16.0, 2.0);
            HIIT h = new("burpees", 15, 60, 60);
            int targetValue = 2;
            //execution
            s.addWorkout(f);
            s.addWorkout(t);
            s.addWorkout(h);
            s.removeWorkout(2);
            //verification
            Assert.AreEqual(targetValue, s.NumWorkouts);
        }

        [TestMethod]
        public void WorkoutCompletedWhenAllObjectsAreCompleted()
        {
            //setup
            SessionLog s = new SessionLog();
            FitSet f = new("crunches", "core", 0, 20);
            TriWorkout t = new("running", 16.0, 2.0);
            bool targetValue = true;
            //execution
            s.addWorkout(f);
            s.addWorkout(t);
            s.justDoIt(1, 0, 20);
            s.justDoIt(2, 16.0, 2.0);
            //verification
            Assert.AreEqual(targetValue, s.workoutCompleted);
        }

        [TestMethod]
        public void WorkoutNotCompletedWhenNotAllObjectsAreCompleted()
        {
            //setup
            SessionLog s = new SessionLog();
            FitSet f = new("crunches", "core", 0, 20);
            TriWorkout t = new("running", 16.0, 2.0);
            bool targetValue = false;
            //execution
            s.addWorkout(f);
            s.addWorkout(t);
            s.justDoIt(1, 0, 20);
            //verification
            Assert.AreEqual(targetValue, s.workoutCompleted);
        }

        [TestMethod]
        public void BuildSessionAddsMultipleEntries()
        {
            //setup
            SessionLog s = new SessionLog();
            List<Workout> entries = new List<Workout>();
            FitSet f = new("crunches", "core", 0, 20);
            TriWorkout t = new("running", 16.0, 2.0);
            HIIT h = new("burpees", 15, 60, 60);
            int targetValue = 3;
            //execution
            s.addWorkout(f);
            entries.Add(t);
            entries.Add(h);
            s.buildSession(entries);
            //verification
            Assert.AreEqual(targetValue, s.NumWorkouts);
        }

        [TestMethod]
        public void ShareSessionProvidesCorrectOutputForAllTypes()
        {
            //setup
            SessionLog s = new SessionLog();
            FitSet f = new("crunches", "core", 0, 20);
            TriWorkout t = new("running", 16.0, 2.0);
            HIIT h = new("burpees", 15, 60, 60);
            string targetValue = "";
            targetValue += "crunches\tGoal Weight: 0\tGoal Reps: 20\tPerformed Weight: 0\tPerformed Reps: 20";
            targetValue += "\n";
            targetValue += "running\tGoal Time: 16\tGoal Distance: 2\tPerformed Time: 16\tPerformed Distance: 2";
            targetValue += "\n";
            targetValue += "burpees\tGoal Reps: 15\tGoal Time: 60\tGoal Rest: 60\tPerformed Reps: 15\tPerformed Time: 60\tPerformed Rest: 60";
            targetValue += "\n";
            //execution
            s.addWorkout(f);
            s.addWorkout(t);
            s.addWorkout(h);
            s.justDoIt(1, 0, 20);
            s.justDoIt(2, 16.0, 2.0);
            s.justDoIt(3, 15, 60, 60);
            //verification
            Assert.AreEqual(targetValue, s.shareSession());
        }

        [TestMethod]
        public void BuildSessionCreatesBuildableCopy()
        {
            //setup
            SessionLog s = new SessionLog();
            FitSet f = new("crunches", "core", 0, 20);
            TriWorkout t = new("running", 16.0, 2.0);
            HIIT h = new("burpees", 15, 60, 60);
            SessionLog buildable = new SessionLog();
            bool targetValue = false;
            //execution
            s.addWorkout(f);
            s.addWorkout(t);
            s.addWorkout(h);
            s.justDoIt(1, 0, 20);
            s.justDoIt(2, 16.0, 2.0);
            s.justDoIt(3, 15, 60, 60);
            buildable.addWorkout(f);
            buildable.buildSession(s);
            buildable.justDoIt(1, 0, 100);
            //verification
            Assert.AreEqual(targetValue, buildable.workoutCompleted);
        }

        [TestMethod]
        public void BuildSessionCreatesSessionLogWithCorrectNumberOfItems()
        {
            //setup
            SessionLog s = new SessionLog();
            FitSet f = new("crunches", "core", 0, 20);
            TriWorkout t = new("running", 16.0, 2.0);
            HIIT h = new("burpees", 15, 60, 60);
            SessionLog buildable = new SessionLog();
            int targetValue = 3;
            //execution
            s.addWorkout(f);
            s.addWorkout(t);
            s.addWorkout(h);
            s.justDoIt(1, 0, 20);
            s.justDoIt(2, 16.0, 2.0);
            s.justDoIt(3, 15, 60, 60);
            buildable.addWorkout(f);
            buildable.buildSession(s);
            //verification
            Assert.AreEqual(targetValue, buildable.NumWorkouts);
        }
    }
}