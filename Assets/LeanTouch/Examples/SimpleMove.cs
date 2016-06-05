using UnityEngine;

// This script will move the GameObject based on finger gestures
public class SimpleMove : MonoBehaviour
{
	public GameObject thisObject;

	protected virtual void LateUpdate()
	{
		// This will move the current transform based on a finger drag gesture
		Lean.LeanTouch.MoveObject(thisObject.transform, Lean.LeanTouch.DragDelta);
	}
}