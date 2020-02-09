using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWizardDemo.Components
{
    public partial class Wizard : ComponentBase
    {
        /// <summary>
        /// the steps
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        private readonly List<IWizardStep> steps = new List<IWizardStep>();

        public IWizardStep ActiveStep { get; private set; }

        /// <summary>
        /// index of active step
        /// </summary>
        private int activeIndex = -1;

        /// <summary>
        /// highest index
        /// </summary>
        private int maxIndex = -1;

        /// <summary>
        /// Highest valid index
        /// </summary>
        private int maxValid = -1;

        public void AddStep(IWizardStep step)
        {
            steps.Add(step);
            // if the first step, set this one as the active step
            if (ActiveStep == null) SetActiveStep(step);
            maxIndex = steps.Count - 1;
            // if previous index was valid..
            if(maxValid == maxValid - 1)
            {
                // if is valid, set max valid to this
                if (step.IsValid)
                    maxValid = maxIndex;
            }
        }

        /// <summary>
        /// Change the active step
        /// </summary>
        /// <param name="step"></param>
        public void SetActiveStep(IWizardStep step)
        {
            if (ActiveStep != step)
            {
                activeIndex = steps.IndexOf(step);
                ActiveStep = step;
                StateHasChanged();
            }
        }

        /// <summary>
        /// Is active step valid
        /// </summary>
        private bool ActiveIsValid => ActiveStep?.IsValid ?? true;

        public bool IsActive(IWizardStep step)
        {
            // get index of the step
            var i = steps.IndexOf(step);
            return i >= maxValid;
        }

        private string Disabled(bool isDisabled) => isDisabled ? "disabled" : null;

        protected string PrevDisabled => Disabled(activeIndex <= 0);

        protected string NextDisabled => Disabled(activeIndex < maxIndex && ActiveIsValid);

        /// <summary>
        /// Handle Prev.click
        /// </summary>
        void Prev()
        {
            if (activeIndex > 0)
            {
                Console.WriteLine($"Prev: change to {activeIndex - 1}");
                var prev = steps[activeIndex - 1];
                SetActiveStep(prev);
            }
            else
                Console.WriteLine("Prev: first step");
        }

        /// <summary>
        /// Handle Next.click
        /// </summary>
        void Next()
        {
            if (activeIndex < maxIndex && ActiveIsValid)
            {
                Console.WriteLine($"Prev: change to {activeIndex + 1}");
                var next = steps[activeIndex + 1];
                SetActiveStep(next);
            }
            else
            {
                Console.WriteLine("Prev: last step - raise OnComplete event");
                OnComplete?.Invoke();
            }
        }

        string NextButtonText => (activeIndex == maxIndex ? "Submit" : "Next");


        /// <summary>
        /// Event raised when 'Submit' is raised 
        /// </summary>
        public event Action OnComplete;
    }
}
