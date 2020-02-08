using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWizardDemo.Components
{
    /// <summary>
    /// Interface each step implements to talk to the parent wizard
    /// </summary>
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
        /// Is the step valid - if it is we can proceed
        /// </summary>
        /// <returns></returns>
        bool IsValid();
    }
}
