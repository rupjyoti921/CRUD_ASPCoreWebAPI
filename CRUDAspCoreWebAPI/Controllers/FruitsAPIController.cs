using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDAspCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsAPIController : ControllerBase
    {
        List<string> fruits = new List<string>()
        {
            "Apple",
            "Banana",
            "Mango",
            "Orange",
            "Pineapple",
            "Grapes"
        };

        Dictionary<string, string> fruitsPrice = new Dictionary<string, string>()
        {
            {"Apple","100" },
            {"Banana","50"},
            {"Mango","80"},
            {"Orange","60"},
            {"Pineapple","120"},
            {"Grapes","90"}
        };

        //[HttpGet]
        //public List<string> GetFruits()
        //{
        //    return fruits;
        //}

        //[HttpGet("prices")]
        //public Dictionary<string,string> GetFruitsPrice()
        //{
        //    return fruitsPrice;
        //}

        //[HttpGet("{id}")]
        //public string GetFruitById(int id)
        //{
        //    try { 
        //        return fruits[id]; 
        //    }
        //    catch(Exception){
        //        return "Fruit not found";
        //    }
        //}
    }
}
