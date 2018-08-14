namespace VRTK.Controllables.ArtificialBased
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using VRTK.Controllables;

	public class StartStopAnimation : MonoBehaviour
	{

		Animator anim;
		public GameObject switchGO;
		float switchstate;

		void Start ()
		{
			anim = GetComponent<Animator> ();	
			switchGO.GetComponent<VRTK_ArtificialRotator> ().SetValue (90);
		}


		void Update ()
		{
		
			switchstate = switchGO.GetComponent<VRTK_ArtificialRotator> ().GetNormalizedValue ();

			anim.SetFloat ("startStopValue", switchstate);	
		}
	}
}