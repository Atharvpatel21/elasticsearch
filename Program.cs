using System;
using Elasticsearch.Net;

namespace elkcar
{
    //class Program
    //{
    //    //static void Main(string[] args)
    //    //{
    //    //    Console.WriteLine("Hello World!");
    //    //}
        class Program
        {
            static async System.Threading.Tasks.Task Main(string[] args)
            {                 
                var settings = new ConnectionConfiguration(new Uri("http://localhost:9200/"))
                .RequestTimeout(TimeSpan.FromMinutes(2));

                var client = new ElasticLowLevelClient(settings);
                var cars = new Cars("Ford", 1000000);
            //var cars = new Cars("Ford", 200000);
            var response = await client.IndexAsync<StringResponse>("cars", "1", PostData.Serializable(cars));
                 string responseString = response.Body;
                 Console.WriteLine(responseString);
            }
        }
    
}
    
