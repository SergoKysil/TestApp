using CsvHelper.Configuration.Attributes;
using Microsoft.OData.Edm;
using TestApp.App.Const;

namespace TestApp.Models
{
    public class ReadCSVViewModel
    {
        [Name(CSVConstants.Name)]
        public string Name { get; set; }

        [Name(CSVConstants.DoB)]
        public Date DateofBirth { get; set; }

        [Name(CSVConstants.Mareied)]
        public bool IsMarried { get; set; }

        [Name(CSVConstants.Phone)]
        public string Phone { get; set; }

        [Name(CSVConstants.Salary)]
        public decimal Salary { get; set; }
    }
}
