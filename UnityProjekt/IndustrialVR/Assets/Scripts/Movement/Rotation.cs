using System.Collections;
using UnityEngine;
using UnityEngine.VR;
public class Rotation : MonoBehaviour {

	public float horizontalSpeed = 2.0F;
	public float zoomSpeed = 0.1F;
	private float currentPosition;
	public float maxDistance = 1.9999F;
	public float minDistance = -1.55F;
	public GameObject wea;

	void Update () {
		//If V is pressed, toggle VRSettings.enabled
		if (Input.GetKeyDown(KeyCode.V))
		{
			UnityEngine.XR.XRSettings.enabled = !UnityEngine.XR.XRSettings.enabled;
			Debug.Log("Changed VRSettings.enabled to:"+UnityEngine.XR.XRSettings.enabled);
		}
	}

	private void OnMouseDrag () {
		wea = GameObject.Find ("WEAPrefab");

		if (Input.GetMouseButton (0)) {
			float h = horizontalSpeed * Input.GetAxis ("Mouse X");
			transform.Rotate (0, -h, 0);

			currentPosition = transform.position.z;

			if (currentPosition <= minDistance + 0.0001F) {
				transform.position = new Vector3 (0, 0, minDistance);
			}
			if (currentPosition >= maxDistance - 0.0001F) {
				transform.position = new Vector3 (0, 0, maxDistance);
			}
			float v = zoomSpeed * Input.GetAxis ("Mouse Y");
			transform.Translate (new Vector3 (0, 0, v), Space.World);
		}


	}

}