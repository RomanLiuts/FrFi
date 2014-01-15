using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using HtmlAgilityPack;

namespace FrFi.DomainModel
{
    public class Vk
    {
        private static string Get(string url)
        {

            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            WebRequest reqGet = WebRequest.Create(url);
            WebResponse resp = reqGet.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd();

        }

        private static string Post(string url, string data)
        {
            var cookies = new CookieContainer();
            ServicePointManager.Expect100Continue = false;

            var request = (HttpWebRequest) WebRequest.Create(url);
            request.CookieContainer = cookies;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            using ( var requestStream = request.GetRequestStream() )
            using ( var writer = new StreamWriter(requestStream) )
            {
                writer.Write(data);
            }

            using ( var responseStream = request.GetResponse().GetResponseStream() )
            using ( var reader = new StreamReader(responseStream) )
            {
                var result = reader.ReadToEnd();
                return result;
            }


        }


        public static string GetData(string email, string pass)
        {
            return string.Format("email=" + email + "&pass=" + pass);
        }

        public static HtmlDocument LogIn(string email, string password)
        {
            string LogInHtml = Get("http://m.vk.com");
            HtmlDocument LogInDocument = new HtmlDocument();
            LogInDocument.LoadHtml(LogInHtml);

            HtmlNode bodyNode = LogInDocument.DocumentNode.SelectSingleNode("//div[@class='form_item fi_fat']/form");
            string action = bodyNode.Attributes["action"].Value;
            string html = Post(action, GetData(email, password));

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            return document;

        }
    }
}