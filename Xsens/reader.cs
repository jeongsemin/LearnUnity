using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class reader : MonoBehaviour
{
    bool IsPause;                                   //일시정지
    int size;                                       //데이터 크기
    int count = 0;                                  //데이터 출력
    List<float> listbar = new List<float>();        //바 높이
    List<float> listbarz = new List<float>();       //바 앞뒤 움직임
    List<float> listvelocity = new List<float>();   //바 이동 속도


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

        //다음 위치에 도착하면 다음 위치로 이동함
        if(transform.position == target)
        {
            count++;
        }
        //마지막까지 가면 다시 돌아감
        else if(count == size)
        {
            count = 0;
        }

        //현재 위치 출력
        print(new Vector3(0, listbar[count + 1], listbarz[count + 1]));

        //ESC누를시 프로그램 종료
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        //spacebar 누를시 프로그램 일시정지
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //일시정지 활성화
            if(IsPause == false)
            {
                Time.timeScale = 0;
                IsPause = true;
                return;
            }

            //일시정지 비활성화
            if(IsPause == true)
            {
                Time.timeScale = 1;
                IsPause = false;
                return;
            }
        }

    }
}
