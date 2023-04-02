/* Name: Saloni Sanger
 * CPSC 3200, Dr. Spinney
 * Homework 3
 * File: Workout.cs
 */

/* Interface invariants:
 * name, invalid, percentOfGoal, Score, completionDate are read only.
 * Invalid is used in subtypes to declare if client input variables have been set more than once.
 * isComplete() returns if all user inputs have been set at least once (respective to subclass)
 */

using System;
namespace PA5
{
    public abstract class Workout
    {

        public string? name { get; protected set; }
        public bool Invalid { get; protected set; }
        public abstract double PercentOfGoal { get; }
        public abstract double Score { get; }
        public abstract bool isComplete();
        public DateTime completionDate { get; protected set; }
    }
}

/* Implementation invariants:
 * string? declares that name is nullable so a constructor doesn't have to be made within Workout.
 */

