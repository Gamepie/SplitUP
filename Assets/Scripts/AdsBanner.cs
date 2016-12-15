using UnityEngine;
using System.Collections;
using Heyzap;
public class AdsBanner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		HZInterstitialAd.Fetch("GameOver");
		HZBannerShowOptions showOptions = new HZBannerShowOptions ();
		showOptions.Position = HZBannerShowOptions.POSITION_BOTTOM;
		showOptions.Tag = "Banner";
		HZBannerAd.ShowWithOptions (showOptions);
		Debug.Log ("BannerON");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
