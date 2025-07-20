using System;



class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Event Type: Lecture");
        Address address1 = new Address("4351 west", "rexburg", "idaho");
        int capacity1 = 5000;
        Lecture lecture1 = new Lecture("Resilence", " Come here about how to build resilence in your life ", "October 20th", "7:30pm", address1, "David Goggins", capacity1);
        lecture1.DisplayLecture();
        Console.ReadKey();
        Console.Clear();

        Address address2 = new Address("4351", "rexburg", "idaho");
        Receptions reception1 = new Receptions("Reception", "You are invited to join us ", "October 20th", "7:30pm", address2, "RSVP");
        reception1.DisplayReceptions();
        Console.ReadKey();
        Console.Clear();

        Address address3 = new Address("4351", "rexburg", "idaho");
        OutdoorGatherings outdoorGatherings1 = new OutdoorGatherings("paintball ", " There will be blood sweat and paint", "October 20th", "7:30pm", address3, "Cloudy with a chance of paintballs");
        outdoorGatherings1.DisplayOutdoorGatherings();
        Console.ReadKey();
        Console.Clear();
    }
        
        
    }


class Event 
{
    private string _tittle;
    private string _description;
    private string _time;
    private Address _address;
    private string _date;

    public Event(string tittle, string description, string date, string time, Address address)
    {
        _tittle = tittle;
        _description = description;
        _time = time;
        _address = address;
        _date = date;
    }
    public string StandardDetails()
    {
        return $"{_tittle} {_description} {_date} {_time} \n {_address.FullAddress()}"; 

    }
    public string FullDetails()
    {
        return StandardDetails(); 
    }

    public string ShortDetails()
    {
        return $"{_tittle} {_date}";
    }
}
class Address 
{
    private string _address;
    private string _city;
    private string _state;

    public Address(string address, string city, string state)
    {
        _address = address;
        _city = city;
        _state = state;
    }
    public string FullAddress()
    {
        return $"{_address} {_city} {_state}"; 
    }
}

class Lecture : Event
{
    public string _speaker;
    public int _capacity;

    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity) : base(title, description, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    public void DisplayLecture()
    {
        Console.WriteLine(StandardDetails());
        Console.WriteLine($"Speaker: {_speaker}");
        Console.WriteLine($"Capacity: {_capacity}");

    }
}
    class Receptions : Event
    {
        public string _rvsp;

        public Receptions(string title, string description, string date, string time, Address address, string RVSP) : base(title, description, date, time, address)
        {
            _rvsp = RVSP;
        }
        public void DisplayReceptions()
        {
            Console.WriteLine(StandardDetails());
            Console.WriteLine("Reception ");
            Console.WriteLine($"Speaker: {_rvsp}");

        }

    }
class OutdoorGatherings : Event
{
    public string _Forecast;

    public OutdoorGatherings(string title, string description, string date, string time, Address address, string Forecast) : base(title, description, date, time, address)
    {
        _Forecast = Forecast;
    }
    public void DisplayOutdoorGatherings()
    {
        Console.WriteLine(StandardDetails());
        Console.WriteLine($" {FullDetails} ");
        Console.WriteLine($"Speaker: {_Forecast}");

    }

}