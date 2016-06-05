using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// This script will spawn a prefab when you tap the screen
public class OnTap : MonoBehaviour
{
	protected virtual void OnEnable()
	{
		Debug.Log ("OnEnable");
		// Hook into the OnFingerTap event
		Lean.LeanTouch.OnFingerTap += OnFingerTap;
	}

	protected virtual void OnDisable()
	{
		Debug.Log ("OnDisable");
		// Unhook into the OnFingerTap event
		Lean.LeanTouch.OnFingerTap -= OnFingerTap;
	}

	public void OnFingerTap(Lean.LeanFinger finger)
	{
		/* Find out which object was tapped */
		Ray screenRay = Camera.main.ScreenPointToRay(finger.ScreenPosition);
		GameObject tappedObject = null;
		RaycastHit hit;
		if (Physics.Raycast(screenRay, out hit)) {
			tappedObject = hit.collider.gameObject;
		}

		if (tappedObject != null && tappedObject.name.Equals (gameObject.name) && tappedObject.name.Contains("furniture")) {

			/* Set this furniture as the selected one */
			bool isActive = false;
			if (global_stuff.selectedFurniture == null) {
				isActive = true;
				global_stuff.selectedFurniture = gameObject.name;
			} else {
				global_stuff.selectedFurniture = null;
			}
			Debug.Log ("selectedFurniture: " + global_stuff.selectedFurniture);

			/* Toggle the objects */
			toggleUIElements (isActive);

			if (isActive) {
				/* Change the title and description text */
				furnPrice furnProperties = GetComponent<furnPrice> ();
				GameObject itemTitle = GameObject.Find ("ItemTitle");
				GameObject itemDescription = GameObject.Find ("ItemDescription");
				itemTitle.GetComponent<Text> ().text = furnProperties.title;
				itemDescription.GetComponent<Text> ().text = furnProperties.description;
			}
		}

	}

	public static void toggleUIElements(bool newState) {
		GameObject[] allGameObjects = Resources.FindObjectsOfTypeAll (typeof(GameObject)) as GameObject[];
		foreach (var thisGameObject in allGameObjects) {
			if (init.objectsToToggle.Contains (thisGameObject.name)) {
				thisGameObject.SetActive (newState);
			}
		}
	}
}