using UnityEngine;
using System.Collections;

public class changeMaterial : MonoBehaviour {

	public void changeTheMaterial(Material newMaterial) {

		/* Get the selected furniture object */
		GameObject selectedObject = GameObject.Find (global_stuff.selectedFurniture);

		MeshRenderer meshRenderer = selectedObject.GetComponent<MeshRenderer> ();
		meshRenderer.material = newMaterial;
	}
}
