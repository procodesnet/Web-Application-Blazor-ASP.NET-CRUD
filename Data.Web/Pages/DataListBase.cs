using Data.Models;
using Microsoft.AspNetCore.Components;

namespace Data.Web.Pages
{
    public class DataListBase : ComponentBase
    {
        public IEnumerable<Record> Records { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(LoadRecords);
        }

        private void LoadRecords()
        {
            System.Threading.Thread.Sleep(1000);
            Record r1 = new Record
            {
                Id = 1,
                Field = "One"
            };
            Record r2 = new Record
            {
                Id = 2,
                Field = "Two"
            };
            Record r3 = new Record
            {
                Id = 3,
                Field = "Three"
            };
            Records = new List<Record> { r1, r2, r3 };
        }
    }
}
