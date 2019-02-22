using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSomeNoise : MonoBehaviour
{
    //perlin noise for waterwaves

    public float power = 3;
    public float scale = 1;
    public float timeScale = 1;

    private float XOffset;
    private float yOffset;
    private MeshFilter mf;

    // Use this for initialization
    void Start()
    {
        mf = GetComponent<MeshFilter>();
        MakeNoise();
    }

    // Update is called once per frame
    void Update()
    {
        MakeNoise();
        XOffset += Time.deltaTime * timeScale;
        yOffset += Time.deltaTime * timeScale;
    }

    void MakeNoise()
    {
        Vector3[] vertices = mf.mesh.vertices; //mesh filter vertices
        for (int i = 0; i < vertices.Length; i++) //height vertices
        {
            vertices[i].y = CalculateHeight(vertices[i].x, vertices[i].z) * power;
        }

        mf.mesh.vertices = vertices;
    }

    float CalculateHeight(float x, float y)
    {
        float xCord = x * scale + XOffset;
        float yCord = y * scale + yOffset;

        return Mathf.PerlinNoise(xCord, yCord);
    }
}





