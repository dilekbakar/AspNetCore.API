using AspNetCore.API.Models;
using Bogus;
using System.Collections.Generic;

namespace AspNetCore.API.Fake
{
    public class FakeData
    {
        private static List<Data> _datas;
        public static List<Data> GetDatas(int number)
        {
            if (_datas==null)
            {
                _datas = new Faker<Data>()
               .RuleFor(d => d.ID, f => f.IndexFaker + 1)
               .RuleFor(d => d.Title, f => f.Name.FirstName())
               .RuleFor(d => d.VideoUrl, f => f.Lorem.Sentence())
               .Generate(number);
            }
           
            return _datas;
        }
    }
}
