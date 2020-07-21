using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KelnerPlus;

namespace KelnerPlus.Tests
{
    [TestClass]
    public class ConnectionsTests
    {
        [TestMethod]
        public void TestGettingConnectionString()
        {
            string var = Connections.GetConnectionString();
                Assert.IsNotNull(var);
        }

        [TestMethod]
        public void TryConnect()
        {

            if (!Connections.IsServerConnected())
                Assert.Fail("Nie ma połączenia");
        }
    }
}
