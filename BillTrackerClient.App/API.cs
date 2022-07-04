using BillTrackerClient.App.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BillTrackerClient.App
{
    public class API<T>
    {
        private static readonly string _baseUrl = "http://localhost/BillTrackerAPI/api/";

        public enum MethodTypes
        {
            Post,
            Put,
            Delete,
            Get,
            GetAll,
            Login
        }

        public static HttpResponseMessage Post(T model, string modelPath, MethodTypes method)
        {
            modelPath += ConfgureURL(method);

            using var client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            var postTask = client.PostAsJsonAsync(modelPath, model);
            postTask.Wait();

            return postTask.Result;
        }

        public static Object Login(LoginModel model)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            var postTask = client.PostAsJsonAsync("users/login.php", model);
            postTask.Wait();

            var postResult = postTask.Result;
            Task<T> readTask = null;

            if (postResult.IsSuccessStatusCode)
            {
                postResult.Content.ReadAsAsync<T>();
                readTask.Wait();

                return readTask.Result;
            } else
            {
                return postResult.Content.ReadAsStringAsync().Result;
            }
        }

        private static string ConfgureURL(MethodTypes method)
        {
            if (method == MethodTypes.Post)
            {
                return "/create.php";
            } else if (method == MethodTypes.Put)
            {
                return "/update.php";
            } else if (method == MethodTypes.Get)
            {
                return "/get.php";
            } else if (method == MethodTypes.GetAll)
            {
                return "/get_all.php";
            } else if (method == MethodTypes.Delete)
            {
                return "/delete.php";
            } else if (method == MethodTypes.Login)
            {
                return "/login.php";
            }
            else
            {
                throw new ArgumentException("Not a valid option");
            }
        }
    }
}
