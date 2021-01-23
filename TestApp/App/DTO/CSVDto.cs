using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.App.DTO
{
    public class CSVDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public DateTime DateofBirth { get; set; }

        public bool IsMarried { get; set; }

        public string Phone { get; set; }

        public decimal Salary { get; set; }
    }
}
