using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour 
{
	//valores para randomizar velocidad
	public float maxMoveForce = 5.0f;
	public float minMoveForce = 2.0f;

	public Transform player;

	public GameObject[] pickups;

	GameObject optimalPickup;

	float optimalDistance; //Distancia entre este objeto y el pickup más cercano

	enum State {Idle, Recollecting, Escaping}

	State currState;

	Rigidbody rb;

	float[] distPickUp;
	float[] distPlayer;


	// Use this for initialization
	void Awake () {
		distPickUp = new float[pickups.Length];
		distPlayer = new float[pickups.Length];
		currState = State.Recollecting;
		// player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();

		rb = GetComponent<Rigidbody> ();

		InvokeRepeating ("SelectTarget", 0.0f, 1.0f);
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		//float separation = Vector3.Distance (player.position, this.transform.position);
		switch (currState) {
		//case State.Recollecting:
		//Definimos la dirección tomando la posición del pickup y le damos una fuerza
		//Vector3 direction = optimalPickup.position - transform.position;
		//rb.AddForce (direction * Random.Range (minMoveForce, maxMoveForce));

		//	break;
		//}
		case State.Recollecting:
		//definimos la posicion del jugador y le damos una fuerza en la dirección opuesta al el

		if (optimalPickup.activeInHierarchy) {
			Vector3 direction = optimalPickup.transform.position - transform.position;
			rb.AddForce (direction.normalized * Random.Range (minMoveForce, maxMoveForce));
		} else {
			SelectTarget ();
		}
		break;
		case State.Escaping:
			Escape ();
			break;
		}
	}

	//función para seleccionar el objetivo óptimo
	public void SelectTarget()
	{
		optimalDistance = 100000.0f;
		float distToPlayer = Vector3.Distance (this.transform.position, player.position);
		//Se chequea uno por uno los pickups y se define el más cercano
		for (int i = 0; i < pickups.Length; i++) 
		{
				
			//	distPickUp [i] = Vector3.Distance (this.transform.position, pickups [i].transform.position);
			//	distPlayer [i] = Vector3.Distance (player.position, pickups [i].transform.position);
			float distPickUp1  = Vector3.Distance (this.transform.position, pickups [i].transform.position);
			float distPlayer1  = Vector3.Distance (player.position, pickups [i].transform.position);
			bool isSecure = distPlayer1 > distToPlayer;
			Debug.Log (isSecure);
			if (optimalDistance > distPickUp1 && isSecure && pickups [i].activeSelf)
			{
				
				optimalDistance = distPickUp1;
				optimalPickup = pickups [i];
				Debug.Log (optimalPickup);
			}
		}

		/*int[] arrayDeIndices= new int[distPickUp.Length];
		float[] copiaPickUp = new float[distPickUp.Length];

		System.Array.Copy (distPickUp, copiaPickUp, distPickUp.Length);

		float menorParaSort = 1000000.0f;

		for (int j = 0; j < arrayDeIndices.Length; j++) { 
			for (int i = 0; i < distPickUp.Length; i++) {
				if (menorParaSort > copiaPickUp [i]) {
					menorParaSort = copiaPickUp [i];
					arrayDeIndices [j] = i;
				}
			}
			menorParaSort = 1000000.0f;
			copiaPickUp[arrayDeIndices[j]] = 100000.0f;
		}

		float distPlayerEnemy = Vector3.Distance (this.transform.position, player.position);

		for (int i = 0; i < arrayDeIndices.Length; i++) {
			if (distPlayerEnemy < distPlayer [arrayDeIndices [i]]) {
				Debug.Log ("si entro");
				optimalPickup = pickups [arrayDeIndices [i]];
				break;
			}
			if (i == arrayDeIndices.Length-1) {
				for (int j = 0;j<arrayDeIndices.Length;j++)
				{
					if (pickups [arrayDeIndices [j]].activeSelf)
						optimalPickup = pickups [arrayDeIndices [j]];
					else
						Escape ();
				}
			}
		}

		Debug.Log(optimalPickup);
		System.Array.Sort(
		for (int i = 0; i < distPickUp.Length; i++) { 
			Debug.Log (arrayDeIndices[i]);

		}
		for (int i = 0; i < distPickUp.Length; i++) { 
			Debug.Log (distPickUp[arrayDeIndices[i]]);

		}
		for (int i = 0; i < distPickUp.Length; i++) { 
			Debug.Log (distPlayer[arrayDeIndices[i]]);

		}*/


	}
	void Escape (){
		Vector3 direction = transform.position - player.position;
		rb.AddForce (direction.normalized * Random.Range (minMoveForce, maxMoveForce));


	}
		
}

