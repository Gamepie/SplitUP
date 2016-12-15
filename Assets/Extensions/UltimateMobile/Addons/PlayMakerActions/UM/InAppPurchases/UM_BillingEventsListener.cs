using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions {

	[ActionCategory("Ultimate Mobile - InAppPurchases")]
	[Tooltip("Initialize billing. Best practice to do this on appplicaton start")]
	public class UM_BillingEventsListener : FsmStateAction {

		[Tooltip("Event fired when billing initlization is complete")]
		public FsmEvent BillingConnected;

		[Tooltip("Event fired when transaction restore actions is complete, IOS only")]
		public FsmEvent TransactionsRestored;


		[Tooltip("Event fired when InApp purchase is complete")]
		public FsmEvent ItemPurchased;
		public FsmString PurshasedItemId;
		
	
		
		public override void Reset() {
			
		}		
		
		public override void OnEnter() {

			Unsubuscibe();

			UM_InAppPurchaseManager.OnBillingConnectFinishedAction += OnStoreInitComplete;
			UM_InAppPurchaseManager.OnPurchaseFlowFinishedAction += OnPurchaseFlowFinishedAction;
			UM_InAppPurchaseManager.OnPurchasesRestoreFinishedAction += OnPurchasesRestoreFinishedAction;
		}
		
		private void OnStoreInitComplete (UM_BillingConnectionResult res) {
			Fsm.Event(BillingConnected);
		}

		void OnPurchaseFlowFinishedAction (UM_PurchaseResult res) {
			if(res.isSuccess) {
				PurshasedItemId.Value = res.product.id;
				Fsm.Event(ItemPurchased);
			}
		
		}

		void OnPurchasesRestoreFinishedAction (UM_BaseResult res) {
			if(res.IsSucceeded) {
				Fsm.Event(TransactionsRestored);
			}
		}


		void Unsubuscibe() {
			UM_InAppPurchaseManager.OnBillingConnectFinishedAction -= OnStoreInitComplete;
			UM_InAppPurchaseManager.OnPurchaseFlowFinishedAction -= OnPurchaseFlowFinishedAction;
			UM_InAppPurchaseManager.OnPurchasesRestoreFinishedAction -= OnPurchasesRestoreFinishedAction;
		}

		void OnDestroy() {
			Unsubuscibe();
		}
	}
}
