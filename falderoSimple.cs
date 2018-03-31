using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falderoSimple : MonoBehaviour {
	//este es para poner a un animal curioso que siga por un momento y se quede quieto despues
	public Transform player;
	public Animator anim;
	//static Animator anim;
	// Use this for initialization
	void Start () {
		//agrega las animaciones bool, ESTAS SE HACEN CON OPCION BOOL EN LOS PARAMETROS DEL"ANIMATOR" Y SE AGREGAN LOS NOMBRES.
		//anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (player.position, this.transform.position) < 12) 
		{
			Vector3 direction = player.position - this.transform.position;
			direction.y = 0;
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.5f);
			//corta la animacion Idle y da paso a la nueva animacion
			//anim.SetBool ("animationIdle", false);

			if (direction.magnitude > 5) {
				this.transform.Translate(0,0,0.08f);
				//agrega la animacion de correr para estar cerca.
				//anim.SetBool ("animRun" , true);
			}
		}
	}
}
