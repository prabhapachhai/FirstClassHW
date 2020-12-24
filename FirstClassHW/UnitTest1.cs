using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace FirstClassHW
{
    public class Tests
    {
        IWebDriver driver;


        [SetUp]
        public void BeforeTest()
        {
            driver = new ChromeDriver(@"C:\Users\12144\Downloads\chromedriver_win32");
            driver.Url = "https://www.globalsqa.com/samplepagetest/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        }

        [Test]
        public void SamplePageTest()
        {
            IWebElement chooseFile = driver.FindElement(By.Name("file-553"));
            chooseFile.SendKeys(@"C:\Users\220px-Image_created_with_a_mobile_phone.png");
            IWebElement uplodedFile = driver.FindElement(By.Name("file-553"));

            IWebElement nameBox = driver.FindElement(By.Id("g2599-name"));
            nameBox.SendKeys("prabha");
            IWebElement emailBox = driver.FindElement(By.Id("g2599-email"));
            emailBox.SendKeys("pachhai_prabha@hotmail.com");

            IWebElement websiteBox = driver.FindElement(By.Id("g2599-website"));
            websiteBox.SendKeys("https://www.google.com");

            IWebElement experienceDroupBox = driver.FindElement(By.Id("g2599-experienceinyears"));
            SelectElement select = new SelectElement(experienceDroupBox);
            select.SelectByIndex(4);

            {
                ReadOnlyCollection<IWebElement> multipleCheckBox = driver.FindElements(By.Name("g2599-expertise[]"));
                foreach (var item in multipleCheckBox)
                {
                    item.Click();
                    Thread.Sleep(2000);
                }
                IWebElement checkBox = driver.FindElement(By.Name("g2599-education"));
                checkBox.Click();

                IWebElement alertBoxClickMeHereButton = driver.FindElement(By.XPath("//*[@onclick='myFunction()']"));
                alertBoxClickMeHereButton.Click();
                Thread.Sleep(5000);
                driver.SwitchTo().Alert().Accept();
                driver.SwitchTo().Alert().Accept();
                Thread.Sleep(10000);
                IWebElement alertBoxClickMeHere2 = driver.FindElement(By.XPath("//*[@onclick='myFunction()']"));
                alertBoxClickMeHere2.Click();
                driver.SwitchTo().Alert().Dismiss();
                driver.SwitchTo().Alert().Accept();
         

                IWebElement commentBox = driver.FindElement(By.Id("contact-form-comment-g2599-comment"));
                commentBox.SendKeys("what is selenium?");

                IWebElement submitButton = driver.FindElement(By.ClassName("pushbutton-wide"));
                submitButton.Click();
                Thread.Sleep(2000);
                IWebElement displayMessage = driver.FindElement(By.ClassName("page_heading"));
                Thread.Sleep(5000);
               

            }
        }
        [TearDown]
        public void AfterTest()
        {
            driver.Close();
            driver.Quit();

        }

    }
}

    