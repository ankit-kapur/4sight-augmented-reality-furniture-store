using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//#define MAX_NO 10

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
//		GameObject[] objs = GameObject.FindGameObjectsWithTag ("furniture");
		string selectedFurniture = global_stuff.selectedFurniture;


			

		/*
		GameObject arCamera = GameObject.Find ("ARCamera");
		Vector3 closestP = arCamera.GetComponent<Transform> ().position;
		closestP.x =  0 - closestP.x;
		closestP.y =  closestP.y;
		text.transform.position = closestP;
		*/

		if (text != null) {
			text.text = "";
			int sumPrice = 0;
//			foreach (GameObject obj in objs) {
			if (selectedFurniture != null) {
				GameObject obj = GameObject.Find (selectedFurniture);
				
				Vector3 vec = obj.GetComponent<Renderer> ().bounds.size;
				string name = obj.name;
				furnPrice price = obj.GetComponent<furnPrice> ();
				sumPrice += price.price;
				if (obj.activeSelf == true) {
					text.text = text.text + "------------------\n";
					text.text = text.text + name + "\n";
					text.text = text.text + "$" + price.toString () + "\n";
					text.text = text.text + (int)vec.x + "\' x " + (int)vec.y + "\' x " + (int)vec.z + "\'\n";
				}
			}
			text.text = "Furniture details\n" + "Price: $" + sumPrice.ToString () + "\n" + text.text; 
		}
	}
}
