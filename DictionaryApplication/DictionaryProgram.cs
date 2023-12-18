// READ ME
// currently "works" 


using System;
using System.Net.Http;


namespace DictionaryNamespace
{
    class DictionaryNamespace
    {
        static async Task Main()
        {
            
            // word from user
            Console.Write("Search: ");
            string UserWord = Console.ReadLine();

            // the url
            string WebsiteUrl = ($"https://api.dictionaryapi.dev/api/v2/entries/en/{UserWord}");

            // http user client
            using (HttpClient UserClient = new HttpClient())
            {
                
                // waits for api response
                HttpResponseMessage ApiReturn = await UserClient.GetAsync(WebsiteUrl);

                // converts api data to a string 
                string PreWebsiteContent = await ApiReturn.Content.ReadAsStringAsync();

                //Console.WriteLine(Stuffs);


                int Counter = 0;

                char[] WebsiteContent = PreWebsiteContent.ToCharArray();


                // replaces annoying characters with a space
                foreach (char i in WebsiteContent)
                {
                    if (i == '[' || i == ']' || i == '{' || i == '}' || i == '"')
                    {
                        WebsiteContent[Counter] = ' ';
                    }
                    
                    Counter++;
                }


                // too tired to figure out how to get index of first dictionary entry
                // will fix later

                /*
                int Counter2 = 0;

                while (Counter2 < WebsiteContent.Length - 1)
                {
                    if (WebsiteContent[Counter2] == 'd' && WebsiteContent[Counter2 + 1] == 'e')
                    {
                        Console.WriteLine(" ");
                    }
                    Counter2++;
                }
                */



                Console.WriteLine(WebsiteContent);

            }
        }
    }
}