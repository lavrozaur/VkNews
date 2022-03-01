using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Runtime.Serialization.Json;

namespace WpfApp67
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SetTextInWebElement(ChromeDriver chromeDriver, string id, string value)
        {
            List<IWebElement> webElements = chromeDriver.FindElements(By.Id(id)).ToList();
            foreach (var item in webElements)
            {
                if (!item.Displayed)
                    continue;
                item.SendKeys(value);
            }
        }
        private void SetClickInDate(ChromeDriver chromeDriver, string data, string id)
        {
            List<IWebElement> webElements = chromeDriver.FindElements(By.TagName("div")).ToList();
            foreach (var item in webElements)
            {
                if (!item.Displayed)
                    continue;
                if (item.GetAttribute("data-test-id") == null)
                    continue;
                if (!item.GetAttribute("data-test-id").Equals(data))
                    continue;
                item.Click();
                break;
            }
            //string pagesource = chromeDriver.PageSource;
            webElements = chromeDriver.FindElements(By.Id(id)).ToList();
            foreach (var item in webElements)
            {
                if (!item.Displayed)
                    continue;
                item.Click();
                break;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument(@"user-data-dir=C:\Users\79115\AppData\Local\Google\Chrome\User Data\Default");
            ChromeDriver chromeDriver = new ChromeDriver(chromeOptions);
            chromeDriver.Navigate().GoToUrl("https://vk.com/feed");

            //chromeDriver.Navigate().GoToUrl("https://account.mail.ru/signup?from=main&rf=auth.mail.ru&app_id_mytracker=58519");
            /*            chromeDriver.Navigate().GoToUrl("https://mail.ru");
            List<IWebElement> webElements = chromeDriver.FindElements(By.TagName("a")).ToList();
            foreach (var item in webElements)
            {
                if (!item.Displayed)
                    continue;
                if(!item.Text.ToLower().Trim().Equals("создать почту"))
                    continue;
                item.Click();
                break;
            }*/
            /*Thread.Sleep(1000);
            SetTextInWebElement(chromeDriver, "fname", "Никита");
            SetTextInWebElement(chromeDriver, "lname", "Чугаев");
            SetClickInDate(chromeDriver, "birth-date__day", "react-select-2-option-0");
            SetClickInDate(chromeDriver, "birth-date__month", "react-select-3-option-6");
            SetClickInDate(chromeDriver, "birth-date__year", "react-select-4-option-20");*/
            //"birth-date__day"
            //"react-select-2-option-0"
            //"birth-date__day"
            List<IWebElement> webElements = chromeDriver.FindElements(By.TagName("div")).ToList();
            int i = 1;
            List<NewsVk> news = new List<NewsVk>();
            foreach (var item in webElements)
            {
                i += 1;
                try
                {
                    if (!item.Displayed)
                        continue;
                }
                catch (Exception)
                {
                    continue;
                }
                if (item.GetAttribute("class") == null)
                    continue;
                if (!item.GetAttribute("class").Trim().Equals("feed_row"))
                    continue;
                IWebElement itemId = item.FindElement(By.TagName("div"));
                if (itemId == null)
                    continue;
                if ((itemId.GetAttribute("id") == null) || (itemId.GetAttribute("id") == ""))
                    continue;
                Console.WriteLine(itemId.GetAttribute("id"));
                news.Add(new NewsVk()
                {
                    Text = item.Text,
                    Id = itemId.GetAttribute("id")
                });
                JSONWorker.setDataInJson(news);
                
                if (i > 10)
                    this.Close();
            }
        }
       
    }
}
