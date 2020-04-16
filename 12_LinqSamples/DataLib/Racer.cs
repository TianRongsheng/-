using System;
using System.Collections.Generic;

namespace DataLib
{
    /// <summary>  
    ///实现了IFormattable 接口，以支持格式字符串的不同变体，
    ///实现了IComparable<Racer>接口，它根据Lastname为赛车手排序。
    /// </summary>
    public class Racer : IComparable<Racer>, IFormattable
    {

        public Racer(string firstName, string lastName, string country, int starts, int wins, IEnumerable<int> years, IEnumerable<string> cars)
        {
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            Starts = starts;
            Wins = wins;
            //多值属性Years 属性列出了赛车手获得冠军的年份，一些赛车手曾多次获得冠军。
            Years = years != null ? new List<int>(years) : new List<int>();
            //Cars 属性用于列出赛车手在获得冠军中使用的所有车型
            Cars = cars != null ? new List<string>(cars) : new List<string>();
        }
        public Racer(string firstName, string lastName, string country, int starts, int wins)
          : this(firstName, lastName, country, starts, wins, null, null) { }

        public string FirstName { get; }
        public string LastName { get; }
        public string Country { get; }
        public int Wins { get; }
        public int Starts { get; }
        public IEnumerable<string> Cars { get; }
        public IEnumerable<int> Years { get; }
        
        //重载的ToString0方法，该方法以字符串格式显示赛车手。
        public override string ToString()
        { 
        return $"{FirstName} {LastName}";
        }


        public int CompareTo(Racer other)
        {
            return LastName.CompareTo(other?.LastName);
        }

        public string ToString(string format)
        {
            return ToString(format, null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case null:
                case "N":
                    return ToString();
                case "F":
                    return FirstName;
                case "L":
                    return LastName;
                case "C":
                    return Country;
                case "S":
                    return Starts.ToString();
                case "W":
                    return Wins.ToString();
                case "A":
                    return $"{FirstName} {LastName}, country: {Country}; starts: {Starts}, wins: {Wins}";
                default:
                    throw new FormatException($"Format {format} not supported");
            }
        }
    }
}