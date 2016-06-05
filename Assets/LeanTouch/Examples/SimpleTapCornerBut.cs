using UnityEngine;
using System.Collections;

public class SimpleTapCornerBut : MonoBehaviour {
	public GameObject Prefab;
	private GameObject bar_material;
	private GameObject bar_dimension;
	private GameObject[] onTapDisplays;

	protected virtual void OnEnable()
	{
		// Hook into the OnFingerTap event
		Lean.LeanTouch.OnFingerTap += OnFingerTap;
	}

	protected virtual void OnDisable()
	{
		// Unhook into the OnFingerTap event
		Lean.LeanTouch.OnFingerTap -= OnFingerTap;
	}

	void Start(){
		//bar_material = GameObject.Find ("Drpd_material");
		//bar_dimension = GameObject.Find ("text_dimension");
		onTapDisplays = GameObject.FindGameObjectsWithTag ("onTapDisplay");
	}

	public void OnFingerTap(Lean.LeanFinger finger)
	{
		Vector2 referencePoint = new Vector2 ();
		referencePoint.x = 0.0f;
		referencePoint.y = 0.0f;
		if( finger.GetDistance(referencePoint) < 200.0 ) {
			foreach (GameObject obj in onTapDisplays) {
				obj.SetActive (!obj.activeSelf);
			}
		}


		// Does the prefab exist?
		if (Prefab != null)
		{
			// Make sure the finger isn't over any GUI elements
			if (finger.IsOverGui == false)
			{
				// Clone the prefab, and place it where the finger was tapped
				var position = finger.GetWorldPosition(50.0f);
				var rotation = Quaternion.identity;
				var clone    = (GameObject)Instantiate(Prefab, position, rotation);

				// Make sure the prefab gets destroyed after some time
				Destroy(clone, 2.0f);
			}
		}
	}
}
