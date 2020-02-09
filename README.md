# BlazorWizardDemo

This code demonstrates simple Wizard component using [Blazor](https://www.blazor.net).

## Requirements

What I wanted to create was a wizard control that contains a number of steps. The 
navigation to the next step must be controlled by the current step. If the current 
step wishes, it should be able to prevent the user moving to the next step. 


I started by looking at the [tab sample](https://docs.microsoft.com/en-us/aspnet/core/blazor/components?view=aspnetcore-3.1#tabset-example)
in the Blazor documentation. This creates a `<TabSet>` container with `<Tab>` 
components in the child content, using `[CascadingProperty]` to communicate between 
the `Tab` and the parent `TabSet`.

This design is simple and works well. Each each `Tab` has to render some content 
for the menu, which allows the Tabs to 'exist' in the render. A Wizard would be slightly different, 
as each step would need to be enabled or disabled based on whether it was 'complete'.

The wizard would also have a [Next] and [Prev] buttons.

So we want a wizard component that contains a number of steps. My first idea was to allow each step
to be a custom component containing the content for the step, and also implementing an interface.

```
<Wizard>
  <Step1 />
  <Step2 />
  <Step3 />
</Wizard>
```
This puts the content into special step components that implement an interface


If we re-use the tab example, we have HTML something like this:
```
<Wizard>
  <Step Title="Step 1" PermitNext="AllowStep2" >
    <input type='checkbox' @bind="permitNext" />
  </Step>
 <Step>
    .. content  
  </Step>
 <Step>
    .. content  
  </Step>
</Wizard>

@code
{
   bool permitNext = false;

   bool AllowStep2() 
   {
      // some logic based on step 1 content
      return permitNext;
   }
}
```

This would work but a lot of the logic is now in this screen, but it works

Flow of messages

![Dalek Class](http://yuml.me/diagram/plain;dir:LR;scale:80/class/,%20%5BModel%5D%20-%3E%20%5BStep%5D,%20%5BContent%5D-%3E%5BStep%5D,%20%5BStep%5D-%3E%5BWizard%5D.png)
