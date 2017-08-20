using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AutoLogin.Model
{
    public class Login
    {


        HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(new Uri("http://www.xxxx.com/chk.asp"));


        public bool Execute(string user,string pwd)
        {
            string loginUrl = "http://202.114.74.218/web3/login.aspx";
            string loginData = "uid=******&pwd=******";
            CookieContainer cookies = new CookieContainer();
            string loginResult = HttpPost(loginUrl, loginData, cookies);
            Console.WriteLine("这是登陆后的界面信息！");
            Console.WriteLine(loginResult);

            HttpWebResponse response2 = (HttpWebResponse)webRequest2.GetResponse();
            StreamReader sr2 = new StreamReader(response2.GetResponseStream(), Encoding.Default);
            string text2 = sr2.ReadToEnd();
            return true;
        }
        public static string HttpPost(string url, string data, CookieContainer cookies)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            //FORM元素的enctype属性指定了表单数据向服务器提交时所采用的编码类型，默认的缺省值是“application/x-www-form-urlencoded”  
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = Encoding.UTF8.GetByteCount(data);
            request.CookieContainer = cookies;
            Stream requetStream = request.GetRequestStream();
            StreamWriter streamWriter = new StreamWriter(requetStream);
            streamWriter.Write(data);
            streamWriter.Close();

            request.CookieContainer = cookies;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            response.Cookies = cookies.GetCookies(response.ResponseUri);
            cookies.Add(response.Cookies);
            Stream responseStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("GB2312"));
            string result = streamReader.ReadToEnd();
            streamReader.Close();
            responseStream.Close();
            return result;
        }
    }
}