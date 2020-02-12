using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWizardDemo.Example
{
    public class Car
    {
        public Car(string name, string image)
        {
            Name = name; 
            Image = image;
        }

        public string Name { get; set; }
        public string Image { get; set; }
    }
}
