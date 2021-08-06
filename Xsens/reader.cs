using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class reader : MonoBehaviour
{
    bool IsPause;                                   //�Ͻ�����
    int size;                                       //������ ũ��
    int count = 0;                                  //������ ���
    List<float> listbar = new List<float>();        //�� ����
    List<float> listbarz = new List<float>();       //�� �յ� ������
    List<float> listvelocity = new List<float>();   //�� �̵� �ӵ�


    // Start is called before the first frame update
    void Start()
    {
        IsPause = false;
        

        /*position = transform.position;*/

        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Xsens2");

        size = data_Dialog.Count;

        for (int i = 0; i < data_Dialog.Count; i++)
        {
            listbar.Add(10 * float.Parse(data_Dialog[i]["bar_height"].ToString()));
            listvelocity.Add(float.Parse(data_Dialog[i]["velocity"].ToString()));
            listbarz.Add(float.Parse(data_Dialog[i]["horizontal_displacement"].ToString()));
        }

        transform.position = new Vector3(0, listbar[count], listbarz[count]);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 target = new Vector3(0, listbar[count + 1], listbarz[count + 1]);

        transform.position = Vector3.MoveTowards(transform.position, target, 1.0f * Time.deltaTime);

        //���� ��ġ�� �����ϸ� ���� ��ġ�� �̵���
        if(transform.position == target)
        {
            count++;
        }
        //���������� ���� �ٽ� ���ư�
        else if(count == size)
        {
            count = 0;
        }

        //���� ��ġ ���
        print(new Vector3(0, listbar[count + 1], listbarz[count + 1]));

        //ESC������ ���α׷� ����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        //spacebar ������ ���α׷� �Ͻ�����
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //�Ͻ����� Ȱ��ȭ
            if(IsPause == false)
            {
                Time.timeScale = 0;
                IsPause = true;
                return;
            }

            //�Ͻ����� ��Ȱ��ȭ
            if(IsPause == true)
            {
                Time.timeScale = 1;
                IsPause = false;
                return;
            }
        }

    }
}
