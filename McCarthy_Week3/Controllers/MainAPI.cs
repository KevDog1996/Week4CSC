using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace McCarthy_Week3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //Week5 Adding to github.
    public class MainAPI : ControllerBase
    {

        [HttpPost(Name = "GetWeatherForecast")]
        public ActionResult<List<string>> IntList(List<int> lint)
        {

            List<string> slist = new List<string>();
            List<int> clist = new List<int>();
            double sum = 0;
            double counter = 0;
            double mean = 0;
            double difference = 0;
            double sd = 0;

            lint.Sort();

            foreach (int i in lint)
            {
                
                    clist.Add(i);
                    counter++;
                    sum += i;
                    mean = clist.Average();
                    difference = clist.Sum(i => Math.Pow(i - mean, 2));
                    sd = Math.Sqrt((difference) / (clist.Count() - 1));

                    if (sd > 0)
                    {
                        slist.Add("Elements: "+counter+" Current Standard deviation: " + sd);
                    }
                    else
                    {
                        slist.Add("list too small!");
                    }

                

                LogObject(i);
            }
            static void LogObject(int lint)
            {
                System.Diagnostics.Debug.WriteLine(lint);
            }

            return slist;
        }
    }
}