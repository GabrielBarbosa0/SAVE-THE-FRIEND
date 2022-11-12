using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class DialogoController : MonoBehaviour {

	public GameObject painelDeDialogo;

	public Text falaNPC;

	public GameObject resposta;

	private bool falaAtiva = false;

	FalaNPC falas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButtonDown(0) && falaAtiva)
		{
			if (falas.respostas.Length > 0){
					MostrarRespostas();
			}
			else
			
			{
				falaAtiva = false;
				painelDeDialogo.SetActive(false);
				falaNPC.gameObject.SetActive(false);
				//FindObjectOfType<Player>().speed = 5;
			}
		}

	}

	void MostrarRespostas()
	{
		falaNPC.gameObject.SetActive(false);
		falaAtiva = false;

		for (int i = 0; i < falas.respostas.Length; i++)
		{

			GameObject tempResposta = Instantiate(resposta, painelDeDialogo.transform) as GameObject;
			tempResposta.GetComponent<Text>().text = falas.respostas[i].resposta;
			tempResposta.GetComponent<AnswerButton>().Setup(falas.respostas[i]);

			if(i>5){
				
			}
	    }
	
	//   if(falas.respostas[i]){

	//   }
	}

	public void ProximaFala(FalaNPC fala)
	{
		falas = fala;

		LimparRespostas();

		falaAtiva = true;
		painelDeDialogo.SetActive(true);
		falaNPC.gameObject.SetActive(true);

		falaNPC.text = falas.fala;

	}

	void LimparRespostas()
	{
		AnswerButton[] buttons = FindObjectsOfType<AnswerButton>();
		foreach(AnswerButton button in buttons)
		{
			Destroy(button.gameObject);
		}
	}
}
