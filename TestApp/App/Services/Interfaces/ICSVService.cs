using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.App.DTO;

namespace TestApp.App.Services.Interfaces
{
    public interface ICSVService
    {
        Task<CSVDto> GetById(int? id);

        Task Update(CSVDto CSVDto);

        Task<CSVDto> Remove(int csvId);

        Task AddRange(string path);

        Task<IEnumerable<CSVDto>> GetAllCSVs();
       
    }
}
