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
        /// Event raised if model changes
        /// </summary>
        public event Action OnChange;

        /// <summary>
        /// Flag changes
        /// </summary>
        private void HasChanged() => OnChange?.Invoke();

        /// <summary>
        /// customer must be 18
        /// </summary>
        public bool IsOver18
        {
            get => _isOver18;
            set
            {
                _isOver18 = value;
                HasChanged(); // flag change
            }
        }
        private bool _isOver18 = false;

        /// <summary>
        /// Customer needs to agree to terms
        /// </summary>
        public bool AgreeToTerms
        {
            get => _agreeToTerms;
            set
            {
                _agreeToTerms = value;
                HasChanged();
            }
        }
        private bool _agreeToTerms = false;

        // Flag for Step1 
        public bool Step1OK() => IsOver18 & AgreeToTerms;

        // STEP 2
        // ======

        public string CarType { get => _carType;
            set
            {
                _carType = value;
                HasChanged();
            }
        }
        private string _carType = null;

        public static List<Car> GetCars()
        {
            return new List<Car>() {
                new Car("Ford Focus", "/img/fiesta.png"),
                new Car("Ford EcoSport", "/img/ecosport.webp"),
                new Car("Ford Puma", "/img/puma.webp"),
                new Car("Ford Modeo", "/img/mondeo.webp")
            };
        }

        /// <summary>
        /// Customer wants child seats
        /// </summary>
        public bool ChildSeatsRequired
        {
            get => _childSeatsRequired;
            set
            {
                _childSeatsRequired = value;
                HasChanged();
            }
        }
        private bool _childSeatsRequired = false;

        /// <summary>
        /// Flag for Step2 - a car must be selected
        /// </summary>
        public bool Step2OK() => !string.IsNullOrEmpty(CarType);

        // STEP 3 
        // ======
        // only shown if child seats are requested

        public string ChildSeatType { get; set; }

        public bool Step3OK() => true;

        // STEP 4
        // ======
        private string _paymentType;

        public string PaymentType
        {
            get => _paymentType; 
            set { _paymentType = value; }
        }

        /// <summary>
        /// Final step - valid if payment type selected
        /// </summary>
        public bool Step4OK() => !string.IsNullOrEmpty(PaymentType);

    }
}
