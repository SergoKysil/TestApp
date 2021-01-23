using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Domain.Entities
{
    public class CSV : IEntityBase
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public DateTime DateofBirth { get; set; }

        public bool IsMarried { get; set; }

        public string Phone { get; set; }

        public decimal Salary { get; set; }
    }
}
