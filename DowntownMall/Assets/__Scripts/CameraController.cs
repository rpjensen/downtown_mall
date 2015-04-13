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

	public float maxZ = 12f;
	public float minZ = -12f;
	public float minX = -18f;
	public float maxX = 18f;
	public float maxY = 10f;
	public float minY = 1f;
	public float maxTilt = 90f;
	public float minTilt = 30f;

	public float translationSensitivity = 1f;
	public float rotationSensitivity = 1f;
	public float tiltSensitivity = 1f;
	public float zoomSensitivity = 1f;

	public bool _____________________;

	private Vector3 _rotation;



	// Use this for initialization
	void Start () {
		/*
		//this.gameObject.GetComponent<CameraButton> ().SetFun (Fun);
		this.gameObject.GetComponent<CameraButton> ().Call();
		//this.gameObject.GetComponent<CameraButton> ().SetFun (Fun2);
		this.gameObject.GetComponent<CameraButton> ().Call();
		*/

		_rotation = new Vector3 (90, 0, 0);
		transform.rotation = Quaternion.Euler(_rotation);

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
		Vector3 mult = transform.up;
		mult.y = 0;
		mult.Normalize ();
		transform.position += Time.deltaTime * translationSensitivity * mult;

	}

	void Down () {
		// Neg Z
		print ("Down called");
		Vector3 mult = transform.up;
		mult.y = 0;
		mult.Normalize ();
		transform.position += Time.deltaTime * translationSensitivity * -mult;
	}

	void Left () {
		// Neg X
		print ("Left called");
		Vector3 pos = transform.position;
		transform.position += Time.deltaTime * translationSensitivity * -transform.right;
	}

	void Right () {
		// Pos X
		print ("Right called");
		Vector3 pos = transform.position;
		transform.position += Time.deltaTime * translationSensitivity * transform.right;
	}

	void RotateUp () {
		// Local X minus
		print ("RUP called");

		//transform.RotateAround(transform.position, transform.right, Time.deltaTime * -rotationSensitivity);
		/*Vector3 rotation = transform.rotation.eulerAngles;
		rotation.x += Time.deltaTime * rotationSensitivity;
		transform.rotation = Quaternion.Euler (rotation);
		 transform.Rotate (transform.right, -Time.deltaTime * tiltSensitivity);*/
		_rotation.x -= Time.deltaTime * tiltSensitivity;
		transform.rotation = Quaternion.Euler (_rotation);

	}
	
	void RotateDown () {
		// Local X plus
		print ("RDown called");

		//transform.RotateAround(transform.position, transform.right, Time.deltaTime * rotationSensitivity);
		/*Vector3 rotation = transform.rotation.eulerAngles;
		rotation.x -= Time.deltaTime * rotationSensitivity;
		transform.rotation = Quaternion.Euler (rotation);
		transform.Rotate (transform.right, Time.deltaTime * tiltSensitivity);*/
		_rotation.x += Time.deltaTime * tiltSensitivity;
		transform.rotation = Quaternion.Euler (_rotation);
	}
	
	void RotateLeft () {
		// Global Y minus
		print ("Rleft called");
		Vector3 rotation = transform.rotation.eulerAngles;

		rotation.y -= Time.deltaTime * rotationSensitivity;
		transform.rotation = Quaternion.Euler (rotation);
	}
	
	void RotateRight () {
		// Global Y Plus
		print ("RRight called");
		Vector3 rotation = transform.rotation.eulerAngles;
		rotation.y += Time.deltaTime * rotationSensitivity;
		transform.rotation = Quaternion.Euler (rotation);
	}

	void ZoomIn () {
		// Local Z plus
		print ("Zin called");
		Vector3 pos = transform.position;
		transform.position += transform.forward * Time.deltaTime * zoomSensitivity;
	}
	
	void ZoomOut () {
		// Local Z minus
		print ("Zout called");
		transform.position -= transform.forward * Time.deltaTime * zoomSensitivity;
	}

	void FixConstraints() {
		if (transform.position.x < minX) {
			Vector3 pos = transform.position;
			pos.x = minX;
			transform.position = pos;
		}
		if (transform.position.x > maxX) {
			Vector3 pos = transform.position;
			pos.x = maxX;
			transform.position = pos;
		}
		if (transform.position.z < minZ) {
			Vector3 pos = transform.position;
			pos.z = minZ;
			transform.position = pos;
		}
		if (transform.position.z > maxZ) {
			Vector3 pos = transform.position;
			pos.z = maxZ;
			transform.position = pos;
		}
		if (transform.position.y < minY) {
			Vector3 pos = transform.position;
			pos.y = minY;
			transform.position = pos;
		}
		if (transform.position.y > maxY) {
			Vector3 pos = transform.position;
			pos.y = maxY;
			transform.position = pos;
		}
		/*if (transform.rotation.eulerAngles.z > 0) {
			Vector3 rot = transform.rotation.eulerAngles;
			rot.x = 90;
			rot.z = 0;
			transform.rotation = Quaternion.Euler(rot);
		}*/

	}
}
