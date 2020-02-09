using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWizardDemo.Components
{
    public partial class WizardStep : ComponentBase, IWizardStep
    {

        [CascadingParameter] public Wizard Parent { get; set; }

        /// <summary>
        /// The child content for a step (IWizardStep)
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// the step title (IWizardStep)
        /// </summary>
        [Parameter] public string Title { get; set; }

        /// <summary>
        /// Return either null, active or disabled css for link
        /// </summary>
        private string LinkCSS
        {
            get
            {
                if(Parent.ActiveStep == this) return "active";
                // if not the active step we query parent wizard
                // to see if it should be enabled
                return Parent.IsActive(this) ? null : "disabled";
            }
        }

        protected override void OnInitialized()
        {
            Parent.AddStep(this);
            base.OnInitialized();
        }

        /// <summary>
        /// Is step valid: set via property
        /// </summary>
        [Parameter] public bool IsValid { get; set; } = true;

        ///// <summary>
        ///// Event alerting consumer the IsValid value changed
        ///// </summary>
        ///// <remarks>
        ///// consume by adding an event handler [service].OnValidChanged += { ... }
        ///// </remarks>
        //public event Action<bool> OnIsValidChanged;

    }
}
