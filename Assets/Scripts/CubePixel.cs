using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePixel : MonoBehaviour
{


    Renderer rend;
    Color color;
    float scaleFactor;
    float size;

    float colorSmoother = 0.02f;
    float scaleFactorSmoother = 0.02f;

    public float Size
    {
        set
        {
            size = value;
            transform.localScale = new Vector3(value, value, value);
        }
        private get
        {
            return size;
        }
    }

    public Color Color
    {
        set
        {
            if (rend != null)
            {
                Color offset = value - color;
                offset *= colorSmoother;
                color += offset;
                rend.material.SetColor("_Color", color);
                //rend.material.SetColor("_EmissionColor", color);
            }
            else
            {
                Debug.LogError("no renderer");
            }
        }
    }

    public float ScaleFactor
    {
        set
        {
            float offset = value - scaleFactor;
            offset *= scaleFactorSmoother;
            scaleFactor += offset;
            transform.localScale = new Vector3(size, size * scaleFactor, size);
        }
    }





    void Start()
    {
        rend = GetComponent<Renderer>();
        //rend.material.SetFloat("_Glossiness", 1f);
        ////rend.material.SetFloat("_Metallic", 1f);
    }


    void FixedUpdate()
    {

    }
}
