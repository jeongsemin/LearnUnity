  
Unity에서 Excel파일을 읽는 방법(csv)

사용 방법 : https://yoonstone-games.tistory.com/14 를 참조하여 했습니다.

1. 3D object 아무거나 만든다.

2. Unity 프로젝트 Asset에 Resources 폴더를 만들고 그 안에 csv파일을 저장한다.

3. CSVReader.sc 를 같은 Asset에 넣는다.

4. 3D object에 Script를 새로 만든다.

5. Script의 void start()에 
List<Dictionary<string, object>> data = CSVReader.Read("Resources에 들어가있는 파일 이름");
for (int i = 0; i < data_Dialog.Count; i++)
        {
            print(data[i]["원하는 항목이름"].ToString());
        }
        
하면 항목의 리스트가 쭉 뜬다.


![image](https://user-images.githubusercontent.com/73982568/127736884-76808b5a-1896-4b4b-9693-1c6d2b628773.png)
