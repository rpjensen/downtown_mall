using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Building : MonoBehaviour {

	public string buildingName;
	public Text buildingLabel;


	// Use this for initialization
	void Start () {
		buildingLabel = GameObject.Find ("BuildingLabel").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter() {
		print ("mouse in");
		buildingLabel.text = buildingName;
	}

	void OnMouseExit() {
		print ("mouse out");
		if (buildingLabel.text == buildingName) {
			buildingLabel.text = "";
		}
	}
}
