using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class renderPoints : MonoBehaviour
{
    [SerializeField] private TextAsset vertexData;

    Vector3[] vertices = new Vector3[1115322];

    public GameObject myPrefab;

    // Start is called before the first frame update
    void Start()
    {

        readTextFile();

    }

    void readTextFile()
    {
        if (!vertexData)
            Debug.LogWarning("vertexdata not found");

        string[] splitfile = new[] { "\r\n", "\n", "\r" };
        char[] splitchars = new[] { ' ', '\t' };

        string[] vertexLines = vertexData.text.Split(splitfile, System.StringSplitOptions.RemoveEmptyEntries);

        //int vertexNumLines = int.Parse(vertexLines[0]);

        for (int i = 1; i < vertices.Length + 1;)
        {
            //Debug.Log("insert vertecies");
            var xyz = vertexLines[i].Split(splitchars, StringSplitOptions.RemoveEmptyEntries);

            float x = float.Parse(xyz[0], CultureInfo.InvariantCulture) / 1000; // deler på 1000 for å få det nærmere
            float y = float.Parse(xyz[1], CultureInfo.InvariantCulture) / 1000;
            float z = float.Parse(xyz[2], CultureInfo.InvariantCulture) / 1000;

            Debug.Log("x:" + x + "y:" + y + "z:" + z);

            vertices[i - 1] = new Vector3(x, z, y);

            Instantiate(myPrefab, vertices[i - 1], Quaternion.identity);

            i = i + 1000; //render vær 1000 punkt
        }

    }


}
