using Mobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Mobile.Common
{
    public class LoadResourceJson
    {
        public static string GetJsonFile()
        {
            try
            {
                var assembly = typeof(App).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("Mobile.report.json");
                string text = "";
                using (var reader = new System.IO.StreamReader(stream))
                {
                    text = reader.ReadToEnd();
                }
                return text;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public static List<Part> GetBeforeDisater()
        {
            try
            {
                var assembly = typeof(App).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("Mobile.BeforeDisater.json");
                string text = "";
                using (var reader = new System.IO.StreamReader(stream))
                {
                    text = reader.ReadToEnd();
                }
                return JsonConvert.DeserializeObject<List<Part>>(text);
            }
            catch (Exception ex)
            {
                return new List<Part>();
            }
        }
    }
}
