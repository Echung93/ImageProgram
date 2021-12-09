using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ImageProgram
{
    class API
    {
        const string NAVER_DISPLAY_STRING = "&display=";
        const string NAVER_ID = "4djOgPTvaUjxuEqSudHM";
        const string NAVER_SECRET = "bDuwCmqIPr";
        public const string NAVER_URL = "https://openapi.naver.com/v1/search/image.xml?query=";
        public API()
        {

        }

        public List<ImageVO> searchImage(string input)
        {
            WebRequest request;
            WebResponse response;
            Stream stream;
            XmlNode firstNode;
            XmlNode secondNode;
            XmlDocument xmlDocument = new XmlDocument();
            XmlNodeList xmlNodeList;
            List<ImageVO> list = new List<ImageVO>();

            string url = NAVER_URL + input + NAVER_DISPLAY_STRING + "100" + "&start=1";
            request = (HttpWebRequest)WebRequest.Create(url);

            request.Headers.Add("X-Naver-Client-Id", NAVER_ID);
            request.Headers.Add("X-Naver-Client-Secret", NAVER_SECRET);           //api 접근

            response = request.GetResponse();
            stream = response.GetResponseStream();
            xmlDocument.Load(stream);

            firstNode = xmlDocument.SelectSingleNode("rss");
            secondNode = firstNode.SelectSingleNode("channel");

            xmlNodeList = secondNode.SelectNodes("item");

            foreach (XmlNode xmlNode in xmlNodeList)
            {

                list.Add(new ImageVO(xmlNode.SelectSingleNode("title").InnerText.Replace("<b>", "").Replace("</b>", "")
                   , xmlNode.SelectSingleNode("link").InnerText.Replace("<b>", "").Replace("</b>", "")
                   , xmlNode.SelectSingleNode("thumbnail").InnerText.Replace("<b>", "").Replace("</b>", "")
                   , xmlNode.SelectSingleNode("sizeheight").InnerText.Replace("<b>", "").Replace("</b>", "")
                   , xmlNode.SelectSingleNode("sizewidth").InnerText.Replace("<b>", "").Replace("</b>", "")));
            }

            return list;
        }
    }
}
