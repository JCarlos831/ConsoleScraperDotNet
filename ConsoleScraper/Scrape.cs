using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleScraper
{
    public class Scrape
    {
        public static void scrapeData()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--headless");
            var driver = new FirefoxDriver(options);

            // Open the browser and navigate to the Yahoo! Finance login page.
            driver.Url = "https://login.yahoo.com/config/login?.intl=us&.lang=en-US&.src=finance&.done=https%3A%2F%2Ffinance.yahoo.com%2F";

            // Maximize the window.
            driver.Manage().Window.Maximize();

            // If element cannot be found in three seconds, timeout.
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            // Find username text box, enter username, and press Enter.
            driver.FindElement(By.Id("login-username")).SendKeys("testfinance@yahoo.com" + Keys.Enter);

            // If element cannot be found in three seconds, timeout.
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            // Find password text box, enter password, and press Enter.
            driver.FindElement(By.Id("login-passwd")).SendKeys("3eggWhites6Almonds" + Keys.Enter);

            // Find 'My Portfolio' link and click
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/div/div[1]/div[2]/div[1]/div/div/div/div/div/div/div/nav/div/div/div/div[3]/div/div[1]/ul/li[2]/a")).Click();
            driver.FindElement(By.XPath("/html/body/dialog/section/button")).Click();

            // Click the 'x' on the pop up box
            driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section/div[2]/table/tbody/tr[1]/td[1]/a")).Click();

            // Path to write data to
            string path = @"C:\Users\A-JMontoya\source\repos\ConsoleScraper\ConsoleScraper\csv\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".csv";

            // If element cannot be found in three seconds, timeout.
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            // Find table with stock data
            IWebElement table = driver.FindElement(By.ClassName("_1TagL"));

            // Find all rows in the table
            IList<IWebElement> rows = new List<IWebElement>(table.FindElements(By.TagName("tr")));
            String strRowData = "";

            // Go through each row
            // foreach (var row in rows)
            // {
            for (int j = 1; j < rows.Count; j++)
            {
                // Get the columns from a particular row
                List<IWebElement> lstTdElem = new List<IWebElement>(rows[j].FindElements(By.TagName("td")));
                if (lstTdElem.Count > 0)
                {
                    // // Go through each column
                    // foreach (var elemTd in lstTdElem)
                    // {
                    //     // Add text found from each cell to strRowData
                    //     strRowData = strRowData + elemTd.Text + ",";
                    // }

                    for (int i = 0; i < 9; i++)
                    {
                        strRowData = strRowData + lstTdElem[i].Text + ",";
                    }
                }
                else
                {
                    // To print the data into the console and add comma between text

                    Console.WriteLine(rows[0].Text.Replace(" ", ","));
                    File.AppendAllText(path, rows[0].Text.Replace(" ", ","));
                }

                // Print the data to the console
                System.Console.WriteLine(strRowData + DateTime.Now.ToShortDateString());

                // Print data to file
                File.AppendAllText(path, strRowData + driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section[2]/div[2]/table/tbody/tr[1]/td[13]/span")).Text + "," + DateTime.Now.ToShortDateString() + "\n");

                // 
                strRowData = String.Empty;
                System.Console.WriteLine(strRowData);

            }

            System.Console.WriteLine("\n");

            driver.Close();
        }
    }
}
