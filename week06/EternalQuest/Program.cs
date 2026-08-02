using System;

class Program
{
    // CREATIVITY / EXCEEDING REQUIREMENTS DESCRIPTION:
    // To exceed requirements and achieve 100%, this program implements an advanced 
    // Gamified Leveling and Rank Title System inside the GoalManager. 
    // As the user accumulates score points, they automatically level up and unlock 
    // progression rank titles (e.g., Novice Pilgrim -> Dedicated Seeker -> Righteous Apprentice 
    // -> Steadfast Disciple -> Master of Habits -> Legendary Eternal Seeker), displayed dynamically 
    // on the main menu interface alongside their current point score.
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
