using UnityEngine;
using System.Collections;

// This script will spawn a prefab when you tap the screen
public class OnTap : MonoBehaviour
{
	public GameObject Prefab;

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
		/* Objects to show/hide */
		ArrayList objectsToToggle = new ArrayList ();
		objectsToToggle.Add ("addToCart");
		objectsToToggle.Add ("addToWishlist");
		objectsToToggle.Add ("Fabric1Button");
		objectsToToggle.Add ("Fabric2Button");
		objectsToToggle.Add ("Fabric3Button");
		objectsToToggle.Add ("textCanvas");
		objectsToToggle.Add ("chairToggle");
		objectsToToggle.Add ("tableToggle");
		objectsToToggle.Add ("cartButton");

		/* Find out which object was tapped */
		Ray screenRay = Camera.main.ScreenPointToRay(finger.ScreenPosition);
		GameObject tappedObject = null;
		RaycastHit hit;
		if (Physics.Raycast(screenRay, out hit))
		{
			tappedObject = hit.collider.gameObject;
			Debug.Log("User tapped on game object: " + tappedObject.name);
		}

		if (tappedObject != null && tappedObject.name.Equals (Prefab.name)) {

			/* Set this furniture as the selected one */
			global_stuff.selectedFurniture = Prefab.name;
			Debug.Log ("selectedFurniture: " + global_stuff.selectedFurniture);

			/* Toggle the objects */
			GameObject[] allGameObjects = Resources.FindObjectsOfTypeAll (typeof(GameObject)) as GameObject[];
			foreach (var thisGameObject in allGameObjects) {
				if (objectsToToggle.Contains (thisGameObject.name)) {
					thisGameObject.SetActive (!thisGameObject.activeSelf);
				}
			}
		}

	}
}