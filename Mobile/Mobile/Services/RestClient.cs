using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Mobile.Common;
using Mobile.Models;
using Plugin.Connectivity;

namespace Mobile.Services
{
    public class RestClient
    {
        public async Task<T> Get<T>(string model) where T : class
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                if (App.token == null)
                {
                    TokenAuth tokenAuth = new TokenAuth();
                    tokenAuth.userId = App.user != null ? App.user.UserId : "";
                    tokenAuth.secretCode = App.user != null ? App.user.SecretCode : "";
                    App.token = await PostAndReturnToken<Token>("tokens", tokenAuth);
                }
                try
                {
                    HttpClient client = new HttpClient();
					if (App.token != null)
                    {
                        if (!string.IsNullOrEmpty(App.token.token))
                        {
                            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + App.token.token);
                        }
                    }
                    client.BaseAddress = new Uri(CommonConstant.apiUrl);
                    var response = await client.GetAsync(model);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(jsonString);
                    }
                }
                catch (Exception ex)
                {
					Console.WriteLine(ex.Source);
                }
            }
            return default(T);
        }
        public async Task<string> PostAsync(string model, object obj)
        {
            try
            {
                if (App.token == null)
                {
                    TokenAuth tokenAuth = new TokenAuth();
                    tokenAuth.userId = App.user != null ? App.user.UserId : "";
                    tokenAuth.secretCode = App.user != null ? App.user.SecretCode : "";
                    App.token = await PostAndReturnToken<Token>("tokens", tokenAuth);
                }
                var serializerSettings = new JsonSerializerSettings();
                serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                var jsonRequest = JsonConvert.SerializeObject(obj, serializerSettings);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
                HttpClient client = new HttpClient();
                if (App.token != null)
                {
                    if (!string.IsNullOrEmpty(App.token.token))
                    {
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + App.token.token);
                    }
                }
                client.BaseAddress = new Uri(CommonConstant.apiUrl);
                var response = await client.PostAsync(model, content);
                if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK
                    || response.StatusCode == HttpStatusCode.Accepted
                    || response.StatusCode == HttpStatusCode.NoContent
                    || response.StatusCode == HttpStatusCode.Moved)
                {
                    return ApiStatusConstant.SUCCESS;
                }
                return response.Content.ReadAsStringAsync().Result;
            }
            catch
            {

            }
            return default(string);
        }
        public async Task<string> PutAsync(string model, object obj, object id)
        {
            try
            {
                if (App.token == null)
                {
                    TokenAuth tokenAuth = new TokenAuth();
                    tokenAuth.userId = App.user != null ? App.user.UserId : "";
                    tokenAuth.secretCode = App.user != null ? App.user.SecretCode : "";
                    App.token = await PostAndReturnToken<Token>("tokens", tokenAuth);
                }
                var serializerSettings = new JsonSerializerSettings();
                serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                var jsonRequest = JsonConvert.SerializeObject(obj, serializerSettings);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
                HttpClient client = new HttpClient();
                if (App.token != null)
                {
                    if (!string.IsNullOrEmpty(App.token.token))
                    {
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + App.token.token);
                    }
                }
                client.BaseAddress = new Uri(CommonConstant.apiUrl);
                var response = await client.PutAsync(model + "/" + id.ToString(), content);
                if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK)
                {
                    return ApiStatusConstant.SUCCESS;
                }
            }
            catch
            {

            }
            return default(string);
        }
        public async Task<string> DeleteAsync(string model, object id)
        {
            try
            {
                if (App.token == null)
                {
                    TokenAuth tokenAuth = new TokenAuth();
                    tokenAuth.userId = App.user != null ? App.user.UserId : "";
                    //tokenAuth.userId = "abc@gmail.com";
                    tokenAuth.secretCode = App.user != null ? App.user.SecretCode : "";
                    App.token = await PostAndReturnToken<Token>("tokens", tokenAuth);
                }
                HttpClient client = new HttpClient();
                if (App.token != null)
                {
                    if (!string.IsNullOrEmpty(App.token.token))
                    {
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + App.token.token);
                    }
                }
                client.BaseAddress = new Uri(CommonConstant.apiUrl);
                var response = await client.DeleteAsync(model + "/" + id.ToString());
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return ApiStatusConstant.SUCCESS;
                }
            }
            catch
            {

            }
            return default(string);
        }
        public static async Task<T> PostAndReturnToken<T>(string model, TokenAuth obj)
        {
            using (var client = new HttpClient())
            {
                var serializerSettings = new JsonSerializerSettings();
                serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                var jsonRequest = JsonConvert.SerializeObject(obj, serializerSettings);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
                client.BaseAddress = new Uri(CommonConstant.apiUrl);
                var postTask = client.PostAsync(model, content);
                postTask.Wait();
                var result = postTask.Result;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await result.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(jsonString);
                }
            }
            return default(T);
        }
        public async Task<string> GetAndReturnObject(string model, string id, Token token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    if (token != null)
                    {
                        if (!string.IsNullOrEmpty(token.token))
                        {
                            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.token);
                        }
                    }
                    client.BaseAddress = new Uri(CommonConstant.apiUrl);
                    var responseTask = client.GetAsync(model + "/" + id);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var jsonString = await result.Content.ReadAsStringAsync();
                        return jsonString;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async void AddEvent(string action)
        {
            Log logs = new Log();
            logs.Action = action;
            logs.CreatedTime = DateTime.Now;
            logs.User = App.user;
            await PostAsync("logs", logs);
        }
    }
}
