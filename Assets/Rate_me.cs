using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rate_me : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void rate () {
		#if UNITY_ANDROID
	Application.OpenURL("market://details?id=com.gamepie.splitup");
		#elif UNITY_IPHONE
		Application.OpenURL("itms-apps://itunes.apple.com/app/id1188678963");
		#endif
	}
}
