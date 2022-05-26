using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using WebTest;
namespace WebTest
{
    [TestClass]
    public class websiteTest
    {
        public IWebDriver driver;
        public Logger _logger = Logger.GetInstance().setLogWriter(new txtLogWriter());


        [TestMethod]
        public void TestInput()
        {
            
            try
            {
                System.Console.WriteLine("Try to open browser");
                //Instancia um novo FirefoxDriver();
                driver = new FirefoxDriver();
                //Direciona para o url ""
                //driver.Url = "https://localhost:44369/Main";//SSL Chrome
                driver.Url = "http://localhost:64766/main";//No SSL Firefox
                driver.Manage().Window.Minimize();
                System.Console.WriteLine("Open browser");
                _logger.RegisterLog(new Log { Message = "Open browser" });
                _logger.WriteLog();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in opening the website");
                Console.WriteLine(ex.Message);
                _logger.RegisterLog(new Log { Message = "Error in opening the website" });
                _logger.WriteLog();                
                throw new Exception();
            }
            try
            {
                System.Console.WriteLine("Finding the input box");
                //Encontra o elemento tb_input e preeench com valor "10"
                driver.FindElement(By.Id("tb_input")).SendKeys("10");
                System.Console.WriteLine("Input box found");
                _logger.RegisterLog(new Log { Message = "Input box found" });
                _logger.WriteLog();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in finding the input box");
                Console.WriteLine(ex.Message);    
                _logger.RegisterLog(new Log { Message = "Error in finding the input box" });
                _logger.WriteLog();
                throw new Exception();
            }

            try
            {
                Console.WriteLine("Finding the button");
                //Usando XPATH para encontrar o elemento que possui o id btn_confirm e clica nele
                driver.FindElement(By.XPath("//*[@id=\"btn_confirm\"]")).Click();
                Console.WriteLine("Button found");
                _logger.RegisterLog(new Log { Message = "Button found" });
                _logger.WriteLog();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in finding the confirm button");
                Console.WriteLine(ex.Message);
                _logger.RegisterLog(new Log { Message = "Error in finding the confirm button" });
                _logger.WriteLog();
                throw new Exception();
            }

            string result = "";

            try
            {
                Console.WriteLine("Finding the element with id 'lb_output'");
                //Retorna o texto do elemento com id lb_output
                result = driver.FindElement(By.Id("lb_output")).Text;
                Console.WriteLine("Element found");
                System.Console.WriteLine("Value: " + result);
                _logger.RegisterLog(new Log { Message = "Element found" });
                _logger.WriteLog();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in finding the result box");
                Console.WriteLine(ex.Message);       
                _logger.RegisterLog(new Log { Message = "Error in finding the result box" });
                _logger.WriteLog();
                throw new Exception();
            }
            
            string expected = "1000000,0 cm";

            try
            {
                //Assert para validar os resultados
                Console.WriteLine("Comparing the result and expected");
                Assert.AreEqual(expected, result);
                Console.WriteLine("Test passed");
                _logger.RegisterLog(new Log { Message = "Test passed" });
                _logger.WriteLog();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in comparing the result");
                Console.WriteLine(ex.Message);
                _logger.RegisterLog(new Log { Message = "Error in comparing the result" });
                _logger.WriteLog();
                throw new Exception();
            }

            try
            {
                //Verifica se a pagina contem algum elemento com valor "1000000,0 cm"
                Console.WriteLine(driver.PageSource.Contains("1000000,0 cm"));
                Console.WriteLine("Test passed");
                _logger.RegisterLog(new Log { Message = "Test passed" });
                _logger.WriteLog();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.RegisterLog(new Log { Message = "Error in comparing the result" });
                _logger.WriteLog();
                throw new Exception();
            }

            
            driver.Close();
            driver.Quit();
        }
    }
}
