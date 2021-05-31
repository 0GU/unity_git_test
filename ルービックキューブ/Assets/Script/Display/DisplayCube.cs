using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;

public class DisplayCube : MonoBehaviour
{

    GameObject[] tag1_Objects; //代入用のゲームオブジェクト配列を用意

    TextAsset csvFile; // CSVファイル
    public int height; // CSVの行数
    List<string[]> csvDatas1= new List<string[]>(); // CSVの中身を入れるリスト;
    List<string[]> csvDatas2 = new List<string[]>(); // CSVの中身を入れるリスト;
    List<string[]> csvDatas3 = new List<string[]>(); // CSVの中身を入れるリスト;
    List<string[]> csvDatas4 = new List<string[]>(); // CSVの中身を入れるリスト;


    public int[,,] Cube_Color = new int[4,6, 9];

    Vector3 Cube_pos;

    GameObject Change_Cube;

    GameObject Child_Cube1;
    GameObject Child_Cube2;
    GameObject Child_Cube3;
    GameObject Child_Cube4;
    GameObject Child_Cube5;
    GameObject Child_Cube6;
    GameObject save;

    int[] save_Quad=new int[5];

    int g = 0;

    public bool flag = false;



    void Start()
    {
        for (int load = 0; load < 4; load++)
        {

            switch(load)
            {
                case 0:
                    csvFile = Resources.Load("STAGE1") as TextAsset; // Resouces下のCSV読み込み
                    StringReader reader = new StringReader(csvFile.text);

                    // , で分割しつつ一行ずつ読み込み
                    // リストに追加していく
                    while (reader.Peek() > -1) // reader.Peaekが0になるまで繰り返す
                    {
                        string line = reader.ReadLine(); // 一行ずつ読み込み
                        csvDatas1.Add(line.Split(',')); // , 区切りでリストに追加
                        height++; // 行数加算
                    }

                    for (int h = 0; h <= height; h += 4)
                    // csvDatas[行][列]を指定して値を自由に取り出せる
                    {
                        for (int i = 0; i < 3; i++)//縦
                        {
                            for (int j = 0; j < 3; j++)//横
                            {
                                Cube_Color[load, g, (i * 3) + j] = int.Parse(csvDatas1[i + h][j]);
                            }
                        }
                        g++;
                    }

                    tag1_Objects = GameObject.FindGameObjectsWithTag("STAGE1");
                    ChangeGenerate(load);
                    break;
                case 1:
                    csvFile = Resources.Load("STAGE2") as TextAsset; // Resouces下のCSV読み込み
                    StringReader reader1 = new StringReader(csvFile.text);

                    // , で分割しつつ一行ずつ読み込み
                    // リストに追加していく
                    while (reader1.Peek() > -1) // reader.Peaekが0になるまで繰り返す
                    {
                        string line = reader1.ReadLine(); // 一行ずつ読み込み
                        csvDatas2.Add(line.Split(',')); // , 区切りでリストに追加
                        height++; // 行数加算
                    }

                    for (int h = 0; h <= height; h += 4)
                    // csvDatas[行][列]を指定して値を自由に取り出せる
                    {
                        for (int i = 0; i < 3; i++)//縦
                        {
                            for (int j = 0; j < 3; j++)//横
                            {
                                Cube_Color[load, g, (i * 3) + j] = int.Parse(csvDatas2[i + h][j]);
                            }
                        }
                        g++;
                    }

                    tag1_Objects = GameObject.FindGameObjectsWithTag("STAGE2");
                    ChangeGenerate(load);
                    break;
                case 2:
                    csvFile = Resources.Load("STAGE3") as TextAsset; // Resouces下のCSV読み込み
                    StringReader reader2 = new StringReader(csvFile.text);
                    // , で分割しつつ一行ずつ読み込み
                    // リストに追加していく
                    while (reader2.Peek() > -1) // reader.Peaekが0になるまで繰り返す
                    {
                        string line = reader2.ReadLine(); // 一行ずつ読み込み
                        csvDatas3.Add(line.Split(',')); // , 区切りでリストに追加
                        height++; // 行数加算
                    }

                    for (int h = 0; h <= height; h += 4)
                    // csvDatas[行][列]を指定して値を自由に取り出せる
                    {
                        for (int i = 0; i < 3; i++)//縦
                        {
                            for (int j = 0; j < 3; j++)//横
                            {
                                Cube_Color[load, g, (i * 3) + j] = int.Parse(csvDatas3[i + h][j]);
                            }
                        }
                        g++;
                    }

                    tag1_Objects = GameObject.FindGameObjectsWithTag("STAGE3");
                    ChangeGenerate(load);
                    break;
                case 3:
                    csvFile = Resources.Load("STAGE4") as TextAsset; // Resouces下のCSV読み込み
                    StringReader reader3 = new StringReader(csvFile.text);

                    // , で分割しつつ一行ずつ読み込み
                    // リストに追加していく
                    while (reader3.Peek() > -1) // reader.Peaekが0になるまで繰り返す
                    {
                        string line = reader3.ReadLine(); // 一行ずつ読み込み
                        csvDatas4.Add(line.Split(',')); // , 区切りでリストに追加
                        height++; // 行数加算
                    }

                    for (int h = 0; h <= height; h += 4)
                    // csvDatas[行][列]を指定して値を自由に取り出せる
                    {
                        for (int i = 0; i < 3; i++)//縦
                        {
                            for (int j = 0; j < 3; j++)//横
                            {
                                Cube_Color[load, g, (i * 3) + j] = int.Parse(csvDatas4[i + h][j]);
                            }
                        }
                        g++;
                    }

                    tag1_Objects = GameObject.FindGameObjectsWithTag("STAGE4");
                    ChangeGenerate(load);
                    break;
            }
            g = 0;
            height = 0;
           
        }
    
        


    }

