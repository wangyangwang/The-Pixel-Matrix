using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Destroy", 2f);
	}
	
    void Destroy(){
        Destroy(gameObject);
    }
}
