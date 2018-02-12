using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMe : MonoBehaviour {

    public CaptureColor captureColor;

    private void Start()
    {
        captureColor.OnCubeMatrixCreated += Rotate;
    }

    // Use this for initialization
    void Rotate(){
        transform.RotateAround(transform.position, Vector3.forward, 90);
    }

}
