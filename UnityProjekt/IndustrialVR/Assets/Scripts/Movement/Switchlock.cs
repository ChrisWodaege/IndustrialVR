namespace VRTK.Controllables.ArtificialBased
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using VRTK.Controllables;


	public class Switchlock : MonoBehaviour
	{

		public GameObject activeSwitch;
		public GameObject[] unlockLock;
	
		private float switchstate;

		void Update ()
		{
		
			switchstate = activeSwitch.GetComponent<VRTK_ArtificialRotator> ().GetNormalizedValue ();

			if (switchstate > 0.9) {
				lockSwitch ();
			}
			unlockSwitch ();
			if (switchstate < 0.1) {
				
			}
		}

		void lockSwitch ()
		{
			foreach (GameObject go in unlockLock) {
				go.GetComponent<VRTK_ArtificialRotator> ().enabled = true;
			}
		}

		void unlockSwitch ()
		{
			foreach (GameObject go in unlockLock) {
				go.GetComponent<VRTK_ArtificialRotator> ().enabled = false;
			}
		}
	}
}
