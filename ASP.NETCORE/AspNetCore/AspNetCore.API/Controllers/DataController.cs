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

        public Data Post([FromBody]Data data)
        {
            _datas.Add(data);
            return data;
        }
        [HttpPut]
        public Data Put([FromBody] Data data)
        {
            var _editedData= _datas.FirstOrDefault(x=>x.ID==data.ID);
            _editedData.Title=data.Title;   
            _editedData.VideoUrl=data.VideoUrl;
          
            return data;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deletedUser=_datas.FirstOrDefault(x=>x.ID==id);
            _datas.Remove(deletedUser);
        }
    }


}
