using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HttpLearn
{
    class MainClass
    {
        private static string endPoint = "https://jsonplaceholder.typicode.com/posts";

        public static void Main(string[] args)
        {

            var _posts = JsonConvert.DeserializeObject<List<Post>>(MakeRequest());

            if (_posts == null) return;
            for (int i = 0; i < 3; i++)
            {
                Random r = new Random();
                int rInt = r.Next(0, _posts.Count);
                Console.WriteLine(_posts[rInt].Id);
                Console.WriteLine(_posts[rInt].Title);
                Console.WriteLine(_posts[rInt].Body);
                Console.WriteLine();
            }
        }
        public static string MakeRequest()
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                return stream.ReadToEnd();
            }
        }
    }
    
}
