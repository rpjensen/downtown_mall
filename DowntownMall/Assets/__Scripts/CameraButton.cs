using UnityEngine;
using System.Collections;

public class CameraButton : MonoBehaviour {

	public delegate void Callback();
	public Callback callback;

	private bool _callFunction = false;

	// Use this for initialization
	void Start () {
		callback = DefaultCallback;
	}
	
	// Update is called once per frame
	void Update () {
		if (_callFunction) {
			callback();
		}
	}

	public void SetCallback (Callback callback) {
		this.callback = callback;
	}

	public void ResetCallback () {
		this.callback = DefaultCallback;
	}

	public void MouseDown() {
		print ("On mouse down");
		_callFunction = true;
	}

	public void MouseUp() {
		print ("On mosue up");
		_callFunction = false;
	}


	private void DefaultCallback() {
		// Do nothing
	}
}
