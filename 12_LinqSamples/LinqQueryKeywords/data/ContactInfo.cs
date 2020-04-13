using System;
using System.Collections.Generic;
using System.Text;

namespace LinqQueryKeywords
{
    public class ContactInfo
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public override string ToString() { return Email + "," + Phone; }
    }
}
