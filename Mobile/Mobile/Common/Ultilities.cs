using Mobile.Models.ReportBO;
using Mobile.Models.Validate;
using Mobile.SQLiteModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace Mobile.Common
{
    public static class Ultilities
    {
        public static StringContent ConvertContent<T>(T obj)
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var jsonRequest = JsonConvert.SerializeObject(obj, serializerSettings);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
            return content;
        }
        public static string RemoveHtml(this string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                text = WebUtility.HtmlDecode(text);
                text = Regex.Replace(text, "<[^>]*>", string.Empty);
                return string.Join(" ", Regex.Split(text, @"(?:\r\n|\n|\r)"));
            }
            return "";
        }
        public static string ConvertToVN(this string chucodau)
        {
            const string FindText = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
            const string ReplText = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY";
            int index = -1;
            char[] arrChar = FindText.ToCharArray();
            while ((index = chucodau.IndexOfAny(arrChar)) != -1)
            {
                int index2 = FindText.IndexOf(chucodau[index]);
                chucodau = chucodau.Replace(chucodau[index], ReplText[index2]);
            }
            return chucodau;
        }
        public static string ReplaceData(this string text, List<ReportBO> ListReport)
        {
            try
            {
                #region Tab1
                text = text.Replace("num1a", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num2a", string.IsNullOrEmpty(ListReport[0].ListQuestion[1].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[1].ListAnswer[0].Note);
                text = text.Replace("num3a", string.IsNullOrEmpty(ListReport[0].ListQuestion[2].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[2].ListAnswer[0].Note);
                text = text.Replace("num4a", string.IsNullOrEmpty(ListReport[0].ListQuestion[3].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[3].ListAnswer[0].Note);
                text = text.Replace("num5a", string.IsNullOrEmpty(ListReport[0].ListQuestion[4].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[4].ListAnswer[0].Note);
                text = text.Replace("num6a", string.IsNullOrEmpty(ListReport[0].ListQuestion[5].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[5].ListAnswer[0].Note);
                text = text.Replace("num7a", string.IsNullOrEmpty(ListReport[0].ListQuestion[6].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[6].ListAnswer[0].Note);
                text = text.Replace("num8a", string.IsNullOrEmpty(ListReport[0].ListQuestion[7].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[7].ListAnswer[0].Note);
                text = text.Replace("num9a", string.IsNullOrEmpty(ListReport[0].ListQuestion[8].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[8].ListAnswer[0].Note);
                text = text.Replace("num10", string.IsNullOrEmpty(ListReport[0].ListQuestion[9].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[9].ListAnswer[0].Note);
                text = text.Replace("num11", string.IsNullOrEmpty(ListReport[0].ListQuestion[10].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[10].ListAnswer[0].Note);
                text = text.Replace("num12", string.IsNullOrEmpty(ListReport[0].ListQuestion[11].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[11].ListAnswer[0].Note);
                text = text.Replace("num13a", string.IsNullOrEmpty(ListReport[0].ListQuestion[12].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[12].ListAnswer[0].Note);
                text = text.Replace("num13b", string.IsNullOrEmpty(ListReport[0].ListQuestion[12].ListAnswer[1].Note) ? "0" : ListReport[0].ListQuestion[12].ListAnswer[1].Note);
                text = text.Replace("num13c", string.IsNullOrEmpty(ListReport[0].ListQuestion[12].ListAnswer[2].Note) ? "0" : ListReport[0].ListQuestion[12].ListAnswer[2].Note);
                text = text.Replace("num13d", string.IsNullOrEmpty(ListReport[0].ListQuestion[12].ListAnswer[3].Note) ? "0" : ListReport[0].ListQuestion[12].ListAnswer[3].Note);
                text = text.Replace("num13e", string.IsNullOrEmpty(ListReport[0].ListQuestion[12].ListAnswer[4].Note) ? "0" : ListReport[0].ListQuestion[12].ListAnswer[4].Note);
                text = text.Replace("num13f", string.IsNullOrEmpty(ListReport[0].ListQuestion[12].ListAnswer[5].Note) ? "0" : ListReport[0].ListQuestion[12].ListAnswer[5].Note);
                text = text.Replace("num14a", string.IsNullOrEmpty(ListReport[0].ListQuestion[13].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[13].ListAnswer[0].Note);
                text = text.Replace("num14b", string.IsNullOrEmpty(ListReport[0].ListQuestion[13].ListAnswer[1].Note) ? "0" : ListReport[0].ListQuestion[13].ListAnswer[1].Note);
                text = text.Replace("num15", string.IsNullOrEmpty(ListReport[0].ListQuestion[14].ListAnswer[0].Note) ? "" : ListReport[0].ListQuestion[14].ListAnswer[0].Note);

                text = text.Replace("num16a", string.IsNullOrEmpty(ListReport[0].ListQuestion[15].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[15].ListAnswer[0].Note);
                text = text.Replace("num16b", string.IsNullOrEmpty(ListReport[0].ListQuestion[15].ListAnswer[1].Note) ? "0" : ListReport[0].ListQuestion[15].ListAnswer[1].Note);
                text = text.Replace("num16c", string.IsNullOrEmpty(ListReport[0].ListQuestion[15].ListAnswer[2].Note) ? "0" : ListReport[0].ListQuestion[15].ListAnswer[2].Note);
                text = text.Replace("num16d", string.IsNullOrEmpty(ListReport[0].ListQuestion[15].ListAnswer[3].Note) ? "0" : ListReport[0].ListQuestion[15].ListAnswer[3].Note);
                text = text.Replace("num16e", string.IsNullOrEmpty(ListReport[0].ListQuestion[15].ListAnswer[4].Note) ? "0" : ListReport[0].ListQuestion[15].ListAnswer[4].Note);
                text = text.Replace("num16f", string.IsNullOrEmpty(ListReport[0].ListQuestion[15].ListAnswer[5].Note) ? "0" : ListReport[0].ListQuestion[15].ListAnswer[5].Note);
                text = text.Replace("num16g", string.IsNullOrEmpty(ListReport[0].ListQuestion[15].ListAnswer[6].Note) ? "0" : ListReport[0].ListQuestion[15].ListAnswer[6].Note);

                text = text.Replace("num17af", string.IsNullOrEmpty(ListReport[0].ListQuestion[16].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[16].ListAnswer[0].Note);
                text = text.Replace("num17bf", string.IsNullOrEmpty(ListReport[0].ListQuestion[16].ListAnswer[1].Note) ? "0" : ListReport[0].ListQuestion[16].ListAnswer[1].Note);
                text = text.Replace("num17cf", string.IsNullOrEmpty(ListReport[0].ListQuestion[16].ListAnswer[2].Note) ? "0" : ListReport[0].ListQuestion[16].ListAnswer[2].Note);
                text = text.Replace("num17aa", string.IsNullOrEmpty(ListReport[0].ListQuestion[16].ListAnswer[3].Note) ? "0" : ListReport[0].ListQuestion[16].ListAnswer[3].Note);
                text = text.Replace("num17ba", string.IsNullOrEmpty(ListReport[0].ListQuestion[16].ListAnswer[4].Note) ? "0" : ListReport[0].ListQuestion[16].ListAnswer[4].Note);
                text = text.Replace("num17ca", string.IsNullOrEmpty(ListReport[0].ListQuestion[16].ListAnswer[5].Note) ? "0" : ListReport[0].ListQuestion[16].ListAnswer[5].Note);

                text = text.Replace("num18a", string.IsNullOrEmpty(ListReport[0].ListQuestion[17].ListAnswer[0].Note) ? "" : ListReport[0].ListQuestion[17].ListAnswer[0].Note);
                text = text.Replace("num18b", string.IsNullOrEmpty(ListReport[0].ListQuestion[17].ListAnswer[1].Note) ? "" : ListReport[0].ListQuestion[17].ListAnswer[1].Note);
                text = text.Replace("num19note", string.IsNullOrEmpty(ListReport[0].ListQuestion[18].ListAnswer[1].Note) ? "" : ListReport[0].ListQuestion[18].ListAnswer[1].Note);
                text = text.Replace("num19", string.IsNullOrEmpty(ListReport[0].ListQuestion[18].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[18].ListAnswer[0].Note);
                text = text.Replace("num20a", string.IsNullOrEmpty(ListReport[0].ListQuestion[19].ListAnswer[0].Note) ? "" : ListReport[0].ListQuestion[19].ListAnswer[0].Note);
                text = text.Replace("num20b", string.IsNullOrEmpty(ListReport[0].ListQuestion[19].ListAnswer[1].Note) ? "" : ListReport[0].ListQuestion[19].ListAnswer[1].Note);
                text = text.Replace("num20c", string.IsNullOrEmpty(ListReport[0].ListQuestion[19].ListAnswer[2].Note) ? "" : ListReport[0].ListQuestion[19].ListAnswer[2].Note);
                #endregion
                #region Tab2
                text = text.Replace("num21a", string.IsNullOrEmpty(ListReport[1].ListQuestion[0].ListAnswer[2].Note) ? "" : ListReport[1].ListQuestion[0].ListAnswer[2].Note);
                text = text.Replace("num21b", string.IsNullOrEmpty(ListReport[1].ListQuestion[0].ListAnswer[3].Note) ? "" : ListReport[1].ListQuestion[0].ListAnswer[3].Note);
                text = text.Replace("num21c", string.IsNullOrEmpty(ListReport[1].ListQuestion[0].ListAnswer[4].Note) ? "" : ListReport[1].ListQuestion[0].ListAnswer[4].Note);
                text = text.Replace("num21d", string.IsNullOrEmpty(ListReport[1].ListQuestion[0].ListAnswer[5].Note) ? "" : ListReport[1].ListQuestion[0].ListAnswer[5].Note);
                text = text.Replace("num21", string.IsNullOrEmpty(ListReport[1].ListQuestion[0].ListAnswer[0].Note) ? "" : ListReport[1].ListQuestion[0].ListAnswer[0].Note);

                text = text.Replace("num22a", string.IsNullOrEmpty(ListReport[1].ListQuestion[1].ListAnswer[2].Note) ? "" : ListReport[1].ListQuestion[1].ListAnswer[2].Note);
                text = text.Replace("num22b", string.IsNullOrEmpty(ListReport[1].ListQuestion[1].ListAnswer[3].Note) ? "" : ListReport[1].ListQuestion[1].ListAnswer[3].Note);
                text = text.Replace("num22c", string.IsNullOrEmpty(ListReport[1].ListQuestion[1].ListAnswer[4].Note) ? "" : ListReport[1].ListQuestion[1].ListAnswer[4].Note);
                text = text.Replace("num22", string.IsNullOrEmpty(ListReport[1].ListQuestion[1].ListAnswer[0].Note) ? "0" : ListReport[1].ListQuestion[1].ListAnswer[0].Note);

                text = text.Replace("num23detail", string.IsNullOrEmpty(ListReport[1].ListQuestion[2].ListAnswer[1].Note) ? "" : ListReport[1].ListQuestion[2].ListAnswer[1].Note);
                text = text.Replace("num23", string.IsNullOrEmpty(ListReport[1].ListQuestion[2].ListAnswer[0].Note) ? "0" : ListReport[1].ListQuestion[2].ListAnswer[0].Note);
                text = text.Replace("num24a", string.IsNullOrEmpty(ListReport[1].ListQuestion[3].ListAnswer[0].Note) ? "" : ListReport[1].ListQuestion[3].ListAnswer[0].Note);
                text = text.Replace("num24b", string.IsNullOrEmpty(ListReport[1].ListQuestion[3].ListAnswer[1].Note) ? "" : ListReport[1].ListQuestion[3].ListAnswer[1].Note);
                text = text.Replace("num24c", string.IsNullOrEmpty(ListReport[1].ListQuestion[3].ListAnswer[2].Note) ? "" : ListReport[1].ListQuestion[3].ListAnswer[2].Note);
                #endregion
                #region Tab3
                text = text.Replace("num25a", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num25b", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num26", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num27a", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num27b", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num27c", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num27d", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num27e", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num28a", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num28bnote", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num28b", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num28c", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num29a", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num29b", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num30anote", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num30a", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num30bnote", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num30b", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num31", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num32a", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num32b", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num33a", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num33bnote1", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num33bnote2", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num33b", string.IsNullOrEmpty(ListReport[0].ListQuestion[0].ListAnswer[0].Note) ? "0" : ListReport[0].ListQuestion[0].ListAnswer[0].Note);
                text = text.Replace("num34a", ListReport[0].ListQuestion[0].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num34b", ListReport[0].ListQuestion[0].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num34c", ListReport[0].ListQuestion[0].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num34d", ListReport[0].ListQuestion[0].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num34e", ListReport[0].ListQuestion[0].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num34f", ListReport[0].ListQuestion[0].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num35a", ListReport[0].ListQuestion[0].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num35b", ListReport[0].ListQuestion[0].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num35c", ListReport[0].ListQuestion[0].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num35", ListReport[0].ListQuestion[0].ListAnswer[0].Note.ConvertToString(false));
                text = text.Replace("num36", ListReport[0].ListQuestion[0].ListAnswer[0].Note.ConvertToString(false));
                text = text.Replace("num37a", ListReport[0].ListQuestion[0].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num37b", ListReport[0].ListQuestion[0].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num37note1", ListReport[0].ListQuestion[0].ListAnswer[0].Note.ConvertToString(false));
                text = text.Replace("num37note2", ListReport[0].ListQuestion[0].ListAnswer[0].Note.ConvertToString(false));
                text = text.Replace("num38a", ListReport[0].ListQuestion[0].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num38b", ListReport[0].ListQuestion[0].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num38c", ListReport[0].ListQuestion[0].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num38d", ListReport[0].ListQuestion[0].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num39a", ListReport[0].ListQuestion[0].ListAnswer[0].Note.ConvertToString(false));
                text = text.Replace("num39b", ListReport[0].ListQuestion[0].ListAnswer[0].Note.ConvertToString(false));
                text = text.Replace("num39c", ListReport[0].ListQuestion[0].ListAnswer[0].Note.ConvertToString(false));
                #endregion
                #region Tab4
                text = text.Replace("num40a", ListReport[3].ListQuestion[0].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num40bNote", ListReport[3].ListQuestion[0].ListAnswer[2].Note.ConvertToString(false));
                text = text.Replace("num40b", ListReport[3].ListQuestion[0].ListAnswer[1].Note.ConvertToString(true));

                text = text.Replace("num41bNote", ListReport[3].ListQuestion[1].ListAnswer[2].Note.ConvertToString(false));
                text = text.Replace("num41a", ListReport[3].ListQuestion[1].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num41b", ListReport[3].ListQuestion[1].ListAnswer[1].Note.ConvertToString(true));
                
                text = text.Replace("num42", ListReport[3].ListQuestion[2].ListAnswer[0].Note.ConvertToString(false));

                text = text.Replace("num43a", ListReport[3].ListQuestion[3].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num43b", ListReport[3].ListQuestion[3].ListAnswer[1].Note.ConvertToString(true));
                text = text.Replace("num43Note1", ListReport[3].ListQuestion[3].ListAnswer[2].Note.ConvertToString(false));
                text = text.Replace("num43Note2", ListReport[3].ListQuestion[3].ListAnswer[3].Note.ConvertToString(false));

                text = text.Replace("num44a", ListReport[3].ListQuestion[4].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num44bNote", ListReport[3].ListQuestion[4].ListAnswer[2].Note.ConvertToString(false));
                text = text.Replace("num44b", ListReport[3].ListQuestion[4].ListAnswer[1].Note.ConvertToString(true));

                text = text.Replace("number45aa", ListReport[3].ListQuestion[5].ListAnswer[2].Note.ConvertToString(true));
                text = text.Replace("number45ab", ListReport[3].ListQuestion[5].ListAnswer[3].Note.ConvertToString(true));
                text = text.Replace("number45ac", ListReport[3].ListQuestion[5].ListAnswer[4].Note.ConvertToString(true));
                text = text.Replace("num45a", ListReport[3].ListQuestion[5].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num45b", ListReport[3].ListQuestion[5].ListAnswer[1].Note.ConvertToString(true));

                text = text.Replace("num46", ListReport[3].ListQuestion[6].ListAnswer[0].Note.ConvertToString(false));

                text = text.Replace("number47bNote", ListReport[3].ListQuestion[7].ListAnswer[2].Note.ConvertToString(false));
                text = text.Replace("num47a", ListReport[3].ListQuestion[7].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num47b", ListReport[3].ListQuestion[7].ListAnswer[1].Note.ConvertToString(true));

                text = text.Replace("num48a", ListReport[3].ListQuestion[8].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num48b", ListReport[3].ListQuestion[8].ListAnswer[1].Note.ConvertToString(true));
                text = text.Replace("num48c", ListReport[3].ListQuestion[8].ListAnswer[2].Note.ConvertToString(true));
                text = text.Replace("num48d", ListReport[3].ListQuestion[8].ListAnswer[3].Note.ConvertToString(true));

                text = text.Replace("num49a", ListReport[3].ListQuestion[9].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num49b", ListReport[3].ListQuestion[9].ListAnswer[1].Note.ConvertToString(true));

                text = text.Replace("number50bNote", ListReport[3].ListQuestion[10].ListAnswer[2].Note.ConvertToString(false));
                text = text.Replace("num50a", ListReport[3].ListQuestion[10].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num50b", ListReport[3].ListQuestion[10].ListAnswer[1].Note.ConvertToString(true));

                text = text.Replace("num51a", ListReport[3].ListQuestion[10].ListAnswer[0].Note.ConvertToString(false));
                text = text.Replace("num51b", ListReport[3].ListQuestion[10].ListAnswer[1].Note.ConvertToString(false));
                text = text.Replace("num51c", ListReport[3].ListQuestion[10].ListAnswer[2].Note.ConvertToString(false));
                #endregion
                #region Tab5
                text = text.Replace("num52", ListReport[4].ListQuestion[0].ListAnswer[0].Note.ConvertToString(false));
                text = text.Replace("num53", ListReport[4].ListQuestion[1].ListAnswer[0].Note.ConvertToString(false));

                text = text.Replace("num54a", !string.IsNullOrEmpty(ListReport[4].ListQuestion[2].ListAnswer[0].Note) ? "1" : "0");
                text = text.Replace("number54aNote", ListReport[4].ListQuestion[2].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num54b", !string.IsNullOrEmpty(ListReport[4].ListQuestion[2].ListAnswer[1].Note) ? "1" : "0");
                text = text.Replace("number54bNote", ListReport[4].ListQuestion[2].ListAnswer[1].Note.ConvertToString(false));
                text = text.Replace("num54c", !string.IsNullOrEmpty(ListReport[4].ListQuestion[2].ListAnswer[2].Note) ? "1" : "0");
                text = text.Replace("number54cNote", ListReport[4].ListQuestion[2].ListAnswer[2].Note.ConvertToString(false));
                text = text.Replace("num54d", !string.IsNullOrEmpty(ListReport[4].ListQuestion[2].ListAnswer[3].Note) ? "1" : "0");
                text = text.Replace("number54dNote", ListReport[4].ListQuestion[2].ListAnswer[3].Note.ConvertToString(false));

                text = text.Replace("num55a", ListReport[4].ListQuestion[3].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num55b", ListReport[4].ListQuestion[3].ListAnswer[1].Note.ConvertToString(true));
                text = text.Replace("num55c", ListReport[4].ListQuestion[3].ListAnswer[2].Note.ConvertToString(true));
                text = text.Replace("number55dNote", ListReport[4].ListQuestion[3].ListAnswer[3].Note.ConvertToString(false));
                text = text.Replace("num55d", !string.IsNullOrEmpty(ListReport[4].ListQuestion[3].ListAnswer[3].Note) ? "1" : "0");

                text = text.Replace("num56ab", ListReport[4].ListQuestion[4].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num56bb", ListReport[4].ListQuestion[4].ListAnswer[1].Note.ConvertToString(true));
                text = text.Replace("num56aa", ListReport[4].ListQuestion[4].ListAnswer[0].Note.Equals("1") ? "0" : "1");
                text = text.Replace("num56ba", ListReport[4].ListQuestion[4].ListAnswer[1].Note.Equals("1") ? "0" : "1");

                text = text.Replace("num57a", ListReport[4].ListQuestion[5].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num57b", !string.IsNullOrEmpty(ListReport[4].ListQuestion[5].ListAnswer[1].Note) ? "1" : "0");
                text = text.Replace("number57bNote", ListReport[4].ListQuestion[5].ListAnswer[1].Note.ConvertToString(false));

                text = text.Replace("num58a", ListReport[4].ListQuestion[6].ListAnswer[0].Note.ConvertToString(true));

                text = text.Replace("num59b", ListReport[4].ListQuestion[6].ListAnswer[0].Note.Equals("1") ? "0" : "1");
                text = text.Replace("number59bNote1", ListReport[4].ListQuestion[6].ListAnswer[1].Note.ConvertToString(false));
                text = text.Replace("number59bNote2", ListReport[4].ListQuestion[6].ListAnswer[2].Note.ConvertToString(false));

                text = text.Replace("num60a", ListReport[4].ListQuestion[7].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num60b", ListReport[4].ListQuestion[7].ListAnswer[1].Note.ConvertToString(true));

                text = text.Replace("num61a", ListReport[4].ListQuestion[9].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num61b", ListReport[4].ListQuestion[9].ListAnswer[1].Note.ConvertToString(true));

                text = text.Replace("num62", ListReport[4].ListQuestion[8].ListAnswer[0].Note.ConvertToString(false));

                text = text.Replace("num63a", ListReport[4].ListQuestion[10].ListAnswer[0].Note.ConvertToString(true));
                text = text.Replace("num63b", ListReport[4].ListQuestion[10].ListAnswer[0].Note.Equals("1") ? "0" : "1");
                text = text.Replace("number63bNote1", ListReport[4].ListQuestion[10].ListAnswer[1].Note.ConvertToString(false));
                text = text.Replace("number63bNote2", ListReport[4].ListQuestion[10].ListAnswer[2].Note.ConvertToString(false));

                text = text.Replace("num64a", ListReport[4].ListQuestion[11].ListAnswer[0].Note.ConvertToString(false));
                text = text.Replace("num64b", ListReport[4].ListQuestion[11].ListAnswer[1].Note.ConvertToString(false));
                text = text.Replace("num64c", ListReport[4].ListQuestion[11].ListAnswer[2].Note.ConvertToString(false));
                #endregion
            }
            catch (Exception ex)
            {

            }
            return text;
        }
        public static float ConvertToFloat(this string text)
        {
            try
            {
                return float.Parse(text);
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
        public static string ConvertToString(this string text, bool isSelect)
        {
            if (string.IsNullOrEmpty(text) && isSelect)
            {
                return "0";
            }
            else if (string.IsNullOrEmpty(text))
            {
                return "";
            }
            return text;
        }
        public static List<Models.User> ConvertToListUser(this List<UserLite> userLites)
        {
            List<Models.User> users = new List<Models.User>();
            foreach (var item in userLites)
            {
                Models.User user = new Models.User();
                user.Alerts = new List<Models.Alert>();
                user.BloodType = item.BloodType;
                user.CellPhone = item.CellPhone;
                user.CreatedTime = item.CreatedTime;
                user.DayOfBirth = item.DayOfBirth;
                user.DesktopPhone = item.DesktopPhone;
                user.Events = new List<Models.Event>();
                user.Families = new List<Models.Family>();
                user.Gender = item.Gender;
                user.GPSCreateTime = item.GPSCreateTime;
                user.Latitude = item.Latitude;
                user.Location = new Models.Location();
                user.Location.Name = item.LocationName;
                user.Location.LocationId = item.LocationId;
                user.Logs = new List<Models.Log>();
                user.Longitude = item.Longitude;
                user.Name = item.Name;
                user.News = new List<Models.News>();
                user.ObjectId = item.ObjectId;
                user.Password = item.Password;
                user.Position = item.Position;
                user.Reports = new List<Models.Report>();
                user.ReportSynthesized = new List<Models.ReportSynthesized>();
                user.Role = item.Role;
                user.SecretCode = item.SecretCode;
                user.Status = item.Status;
                user.UserId = item.UserId;
                users.Add(user);
            }
            return users;
        }
        public static Models.Validate.Register ConvertToUser(this Models.User users)
        {
            Register register = new Register();
            register.BloodType.Name = users.BloodType;
            register.CellPhone.Name = users.CellPhone;
            register.DayOfBirth.Name = users.DayOfBirth.HasValue ? users.DayOfBirth.Value.ToString("dd/MM/yyyy") : "";
            register.DesktopPhone.Name = users.DesktopPhone;
            register.Gender.Name = users.Gender;
            register.LocationId.Name = users.Location != null ? users.Location.LocationId.ToString() : "0";
            register.Name.Name = users.Name;
            register.ObjectId.Name = users.ObjectId;
            register.Password.Name = users.Password;
            register.Position.Name = users.Position;
            register.Role.Name = users.Role;
            register.SecretCode.Name = users.SecretCode;
            register.Status.Name = users.Status.ToString();
            register.UserId.Name = users.UserId;
            return register;
        }
        public static List<UserLite> ConvertToListUserLite(this List<Models.User> users)
        {
            List<UserLite> UserLites = new List<UserLite>();
            foreach (var item in users)
            {
                UserLite userLite = new UserLite();
                userLite.BloodType = item.BloodType;
                userLite.CellPhone = item.CellPhone;
                userLite.CreatedTime = item.CreatedTime;
                userLite.DayOfBirth = item.DayOfBirth;
                userLite.DesktopPhone = item.DesktopPhone;
                userLite.Gender = item.Gender;
                userLite.GPSCreateTime = item.GPSCreateTime;
                userLite.Latitude = item.Latitude;
                userLite.LocationId = item.Location != null ? item.Location.LocationId : 0;
                userLite.LocationName = item.Location != null ? item.Location.Name : "";
                userLite.Longitude = item.Longitude;
                userLite.Name = item.Name;
                userLite.ObjectId = item.ObjectId;
                userLite.Password = item.Password;
                userLite.Position = item.Position;
                userLite.Role = item.Role;
                userLite.SecretCode = item.SecretCode;
                userLite.Status = item.Status;
                userLite.UserId = item.UserId;
                UserLites.Add(userLite);
            }
            return UserLites;
        }
        public static List<EventLite> ConvertToListEventLite(this List<Models.Event> Events)
        {
            List<EventLite> EventLites = new List<EventLite>();
            foreach (var item in Events)
            {
                EventLite eventLite = new EventLite();
                eventLite.CreatedTime = item.CreatedTime;
                eventLite.Desc = item.Desc;
                eventLite.EventId = item.EventId;
                eventLite.Name = item.Name;
                EventLites.Add(eventLite);
            }
            return EventLites;
        }
        public static List<Models.Event> ConvertToListEvent(this List<EventLite> EventLite)
        {
            List<Models.Event> Events = new List<Models.Event>();
            foreach (var item in EventLite)
            {
                Models.Event events = new Models.Event();
                events.CreatedTime = item.CreatedTime;
                events.Desc = item.Desc;
                events.EventId = item.EventId;
                events.Name = item.Name;
                Events.Add(events);
            }
            return Events;
        }
    }
}
