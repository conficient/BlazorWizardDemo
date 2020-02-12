using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWizardDemo.Example
{
    public class RentalModel
    {
        /// <summary>
        /// customer must be 18
        /// </summary>
        public bool IsOver18 { get; set; }

        public bool AgreeToTerms { get; set; }

        public bool Step1OK => IsOver18 & AgreeToTerms;

        public bool Step2OK => true;

        public bool Step3OK => true;

    }
}
