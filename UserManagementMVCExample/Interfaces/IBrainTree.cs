using Braintree;

namespace UserManagementMVCExample.Interfaces
{
    public interface IBrainTree
    {
        IBraintreeGateway CreateGetway();
        IBraintreeGateway GetGateway();
    }
}
