/*
CSE 210 W06 - Eternal Quest Program
Author: Your Name

EXCEEDING REQUIREMENTS:
1. Leveling System: Player gains 1 level per 1000 points earned. 
2. Rank Titles: Player earns funny ranks like "Diligent Seeker", "Faithful Warrior", "Ninja Unicorn" at level 13.
3. Level Up Celebrations: Special message displays when leveling up to encourage the user.
These features add gamification beyond basic points to keep users engaged in their eternal quest.
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}