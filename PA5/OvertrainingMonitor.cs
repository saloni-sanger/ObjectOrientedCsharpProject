using System;
using PA5;

/* Class Invariants:
 * targetDist never changed.
 */

namespace PA5
{
    public class OvertrainingMonitor : IObserver<SessionLog>
    {
        TextWriter obj;
        double targetDist;

        public OvertrainingMonitor(TextWriter t, double targetDistance)
        {
            obj = t;
            targetDist = targetDistance;
        }

        //Preconditions: None
        //Postconditions: Text may be written to TextWriter obj
        public void OnNext(SessionLog s)
        {
            double performedDist = 0.0;

            foreach (Workout w in s.getLog())
            {
                if (w is TriWorkout t)
                {
                    performedDist += t.performedDistance;
                }
            }

            if (performedDist > targetDist)
            {
                obj.WriteLine("The combined performed distances of this SessionLog's TriWorkouts is greater then the specified target distance.");
            }
        }

        public void OnError(Exception error) { }

        public void OnCompleted() { }
    }
}

/* Implementation Invariants:
 * Sends message to TextWriter if combined performed distances of this SessionLog's TriWorkouts is greater then the specified target distance.
 */