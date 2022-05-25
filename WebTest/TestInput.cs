using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace WebTest
{
    [TestClass]
    public class websiteTest
    {
        public IWebDriver driver;
        
        [TestMethod]
        public void TestInput()
        {
            try
            {
                System.Console.WriteLine("Try to open browser");
                //Instancia um novo FirefoxDriver();
                driver = new FirefoxDriver();
                //Direciona para o url "http://localhost:64766/main"
                driver.Url = "http://localhost:64766/main";
                System.Console.WriteLine("Open browser");
            }
            catch (Exception)
            {
                Console.WriteLine("Error in opening the website");
                throw new Exception("Error in opening the website");
            }

            try
            {
                System.Console.WriteLine("Finding the input box");
                //Encontra o elemento tb_input e preeench com valor "10"
                driver.FindElement(By.Id("tb_input")).SendKeys("10");
                System.Console.WriteLine("Input box found");
            }
            catch (Exception)
            {
                Console.WriteLine("Error in finding the input box");
                throw new Exception("Error in finding the input box");
            }

            try
            {
                Console.WriteLine("Finding the button");
                //Usando XPATH para encontrar o elemento que possui o id btn_confirm e clica nele
                driver.FindElement(By.XPath("//*[@id=\"btn_confirm\"]")).Click();
                Console.WriteLine("Button found");
            }
            catch (Exception)
            {
                Console.WriteLine("Error in finding the confirm button");
                throw new Exception("Error in finding the confirm button");
            }

            string result = "";

            try
            {
                Console.WriteLine("Finding the element with id 'lb_output'");
                //Retorna o texto do elemento com id lb_output
                result = driver.FindElement(By.Id("lb_output")).Text;
                Console.WriteLine("Element found");
                System.Console.WriteLine("Value: " + result);
            }
            catch (Exception)
            {
                Console.WriteLine("Error in finding the result box");
                throw new Exception("Error in finding the result box");
            }
            
            string expected = "1000000,0 cm";

            try
            {
                //Assert para validar os resultados
                Console.WriteLine("Comparing the result and expected");
                Assert.AreEqual(expected, result);
                Console.WriteLine("Test passed");
            }
            catch (Exception)
            {
                Console.WriteLine("Error in comparing the result");
                throw new Exception("Test failed");
            }

            try
            {
                //Verifica se a pagina contem algum elemento com valor "1000000,0 cm"
                Console.WriteLine(driver.PageSource.Contains("1000000,0 cm"));
            }
            catch (Exception)
            {
                Console.WriteLine("A");
            }
        }
    }
}
