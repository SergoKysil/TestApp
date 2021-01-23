using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestApp.App.DTO;
using TestApp.App.Services.Interfaces;
using TestApp.Domain;
using TestApp.Domain.Entities;
using TestApp.Models;

namespace TestApp.App.Services.Implementation
{
    public class CSVService : ICSVService 
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CSV> _csvRepository;
        public CSVService(IRepository<CSV> csvRepository, IMapper mapper)
        {
            this._mapper = mapper;
            this._csvRepository = csvRepository;
            
        }

        public async Task<CSVDto> GetById(int? id)
        {
            return _mapper.Map<CSVDto>(await _csvRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task AddRange(string path)
        {
            var config = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ";"
            };
            using StreamReader streamReader = new StreamReader(path);
            using CsvReader csvReader = new CsvReader(streamReader, config);
            var rec = csvReader.GetRecords<ReadCSVViewModel>();

            IEnumerable<CSV> csv = rec.Select(s => new CSV
            {
                Name = s.Name,
                DateofBirth = s.DateofBirth,
                IsMarried = s.IsMarried,
                Salary = s.Salary,
                Phone = s.Phone
            });

            _csvRepository.AddRange(csv);
            await _csvRepository.SaveChangesAsync(); 
        }


        public async Task<CSVDto> Remove(int csvId)
        {
            var location = await _csvRepository.FindByIdAsync(csvId);
            if (location == null)
                return null;
            _csvRepository.Remove(location);
            await _csvRepository.SaveChangesAsync();
            return _mapper.Map<CSVDto>(location);
        }

        public async Task Update(CSVDto CSVDto)
        {
            var newCSV = _mapper.Map<CSV>(CSVDto);
            _csvRepository.Update(newCSV);
            var affectedRows = await _csvRepository.SaveChangesAsync();
            if (affectedRows == 0)
            {
                throw new DbUpdateException();
            }
        }

        public async Task<IEnumerable<CSVDto>> GetAllCSVs()
        {
            return _mapper.Map<IEnumerable<CSVDto>>(await _csvRepository.GetAll().ToListAsync());
        }
    }
}
