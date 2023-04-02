/* Name: Saloni Sanger
 * CPSC 3200, Dr. Spinney
 * Homework 3
 * File: FitSet.cs
 */

/* Class invariants:
 * Weight and Repetition variables are nonnegative.
 * The FitSet has a name and classification that does not change.
 * A FitSet is invalid if the reps or weight performed are set more than once.
 * A FitSet is complete once performed weight and reps have been entered at least once.
 */

using System;
using PA5;

namespace PA5
{
    public class FitSet : Workout
    {
        //instructor input: name, classification, weight, targetReps
        public string classification { get; private set; }
        public uint weight { get; private set; }
        public uint targetReps { get; private set; }


        private bool repsChanged;
        private bool weightChanged;

        //client input
        public uint performedReps { get; private set; }
        public uint performedWeight { get; private set; }

        //Preconditions: None
        //Postconditions: name, classification, weight, and targetReps have been entered.
        public FitSet(string name, string classification, uint weight,
                      uint targetReps)
        {
            this.name = name;
            this.classification = classification;
            this.weight = weight;
            this.targetReps = targetReps;
        }

        //Preconditions: performedReps has been entered
        //Postconditions: None
        public override double PercentOfGoal
        {
            get { return (((performedReps * 1.0) / (targetReps * 1.0)) * 100); }
        }

        //Preconditions: performedReps and performedWeight have been entered
        //Postconditions: None
        public override double Score
        {
            get { return (performedReps + performedWeight); }
        }

        //Preconditions: none, however, assumes weight has been entered because date of completion
        //is recorded in this function
        //Postconditions: Validity may have changed, date is recorded
        public void setPerformedReps(uint performedReps)
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
        public void setPerformedWeight(uint performedWeight)
        {
            if (weightChanged == true)
            {
                Invalid = true;
            }
            this.performedWeight = performedWeight;
            weightChanged = true;
        }

        //Preconditions: None
        //Postconditions: None
        public override bool isComplete()
        {
            if (repsChanged && weightChanged)
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
 * All weight and repetition variables are unsigned to prevent invalid negative values.
 * Bools repsChanged and weightChanged are only used internally to track validity.
 * performedWeight added so client can change the weight if different than instructed (affects validity).
 * performedReps and performedWeight will still be set per request regardless of validity.
 * The date is set when the performedReps is recorded, which is meant to be set after performedWeight.
 * Constructor assumes valid input.
 */

