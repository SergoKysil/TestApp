using Microsoft.OData.Edm;
using System;
using System.ComponentModel.DataAnnotations;

namespace TestApp.Models
{
    public class CSVViewModel
    {

        [Required]
        public int? Id { get; set; }


        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        
        [Required]
        [DataType(DataType.Date)]
        public Date DateofBirth { get; set; }

        
        [Required]
        public bool IsMarried { get; set; }

        
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

      
        [Required]
        [DataType(DataType.Text)]
        public decimal Salary { get; set; }
    }
}
