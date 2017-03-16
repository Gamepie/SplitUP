using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoxelBusters.Utility;
using VoxelBusters.NativePlugins;


namespace VoxelBusters.NativePlugins {
public class Buyiap : MonoBehaviour {

		public bool Adsbought = false;
		public string boughtrestore = "";
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {

	}
		public void BuyRemoveADS()
		{
			BuyProduct(NPSettings.Billing.Products[0]);
		}

	public void RequestBillingProducts ()
	{
		NPBinding.Billing.RequestForBillingProducts(NPSettings.Billing.Products);

		// At this point you can display an activity indicator to inform user that task is in progress
			Debug.Log ("In progress");
	}



private void OnEnable ()
{
    // Register for callbacks
    Billing.DidFinishRequestForBillingProductsEvent    += OnDidFinishProductsRequest;
    Billing.DidFinishProductPurchaseEvent            += OnDidFinishTransaction;

    // For receiving restored transactions.
    Billing.DidFinishRestoringPurchasesEvent        += OnDidFinishRestoringPurchases;

}

private void OnDisable ()
{
    // Deregister for callbacks
    Billing.DidFinishRequestForBillingProductsEvent    -= OnDidFinishProductsRequest;
    Billing.DidFinishProductPurchaseEvent            -= OnDidFinishTransaction;
    Billing.DidFinishRestoringPurchasesEvent        -= OnDidFinishRestoringPurchases;        
}

	private void OnDidFinishProductsRequest (BillingProduct[] _regProductsList, string _error)
	{
		// Hide activity indicator
			Debug.Log ("PreqD");

		// Handle response
		if (_error != null)
		{        
			// Something went wrong
		}
		else 
		{    
			// Inject code to display received products
				Debug.Log ("LNoads");

		}
	}

		public void BuyProduct (BillingProduct _product)
		{
			Debug.Log (_product.Name);
			if (NPBinding.Billing.IsProductPurchased(_product.ProductIdentifier))
			{
				// Show alert message that item is already purchased
				Debug.Log ("already bought");
				boughtrestore = "restore";

				return;
			}

			// Call method to make purchase
			NPBinding.Billing.BuyProduct(_product);

			// At this point you can display an activity indicator to inform user that task is in progress
			Debug.Log ("Buying...");
		}


		private void OnDidFinishTransaction (BillingTransaction _transaction)
		{
			if (_transaction != null)
			{

				if (_transaction.VerificationState == eBillingTransactionVerificationState.SUCCESS)
				{
					if (_transaction.TransactionState == eBillingTransactionState.PURCHASED)
					{
						Debug.Log ("Bought, no more ads");
						Adsbought = true;
					}
				}
			}
		}
		private void RestoreCompletedTransactions ()
		{
			NPBinding.Billing.RestoreCompletedTransactions ();
		}
		
		private void OnDidFinishRestoringPurchases (BillingTransaction[] _transactions, string _error)
{
    Debug.Log(string.Format("Received restore purchases response. Error = {0}.", _error.GetPrintableString()));

    if (_transactions != null)
    {                
        Debug.Log(string.Format("Count of transaction information received = {0}.", _transactions.Length));

        foreach (BillingTransaction _currentTransaction in _transactions)
        {
            Debug.Log("Product Identifier = "         + _currentTransaction.ProductIdentifier);
            Debug.Log("Transaction State = "        + _currentTransaction.TransactionState);
            Debug.Log("Verification State = "        + _currentTransaction.VerificationState);
            Debug.Log("Transaction Date[UTC] = "    + _currentTransaction.TransactionDateUTC);
            Debug.Log("Transaction Date[Local] = "    + _currentTransaction.TransactionDateLocal);
            Debug.Log("Transaction Identifier = "    + _currentTransaction.TransactionIdentifier);
            Debug.Log("Transaction Receipt = "        + _currentTransaction.TransactionReceipt);
            Debug.Log("Error = "                    + _currentTransaction.Error.GetPrintableString());
					Adsbought = true;
        }
    }
}


}
}

