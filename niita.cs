using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class niita : MonoBehaviour {
	//este es para poner a un animal curioso que siga por un momento y se quede quieto despues
	public Transform player;
	public Animator anim;
	//static Animator anim;

	// Use this for initialization
	void Start () {
		//agrega las animaciones bool, ESTAS SE HACEN CON OPCION BOOL EN LOS PARAMETROS DEL"ANIMATOR" Y SE AGREGAN LOS NOMBRES.
		anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (player.position, this.transform.position) < 5) 
		{
			Vector3 direction = player.position - this.transform.position;
			direction.y = 0;
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);
			//corta la animacion Idle y da paso a la nueva animacion
			anim.SetBool ("animIdle", false);
		

			if (direction.magnitude > 2.5f) {
				this.transform.Translate(0,0.07f,0.07F);
				//agrega la animacion de correr para estar cerca.
				anim.SetBool ("animRun" , true);
				anim.SetBool ("animIdle", false);
				anim.SetBool ("animJump", false);
			}

			 else 
			{
				anim.SetBool ("animRun", false);
				anim.SetBool ("animIdle", true);
				anim.SetBool ("animJump",false);
			}


		}
		else 
		{
			anim.SetBool ("animRun", false);
			anim.SetBool ("animIdle", true);
			anim.SetBool ("animJump", false);

		}
	}

}
