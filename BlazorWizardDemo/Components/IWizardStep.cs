using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWizardDemo.Components
{
    public interface IWizardStep
    {
        /// <summary>
        /// The step content to be rendered
        /// </summary>
        RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Title for this step
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Function to return if step is valid
        /// </summary>
        public Func<bool> IsValid { get; set; }

        ///// <summary>
        ///// Event raised when validity changes
        ///// </summary>
        //event Action<bool> OnValidChanged;
    }
}
