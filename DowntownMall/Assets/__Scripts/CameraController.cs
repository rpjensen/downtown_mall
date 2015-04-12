using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

	public GameObject goUpButton;
	public GameObject goDownButton;
	public GameObject goLeftButton;
	public GameObject goRightButton;

	public GameObject goRotateUp;
	public GameObject goRotateDown;
	public GameObject goRotateLeft;
	public GameObject goRotateRight;

	public GameObject goZoomIn;
	public GameObject goZoomOut;

	public float maxTop = 12f;
	public float maxBottom = -12f;
	public float maxLeft = -18f;
	public float maxRight = 18f;
	public float maxHeight = 10f;
	public float minHeight = 1f;
	public float maxTilt = 90f;
	public float minTilt = 30f;

	public float translationSensitivity = 1f;
	public float rotationSensitivity = 1f;
	public float zoomSensitivity = 1f;

	public bool _____________________;



	// Use this for initialization
	void Start () {
		/*
		//this.gameObject.GetComponent<CameraButton> ().SetFun (Fun);
		this.gameObject.GetComponent<CameraButton> ().Call();
		//this.gameObject.GetComponent<CameraButton> ().SetFun (Fun2);
		this.gameObject.GetComponent<CameraButton> ().Call();
		*/

		CameraButton upButton = goUpButton.GetComponent<CameraButton> ();
		upButton.SetCallback(Up);
		/*
		Button downButton = goDownButton.GetComponent<Button> ();
		downButton.onClick.AddListener (() => Down ());

		Button leftButton = goLeftButton.GetComponent<Button> ();
		leftButton.onClick.AddListener (() => Left ());

		Button rightButton = goRightButton.GetComponent<Button> ();
		rightButton.onClick.AddListener (() => Right ());

		Button rotUpButton = goRotateUp.GetComponent<Button> ();
		rotUpButton.onClick.AddListener (() => RotateUp ());

		Button rotDownButton = goRotateDown.GetComponent<Button> ();
		rotDownButton.onClick.AddListener (() => RotateDown ());

		Button rotRightButton = goRotateRight.GetComponent<Button> ();
		rotRightButton.onClick.AddListener (() => RotateRight ());

		Button rotLeftButton = goLeftButton.GetComponent<Button> ();
		rotLeftButton.onClick.AddListener (() => RotateLeft ());

		Button zoomInButton = goZoomIn.GetComponent<Button> ();
		zoomInButton.onClick.AddListener (() => ZoomIn ());

		Button zoomOutButton = goZoomOut.GetComponent<Button> ();
		zoomOutButton.onClick.AddListener (() => ZoomOut ());
		*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Up () {
		// Pos Z
		//print ("Up called");

	}

	void Down () {
		// Neg Z
	}

	void Left () {
		// Neg X
	}

	void Right () {
		// Pos X
	}

	void RotateUp () {
		// Local X minus
	}
	
	void RotateDown () {
		// Local X plus
	}
	
	void RotateLeft () {
		// Global Y minus
	}
	
	void RotateRight () {
		// Global Y Plus
	}

	void ZoomIn () {
		// Local Z plus
	}
	
	void ZoomOut () {
		// Local Z minus
	}
}
