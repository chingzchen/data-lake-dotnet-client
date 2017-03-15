using MSAZURERM = Microsoft.Azure.Management.ResourceManager;
using System.Collections.Generic;
using AdlClient.Authentication;
using AdlClient.Rest;
using Microsoft.Azure.Management.ResourceManager;

namespace AdlClient
{
    public class ResourceClient: ClientBase
    {
        private readonly AnalyticsAccountManagmentRestWrapper _adlaAccountMgmtClientWrapper;
        private readonly StoreManagementRestWrapper _adls_account_mgmt_client;
        public readonly Subscription Subscription;

        MSAZURERM.ResourceManagementClient rmclient;

        public AnalyticsResourceCommands Analytics;
        public StoreResourceCommands Store;

        public ResourceClient(Subscription subscription, AuthenticatedSession authSession) :
            base(authSession)
        {
            this.Subscription = subscription;
            this._adlaAccountMgmtClientWrapper = new AnalyticsAccountManagmentRestWrapper(subscription, authSession.Credentials);
            this._adls_account_mgmt_client = new StoreManagementRestWrapper(subscription, authSession.Credentials);

            this.Analytics = new AnalyticsResourceCommands(subscription, authSession, _adlaAccountMgmtClientWrapper);
            this.Store = new StoreResourceCommands(subscription,authSession,this._adls_account_mgmt_client);

            this.rmclient = new MSAZURERM.ResourceManagementClient(authSession.Credentials);
            this.rmclient.SubscriptionId = subscription.Id;
        }

        public IEnumerable<MSAZURERM.Models.ResourceGroup> ListResourceGroups()
        {
            var rgs = this.rmclient.ResourceGroups.List();
            foreach (var rg in rgs)
            {
                yield return rg;
            }
        }

    }
}
