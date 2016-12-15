using UnityEngine;
using System.Collections;
using Heyzap;
public class AdsMenu : MonoBehaviour {

	public static bool showOnce = false;

	// Use this for initialization
	void Start () {
		HZBannerAd.Destroy();
		HZInterstitialAd.Fetch("MainMenu");
	}
	
	// Update is called once per frame
	void Update () {
		if (HZInterstitialAd.IsAvailable("MainMenu")) {
			if (!showOnce) {
				HZShowOptions showOptions = new HZShowOptions();
				showOptions.Tag = "MainMenu";
				HZInterstitialAd.ShowWithOptions(showOptions);
			}

			showOnce = true;
		}
	}
}
