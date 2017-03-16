using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAdlClient.Analytics
{
    [TestClass]
    public class Analytics_Management_Tests : Base_Tests
    {


        [TestMethod]
        public void List_ADLA_Accounts()
        {
            this.Initialize();
            var adla_accounts = this.AzureClient.Analytics.ListAccounts();
            foreach (var a in adla_accounts)
            {
                System.Console.WriteLine("Analytics {0} ", a.Name);
            }

        }
    }
}