using System;

/* Class Invariants:
 * None
 */

namespace PA5
{
    public class RepetitionMonitor : IObserver<SessionLog>
    {
        TextWriter obj;

        public RepetitionMonitor(TextWriter t)
        {
            obj = t;
        }

        //Preconditions: None
        //Postconditions: Text may be written to TextWriter obj
        public void OnNext(SessionLog s)
        {
            bool invalidReps = false;
           
            foreach (Workout w in s.getLog())
            {
                if (w is FitSet f)
                {
                    if(f.performedReps > f.targetReps)
                    {
                        invalidReps = true;
                    }
                } 
                else if (w is HIIT h)
                {
                    if(h.performedReps > h.repGoal)
                    {
                        invalidReps = true;
                    }
                }
            }

            if(invalidReps == true)
            {
                obj.WriteLine("This SessionLog has at least one Workout where the performed reps are greater than the target reps.");
            }
            
        }

        public void OnError(Exception error) { }

        public void OnCompleted() { }
    }
}

/* Implementation Invariants:
 * Sends message to TextWriter if at least one Workout where the performed reps are greater than the target reps.
 */