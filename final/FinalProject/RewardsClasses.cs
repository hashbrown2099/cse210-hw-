using System;

namespace FinalProject;

class RewardsAccountTracker // responsible for keep track of the points 
{
    public int points;

    public RewardsAccountTracker()
    {
        points = 0;
    }

    public int Points
    {
        get { return points; }
    }

    public void AddPoints(int amount)
    {
        points = amount;
    }

    public void MinusPoints(int amount) // if points are greater than or equals to the amount then points. then points get subtracted from the amount of points, 
    {
        if (points >= amount)
        {
            points -= amount;
        }
        else
        {
            Console.WriteLine("you dont not have enough points."); // if  you do not have enough points then it will not display the message 
        }
    }
}
class RewardAccountDistributor // essentially the shop for the rewards program 
{
     public RewardsAccountTracker tracker;

    public RewardAccountDistributor(RewardsAccountTracker tracker)
    {
        this.tracker = tracker;



    public double RedeemPoints()
    {
        double cashBack = 0;

        if (tracker.Points = 26600)
        {
            cashBack = 100;
            tracker.MinusPoints(26600);
        }
        else if (tracker.Points = 13300)
        {
            cashBack = 50
            tracker.MinusPoints(13300)

            else if = (tracker.Points = 6650)
            cashBack = 25
            tracker.MinusPoints = 6650


        return cashBack;
        }
    }
    class RewardManager 

