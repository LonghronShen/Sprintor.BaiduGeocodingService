using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;

namespace System.Net.Http
{

    internal static class HttpUtils
    {

        public static T HttpGet<T>(string url)
        {
#if NETSTANDARD1_0 || NETSTANDARD1_1 || NETSTANDARD1_6 || PORTABLE
            return HttpGetAsync<T>(url).GetAwaiter().GetResult();
#else
            var rnd = new Random((int)DateTime.Now.Ticks);
            while (true)
            {
                try
                {
                    var request = (HttpWebRequest)WebRequest.Create(url);
                    using (var response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            throw new WebException($"Failed to send request to url: `{url}`");
                        }
                        using (var stream = response.GetResponseStream())
                        {
                            using (TextReader reader = new StreamReader(stream))
                            {
                                var body = reader.ReadToEnd();
                                var item = JsonConvert.DeserializeObject<T>(body);
                                return item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                }
                var sleepTime = rnd.Next(10, 100000);
                Thread.Sleep(sleepTime);
            }
#endif
        }

        public static async Task<T> HttpGetAsync<T>(string url)
        {
#if NET35 || NET20
            return await Task.Run(() => HttpGet<T>(url));
#elif NETSTANDARD1_0
            var rnd = new Random((int)DateTime.Now.Ticks);
            while (true)
            {
                try
                {
                    var request = (HttpWebRequest)WebRequest.Create(url);
                    using (var response =
                        (HttpWebResponse)await Task.Factory.FromAsync(
                            request.BeginGetResponse, request.EndGetResponse, request))
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            throw new WebException($"Failed to send request to url: `{url}`");
                        }
                        using (var stream = response.GetResponseStream())
                        {
                            using (TextReader reader = new StreamReader(stream))
                            {
                                var body = await reader.ReadToEndAsync();
                                var item = JsonConvert.DeserializeObject<T>(body);
                                return item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                }
                var sleepTime = rnd.Next(10, 100000);
                await Task.Delay(sleepTime);
            }
#else
            var rnd = new Random((int)DateTime.Now.Ticks);
            while (true)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        var response = await client.GetAsync(url);
                        response.EnsureSuccessStatusCode();
                        var body = await response.Content.ReadAsStringAsync();
                        var item = JsonConvert.DeserializeObject<T>(body);
                        return item;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                }
                var sleepTime = rnd.Next(10, 100000);
#if NET40 || PROFILE_328
                await TaskEx.Delay(sleepTime);
#else
                await Task.Delay(sleepTime);
#endif
            }
#endif
        }

    }

}