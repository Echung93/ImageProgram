//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml;

//namespace ImageProgram.Controller
//{
//    class API
//    {
//        const string NAVER_DISPLAY_STRING = "&display=";
//        const string NAVER_ID = "4djOgPTvaUjxuEqSudHM";
//        const string NAVER_SECRET = "bDuwCmqIPr";
//        public const string NAVER_URL = "https://openapi.naver.com/v1/search/book_adv.xml?d_titl=";
//        Function function = new Function();
//        public API()
//        {

//        }
//        public void searchBook(string input, string s)
//        {
//            string a = "1";
//            int count = 0;
//            int check = 0;
//            while (true)
//            {
//                Console.Clear();
//                WebRequest request;
//                WebResponse response;
//                Stream stream;
//                XmlNode firstNode;
//                XmlNode secondNode;
//                XmlDocument xmlDocument = new XmlDocument();
//                XmlNodeList xmlNodeList;
//                List<BookVO> list = new List<BookVO>();


//                string url = NAVER_URL + input + NAVER_DISPLAY_STRING + s + "&start=" + a;
//                request = (HttpWebRequest)WebRequest.Create(url);

//                request.Headers.Add("X-Naver-Client-Id", NAVER_ID);
//                request.Headers.Add("X-Naver-Client-Secret", NAVER_SECRET);           //api 접근

//                response = request.GetResponse();
//                stream = response.GetResponseStream();
//                xmlDocument.Load(stream);

//                firstNode = xmlDocument.SelectSingleNode("rss");
//                secondNode = firstNode.SelectSingleNode("channel");

//                xmlNodeList = secondNode.SelectNodes("item");

//                foreach (XmlNode xmlNode in xmlNodeList)
//                {

//                    list.Add(new BookVO(xmlNode.SelectSingleNode("title").InnerText.Replace("<b>", "").Replace("</b>", "")
//                       , xmlNode.SelectSingleNode("title").InnerText.Replace("<b>", "").Replace("</b>", "")
//                       , xmlNode.SelectSingleNode("publisher").InnerText.Replace("<b>", "").Replace("</b>", "")
//                       , xmlNode.SelectSingleNode("author").InnerText.Replace("<b>", "").Replace("</b>", "")
//                       , xmlNode.SelectSingleNode("price").InnerText.Replace("<b>", "").Replace("</b>", "")
//                       , xmlNode.SelectSingleNode("pubdate").InnerText.Replace("<b>", "").Replace("</b>", "")
//                       , xmlNode.SelectSingleNode("isbn").InnerText.Replace("<b>", "").Replace("</b>", "")
//                       , xmlNode.SelectSingleNode("description").InnerText.Replace("<b>", "").Replace("</b>", "")
//                       ));
//                    //Console.WriteLine(xmlNode.SelectSingleNode("title").InnerText);  //책 출력.
//                }
//                foreach (BookVO bv in list)
//                {
//                    Console.WriteLine("------------------------------------------------------------------    ");
//                    Console.WriteLine("\r\n");
//                    Console.WriteLine($"책 이름 : {bv.BookName}");
//                    Console.WriteLine($"책 작가 : {bv.BookAuthor}");
//                    Console.WriteLine($"책 가격 : {bv.BookPrice}");
//                    Console.WriteLine($"책 출판사 : {bv.BookPublisher}");
//                    Console.WriteLine($"책 출간일 : {bv.BookPublicationDate}");
//                    Console.WriteLine($"책 ISBN : {bv.BookISBN}");
//                    Console.WriteLine($"책 설명 : {bv.BookDescription}");
//                    Console.WriteLine("\r\n");

//                }
//                Console.WriteLine("------------------------------------------------------------------    ");
//                Console.WriteLine("\r\n1 : 등록   ESC : 뒤로가기   방향키 : 이동");
//                //new DB(list);
//                if (check == 1)
//                {
//                    Console.WriteLine("\r\n처음 페이지 입니다.");
//                    check = 0;
//                }

//                else if (check == 2)
//                {
//                    Console.WriteLine("\r\n마지막 페이지 입니다.");
//                    check = 0;
//                }

//                else
//                {
//                    Console.WriteLine($"\r\n{count + 1}번 페이지 입니다.");
//                }

//                ConsoleKeyInfo key;
//                key = Console.ReadKey(true);

//                if (key.Key == ConsoleKey.D1)
//                {
//                    function.addBookWithApi(list);
//                    break;
//                }

//                else if (key.Key == ConsoleKey.RightArrow) //우측키 입력
//                {
//                    if (list.Count < int.Parse(s))
//                    {
//                        check = 2;
//                    }

//                    else
//                    {
//                        count++;
//                        a = "1";
//                        int b = int.Parse(a) + int.Parse(s) * (count);
//                        a = b.ToString();
//                    }
//                }

//                else if (key.Key == ConsoleKey.LeftArrow) // 좌측키 입력
//                {
//                    if (count == 0)
//                    {
//                        check = 1;
//                    }

//                    else
//                    {
//                        count--;
//                        a = "1";
//                        int b = int.Parse(a) + int.Parse(s) * (count);
//                        a = b.ToString();
//                    }
//                }

//                else if (key.Key == ConsoleKey.Escape)
//                {
//                    goto Exit;
//                }
//            }
//        Exit:
//            ;
//        }
//    }
//}
