using System;

/* Class Invariants:
 * None
 */

namespace PA5
{
    public class WeightMonitor : IObserver<SessionLog>
    {
        TextWriter obj;

        public WeightMonitor(TextWriter t)
        {
            obj = t;
        }

        //Preconditions: None
        //Postconditions: Text may be written to TextWriter obj
        public void OnNext(SessionLog s)
        {
            bool invalidWeight = false;

            foreach (Workout w in s.getLog())
            {
                if (w is FitSet f)
                {
                    if (f.performedWeight > f.weight)
                    {
                        invalidWeight = true;
                    }
                } 
            }

            if (invalidWeight == true)
            {
                obj.WriteLine("This SessionLog has at least one Workout where the performed weight is greater than the target weight.");
            }

        }

        public void OnError(Exception error) { }

        public void OnCompleted() { }
    }
}

/* Implementation Invariants:
 * Sends message to TextWriter if at least one Workout where the performed weight are greater than the target weight.
 */

