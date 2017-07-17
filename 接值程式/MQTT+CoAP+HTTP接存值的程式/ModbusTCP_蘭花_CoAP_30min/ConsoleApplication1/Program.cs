using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoAP.Util;

namespace ConsoleApplication1
{
    class Program
    {
        public static double Sum_Post_RTT = 0;
        public static double Sum_Get_RTT = 0;

        static void Main(string[] args)
        {
            String uri_post = "coap://140.127.22.61/om2m/nscl/applications/G_Internet/containers/THZ100_1/contentInstances?authorization=admin:admin";

            String uri_get = "coap://140.127.22.61/om2m/nscl/applications/G_Internet/containers/THZ100_1/contentInstances/latest/content?authorization=admin:admin";

            
            //Post_Function(uri_post);
            for (int i = 0; i < 10; i++)
            {
                Get_Function(uri_get);
            }
            Console.WriteLine("Get Response Time (ms): " + Sum_Get_RTT);
            Console.ReadLine();
        }

        private static void Post_Function(String Uri_Post)
        {
            CoAP.Request request = CoAP.Request.NewPost();
            request.URI = new Uri(Uri_Post);
            request.SetPayload("<obj> <str name='appId' val='G_Internet'/> <str name='obu_id' val='786506'/> <str name='car_no' val='THZ100_1'/> <int name='gps_time' val='2015/5/25 15:04:00'/> <int name='speed' val='50'/> <str name='lon' val='120.619316666667'/> </obj>", CoAP.MediaType.TextPlain);

            request.Send();

            CoAP.Response response = request.WaitForResponse();
            if (response == null)
            {
                Console.WriteLine("Request timeout!");
            }
            else
            {
                Sum_Post_RTT += response.RTT;
                Console.WriteLine("Create Time (ms): " + response.RTT);
            }
        }

        private static void Get_Function(String Uri_Get)
        {
            /*
             * last 找最後一筆的content
            coap://140.127.22.61/om2m/nscl/applications/G_Internet/containers/THZ100_1/contentInstances/latest/content?authorization=admin:admin
             *
             */
             
            CoAP.Request request = CoAP.Request.NewGet();
            request.URI = new Uri(Uri_Get);
            request.Send();

            CoAP.Response response = request.WaitForResponse();
            if (response == null)
            {
                Console.WriteLine("Request timeout!");
            }
            else
            {
                Console.WriteLine(response.PayloadString);
                Sum_Get_RTT += response.RTT;
                Console.WriteLine("Response Time (ms): " + response.RTT);
                Console.WriteLine("Response PayloadSize: " + response.PayloadSize);
            } 
        }
    }
}
