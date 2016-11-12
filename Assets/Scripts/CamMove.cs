using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour {

	public Transform camposone;
	public Transform campostwo;

	public void FieldCam(){
		this.gameObject.transform.position = campostwo.position;
	}

	public void KitchenCam(){
		this.gameObject.transform.position = camposone.position;
	}
}
