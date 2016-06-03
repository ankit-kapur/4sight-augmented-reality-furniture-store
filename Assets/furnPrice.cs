using UnityEngine;
using System.Collections;

public class furnPrice : MonoBehaviour {
	public int price;

	// Use this for initialization
	void Start () {
		price = 20;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vec = GetComponent<Renderer> ().bounds.size;
		if (vec.x != 0)
			price = (int)vec.x;
		if (vec.y != 0)
			price = price * (int)vec.y;
		if (vec.z != 0)
			price = price * (int)vec.z;
		price = price / 2000 + 20;
	}

	public string toString () {
		return price.ToString ();
	}
}
