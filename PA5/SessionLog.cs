/* Name: Saloni Sanger
 * CPSC 3200, Dr. Spinney
 * Homework 3
 * File: SessionLog.cs
 */

/* Class invariants:
 * Editting the SessionLog in any way is only allowed if workoutCompleted is false.
 * All workouts in log must be completed on the same day, or performed values will not be set by justDoIt().
 * There is no limit on how many workouts a SessionLog can have.
 */

using System;
using PA5;

namespace PA5
{
    public class SessionLog
    {
        private List<Workout> log = new List<Workout>();
        public bool workoutCompleted { get; private set; }

        public SessionLog() { }

        public int NumWorkouts
        {
            get { return log.Count; }
        }

        public List<Workout> getLog()
        {
            return log;
        }

        //Preconditions: None 
        //Postconditions: One workout may have been appended to log
        public void addWorkout(Workout w)
        {
            if (workoutCompleted == false)
            {
                log.Add(w);
            }
        }

        //Preconditions: exerciseNum <= log.Count
        //Postconditions: One workout may have been deleted to log
        public void removeWorkout(int exerciseNum)
        {
            if (workoutCompleted == false)
            {
                exerciseNum--;
                log.RemoveAt(exerciseNum);
            }
        }

        //Preconditions: exerciseNum <= log.Count, all objects before exerciseNum have been completed, exercise is a FitSet
        //Postconditions: Values may have been set for workout's performed variables, workoutCompleted may have changed
        public void justDoIt(int exerciseNum, uint completedWeight, uint completedReps)
        {
            if (workoutCompleted == false)
            {
                if (enforceSameDate(exerciseNum))
                {
                    exerciseNum--;
                    Workout w = log[exerciseNum];
                    FitSet f = (FitSet)w;
                    f.setPerformedWeight(completedWeight);
                    f.setPerformedReps(completedReps);

                    workoutCompleted = checkCompletion();
                }
            }
        }

        //Preconditions: exerciseNum <= log.Count, all objects before exerciseNum have been completed, exercise is a TriWorkout
        //Postconditions: Values may have been set for workout's performed variables, workoutCompleted may have changed
        public void justDoIt(int exerciseNum, double completedTime, double completedDistance)
        {
            if (workoutCompleted == false)
            {
                if (enforceSameDate(exerciseNum))
                {
                    exerciseNum--;
                    Workout w = log[exerciseNum];
                    TriWorkout t = (TriWorkout)w;
                    t.setPerformedTime(completedTime);
                    t.setPerformedDistance(completedDistance);

                    workoutCompleted = checkCompletion();
                }
            }
        }

        //Preconditions: exerciseNum <= log.Count, all objects before exerciseNum have been completed, exercise is a HIIT
        //Postconditions: Values may have been set for workout's performed variables, workoutCompleted may have changed 
        public void justDoIt(int exerciseNum, double completedReps, double completedRest, double completedTime)
        {
            if (workoutCompleted == false)
            {
                if (enforceSameDate(exerciseNum))
                {
                    exerciseNum--;
                    Workout w = log[exerciseNum];
                    HIIT h = (HIIT)w;
                    h.setPerformedTime(completedTime);
                    h.setPerformedRest(completedRest);
                    h.setPerformedReps(completedReps);

                    workoutCompleted = checkCompletion();
                }
            }
        }

