using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SumatorMVC.Models
{
    public class AdditionViewModel
    {
        public float A { get; set; }

        public float B { get; set; }

        public float Result
        {
            get
            {
                return A + B;
            }
        }
    }
}