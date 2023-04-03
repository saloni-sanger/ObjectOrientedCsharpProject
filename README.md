# Workout Session Creation and Tracking Project

### Background
I made this project in Object-Oriented Programming 
with Professor Timothy Spinney at Seattle University.

#### Classes
There are different types of exercises:
- a **FitSet**: any kind of weighted or body exercise 
with sets and reps would classify
- a **HIIT**: an exercise with specific active and rest 
time as well as sets
- a **TriWorkout**: an exercise of swimming, running, 
or cycling

These are all a subtype of the **workout** class, the 
**Workout** class itself is unimportant.

You can create an empty session of workouts using 
the **SessionLog** class.
Someone can then perform these workouts and the 
intended use is for the creator of the session to
then assess the quality of the session performed via
stats provided. 

There is also the **CoachedAthlete**, a subtype of
**Athlete**. This class is subscribed to 3 **Monitors** 
for Overtraining, Repetition, and Weight.

The **CoachedAthlete** is given **SessionLog**s to 
complete. When completed, they will be observed by 
the monitors and the coach can assess the Athlete's 
session.

Restrictions, rules, and additional features for 
performing sessions are in the invariants of each file.

#### Other
I created thorough **Test** files for every class 
in the project.