        //Preconditions: None
        //Postconditions: None
        private bool enforceSameDate(int exerciseNum)
        {
            exerciseNum--;
            if (exerciseNum == 0)
            {
                return true;
            }
            else
            {
                DateTime today = DateTime.Today;
                if (log[exerciseNum - 1].completionDate.ToString("d") == today.ToString("d"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //Preconditions: None
        //Postconditions: None
        private bool checkCompletion()
        {
            int completed = 0;
            foreach (Workout item in log)
            {
                if (item.isComplete())
                {
                    completed++;
                }
            }
            if (completed == log.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Preconditions: None
        //Postconditions: entries.Count objects may have been appended to log
        public void buildSession(List<Workout> entries)
        {
            if (workoutCompleted == false)
            {
                foreach (Workout w in entries)
                {
                    log.Add(w);
                }
            }
        }

        //Preconditions: None
        //Postconditions: This SessionLog is now a buildable version of the one sent in, anything that was previously in this log is erased.
        public void buildSession(SessionLog s)
        {
            if (workoutCompleted == false)
            {
                log.Clear(); //in case there's something here
                foreach (Workout w in s.log)
                {
                    if (w is FitSet f)
                    {
                        if (f.name != null)
                        {
                            FitSet temp = new FitSet(f.name, f.classification, f.weight, f.targetReps);
                            log.Add(temp);
                        }
                    }
                    else if (w is TriWorkout t)
                    {
                        if (t.name != null)
                        {
                            TriWorkout temp = new TriWorkout(t.name, t.timeGoal, t.distanceGoal);
                            log.Add(temp);
                        }
                    }
                    else if (w is HIIT h)
                    {
                        if (h.name != null)
                        {
                            HIIT temp = new HIIT(h.name, h.repGoal, h.timeGoal, h.restGoal);
                            log.Add(temp);
                        }
                    }

                }
            }
        }

        //Preconditions: None
        //Postconditions: None
        public string shareSession()
        {
            string returnValue = "";
            foreach (Workout w in log)
            {
                if (w is FitSet f)
                {
                    returnValue += f.name;
                    returnValue += "\tGoal Weight: ";
                    returnValue += f.weight.ToString();
                    returnValue += "\tGoal Reps: ";
                    returnValue += f.targetReps.ToString();
                    if (f.isComplete())
                    {
                        returnValue += "\tPerformed Weight: ";
                        returnValue += f.performedWeight.ToString();
                        returnValue += "\tPerformed Reps: ";
                        returnValue += f.performedReps.ToString();
                    }

                }
                else if (w is TriWorkout t)
                {
                    returnValue += t.name;
                    returnValue += "\tGoal Time: ";
                    returnValue += t.timeGoal.ToString();
                    returnValue += "\tGoal Distance: ";
                    returnValue += t.distanceGoal.ToString();
                    if (t.isComplete())
                    {
                        returnValue += "\tPerformed Time: ";
                        returnValue += t.performedTime.ToString();
                        returnValue += "\tPerformed Distance: ";
                        returnValue += t.performedDistance.ToString();
                    }

                }
                else if (w is HIIT h)
                {
                    returnValue += h.name;
                    returnValue += "\tGoal Reps: ";
                    returnValue += h.repGoal.ToString();
                    returnValue += "\tGoal Time: ";
                    returnValue += h.timeGoal.ToString();
                    returnValue += "\tGoal Rest: ";
                    returnValue += h.restGoal.ToString();
                    if (h.isComplete())
                    {
                        returnValue += "\tPerformed Reps: ";
                        returnValue += h.performedReps.ToString();
                        returnValue += "\tPerformed Time: ";
                        returnValue += h.performedTime.ToString();
                        returnValue += "\tPerformed Rest: ";
                        returnValue += h.performedRest.ToString();

                    }
                }
                returnValue += "\n";
            }
            return returnValue;
        }
    }
}

/* Implementation Invariants:
* workoutCompleted is used to limit function use of user.
* The program does not control for the chance that a user enters invalid values for all number variables (negative values are invalid).
* workout is marked completed if each workout in the log returns true for function call isComplete().
* addWorkout() allows user to add one Workout entry to SessionLog, removeWorkout() removes one Workout.
* buildSession allows user to add several Workouts to a SessionLog.
* When an exerciseNum is entered, it is decremented to represent an array index.
* workoutCompleted was made readable for testing purposes, could also be beneficial to user to be able to check if the log is completed.
* NumWorkouts was made for testing purposes.
* justDotIt has 3 implementations for the 3 different types of Workout.
* enforceSameDate ensures that if the user has completed a workout within log, all future workouts performed are on the same day. (the time can differ, the date cannot)
* shareSession provides all info needed to display the log.
*/