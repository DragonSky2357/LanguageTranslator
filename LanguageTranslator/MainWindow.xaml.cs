using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace LanguageTranslator
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public const string idKey = ""; // Input Your IdKey
        public const string secretKey = ""; // Input Your secretKey


        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void BtnTranslation_Click(object sender, RoutedEventArgs e)
        {
            koreanText.Text = "";
            string textEnglish = englishText.Text;

            var client = new RestClient(" https://openapi.naver.com/v1/language/translate");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("charset", "UTF-8");


            request.AddHeader("X-Naver-Client-Id", "ygkfeBaeI6bFIFsj_5fe");
            request.AddHeader("X-Naver-Client-Secret", "qcAreAxBME");
            request.AddParameter("application/x-www-form-urlencoded", "source=en&target=ko&text="+textEnglish.ToString(), ParameterType.RequestBody);


            IRestResponse response = client.Execute(request);
            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();

            var JSONObj = deserial.Deserialize<Dictionary<string, Dictionary<string, object>>>(response);

            object temp = JSONObj["message"]["result"];
            Dictionary<string, object> find_word = (Dictionary<string, object>)temp;


            koreanText.Text=find_word["translatedText"].ToString();

        }

        private void BtnTranslation_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
