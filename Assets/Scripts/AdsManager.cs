using UnityEngine;
using System.Collections;
using Heyzap;
public class AdsManager : MonoBehaviour {



	// Use this for initialization
	void Start () {
		HeyzapAds.Start("35848a20ffa97036bf2d562bcc9641ce", HeyzapAds.FLAG_DISABLE_AUTOMATIC_FETCHING);
		
		


	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void FetchAdGameOver () {
		HZInterstitialAd.Fetch("GameOver");
	}
	
	void FetchAdMainMenu () {
		HZInterstitialAd.Fetch("MainMenu");
	}
	
	void ShowAdBanner () {
		HZBannerShowOptions showOptions = new HZBannerShowOptions ();
		showOptions.Position = HZBannerShowOptions.POSITION_BOTTOM;
		showOptions.Tag = "Banner";
		HZBannerAd.ShowWithOptions (showOptions);
	}
	
	void DestroyAdBanner () {
		HZBannerAd.Destroy ();
	}
	
	void ShowAdMenu () {
			if (HZInterstitialAd.IsAvailable("MainMenu")) {
					
				HZShowOptions showOptions = new HZShowOptions();
				showOptions.Tag = "MainMenu";
				HZInterstitialAd.ShowWithOptions(showOptions);
		}
	}
	void ShowAdGameOver () {
			if (HZInterstitialAd.IsAvailable("GameOver")) {
					
				HZShowOptions showOptions = new HZShowOptions();
				showOptions.Tag = "GameOver";
				HZInterstitialAd.ShowWithOptions(showOptions);
		}
	}
	
	void AdTestSuite () {
		HeyzapAds.ShowMediationTestSuite();
	}
}
