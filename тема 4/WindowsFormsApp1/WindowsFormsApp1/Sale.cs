using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Sale
    {
        private string month;
        private double value;

        public Sale(string month, double value)
        {
            this.month = month;
            this.value = value;
        }

        public string Month
        {
            get { return month; }
        }

        public double Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
}
