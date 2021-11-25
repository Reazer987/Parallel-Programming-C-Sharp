using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebScraper
{
    class Program
    {
        const int loadInterval = 10000;
        static List<string> productInformation = new List<string>();
        static void Main(string[] args)
        {
            string filePath = @$"C:\Users\{Environment.UserName}\Desktop\Parallel-Programming-C-\Homework 3\WebScraper\products.csv";
            
            List<string> productNames = ReadItems(filePath);
            List<string> productUrlsOnPage = new List<string>();
            
            Task[] taskList = new Task[productNames.Count];
            for (int i = 0; i < productNames.Count; i++)
            {
                taskList[i] = Task.Factory.StartNew(() => GetProductsData(productNames[i], new ChromeDriver()));
                Thread.Sleep(1000);
            }

            Task.WaitAll(taskList);


            Console.WriteLine("======= All Products =======");
            foreach (string item in productInformation)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("=====================");
        }

        public static List<string> ReadItems(string filePath)
        {
            List<string> items = new List<string>();
            StreamReader reader = new StreamReader(filePath);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (var value in values)
                {
                    items.Add(value.Replace(' ', '+')); //URL Encode the word
                }
            }

            return items;
        }

        public static void GetProductsData(string queryTerm, ChromeDriver driver)
        {
            List<string> currentPageElementURLs = new List<string>();
            driver.Url = @$"https://www.emag.bg/search/laptopi/{queryTerm}";
            driver.Navigate();
            Thread.Sleep(loadInterval);
            var webElements = driver.FindElements(By.ClassName("card-v2-title"));
            foreach (var element in webElements)
            {
                currentPageElementURLs.Add(element.GetAttribute("href"));
            }

            foreach (string element in currentPageElementURLs)
            {
                string asd = GetProductSecifications(element, ref driver);
                Console.WriteLine(asd);
                productInformation.Add(asd);
            }
        }

        public static string GetProductSecifications(string productUrl, ref ChromeDriver driver)
        {
            StringBuilder sb = new StringBuilder();
            driver.Url = productUrl;
            driver.Navigate();
            Thread.Sleep(loadInterval);
            string tempPrice = string.Empty;
            string productTitleClass = "page-title";
            string priceXpath = "/html/body/div[3]/div[2]/div/section[1]/div/div[2]/div[2]/div/div/div[2]/form/div[1]/div[1]/div/div[1]/p[2]";

            double productPrice = 0;
            string productName = driver.FindElement(By.ClassName(productTitleClass)).Text;
            try
            {
                tempPrice = driver.FindElement(By.XPath(priceXpath)).Text;
            }
            catch (Exception)
            {
                priceXpath = "/html/body/div[4]/div[2]/div/section[1]/div/div[2]/div[2]/div/div/div[2]/form/div[1]/div[1]/div/div[1]/p[2]";
                tempPrice = driver.FindElement(By.XPath(priceXpath)).Text;
            }

            tempPrice = tempPrice.Substring(0, tempPrice.IndexOf(' '));

            if (tempPrice.Contains('.'))
            {
                tempPrice = tempPrice.Replace(".", string.Empty);
                productPrice = double.Parse(tempPrice, System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                productPrice = double.Parse(tempPrice, System.Globalization.CultureInfo.InvariantCulture);
            }

            productPrice /= 100;

            string[] productInfo = productName.Split(", ", StringSplitOptions.RemoveEmptyEntries);

            sb.AppendLine($"====== {productInfo[0]} ======");
            sb.AppendLine($"Price: {productPrice}");
            sb.AppendLine();

            for (int i = 1; i < productInfo.Length; i++)
            {
                sb.AppendLine($" * {productInfo[i]}");
            }

            sb.AppendLine("============= =============");

            return sb.ToString();
        }
    }
}
