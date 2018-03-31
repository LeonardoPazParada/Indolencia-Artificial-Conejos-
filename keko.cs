using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keko : MonoBehaviour {
	public Transform player;
	public Animator anim;
	//static Animator anim;
	// Use this for initialization
	void Start () {
		//agrega las animaciones bool . ESTAS SE HACEN CON OPCION BOOL EN LOS PARAMETROS DEL"ANIMATOR" Y SE AGREGAN LOS NOMBRES.
		anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (player.position, this.transform.position) < 10) 
		{
			Vector3 direction = player.position - this.transform.position;
			direction.y = 0;
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (-direction), 0.1f);
			//corta la animacion Idle y da paso a la nueva animacion
			anim.SetBool ("animIdle", false);
			//anim.SetBool ("animRun" , false);
			//anim.SetBool ("animJump" , true);

			if (direction.magnitude >7) 
			{
				this.transform.Translate (0, 0, 0.03f);
				//agrega la animacion de correr y escapar del conejo
				anim.SetBool ("animRun", false);
				//anim.SetBool ("animIdle", false);
				anim.SetBool ("animJump", true);
			}
		
			if (direction.magnitude < 7) {
				this.transform.Translate(0,0.05f,0.9f);
				//agrega la animacion de correr y escapar del conejo
				anim.SetBool ("animJump" , false);
				anim.SetBool ("animRun" , true);
				anim.SetBool ("animIdle" , false);
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
