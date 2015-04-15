using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

	public static CameraController S;

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

	public GameObject goToggleIntroButton;
	public GameObject goBuildingLabel;

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

	private Button toggleIntroButton;
	private Vector3 _initRotation;
	private Vector3 _initPosition;
	private Vector3 _rotation;
	private bool _introUp;

	private GameObject[] cameraTagged;
	private GameObject[] introTagged;

	void Awake() {
		S = this;
	}

	// Use this for initialization
	void Start () {
		_initPosition = new Vector3 (0, 10, 0);
		transform.position = _initPosition;

		_initRotation = new Vector3 (90, 0, 0);
		_rotation = _initRotation;
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


		// Get the camera tagged objects (can't find by tag once they are inactive)
		cameraTagged = GameObject.FindGameObjectsWithTag ("CameraControl");
		// Get the intro tagged objects (can't find by tag once they are inactive)
		introTagged = GameObject.FindGameObjectsWithTag ("Intro");

		toggleIntroButton = goToggleIntroButton.GetComponent<Button> ();
		toggleIntroButton.onClick.AddListener(() => ToggleIntro ());

		// start false so toggle immediately makes it true
		_introUp = false;
		ToggleIntro ();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ToggleIntro() {
		// The text on the button
		string introButtonText = "";
		if (_introUp) {
			// If the intro is showing now disable it
			// Next click the button will show intro
			introButtonText = "Show Intro";
			DisableIntro();// Disable the intro Game objects
			EnableControls();// Enable the controls
		} else {
			// else the controls are showing so show the intro
			// next click will go back to the world view
			introButtonText = "Begin";
			DisableControls();// Disable the controls
			EnableIntro();// enable the intro
			transform.position = _initPosition;// make sure the camera is back at the top
			//_rotation = _initRotation;
			transform.rotation = Quaternion.Euler(_initRotation);// make sure it is pointing the correct way
		}
		// Set the button text
		toggleIntroButton.GetComponentInChildren<Text>().text = introButtonText;
		_introUp = !_introUp;// Toggle the boolean
	}

	void EnableControls () {
		for (int i = 0; i < cameraTagged.Length; i++) {
			cameraTagged[i].SetActive(true);
		}
	}

	void DisableControls() {
		for (int i = 0; i < cameraTagged.Length; i++) {
			cameraTagged[i].SetActive(false);
		}
	}

	void EnableIntro() {
		for (int i = 0; i < introTagged.Length; i++) {
			introTagged[i].SetActive(true);
		}
	}

	void DisableIntro() {
		for (int i = 0; i < introTagged.Length; i++) {
			introTagged[i].SetActive(false);
		}
	}

	void Up () {
		// Pos Z
		print ("Up called");
		Vector3 mult = transform.up;
		mult.y = 0;
		mult.Normalize ();
		transform.position += Time.deltaTime * translationSensitivity * mult;
		FixConstraints ();
	}

	void Down () {
		// Neg Z
		print ("Down called");
		Vector3 mult = transform.up;
		mult.y = 0;
		mult.Normalize ();
		transform.position += Time.deltaTime * translationSensitivity * -mult;
		FixConstraints ();
	}

	void Left () {
		// Neg X
		print ("Left called");
		transform.position += Time.deltaTime * translationSensitivity * -transform.right;
		FixConstraints ();
	}

	void Right () {
		// Pos X
		print ("Right called");
		transform.position += Time.deltaTime * translationSensitivity * transform.right;
		FixConstraints ();
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
		FixConstraints ();

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
		FixConstraints ();
	}
	
	void RotateLeft () {
		// Global Y minus
		print ("Rleft called");
		_rotation.y -= Time.deltaTime * rotationSensitivity;
		transform.rotation = Quaternion.Euler (_rotation);
		FixConstraints ();
	}
	
	void RotateRight () {
		// Global Y Plus
		print ("RRight called");
		_rotation.y += Time.deltaTime * rotationSensitivity;
		transform.rotation = Quaternion.Euler (_rotation);
		FixConstraints ();
	}

	void ZoomIn () {
		// Local Z plus
		print ("Zin called");
		transform.position += transform.forward * Time.deltaTime * zoomSensitivity;
		FixConstraints ();
	}
	
	void ZoomOut () {
		// Local Z minus
		print ("Zout called");
		transform.position -= transform.forward * Time.deltaTime * zoomSensitivity;
		FixConstraints ();
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
		if (_rotation.x > maxTilt) {
			_rotation.x = maxTilt;
			transform.rotation = Quaternion.Euler(_rotation);
		}
		if (_rotation.x < minTilt) {
			_rotation.x = minTilt;
			transform.rotation = Quaternion.Euler(_rotation);
		}

	}
}
