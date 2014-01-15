using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;

namespace FrFi.DomainModel
{
    public class VkParser: IDisposable
    {
        public string GetCaptchaLink(HtmlDocument html)
        {
            return html.GetElementbyId("captcha").Attributes["src"].Value;
        }

        #region IDisposable Members

        public void Dispose()
        {
            GC.Collect();
        }

        #endregion
    }
}