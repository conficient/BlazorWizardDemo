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
        /// <summary>
        /// The child content for a step
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Should be overridden by step
        /// </summary>
        public virtual string Title { get; }

        /// <summary>
        /// Can override
        /// </summary>
        /// <returns></returns>
        public virtual bool IsValid() => true;
    }
}
