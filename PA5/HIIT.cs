/* Name: Saloni Sanger
 * CPSC 3200, Dr. Spinney
 * Homework 3
 * File: Hiit.cs
 */

/* Class invariants:
 * The HIIT has a name that does not change.
 * A HIIT is invalid if the time, rest or reps performed are set more than once.
 * HIIT is completed once performed time, rest, and reps have been recorded at least once.
 */

using System;
using PA5;

namespace PA5
{
    public class HIIT : Workout
    {
        //instructor input
        public double repGoal { get; private set; }
        public double timeGoal { get; private set; }
        public double restGoal { get; private set; }

        private bool repsChanged;
        private bool timeChanged;
        private bool restChanged;

        //client input
        public double performedTime { get; private set; }
        public double performedRest { get; private set; }
        public double performedReps { get; private set; }

        //Preconditions: None
        //Postconditions: name, repGoal, timeGoal, and restGoal have been entered.
        public HIIT(string name, double repGoal, double timeGoal, double restGoal)
        {
            this.name = name;
            this.repGoal = repGoal;
            this.timeGoal = timeGoal;
            this.restGoal = restGoal;
        }

        //Preconditions: performedTime, performedRest, and performedReps have been entered
        //Postconditions: None
        public override double PercentOfGoal
        {
            get
            {
                return ((performedReps + performedTime + performedRest) / (repGoal + timeGoal + restGoal)) * 100;
            }
        }

        //Preconditions: performedTime, performedRest, and performedReps have been entered
        //Postconditions: None
        public override double Score
        {
            get { return (performedReps + performedTime - (performedRest / 10)); }
        }

        //Preconditions: none, however, assumes performed times have been entered because date of completion
        //is recorded in this function
        //Postconditions: Validity may have changed, date is recorded
        public void setPerformedReps(double performedReps)
        {
            if (repsChanged == true)
            {
                Invalid = true;
            }
            this.performedReps = performedReps;
            repsChanged = true;
            completionDate = DateTime.Today; //date is set when user reports completion
        }

        //Preconditions: None
        //Postconditions: Validity may have changed
        public void setPerformedTime(double performedTime)
        {
            if (timeChanged == true)
            {
                Invalid = true;
            }
            this.performedTime = performedTime;
            timeChanged = true;
        }

        //Preconditions: None
        //Postconditions: Validity may have changed
        public void setPerformedRest(double performedRest)
        {
            if (restChanged == true)
            {
                Invalid = true;
            }
            this.performedRest = performedRest;
            restChanged = true;
        }

        //Preconditions: None
        //Postconditions: None
        public override bool isComplete()
        {
            if (timeChanged && restChanged && repsChanged)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

/* Implementation invariants:
 * The program does not control for the chance that a user enters invalid values for all time or rep variables (negative values are invalid).
 * Bools timeChanged, restChanged, and repsChanged are only used internally to track validity.
 * performedTime, performedRest, performedReps will still be set per request regardless of validity.
 * The date is set when the performedReps are recorded, which is meant to be set after performed time and rest.
 * All time variables are meant to be in seconds.
 */

