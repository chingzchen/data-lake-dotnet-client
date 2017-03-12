using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ADL_Client_Tests.Analytics
{
    [TestClass]
    public class Analytics_Management_Tests : Base_Tests
    {


        [TestMethod]
        public void List_ADLA_Accounts()
        {
            this.Initialize();
            var adla_accounts = this.sub_client.ListAnalyticsAccounts();
            foreach (var a in adla_accounts)
            {
                System.Console.WriteLine("Analytics {0} ", a.Name);
            }

        }
    }
}
