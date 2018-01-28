using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour {

	NPCController npcCont;

	void Awake()
	{
		npcCont = GetComponent<NPCController> ();
	}

	void OnTriggerEnter (Collider coll)
	{
		if (coll.gameObject.tag == "NPC") {
			
			gameObject.SetActive (false);
			npcCont.SelectTarget ();
		}
	}
}
