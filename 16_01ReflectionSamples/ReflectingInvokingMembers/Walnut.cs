using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ReflectingInvokingMembers
{
    public class Walnut
    {
        private bool cracked;
        public void Crack() { cracked = true; }

        public int Title
        {
            get { return 0; }
            set { }
        }

    }
}
