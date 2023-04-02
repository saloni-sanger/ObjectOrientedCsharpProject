using System;
using PA5;

/* Class Invariants:
 * No limit on number of observers.
 * Every SessionLog added will get sent to every observer in observers.
 */

namespace PA5
{
    class NoOpUnsubscriber : IDisposable
    {
        public void Dispose() { }
    }

    public class CoachedAthlete : Athlete, IObservable<SessionLog>
    {
        private List<IObserver<SessionLog>> observers = new();
        private List<SessionLog> logs = new List<SessionLog>();

        public CoachedAthlete() {}

        //Preconditions: None
        //Postconditions: logs has one more sessionLog
        public new void AddSessionLog(SessionLog s) 
        {
            foreach(IObserver<SessionLog> o in observers)
            {
                o.OnNext(s);
            }
            logs.Add(s);
        } 

        //Preconditions: None
        //Postconditions: observers has one more Observer
        public IDisposable Subscribe(IObserver<SessionLog> o)
        {
            observers.Add(o);
            return new NoOpUnsubscriber();
        } 

    }
}

/* Implementation Invariants:
 * List<IObserver<SessionLog>> is a list of observers with type SessionLog.
 * This AddSessionLog overrides Athlete's AddSessionLog with keyword "new".
 * AddSessionLog send SessionLog s to each observer's OnNext function.
 */
