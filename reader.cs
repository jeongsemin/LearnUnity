using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reader : MonoBehaviour
{
    int size;
    int count = 0;
    Vector3 position;
    List<float> listX= new List<float>();
    List<float> listY= new List<float>();
    List<float> listZ= new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;

        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Xsens");

        size = data_Dialog.Count;

        for(int i=0;i<data_Dialog.Count;i++)
        {
            listX.Add(172 + float.Parse(data_Dialog[i]["Euler_X"].ToString()));
        }
        for (int i = 0; i < data_Dialog.Count; i++)
        {
            listY.Add(55 + float.Parse(data_Dialog[i]["Euler_Y"].ToString()));
        }
        for (int i = 0; i < data_Dialog.Count; i++)
        {
            listZ.Add(126 - float.Parse(data_Dialog[i]["Euler_Z"].ToString()));
        }

    }

    // Update is called once per frame
    void Update()
    {
        position.x = listX[count];
        position.y = listY[count];
        position.z = listZ[count];


        transform.position = Vector3.MoveTowards(transform.position, 
            new Vector3(listX[count + 1], listY[count + 1], listZ[count + 1]), 0.5f * Time.deltaTime);

        if (count < size - 2)
        {
            count++;
        }
        else
        {
            count = 0;
        }

    }
}
