namespace VRTK.Controllables.ArtificialBased
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using VRTK.Controllables;
	using VRTK.Examples;

	public class ActivateDeactivateObjects : MonoBehaviour
	{
		public GameObject switchGO;
		public GameObject[] weaPart;
		public GameObject[] scaleUpLabel;
		public GameObject[] scaleDownLabel;
		public GameObject[] enableDisableLabel;
		private bool visibility = true;

		private float switchstate;
		private float startValue = 90f;
		private Material mat;
	
		void Start ()
		{

			foreach (GameObject go in weaPart) {
				Debug.Log (go.name);
			}

			foreach (GameObject go in scaleUpLabel) {
				Debug.Log (go.name);
			}

			SetSwitchstateToStartValue ();
		}

		void Update ()
		{
			SetVisibility ();



		}

		void SetSwitchstateToStartValue ()
		{
			switchGO.GetComponent<VRTK_ArtificialRotator> ().SetValue (startValue);
			switchstate = switchGO.GetComponent<VRTK_ArtificialRotator> ().GetNormalizedValue ();
		}

		void SetVisibility ()
		{
			switchstate = switchGO.GetComponent<VRTK_ArtificialRotator> ().GetNormalizedValue ();

			foreach (GameObject go in weaPart) {

				mat = go.GetComponent<Renderer> ().material;
			
				EnableDisableLabel (switchstate);

				if (switchstate > 0.999) {
					FadeInObject (go);
				} else {
					FadeOutObject (go);
				}
			}
			ScaleUpLabel (switchstate);
			ScaleDownLabel (switchstate);
			setSwitchDisplayText (switchstate);
		
		}

		void FadeInObject (GameObject go)
		{
			
			mat.SetInt ("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
			mat.SetInt ("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
			mat.SetInt ("_ZWrite", 1);
			mat.DisableKeyword ("_ALPHATEST_ON");
			mat.DisableKeyword ("_ALPHABLEND_ON");
			mat.DisableKeyword ("_ALPHAPREMULTIPLY_ON");
			mat.renderQueue = -1;
		}

		void FadeOutObject (GameObject go)
		{
			mat.SetInt ("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
			mat.SetInt ("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
			mat.SetInt ("_ZWrite", 0);
			mat.DisableKeyword ("_ALPHATEST_ON");
			mat.EnableKeyword ("_ALPHABLEND_ON");
			mat.DisableKeyword ("_ALPHAPREMULTIPLY_ON");
			mat.renderQueue = 3000;

			Color currentColor = mat.color;
			currentColor.a = switchstate;
			mat.color = currentColor;

		}
		//scale up und scale down vor skallierung abfragen wie der skalierungswert ist. sonst werden label auf 1 gesetzt und skalliert die eigentlich gerade null sind oder halt label aktivieren und deaktivieren
		void ScaleUpLabel (float switchstate){
			float localState = 1;
			localState -= switchstate;

				foreach (GameObject go in scaleUpLabel) {
				if (switchstate > 0.0001 && switchstate < 0.999) {
					go.transform.localScale = new Vector3 (localState, localState, localState);
				}
			}
		}
		void ScaleDownLabel (float switchstate){
			foreach (GameObject go in scaleDownLabel) {
				if (switchstate > 0.0001 && switchstate < 0.999) {
					go.transform.localScale = new Vector3 (switchstate, switchstate, switchstate);
				}
			}
		}
		void EnableDisableLabel (float switchstate){
			/*
			if (inverse == false) {
				if (visibility == true && switchstate < 0.2) {
					visibility = false;
				}
				if (visibility == false && switchstate > 0.8) {
					visibility = true;
				}
			}

			*/
			//if (inverse == true) {
				if (visibility == true && switchstate > 0.999) {
					visibility = false;
				}
				if (visibility == false && switchstate < 0.999) {
					visibility = true;
				}
		//	}

			foreach (GameObject go in enableDisableLabel) {
				go.SetActive (visibility);
			}
		}

		void setSwitchDisplayText (float switchstate){
			
				if (switchstate > 0.5) {
					switchGO.GetComponent<ControllableReactor> ().displayText.text = "ON";
				} else {
					switchGO.GetComponent<ControllableReactor> ().displayText.text = "OFF";
				}
		
		}
}
}