/* Name: Saloni Sanger
 * CPSC 3200, Dr. Spinney
 * Homework 3
 * File: TriWorkout.cs
 */

/* Class invariants:
 * The TriWorkout has a name that does not change.
 * A TriWorkout is invalid if the time or distance performed are set more than once.
 * TriWorkout is completed once performed time and distance have been recorded at least once.
 */

using System;
using PA5;
using System.Xml.Linq;

namespace PA5
{
    public class TriWorkout : Workout
    {
        //instructor inputs
        public double timeGoal { get; private set; }
        public double distanceGoal { get; private set; }

        private bool timeChanged;
        private bool distanceChanged;

        //client input
        public double performedTime { get; private set; }
        public double performedDistance { get; private set; }

        //Preconditions: None
        //Postconditions: name, timeGoal, and distanceGoal have been entered.
        public TriWorkout(string name, double timeGoal, double distanceGoal)
        {
            if (name == "running" || name == "cycling" || name == "swimming")
            {
                this.name = name;
                this.timeGoal = timeGoal;
                this.distanceGoal = distanceGoal;

            }
            else
            {
                throw new ArgumentException();
            }
        }

        //Preconditions: performedTime and performedDistance have been entered
        //Postconditions: None
        public double Pace
        {
            get
            {
                if (name == "running")
                {
                    return performedTime / performedDistance;
                }
                if (name == "swimming")
                {
                    return performedTime / (performedDistance / 100);
                }
                else //cycling
                {
                    return performedDistance / performedTime;
                }

            }
        }

        //Preconditions: performedTime and performedDistance have been entered
        //Postconditions: None
        public override double PercentOfGoal
        {
            get
            {
                if (name == "running")
                {
                    return (((timeGoal / distanceGoal) / Pace) * 100);
                }
                if (name == "swimming")
                {
                    return (((timeGoal / distanceGoal) / (Pace / 100)) * 100);
                }
                else //cycling
                {
                    return ((Pace / (distanceGoal / timeGoal)) * 100);
                }
            }
        }

        //Preconditions: performedTime and performedDistance have been entered
        //Postconditions: None
        public override double Score
        {
            get { return (performedTime + performedDistance + Pace); }
        }

        //Preconditions: none, however, assumes distance has been entered because date of completion
        //is recorded in this function
        //Postconditions: Validity may have changed, date is recorded
        public void setPerformedTime(double performedTime)
        {
            if (timeChanged == true)
            {
                Invalid = true;
            }
            this.performedTime = performedTime;
            timeChanged = true;
            completionDate = DateTime.Today; //date is set when user reports completion
        }

        //Preconditions: None
        //Postconditions: Validity may have changed
        public void setPerformedDistance(double performedDistance)
        {
            if (distanceChanged == true)
            {
                Invalid = true;
            }
            this.performedDistance = performedDistance;
            distanceChanged = true;
        }

        //Preconditions: None
        //Postconditions: None
        public override bool isComplete()
        {
            if (timeChanged && distanceChanged)
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
 * The program does not control for the chance that a user enters invalid values for all time or distance variables (negative values are invalid).
 * Bools timeChanged and distanceChanged are only used internally to track validity.
 * performedTime and performedDistance will still be set per request regardless of validity.
 * The date is set when the performedTime is recorded, which is meant to be set after performedDistance.
 * For running, the intended units are minutes and miles.
 * For cycling, the intended units are hours and miles.
 * For swimming, the intended units are seconds and yards.
 * The unit for Pace in swimming context is seconds per 100 yards. The constructor takes the raw yard number done (in the hundreds), 
 * and later the Pace function divides the raw number by 100 for unit conversion.
 * Constructor only accepts "running, cycling, swimming" as names, all lower case and no extra spaces.
 * PercentOfGoal is calculated in a way so that for running and swimming: as your pace becomes slower (higher value), percentOfGoal becomes less,
 * and for cycling: percentOfGoal becomes higher as your pace increases.
 */