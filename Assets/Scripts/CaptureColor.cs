using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureColor : MonoBehaviour {


    RenderTexture tvContent;
    Camera tvCamera;
    int textureW = 32;
    int textureH = 32;

    GameObject[,] cubeMatrix;



    [Range(10, 100)]
    public float mult = 10;
    public Transform matrixContainer;


    // Use this for initialization
    void Start()
    {
        tvContent = RenderTexture.GetTemporary(textureW, textureH, 24);
        tvCamera = GetComponent<Camera>();
        tvCamera.targetTexture = tvContent;
        RenderTexture.active = tvContent;

        int size = 1;
        cubeMatrix = new GameObject[textureW, textureH];

        for (int x = 0; x < textureW; x++){
            for (int y = 0; y < textureH; y++){
                GameObject newOne = GameObject.CreatePrimitive(PrimitiveType.Cube);
                newOne.AddComponent<CubePixel>();
                Rigidbody rb = newOne.AddComponent<Rigidbody>();
                rb.isKinematic = true;
                newOne.transform.position = new Vector3(size * x, 0f, size * y);
                if (matrixContainer != null) newOne.transform.parent = matrixContainer;
                cubeMatrix[x, y] = newOne;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        tvCamera.Render();
    }

    void OnPostRender()
    {
        Texture2D tex = new Texture2D(textureW, textureH, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(0, 0, textureW, textureH), 0, 0);
        tex.Apply();
        float r = 0;
        float g = 0;
        float b = 0;
        int counter = 0;
       
        for (int y = 0; y < tex.height; y++)
        {
            for (int x = 0; x < tex.width; x++)
            {
                r += tex.GetPixel(x, y).r;
                g += tex.GetPixel(x, y).g;
                b += tex.GetPixel(x, y).b;
                counter++;
                CubePixel cp = cubeMatrix[x, y].GetComponent<CubePixel>();
                cp.Color = tex.GetPixel(x, y);
                float pixelGreyscale = tex.GetPixel(x, y).grayscale;
                cp.ScaleFactor = pixelGreyscale * mult;
            }
        }



        Color averageColor = new Color(r / counter, g / counter, b / counter);
        //dLight.color = averageColor;
        //RenderSettings.fogColor = averageColor;
        //RenderSettings.ambientLight = averageColor;


    }

}