    private void Update()
    {


    }


    public void ChangeGenerate(int stage)
    {
        for (int i = 0; i < 3; i++)//縦
        {
            for (int j = 0; j < 9; j++)//横
            {
                Cube_pos = tag1_Objects[(i * 9) + j].transform.position;
                Change_Cube = tag1_Objects[(i * 9) + j];
                switch (Cube_pos.x)
                {
                    case 0:
                        switch (Cube_pos.y)
                        {
                            case 0:
                                switch (Cube_pos.z)
                                {
                                    case 0:
                                        Child_Cube1 = Change_Cube.transform.Find("Quad1").gameObject;
                                        Child_Cube3 = Change_Cube.transform.Find("Quad3").gameObject;
                                        Child_Cube6 = Change_Cube.transform.Find("Quad6").gameObject;

                                        Color_Set(Cube_Color[stage,0, 6], Child_Cube1);
                                        Color_Set(Cube_Color[stage, 2, 8], Child_Cube3);
                                        Color_Set(Cube_Color[stage, 5, 0], Child_Cube6);
                                        break;
                                    case 1:
                                        Child_Cube3 = Change_Cube.transform.Find("Quad3").gameObject;
                                        Child_Cube6 = Change_Cube.transform.Find("Quad6").gameObject;

                                        Color_Set(Cube_Color[stage, 2, 7], Child_Cube3);
                                        Color_Set(Cube_Color[stage, 5, 3], Child_Cube6);
                                        break;
                                    case 2:
                                        Child_Cube3 = Change_Cube.transform.Find("Quad3").gameObject;
                                        Child_Cube5 = Change_Cube.transform.Find("Quad5").gameObject;
                                        Child_Cube6 = Change_Cube.transform.Find("Quad6").gameObject;

                                        Color_Set(Cube_Color[stage, 2, 6], Child_Cube3);
                                        Color_Set(Cube_Color[stage, 4, 6], Child_Cube5);
                                        Color_Set(Cube_Color[stage, 5, 6], Child_Cube6);
                                        break;
                                }
                                break;
                            case 1:
                                switch (Cube_pos.z)
                                {
                                    case 0:
                                        Child_Cube1 = Change_Cube.transform.Find("Quad1").gameObject;
                                        Child_Cube3 = Change_Cube.transform.Find("Quad3").gameObject;

                                        Color_Set(Cube_Color[stage, 0, 3], Child_Cube1);
                                        Color_Set(Cube_Color[stage, 2, 5], Child_Cube3);
                                        break;
                                    case 1:

                                        Child_Cube3 = Change_Cube.transform.Find("Quad3").gameObject;

                                        Color_Set(Cube_Color[stage, 2, 4], Child_Cube3);
                                        save = Child_Cube3;

                                        break;
                                    case 2:
                                        Child_Cube3 = Change_Cube.transform.Find("Quad3").gameObject;
                                        Child_Cube5 = Change_Cube.transform.Find("Quad5").gameObject;

                                        Color_Set(Cube_Color[stage, 2, 3], Child_Cube3);
                                        Color_Set(Cube_Color[stage, 4, 3], Child_Cube5);
                                        break;
                                }
                                break;
                            case 2:
                                switch (Cube_pos.z)
                                {
                                    case 0:
                                        Child_Cube1 = Change_Cube.transform.Find("Quad1").gameObject;
                                        Child_Cube2 = Change_Cube.transform.Find("Quad2").gameObject;
                                        Child_Cube3 = Change_Cube.transform.Find("Quad3").gameObject;

                                        Color_Set(Cube_Color[stage, 0, 0], Child_Cube1);
                                        Color_Set(Cube_Color[stage, 1, 6], Child_Cube2);
                                        Color_Set(Cube_Color[stage, 2, 2], Child_Cube3);
                                        break;
                                    case 1:
                                        Child_Cube2 = Change_Cube.transform.Find("Quad2").gameObject;
                                        Child_Cube3 = Change_Cube.transform.Find("Quad3").gameObject;

                                        Color_Set(Cube_Color[stage, 1, 3], Child_Cube2);
                                        Color_Set(Cube_Color[stage, 2, 1], Child_Cube3);
                                        break;
                                    case 2:
                                        Child_Cube2 = Change_Cube.transform.Find("Quad2").gameObject;
                                        Child_Cube3 = Change_Cube.transform.Find("Quad3").gameObject;
                                        Child_Cube5 = Change_Cube.transform.Find("Quad5").gameObject;

                                        Color_Set(Cube_Color[stage, 1, 0], Child_Cube2);
                                        Color_Set(Cube_Color[stage, 2, 0], Child_Cube3);
                                        Color_Set(Cube_Color[stage, 4, 0], Child_Cube5);
                                        break;
                                }
                                break;
                        }
                        break;
                    case 1:
                        switch (Cube_pos.y)
                        {
                            case 0:
                                switch (Cube_pos.z)
                                {
                                    case 0:
                                        Child_Cube1 = Change_Cube.transform.Find("Quad1").gameObject;
                                        Child_Cube6 = Change_Cube.transform.Find("Quad6").gameObject;

                                        Color_Set(Cube_Color[stage, 0, 7], Child_Cube1);
                                        Color_Set(Cube_Color[stage, 5, 1], Child_Cube6);
                                        break;
                                    case 1:
                                        Child_Cube6 = Change_Cube.transform.Find("Quad6").gameObject;

                                        Color_Set(Cube_Color[stage, 5, 4], Child_Cube6);
                                        break;
                                    case 2:
                                        Child_Cube5 = Change_Cube.transform.Find("Quad5").gameObject;
                                        Child_Cube6 = Change_Cube.transform.Find("Quad6").gameObject;

                                        Color_Set(Cube_Color[stage, 4, 7], Child_Cube5);
                                        Color_Set(Cube_Color[stage, 5, 7], Child_Cube6);
                                        break;
                                }
                                break;
                            case 1:
                                switch (Cube_pos.z)
                                {
                                    case 0:
                                        Child_Cube1 = Change_Cube.transform.Find("Quad1").gameObject;
                                        Color_Set(Cube_Color[stage,0, 4], Child_Cube1);
                                        break;
                                    case 1:
                                        break;
                                    case 2:
                                        Child_Cube5 = Change_Cube.transform.Find("Quad5").gameObject;

                                        Color_Set(Cube_Color[stage, 4, 4], Child_Cube5);
                                        break;
                                }
                                break;
                            case 2:
                                switch (Cube_pos.z)
                                {
                                    case 0:
                                        Child_Cube1 = Change_Cube.transform.Find("Quad1").gameObject;
                                        Child_Cube2 = Change_Cube.transform.Find("Quad2").gameObject;

                                        Color_Set(Cube_Color[stage, 0, 1], Child_Cube1);
                                        Color_Set(Cube_Color[stage, 1, 7], Child_Cube2);
                                        break;
                                    case 1:
                                        Child_Cube2 = Change_Cube.transform.Find("Quad2").gameObject;

                                        Color_Set(Cube_Color[stage, 1, 4], Child_Cube2);
                                        break;
                                    case 2:
                                        Child_Cube2 = Change_Cube.transform.Find("Quad2").gameObject;
                                        Child_Cube5 = Change_Cube.transform.Find("Quad5").gameObject;

                                        Color_Set(Cube_Color[stage, 1, 1], Child_Cube2);
                                        Color_Set(Cube_Color[stage, 4, 1], Child_Cube5);
                                        break;
                                }
                                break;
                        }
                        break;
                    case 2:
                        switch (Cube_pos.y)
                        {
                            case 0:
                                switch (Cube_pos.z)
                                {
                                    case 0:
                                        Child_Cube1 = Change_Cube.transform.Find("Quad1").gameObject;
                                        Child_Cube4 = Change_Cube.transform.Find("Quad4").gameObject;
                                        Child_Cube6 = Change_Cube.transform.Find("Quad6").gameObject;

                                        Color_Set(Cube_Color[stage, 0, 8], Child_Cube1);
                                        Color_Set(Cube_Color[stage, 3, 6], Child_Cube4);
                                        Color_Set(Cube_Color[stage, 5, 2], Child_Cube6);
                                        break;
                                    case 1:
                                        Child_Cube4 = Change_Cube.transform.Find("Quad4").gameObject;
                                        Child_Cube6 = Change_Cube.transform.Find("Quad6").gameObject;

                                        Color_Set(Cube_Color[stage, 3, 7], Child_Cube4);
                                        Color_Set(Cube_Color[stage, 5, 5], Child_Cube6);
                                        break;
                                    case 2:
                                        Child_Cube4 = Change_Cube.transform.Find("Quad4").gameObject;
                                        Child_Cube5 = Change_Cube.transform.Find("Quad5").gameObject;
                                        Child_Cube6 = Change_Cube.transform.Find("Quad6").gameObject;

                                        Color_Set(Cube_Color[stage, 3, 8], Child_Cube4);
                                        Color_Set(Cube_Color[stage, 4, 8], Child_Cube5);
                                        Color_Set(Cube_Color[stage, 5, 8], Child_Cube6);
                                        break;
                                }
                                break;
                            case 1:
                                switch (Cube_pos.z)
                                {
                                    case 0:
                                        Child_Cube1 = Change_Cube.transform.Find("Quad1").gameObject;
                                        Child_Cube4 = Change_Cube.transform.Find("Quad4").gameObject;

                                        Color_Set(Cube_Color[stage, 0, 5], Child_Cube1);
                                        Color_Set(Cube_Color[stage, 3, 3], Child_Cube4);
                                        break;
                                    case 1:
                                        Child_Cube4 = Change_Cube.transform.Find("Quad4").gameObject;

                                        Color_Set(Cube_Color[stage, 3, 4], Child_Cube4);
                                        break;
                                    case 2:
                                        Child_Cube4 = Change_Cube.transform.Find("Quad4").gameObject;
                                        Child_Cube5 = Change_Cube.transform.Find("Quad5").gameObject;

                                        Color_Set(Cube_Color[stage, 3, 5], Child_Cube4);
                                        Color_Set(Cube_Color[stage, 4, 5], Child_Cube5);
                                        break;
                                }
                                break;
                            case 2:
                                switch (Cube_pos.z)
                                {
                                    case 0:
                                        Child_Cube1 = Change_Cube.transform.Find("Quad1").gameObject;
                                        Child_Cube2 = Change_Cube.transform.Find("Quad2").gameObject;
                                        Child_Cube4 = Change_Cube.transform.Find("Quad4").gameObject;

                                        Color_Set(Cube_Color[stage, 0, 2], Child_Cube1);
                                        Color_Set(Cube_Color[stage, 1, 8], Child_Cube2);
                                        Color_Set(Cube_Color[stage, 3, 0], Child_Cube4);
                                        break;
                                    case 1:
                                        Child_Cube2 = Change_Cube.transform.Find("Quad2").gameObject;
                                        Child_Cube4 = Change_Cube.transform.Find("Quad4").gameObject;

                                        Color_Set(Cube_Color[stage, 1, 5], Child_Cube2);
                                        Color_Set(Cube_Color[stage, 3, 1], Child_Cube4);
                                        break;
                                    case 2:
                                        Child_Cube2 = Change_Cube.transform.Find("Quad2").gameObject;
                                        Child_Cube4 = Change_Cube.transform.Find("Quad4").gameObject;
                                        Child_Cube5 = Change_Cube.transform.Find("Quad5").gameObject;

                                        Color_Set(Cube_Color[stage, 1, 2], Child_Cube2);
                                        Color_Set(Cube_Color[stage, 3, 2], Child_Cube4);
                                        Color_Set(Cube_Color[stage, 4, 2], Child_Cube5);
                                        break;
                                }
                                break;
                        }
                        break;
                }

            }
        }


    }
  
    public void Color_Set(int col, GameObject Quad)
    {
        switch (col)
        {
            case 0:
                Quad.GetComponent<Renderer>().material.color = Color.blue;
                Quad.tag = "Blue Panel";
                break;
            case 1:
                Quad.GetComponent<Renderer>().material.color = Color.green;
                Quad.tag = "Green Panel";
                break;
            case 2:
                Quad.GetComponent<Renderer>().material.color = Color.yellow;
                Quad.tag = "Yellow Panel";
                break;
            case 3:
                Quad.GetComponent<Renderer>().material.color = Color.red;
                Quad.tag = "Red Panel";
                break;
        }

    }
}