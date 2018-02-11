using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePixel : MonoBehaviour {


    Renderer rend;
    Color color;
    float scaleFactor;

    float colorSmoother = 0.02f;
    float scaleFactorSmoother = 0.02f;

    public Color Color {
        set {
            if(rend!=null){
                Color offset = value - color;
                offset *= colorSmoother;
                color += offset;
                rend.material.SetColor("_Color", color);
            }else{
                Debug.LogError("no renderer");
            }
        }
    }

    public float ScaleFactor {
        set {
            float offset = value - scaleFactor;
            offset *= scaleFactorSmoother;
            scaleFactor += offset;
            transform.localScale = new Vector3(1, scaleFactor, 1);
        }
    }





	void Start () {
        rend = GetComponent<Renderer>();
	}
	

	void FixedUpdate () {
        
	}
}
