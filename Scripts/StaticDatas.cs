using System.Net.Http;
using CsharpPool.Assets.Scripts;
namespace CsharpPool.Assets.Scripts {
    public class StaticDatas {
        static public string Uri {get; set;} = "https://localhost:7040/";
        static public HttpClient Client {get; set;}
        static public Operator MainOperator {get; set; }
    }
}