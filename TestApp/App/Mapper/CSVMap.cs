using CsvHelper.Configuration;
using TestApp.App.DTO;
using Constans = TestApp.App.Const.CSVConstants;

namespace TestApp.App.Mapper
{
    public sealed class CSVMap : ClassMap<CSVDto>
    {
        public CSVMap()
        {
            Map(p => p.Name).Name(Constans.Name);
            Map(p => p.IsMarried).Name(Constans.Mareied);
            Map(p => p.DateofBirth).Name(Constans.DoB);
            Map(p => p.Phone).Name(Constans.Phone);
            Map(p => p.Salary).Name(Constans.Salary);
        }
        
    }
}
