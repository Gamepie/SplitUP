using UnityEngine;
using System.Collections;
using Heyzap;
public class AdsManager : MonoBehaviour {



	// Use this for initialization
	void Start () {
		HeyzapAds.Start("35848a20ffa97036bf2d562bcc9641ce", HeyzapAds.FLAG_DISABLE_AUTOMATIC_FETCHING);
		HZInterstitialAd.Fetch("GameOver");
		HZInterstitialAd.Fetch("MainMenu");


	}
	
	// Update is called once per frame
	void Update () {

	}
}
