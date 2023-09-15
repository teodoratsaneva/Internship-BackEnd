﻿using System;
using System.Reflection;

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
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        private decimal price;
        public string Owner { get; set; }
        public Battery Battery = new Battery();
        public Display Display = new Display();
        private string PhoneNumber { get; set; }
        private List<Call> callHistory = new List<Call>();

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
                    throw new ArgumentException("Price cannot be negative.");
                }
            }
        }

        public GSM()
        {
            Battery = new Battery();
            Display = new Display();
        }

        public GSM(string model, string manufacturer, decimal price, string owner, Battery battery, Display display)
        {
            Model = model;
            Manufacturer = manufacturer;
            Price = price;
            Owner = owner;
            Battery = battery;
            Display = display;
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

            return base.ToString() + ": " + Model.ToString() + " " + Manufacturer.ToString() + " " + Price.ToString() + " " + Owner.ToString() + " " +
              Battery.ToString() + " " + Display.ToString() + " " + callHistoryStr;
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

    public class IPhone4S
    {
        public GSM CreateIPhone4S()
        {
            BatteryType batteryType = BatteryType.LiIon;
            string batteryModel = "iPhone 4S Battery";
            int batteryHoursIdle = 200;
            int batteryHoursTalk = 360;
            Battery battery = new Battery(batteryType, batteryModel, batteryHoursIdle, batteryHoursTalk);

            float displaySize = 3.5f;
            int displayColors = 16777216;
            Display display = new Display(displaySize, displayColors);

            string gsmModel = "iPhone 4S";
            string gsmManufacturer = "Apple";
            decimal gsmPrice = 399;
            string gsmOwner = "Apple Inc.";

            GSM iPhone4S = new GSM(gsmModel, gsmManufacturer, gsmPrice, gsmOwner, battery, display);
            GSM gsm = new GSM();

            Call call = new Call(new DateOnly(2023, 05, 22), new TimeOnly(12, 45), gsm, 345);
            iPhone4S.AddCall(call);

            return iPhone4S;
        }
    }

    public class Battery
    {
        public BatteryType Type { get; set; }
        public string Model { get; set; }
        private int hoursIdle;
        private int hoursTalk;

        public int HoursIdle
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
                    throw new ArgumentException("Hours idle cannot be negative.");
                }
            }
        }

        public int HoursTalk
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
                    throw new ArgumentException("Hours talk cannot be negative.");
                }
            }
        }

        public Battery()
        {
            Type = BatteryType.LiIon;
        }

        public Battery(BatteryType type, string model, int hoursIdle, int hoursTalk)
        {
            Type = type;
            Model = model;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
        }

        public override string ToString()
        {
            return Type.ToString() + " " + Model.ToString() + " " + hoursIdle.ToString() + " " + hoursTalk.ToString();
        }
    }

    public class Display
    {
        private float size;
        private int numberOfColors;

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
                    throw new ArgumentException("Size cannot be negative.");
                }
            }
        }

        public int NumberOfColors
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
                    throw new ArgumentException("Number of colors cannot be negative.");
                }
            }
        }

        public Display()
        {
            size = 0;
            numberOfColors = 0;
        }

        public Display(float size, int numberOfColors)
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
        private DateOnly date;
        private TimeOnly time;

        private GSM callTo = new GSM();

        private uint duration = 0;

        public Call(DateOnly date, TimeOnly time, GSM callTo, uint durationInSeconds)
        {
            this.date = date;
            this.time = time;
            this.callTo = callTo;
            this.duration = durationInSeconds;
        }

        public Call()
        {
            date = DateOnly.MinValue;
            TimeOnly time = TimeOnly.MinValue;
        }

        public override string ToString()
        {
            string date = this.date.ToString();
            string time = this.time.ToString();

            return date.ToString() + " " + time.ToString() + " " + callTo.ToString() + " " + callTo.ToString();
        }

        public uint Duration
        {
            get { return duration; }
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

            Call call1 = new Call(new DateOnly (2023, 09, 02), new TimeOnly(15,52), gsmArray[0], 569) ;

            gsmArray[0].AddCall(call1);

            foreach (GSM phone in gsmArray)
            {
                Console.WriteLine(phone.ToString());
            }

            Console.WriteLine(gsmArray[2].CalculateCallPrice(0.37f));
        }
    }
}


