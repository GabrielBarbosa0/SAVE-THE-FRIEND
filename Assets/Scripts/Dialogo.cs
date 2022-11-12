using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialogo : MonoBehaviour {

	public FalaNPC[] falas = new FalaNPC[2];

	private bool dialogoConcluido = false;

	DialogoController dialogoController;

	// Use this for initialization
	void Start () {

		dialogoController = FindObjectOfType<DialogoController>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			//other.GetComponent<Player>().speed = 0;

			if (!dialogoConcluido)
			{
				dialogoController.ProximaFala(falas[0]);
			}
			else
			{
				dialogoController.ProximaFala(falas[1]);
						

			}
			// if( ){

            //  SceneManager.LoadScene("LevelCombat" , LoadSceneMode.Single);
			// }

 		
		}
	}
}
