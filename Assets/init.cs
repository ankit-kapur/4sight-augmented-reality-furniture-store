using UnityEngine;
using System.Collections;

public class init : MonoBehaviour {

	/* Objects to show/hide */
	public static ArrayList objectsToToggle;

	void Start () {
		objectsToToggle = new ArrayList ();
		objectsToToggle.Add ("addToCart");
		objectsToToggle.Add ("addToWishlist");
		objectsToToggle.Add ("Fabric1Button");
		objectsToToggle.Add ("Fabric2Button");
		objectsToToggle.Add ("Fabric3Button");
		objectsToToggle.Add ("Fabric4Button");
		objectsToToggle.Add ("Fabric5Button");
		objectsToToggle.Add ("Fabric6Button");
		objectsToToggle.Add ("Fabric7Button");
		objectsToToggle.Add ("Fabric8Button");
		objectsToToggle.Add ("textCanvas");
		objectsToToggle.Add ("starRating");
		objectsToToggle.Add ("cartButton");
		objectsToToggle.Add ("ItemTitle");
		objectsToToggle.Add ("ItemDescription");

		/* Deactivate everything initially */
		foreach (var thisGameObjectName in objectsToToggle) {
			Debug.Log (thisGameObjectName);
			GameObject thisGameObject = GameObject.Find ((string)thisGameObjectName);
			thisGameObject.SetActive (false);
		}

		/* Deactivate overlay canvas as well */
		GameObject.Find ("OverlayCanvas").SetActive (false);
	}
}
