// using System;
// using System.Collections.Generic;
// using System.Text;
// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using OpenQA.Selenium;
// using OpenQA.Selenium.Firefox;
// using OpenQA.Selenium.Chrome;
// using WebTest;
// namespace WebTest
// {
//     [TestClass]
//     public class LoggerTest
//     {
//         [TestMethod]
//         public void TestMethod1()
//         {
//             Logger logger = Logger.GetInstance().setLogWriter(new txtLogWriter());
//             logger.RegisterLog(new Log { Message = "Open browser" });
//             logger.RegisterLog(new Log { Message = "Input box found" });
//             logger.RegisterLog(new Log { Message = "Error in finding the input box" });
//             logger.RegisterLog(new Log { Message = "Error in opening the website" });
//             logger.WriteLog();
//         }
//     }
// }
