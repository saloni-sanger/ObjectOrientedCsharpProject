using System;
using PA5;

/* Class Invariants:
 * No limit on number of SessionLogs in logs
 */

namespace PA5
{
    public class Athlete
    {
        private List<SessionLog> logs = new List<SessionLog>();

        public Athlete() {}

        //Preconditions: None
        //Postconditions: logs has another SessionLog
        public void AddSessionLog(SessionLog s)
        {
            logs.Add(s);
        }

        //Preconditions: None
        //Postconditions: None
        public string Report()
        {
            string returnValue = "";
            foreach (SessionLog s in logs)
            {
                returnValue += s.shareSession();
                returnValue += "\n";
            }
            return returnValue;
        }
    }
}

/* Implementation Invariants:
 * None
 */

