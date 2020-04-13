using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinqQueryKeywords
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public List<int> Scores { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName + ":" + ID;
        }
        public  ContactInfo GetContactInfo(List<ContactInfo> contactList)
        {
            ContactInfo cInfo =
                (from ci in contactList
                 where ci.ID == ID
                 select ci)
                .FirstOrDefault();
            return cInfo;
        }

    }
}
