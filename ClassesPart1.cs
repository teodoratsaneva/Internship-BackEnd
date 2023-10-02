using System;
using System.Collections.Generic;

namespace MobilePhone
{
    public enum BatteryType
    {
        LiIon,
        NiMH,
        NiCd
    }

    public class GSM
    {
        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value >= 0)
                {
                    price = value;
                }
                else
                {
                    Console.WriteLine("Price cannot be negative.");
                }
            }
        }

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public Battery Battery
        {
            get { return battery; }
            set { battery = value; }
        }

        public Display Display
        {
            get { return display; }
            set { display = value; }
        }

        public GSM()
        {
            model = null;
            manufacturer = null;
            price = 0;
            owner = null;
            battery = new Battery();
            display = new Display();
            callHistory = new List<Call>();
        }

        public GSM(string model, string manufacturer, decimal price, string owner, Battery battery, Display display)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            this.battery = battery;
            this.display = display;
            callHistory = new List<Call>();
        }

        public void AddCall(Call call)
        {
            callHistory.Add(call);
        }

        public void DeleteCall(Call call)
        {
            callHistory.Remove(call);
        }

        public void ClearCallHistory()
        {
            callHistory.Clear();
        }

        public override string ToString()
        {
            string callHistoryStr = string.Join(" ", callHistory);

            return base.ToString() + ": " + model.ToString() + " " + manufacturer.ToString() + " " + price.ToString() + " " + owner.ToString() + " " +
              battery.ToString() + " " + display.ToString() + " " + callHistoryStr;
        }

        public float CalculateCallPrice(float pricePerMinute)
        {
            float minutes = 0;
            const int oneHouInMinutes = 60;

            foreach (Call call in callHistory)
            {
                minutes += call.Duration / oneHouInMinutes;
            }

            return minutes * pricePerMinute;
        }
    }

    public class IPhone4S : GSM
    {
        public IPhone4S()
        : base("iPhone 4S", "Apple", 399, "Apple Inc.", new Battery(BatteryType.LiIon, "iPhone 4S Battery", 200, 360), new Display(3.5f, 16777216))
        {
            Call call = new Call("21/11/2022", "14:49", "0878964523", 345);
            AddCall(call);
        }
    }

    public class Battery
    {
        private BatteryType type;
        private string model;
        private uint hoursIdle;
        private uint hoursTalk;

        public BatteryType Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public uint HoursIdle
        {
            get { return hoursIdle; }
            set
            {
                if (value >= 0)
                {
                    hoursIdle = value;
                }
                else
                {
                    Console.WriteLine("HoursIdle cannot be negative.");
                }
            }
        }

        public uint HoursTalk
        {
            get { return hoursTalk; }
            set
            {
                if (value >= 0)
                {
                    hoursTalk = value;
                }
                else
                {
                    Console.WriteLine("HoursTalk cannot be negative.");
                }
            }
        }

        public Battery()
        {
            type = BatteryType.LiIon;
            model = null;
            hoursIdle = 0;
            hoursTalk = 0;
        }

        public Battery(BatteryType type, string model, uint hoursIdle, uint hoursTalk)
        {
            this.type = type;
            this.model = model;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
        }

        public override string ToString()
        {
            return type.ToString() + " " + model.ToString() + " " + hoursIdle.ToString() + " " + hoursTalk.ToString();
        }
    }

    public class Display
    {
        private float size;
        private uint numberOfColors;

        public float Size
        {
            get { return size; }
            set
            {
                if (value >= 0)
                {
                    size = value;
                }
                else
                {
                    Console.WriteLine("Size cannot be negative.");
                }
            }
        }

        public uint NumberOfColors
        {
            get { return numberOfColors; }
            set
            {
                if (value >= 0)
                {
                    numberOfColors = value;
                }
                else
                {
                    Console.WriteLine("NumberOfColors cannot be negative.");
                }
            }
        }

        public Display()
        {
            size = 0;
            numberOfColors = 0;
        }

        public Display(float size, uint numberOfColors)
        {
            this.size = size;
            this.numberOfColors = numberOfColors;
        }

        public override string ToString()
        {
            return size.ToString() + " " + numberOfColors.ToString();
        }
    }

    public class Call
    {
        private string date;
        private string time;
        private string phoneNumber;
        private uint duration;

        public Call()
        {
            date = null;
            time = null;
            phoneNumber = null;
            duration = 0;
        }


        public Call(string date, string time, string phoneNumber, uint duration)
        {
            this.date = date;
            this.time = time;
            this.phoneNumber = phoneNumber;
            this.duration = duration;
        }

        public uint Duration
        {
            get { return duration; }
        }

        public override string ToString()
        {
            return date.ToString() + " " + time.ToString() + " " + phoneNumber.ToString() + " " + duration.ToString();
        }
    }

public class Program
{
    public static void Main(string[] args)
    {
        IPhone4S iphone4s = new IPhone4S();

        Console.WriteLine(iphone4s.ToString());

        GSM[] gsmArray = new GSM[3];

        gsmArray[0] = new GSM("Samsung S21", "Samsung", 1020, "Samsung Inc.", new Battery(BatteryType.LiIon, "Samsung Battery", 1200, 1300), new Display(6.2f, 16000000));
        gsmArray[1] = new GSM("Google Pixel 5", "Google", 899, "Google Inc.", new Battery(BatteryType.NiCd, "Pixel Battery", 250, 420), new Display(6.0f, 16000000));
        gsmArray[2] = new GSM("OnePlus 9 Pro", "OnePlus", 999, "OnePlus Inc.", new Battery(BatteryType.NiMH, "OnePlus Battery", 400, 440), new Display(6.7f, 16777216));

        Call call1 = new Call("02/08/2023", "12:56", "087832135", 456);
        Call call2 = new Call("03/08/2023", "14:45", "088966452", 3456);
        Call call3 = new Call("01/09/2023", "20:12", "088966452", 2345);

        gsmArray[0].AddCall(call1);
        gsmArray[2].AddCall(call2);
        gsmArray[2].AddCall(call3);

        foreach (GSM phone in gsmArray)
        {
            Console.WriteLine(phone.ToString());
        }

        Console.WriteLine(gsmArray[2].CalculateCallPrice(0.37f));
    }
}
}


