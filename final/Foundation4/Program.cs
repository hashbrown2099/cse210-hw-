using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Console.ReadKey();
        Console.Clear();
        List<Activity> activity1 = new List<Activity>(); //https://www.youtube.com/watch?v=vQzREQUhGSA&t=61s

        activity1.Add(new Running("07/20/25", 25, 20));
        activity1.Add(new Cycling("07/20/25", 25, 20));
        activity1.Add(new Swimming("07/20/26", 25, 20));

        foreach (Activity activity in activity1)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}

class Activity
{
    public string _date;
    public int _time;

    public Activity(string date, int times)
    {
        _date = date;
        _time = times;
    }

    public virtual int GetTime()
    {
        return _time;
    }
    public virtual double distance()
    {
        return 1.10;
    }
    public virtual double speed()
    {
        return 1.10;
    }

    public virtual double pace()
    {
        return 1.10;
    }

    public virtual string GetSummary()
    {
        return $" {_date} {_time} {distance()} {speed()} {pace()} ";
    }
}
class Running : Activity
{
    public int _distance;

    public Running(string date, int distance, int time) : base(date, time)
    {
        _distance = distance;

    }
    
    public override double distance()
    {
        return _distance;
    }
    public override double speed()
    {
        return (_distance / _time );
    }

    public virtual double Pace()
    {
        return ( _time / _distance);
    }

    
}
class Cycling : Activity
{
    public int _speedBike;

    public Cycling(string date, int speedBike, int time) : base(date, time)
    {
        _speedBike = speedBike;

    }
        public override double distance()
    {
        return (_speedBike / _time) ;
    }
    public override double speed()
    {
        return _speedBike; 
    }

    public virtual double Pace()
    {
        return ( 60 / _time );
    }
    

}
class Swimming : Activity
{

    public int _laps;

    public Swimming(string date, int time, int laps) : base(date, time)
   {
        _laps = laps;
   }
    public override double distance()
    {
        double distanceKilometers = (_laps * 50) / 1000.0;
        double distanceMiles = distanceKilometers  * 0.62;
        return distanceMiles;
    }

    public override double speed()
    {
        return (distance() / _time ) * 60;
    }

    public override double pace()
    {
        return (_time  / distance());
    }
    
}