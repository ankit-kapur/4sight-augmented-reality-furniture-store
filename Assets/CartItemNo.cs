using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CartItemNo : MonoBehaviour {
	Text text;
	private static int noItem;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		noItem = 0;
	}

	public void addItem() {
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("furniture");
		noItem += objs.Length;
	}
	
	// Update is called once per frame
	void Update () {
		text = GetComponent<Text> ();
		if (text != null) {
			text.text = noItem.ToString ();
		}
	}
}
