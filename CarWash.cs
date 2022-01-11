using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWash : MonoBehaviour
{
    public Mesh mesh;
    public Color[] vertexColors;
    int vertexLength;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;

        vertexLength = mesh.vertices.Length;

        vertexColors = new Color[vertexLength];

        RandomDirty();
    }

    public void RandomDirty()
    {
        for (int i = 0; i < vertexLength; i++)
        {
            vertexColors[i] = Color.Lerp(Color.black, Color.white, Random.Range(0f, 1f));
        }
        mesh.colors = vertexColors;
    }

    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.gameObject.tag == "shouldWash")
                {
                    Vector3[] carVertices = mesh.vertices;
                    for (int i = 0; i < vertexLength; i++)
                    {
                        float vertDist = Vector3.Distance(transform.TransformPoint(carVertices[i]), hit.point);
                        float formula = 0.1f / vertDist;
                        if (vertDist < 0.1f && vertexColors[i].r < formula)
                        {
                            vertexColors[i] = Color.Lerp(Color.black, Color.white, formula);
                        }
                    }
                    mesh.colors = vertexColors;
                }
            }
        }
    }
}
