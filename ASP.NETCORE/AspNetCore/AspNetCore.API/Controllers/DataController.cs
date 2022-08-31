using AspNetCore.API.Fake;
using AspNetCore.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCore.API.Controllers
{
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private List<Data> _datas = FakeData.GetDatas(100);


        [HttpGet]
        public List<Data> Get()
        {
            return _datas;
        }


        [HttpGet("{id}")]
        public Data Get(int id)
        {
            var data= _datas.FirstOrDefault(x=>x.ID==id);
            return data;
        }

        public Data Post([FromBody]Data datas)
        {
            _datas.Add(datas);
            return datas;
        }

    }


}
