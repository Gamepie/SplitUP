using UnityEngine;
using System.Collections;
using Heyzap;
public class AdsGameO : MonoBehaviour {

	public static bool showOnce = false;

	// Use this for initialization
	void Start () {
		HZInterstitialAd.Fetch("GameOver");

	}
	
	// Update is called once per frame
	void Update () {
		if (HZInterstitialAd.IsAvailable("GameOver")) {
			if (!showOnce) {
				HZShowOptions showOptions = new HZShowOptions();
				showOptions.Tag = "GameOver";
				HZInterstitialAd.ShowWithOptions(showOptions);
			}

			showOnce = true;
		}
	}
}
