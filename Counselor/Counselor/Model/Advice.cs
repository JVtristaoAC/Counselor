using System;
using System.Collections.Generic;
using System.Text;

namespace Counselor.Model
{
    public class Advices
    {
        public string Slip_ID { get; set; }
        public string Advice { get; set; }


        public Advices()
        {
            this.Slip_ID = "";
            this.Advice = "";
        }

    }
}
