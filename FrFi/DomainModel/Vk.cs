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
            using (var requestStream = request.GetRequestStream())
            using ( var writer = new StreamWriter(requestStream) )
            {
                writer.Write(data);
            }

            using (var responseStream = request.GetResponse().GetResponseStream())
            using ( var reader = new StreamReader(responseStream) )
            {
                var result = reader.ReadToEnd();
                return result;
            }


        }




        //TODO: винести в конфиг файл логин и пароль
        static string urlAction = "https://login.vk.com/?act=login&_origin=http://m.vk.com&ip_h=97daccc769df7e746b&role=pda&utf8=1";
        static string email = "sweetboxer@mail.ru";
        static string password = "qwerty";

        public static string GetData(string email, string pass)
        {
            return string.Format("email=" + email + "&pass=" + pass);
        }


        
        //TODO: 
        //TODO: 


        public static HtmlDocument LogIn()
        {

            //TODO: получить url екшена с html кода
            //string html = Get("http://m.vk.com");

            

            //HtmlDocument document = new HtmlDocument();
            //document.Load(html);
            //HtmlNode bodyNode = document.DocumentNode.SelectSingleNode("//div[@class='form_item fi_fat']/form");
            //string action = bodyNode.Attributes["action"].Value;
            string html = Post(urlAction, GetData(email, password));
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            return document;
        }
    }
}