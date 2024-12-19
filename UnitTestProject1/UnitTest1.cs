using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Reflection.Emit;
using System.Text.Json;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (WebClient client = new WebClient())
            {
                string response = client.DownloadString($"https://api.coingecko.com/api/v3/simple/price?ids=bitcoin&vs_currencies=usd");
                decimal price = JsonDocument.Parse(response).RootElement.GetProperty("bitcoin").GetProperty("usd").GetDecimal();
                Assert.IsNotNull(price);    
            }
        }
    }
}
