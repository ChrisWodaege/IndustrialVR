using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour {

    public bool hover = false;
	private bool isCourserOverObject = false;

    void Update () {
		if (isCourserOverObject == true) {
			if (Input.GetMouseButton (0)) {
				hover = true;
			}
		}
		if (Input.GetMouseButtonUp (0)) {
			hover = false;
			isCourserOverObject = false;
		}

    }

    public void OnMouseOver () {
        hover = true;
		isCourserOverObject = true;
    }

    public void OnMouseExit () {
        hover = false;

    }

}