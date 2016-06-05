using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class dmText : MonoBehaviour {
	Text text;

	void Awake () {
		text = GetComponent<Text> ();
	}
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	public void Update () {
		string selectedFurniture = global_stuff.selectedFurniture;

		if (text != null) {
			text.text = "";
			int sumPrice = 0;
			if (selectedFurniture != null) {
				GameObject obj = GameObject.Find (selectedFurniture);
				
				Vector3 vec = obj.GetComponent<Renderer> ().bounds.size;
				furnPrice price = obj.GetComponent<furnPrice> ();
				sumPrice += price.price;
				if (obj.activeSelf == true) {
					text.text = text.text + "Price: $" + price.toString () + "\n";
					text.text = text.text + "Dimensions: " + (int)vec.x + "\' x " + (int)vec.y + "\' x " + (int)vec.z + "\'\n";
				}
			}
		}
	}
}
