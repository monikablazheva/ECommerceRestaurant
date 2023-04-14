using Braintree;
using Microsoft.Extensions.Options;
using UserManagementMVCExample.Interfaces;
using UserManagementMVCExample.Models;

namespace UserManagementMVCExample.Services
{
    public class BrainTree : IBrainTree
    {
        public BrainTreeSettings Options { get; set; }
        private IBraintreeGateway BraintreeGateway { get; set; }

        public BrainTree(IOptions<BrainTreeSettings> options)
        {
            Options = options.Value;
        }
        public IBraintreeGateway CreateGetway()
        {
            return new BraintreeGateway(Options.Environment, Options.MerchantId, Options.PublicKey, Options.PrivateKey);
        }

        public IBraintreeGateway GetGateway()
        {
            if(BraintreeGateway == null)
            {
                BraintreeGateway = CreateGetway();
            }
            return BraintreeGateway;
        }
    }
}
