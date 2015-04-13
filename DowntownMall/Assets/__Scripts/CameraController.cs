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

		CameraButton downButton = goDownButton.GetComponent<CameraButton> ();
		downButton.SetCallback(Down);

		CameraButton rightButton = goRightButton.GetComponent<CameraButton> ();
		rightButton.SetCallback(Right);

		CameraButton leftButton = goLeftButton.GetComponent<CameraButton> ();
		leftButton.SetCallback(Left);

		CameraButton rotRightButton = goRotateRight.GetComponent<CameraButton> ();
		rotRightButton.SetCallback(RotateRight);

		CameraButton rotLeftButton = goRotateLeft.GetComponent<CameraButton> ();
		rotLeftButton.SetCallback(RotateLeft);

		CameraButton rotUpButton = goRotateUp.GetComponent<CameraButton> ();
		rotUpButton.SetCallback(RotateUp);

		CameraButton rotDownButton = goRotateDown.GetComponent<CameraButton> ();
		rotDownButton.SetCallback(RotateDown);

		CameraButton zoomInButton = goZoomIn.GetComponent<CameraButton> ();
		zoomInButton.SetCallback(ZoomIn);

		CameraButton zoomOutButton = goZoomOut.GetComponent<CameraButton> ();
		zoomOutButton.SetCallback(ZoomOut);


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Up () {
		// Pos Z
		print ("Up called");

	}

	void Down () {
		// Neg Z
		print ("Down called");
	}

	void Left () {
		// Neg X
		print ("Left called");
	}

	void Right () {
		// Pos X
		print ("Right called");
	}

	void RotateUp () {
		// Local X minus
		print ("RUP called");
	}
	
	void RotateDown () {
		// Local X plus
		print ("RDown called");
	}
	
	void RotateLeft () {
		// Global Y minus
		print ("Rleft called");
	}
	
	void RotateRight () {
		// Global Y Plus
		print ("RRight called");
	}

	void ZoomIn () {
		// Local Z plus
		print ("Zin called");
	}
	
	void ZoomOut () {
		// Local Z minus
		print ("Zout called");
	}
}
