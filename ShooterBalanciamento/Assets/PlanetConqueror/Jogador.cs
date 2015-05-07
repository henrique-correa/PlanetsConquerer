using UnityEngine;
using System.Collections;

public class Jogador : MonoBehaviour {

	[SerializeField]float velocidade_X;
	[SerializeField]float velocidade_Y;
	[SerializeField]float vida;
	[SerializeField]float dano;
	[SerializeField]float Jogador_velocidade_tiro;
	[SerializeField]float Jogador_cadencia_tiro;
	float Jogador_proximo_tiro = 0.0f;
	float move_X;
	float move_Y;
	GameObject Jog;


	// Use this for initialization
	void Start () {
		Jog = GameObject.FindGameObjectWithTag("Player");

	
	}
	
	// Update is called once per frame
	void Update () {
		Jogador_move();
		if(Input.GetKey(KeyCode.Space)){
			Jogdor_atira();

		}

	
	}


	void Jogador_move(){
		move_X = Input.GetAxis("Horizontal") * velocidade_X;
		//transform.Translate(move_X,0,0);
		
		move_Y = Input.GetAxis("Vertical") * velocidade_Y;
		//transform.Translate(0,0,move_Y);

		gameObject.GetComponent<Rigidbody>().velocity = new Vector3 (move_X, 0, move_Y) ;
	}

	void Jogdor_atira(){
		if(Time.time > Jogador_proximo_tiro){
			Jogador_proximo_tiro = Time.time + Jogador_cadencia_tiro;
			float Jog_vel_tiro;

			GameObject Jogador_tiro = Instantiate(Resources.Load("Jogador_tiro"),transform.position,Quaternion.identity) as GameObject;
			Physics.IgnoreCollision(gameObject.GetComponent<Rigidbody>().GetComponent<Collider>() , Jogador_tiro.GetComponent<Rigidbody>().GetComponent<Collider>());

			if(gameObject.GetComponent<Rigidbody>().velocity.z < 0){
				Jog_vel_tiro = Jogador_velocidade_tiro;
			}
			else{
				Jog_vel_tiro = Jogador_velocidade_tiro + gameObject.GetComponent<Rigidbody>().velocity.z;
			}

			Jogador_tiro.GetComponent<Rigidbody>().velocity += new Vector3(0.0f,0.0f,1.0f) * Jog_vel_tiro;

		}
	}
}


