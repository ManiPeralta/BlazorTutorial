using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        [Inject]
        public IEmployeeService? EmployeeService { get; set; }

        [Parameter]
        public string? Id { get; set; }

        public Employee Employee { get; set; } = new Employee();

        protected override async Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
        }

        protected string? Coordinates { get; set; }

        /// this 'one-line' function, can be represented by a Lambda function straight into the HTML where the call is being made
        //protected void Mouse_Move(MouseEventArgs e)
        //{
        //    Coordinates = $"X: {e.ClientX}, Y: {e.ClientY}";
        //}

        public string ButtonText { get; set; } = "Hide Footer";
        public string CssClass { get; set; } = null;

        protected void Button_Click()
        {
            if(ButtonText == "Hide Footer")
            {
                ButtonText = "Show Footer";
                CssClass = "HideFooter";
            }
            else
            {
                ButtonText = "Hide Footer";
                CssClass = null;
            }
        }

    }
}
