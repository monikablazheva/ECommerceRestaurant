using Braintree;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using UserManagementMVCExample.Interfaces;

namespace UserManagementMVCExample.Controllers
{
    public class BrainTreeController : Controller
    {
        public IBrainTree brainTree { get; set; }

        public BrainTreeController(IBrainTree brainTree)
        {
            this.brainTree = brainTree;
        }

        public IActionResult Index()
        {
            var gateway = brainTree.GetGateway();
            var clientToken = gateway.ClientToken.Generate();

            ViewBag.ClientToken = clientToken;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(IFormCollection formCollection)
        {
            Random random = new Random();
            string nonceFromTheClient = formCollection["payment_method_nonce"];
            var request = new TransactionRequest
            {
                Amount = random.Next(1, 100),
                PaymentMethodNonce = nonceFromTheClient,
                OrderId = "55001",
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };

            var gateway = brainTree.GetGateway();
            Result<Transaction> result = gateway.Transaction.Sale(request);

            if(result.Target.ProcessorResponseText == "Approved")
            {
                TempData["Success"] = "Transaction was successful. ID: " + result.Target.Id +
                                        ". Amount charged: " + result.Target.Amount;
            }

            return RedirectToAction("Index");
        }
    }
}
