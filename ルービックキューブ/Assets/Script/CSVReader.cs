using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;

public class CSVReader : MonoBehaviour
{

    GameObject[] tag1_Objects; //代入用のゲームオブジェクト配列を用意

    TextAsset csvFile; // CSVファイル
    public int height; // CSVの行数
    List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト;

    public GameObject Cube;
    public int[,] Cube_Color = new int[6, 9];

    Vector3 Cube_pos;

    GameObject Change_Cube;

    GameObject Child_Cube1;
    GameObject Child_Cube2;
    GameObject Child_Cube3;
    GameObject Child_Cube4;
    GameObject Child_Cube5;
    GameObject Child_Cube6;

    int[] save_Quad=new int[5];

    int g = 0;

    public bool flag = false;

    GameObject[] Wall; //代入用のゲームオブジェクト配列を用意

    BlockControl Wall_Active;

    void Start()
    {
        Wall = GameObject.FindGameObjectsWithTag("Block_cont");
        Wall_Active = Wall[0].GetComponent<BlockControl>();

        csvFile = Resources.Load("STAGE1") as TextAsset; // Resouces下のCSV読み込み
        StringReader reader = new StringReader(csvFile.text);

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() > -1) // reader.Peaekが0になるまで繰り返す
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            csvDatas.Add(line.Split(',')); // , 区切りでリストに追加
            height++; // 行数加算
        }

        for (int h = 0; h <= height; h += 4)
        // csvDatas[行][列]を指定して値を自由に取り出せる
        {
            for (int i = 0; i < 3; i++)//縦
            {
                for (int j = 0; j < 3; j++)//横
                {
                    Cube_Color[g, (i * 3) + j] = int.Parse(csvDatas[i + h][j]);
                }
            }
            g++;
        }

        ChangeGenerate();

        tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");


    }

    private void Update()
    {


    }


    public async void ChangeGenerate()
    {
        tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");
        for (int i = 0; i < tag1_Objects.Length; i++)
        {
            Destroy(tag1_Objects[i]);
        }

        for (int h = 0; h < 3; h++)
        // csvDatas[行][列]を指定して値を自由に取り出せる
        {
            for (int i = 0; i < 3; i++)//縦
            {
                for (int j = 0; j < 3; j++)//横
                {
                    //Instantiate(生成したいGameObject, 位置, 姿勢);
                    Instantiate(Cube, new Vector3(j, 2 - i, h), Quaternion.identity);
                }
            }
        }
        await Task.Delay(1);
        tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");
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

                                        Color_Set(Cube_Color[0, 6], Child_Cube1);
                                        Color_Set(Cube_Color[2, 8], Child_Cube3);
                                        Color_Set(Cube_Color[5, 0], Child_Cube6);
                                        break;
                                    case 1:
                                        Child_Cube3 = Change_Cube.transform.Find("Quad3").gameObject;
                                        Child_Cube6 = Change_Cube.transform.Find("Quad6").gameObject;

                                        Color_Set(Cube_Color[2, 7], Child_Cube3);
                                        Color_Set(Cube_Color[5, 3], Child_Cube6);
                                        break;
                                    case 2:
                                        Child_Cube3 = Change_Cube.transform.Find("Quad3").gameObject;
                                        Child_Cube5 = Change_Cube.transform.Find("Quad5").gameObject;
                                        Child_Cube6 = Change_Cube.transform.Find("Quad6").gameObject;

                                        Color_Set(Cube_Color[2, 6], Child_Cube3);
                                        Color_Set(Cube_Color[4, 6], Child_Cube5);
                                        Color_Set(Cube_Color[5, 6], Child_Cube6);
                                        break;
                                }
                                break;
                            case 1:
                                switch (Cube_pos.z)
                                {
                                    case 0:
                                        Child_Cube1 = Change_Cube.transform.Find("Quad1").gameObject;
                                        Child_Cube3 = Change_Cube.transform.Find("Quad3").gameObject;

                                        Color_Set(Cube_Color[0, 3], Child_Cube1);
                                        Color_Set(Cube_Color[2, 5], Child_Cube3);
                                        break;
                                    case 1:
                                        Child_Cube3 = Change_Cube.transform.Find("Quad3").gameObject;

                                        Color_Set(Cube_Color[2, 4], Child_Cube3);
                                        break;
                                    case 2:
                                        Child_Cube3 = Change_Cube.transform.Find("Quad3").gameObject;
                                        Child_Cube5 = Change_Cube.transform.Find("Quad5").gameObject;

                                        Color_Set(Cube_Color[2, 3], Child_Cube3);
                                        Color_Set(Cube_Color[4, 3], Child_Cube5);
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

                                        Color_Set(Cube_Color[0, 0], Child_Cube1);
                                        Color_Set(Cube_Color[1, 6], Child_Cube2);
                                        Color_Set(Cube_Color[2, 2], Child_Cube3);
                                        break;
                                    case 1:
                                        Child_Cube2 = Change_Cube.transform.Find("Quad2").gameObject;
                                        Child_Cube3 = Change_Cube.transform.Find("Quad3").gameObject;

                                        Color_Set(Cube_Color[1, 3], Child_Cube2);
                                        Color_Set(Cube_Color[2, 1], Child_Cube3);
                                        break;
                                    case 2:
                                        Child_Cube2 = Change_Cube.transform.Find("Quad2").gameObject;
                                        Child_Cube3 = Change_Cube.transform.Find("Quad3").gameObject;
                                        Child_Cube5 = Change_Cube.transform.Find("Quad5").gameObject;

                                        Color_Set(Cube_Color[1, 0], Child_Cube2);
                                        Color_Set(Cube_Color[2, 0], Child_Cube3);
                                        Color_Set(Cube_Color[4, 0], Child_Cube5);
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

                                        Color_Set(Cube_Color[0, 7], Child_Cube1);
                                        Color_Set(Cube_Color[5, 1], Child_Cube6);
                                        break;
                                    case 1:
                                        Child_Cube6 = Change_Cube.transform.Find("Quad6").gameObject;

                                        Color_Set(Cube_Color[5, 4], Child_Cube6);
                                        break;
                                    case 2:
                                        Child_Cube5 = Change_Cube.transform.Find("Quad5").gameObject;
                                        Child_Cube6 = Change_Cube.transform.Find("Quad6").gameObject;

                                        Color_Set(Cube_Color[4, 7], Child_Cube5);
                                        Color_Set(Cube_Color[5, 7], Child_Cube6);
                                        break;
                                }
                                break;
                            case 1:
                                switch (Cube_pos.z)
                                {
                                    case 0:
                                        Child_Cube1 = Change_Cube.transform.Find("Quad1").gameObject;
                                        Color_Set(Cube_Color[0, 4], Child_Cube1);
                                        break;
                                    case 1:
                                        break;
                                    case 2:
                                        Child_Cube5 = Change_Cube.transform.Find("Quad5").gameObject;

                                        Color_Set(Cube_Color[4, 4], Child_Cube5);
                                        break;
                                }
                                break;
                            case 2:
                                switch (Cube_pos.z)
                                {
                                    case 0:
                                        Child_Cube1 = Change_Cube.transform.Find("Quad1").gameObject;
                                        Child_Cube2 = Change_Cube.transform.Find("Quad2").gameObject;

                                        Color_Set(Cube_Color[0, 1], Child_Cube1);
                                        Color_Set(Cube_Color[1, 7], Child_Cube2);
                                        break;
                                    case 1:
                                        Child_Cube2 = Change_Cube.transform.Find("Quad2").gameObject;

                                        Color_Set(Cube_Color[1, 4], Child_Cube2);
                                        break;
                                    case 2:
                                        Child_Cube2 = Change_Cube.transform.Find("Quad2").gameObject;
                                        Child_Cube5 = Change_Cube.transform.Find("Quad5").gameObject;

                                        Color_Set(Cube_Color[1, 1], Child_Cube2);
                                        Color_Set(Cube_Color[4, 1], Child_Cube5);
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

                                        Color_Set(Cube_Color[0, 8], Child_Cube1);
                                        Color_Set(Cube_Color[3, 6], Child_Cube4);
                                        Color_Set(Cube_Color[5, 2], Child_Cube6);
                                        break;
                                    case 1:
                                        Child_Cube4 = Change_Cube.transform.Find("Quad4").gameObject;
                                        Child_Cube6 = Change_Cube.transform.Find("Quad6").gameObject;

                                        Color_Set(Cube_Color[3, 7], Child_Cube4);
                                        Color_Set(Cube_Color[5, 5], Child_Cube6);
                                        break;
                                    case 2:
                                        Child_Cube4 = Change_Cube.transform.Find("Quad4").gameObject;
                                        Child_Cube5 = Change_Cube.transform.Find("Quad5").gameObject;
                                        Child_Cube6 = Change_Cube.transform.Find("Quad6").gameObject;

                                        Color_Set(Cube_Color[3, 8], Child_Cube4);
                                        Color_Set(Cube_Color[4, 8], Child_Cube5);
                                        Color_Set(Cube_Color[5, 8], Child_Cube6);
                                        break;
                                }
                                break;
                            case 1:
                                switch (Cube_pos.z)
                                {
                                    case 0:
                                        Child_Cube1 = Change_Cube.transform.Find("Quad1").gameObject;
                                        Child_Cube4 = Change_Cube.transform.Find("Quad4").gameObject;

                                        Color_Set(Cube_Color[0, 5], Child_Cube1);
                                        Color_Set(Cube_Color[3, 3], Child_Cube4);
                                        break;
                                    case 1:
                                        Child_Cube4 = Change_Cube.transform.Find("Quad4").gameObject;

                                        Color_Set(Cube_Color[3, 4], Child_Cube4);
                                        break;
                                    case 2:
                                        Child_Cube4 = Change_Cube.transform.Find("Quad4").gameObject;
                                        Child_Cube5 = Change_Cube.transform.Find("Quad5").gameObject;

                                        Color_Set(Cube_Color[3, 5], Child_Cube4);
                                        Color_Set(Cube_Color[4, 5], Child_Cube5);
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

                                        Color_Set(Cube_Color[0, 2], Child_Cube1);
                                        Color_Set(Cube_Color[1, 8], Child_Cube2);
                                        Color_Set(Cube_Color[3, 0], Child_Cube4);
                                        break;
                                    case 1:
                                        Child_Cube2 = Change_Cube.transform.Find("Quad2").gameObject;
                                        Child_Cube4 = Change_Cube.transform.Find("Quad4").gameObject;

                                        Color_Set(Cube_Color[1, 5], Child_Cube2);
                                        Color_Set(Cube_Color[3, 1], Child_Cube4);
                                        break;
                                    case 2:
                                        Child_Cube2 = Change_Cube.transform.Find("Quad2").gameObject;
                                        Child_Cube4 = Change_Cube.transform.Find("Quad4").gameObject;
                                        Child_Cube5 = Change_Cube.transform.Find("Quad5").gameObject;

                                        Color_Set(Cube_Color[1, 2], Child_Cube2);
                                        Color_Set(Cube_Color[3, 2], Child_Cube4);
                                        Color_Set(Cube_Color[4, 2], Child_Cube5);
                                        break;
                                }
                                break;
                        }
                        break;
                }

            }
        }

        await Task.Delay(10);
        Wall_Active.Active_false();
        Wall_Active.Color_Save();
        Wall_Active.Active_true();
    }
    public void ChangeArrayX(int num, bool R)
    {
        if (R == false)
        {
            switch (num)
            {
                case 0:
                    save_Quad[0] = Cube_Color[2, 0];
                    save_Quad[1] = Cube_Color[2, 1];
                    save_Quad[2] = Cube_Color[0, 0];
                    save_Quad[3] = Cube_Color[0, 3];
                    save_Quad[4] = Cube_Color[0, 6];
                    for (int c = 0; c < 4; c++)
                    {
                        switch (c)
                        {
                            case 0:
                                Cube_Color[2, 0] = Cube_Color[2, 2];
                                Cube_Color[2, 1] = Cube_Color[2, 5];
                                Cube_Color[0, 0] = Cube_Color[5, 0];
                                Cube_Color[0, 3] = Cube_Color[5, 3];
                                Cube_Color[0, 6] = Cube_Color[5, 6];
                                break;
                            case 1:
                                Cube_Color[2, 2] = Cube_Color[2, 8];
                                Cube_Color[2, 5] = Cube_Color[2, 7];
                                Cube_Color[5, 0] = Cube_Color[4, 6];
                                Cube_Color[5, 3] = Cube_Color[4, 3];
                                Cube_Color[5, 6] = Cube_Color[4, 0];
                                break;
                            case 2:
                                Cube_Color[2, 8] = Cube_Color[2, 6];
                                Cube_Color[2, 7] = Cube_Color[2, 3];
                                Cube_Color[4, 6] = Cube_Color[1, 0];
                                Cube_Color[4, 3] = Cube_Color[1, 3];
                                Cube_Color[4, 0] = Cube_Color[1, 6];
                                break;
                            case 3:
                                Cube_Color[2, 6] = save_Quad[0];
                                Cube_Color[2, 3] = save_Quad[1];
                                Cube_Color[1, 0] = save_Quad[2];
                                Cube_Color[1, 3] = save_Quad[3];
                                Cube_Color[1, 6] = save_Quad[4];
                                break;
                        }
                    }
                    break;
                case 1:
                    save_Quad[2] = Cube_Color[0, 1];
                    save_Quad[3] = Cube_Color[0, 4];
                    save_Quad[4] = Cube_Color[0, 7];
                    for (int c = 0; c < 4; c++)
                    {
                        switch (c)
                        {
                            case 0:
                                Cube_Color[0, 1] = Cube_Color[5, 1];
                                Cube_Color[0, 4] = Cube_Color[5, 4];
                                Cube_Color[0, 7] = Cube_Color[5, 7];
                                break;
                            case 1:
                                Cube_Color[5, 1] = Cube_Color[4, 7];
                                Cube_Color[5, 4] = Cube_Color[4, 4];
                                Cube_Color[5, 7] = Cube_Color[4, 1];
                                break;
                            case 2:
                                Cube_Color[4, 7] = Cube_Color[1, 1];
                                Cube_Color[4, 4] = Cube_Color[1, 4];
                                Cube_Color[4, 1] = Cube_Color[1, 7];
                                break;
                            case 3:
                                Cube_Color[1, 1] = save_Quad[2];
                                Cube_Color[1, 4] = save_Quad[3];
                                Cube_Color[1, 7] = save_Quad[4];
                                break;
                        }
                    }
                    break;
                case 2:
                    save_Quad[0] = Cube_Color[3, 0];
                    save_Quad[1] = Cube_Color[3, 1];
                    save_Quad[2] = Cube_Color[0, 2];
                    save_Quad[3] = Cube_Color[0, 5];
                    save_Quad[4] = Cube_Color[0, 8];
                    for (int c = 0; c < 4; c++)
                    {
                        switch (c)
                        {
                            case 0:
                                Cube_Color[3, 0] = Cube_Color[3, 2];
                                Cube_Color[3, 1] = Cube_Color[3, 5];
                                Cube_Color[0, 2] = Cube_Color[5, 2];
                                Cube_Color[0, 5] = Cube_Color[5, 5];
                                Cube_Color[0, 8] = Cube_Color[5, 8];
                                break;
                            case 1:
                                Cube_Color[3, 2] = Cube_Color[3, 8];
                                Cube_Color[3, 5] = Cube_Color[3, 7];
                                Cube_Color[5, 2] = Cube_Color[4, 8];
                                Cube_Color[5, 5] = Cube_Color[4, 5];
                                Cube_Color[5, 8] = Cube_Color[4, 2];
                                break;
                            case 2:
                                Cube_Color[3, 8] = Cube_Color[3, 6];
                                Cube_Color[3, 7] = Cube_Color[3, 3];
                                Cube_Color[4, 8] = Cube_Color[1, 2];
                                Cube_Color[4, 5] = Cube_Color[1, 5];
                                Cube_Color[4, 2] = Cube_Color[1, 8];
                                break;
                            case 3:
                                Cube_Color[3, 6] = save_Quad[0];
                                Cube_Color[3, 3] = save_Quad[1];
                                Cube_Color[1, 2] = save_Quad[2];
                                Cube_Color[1, 5] = save_Quad[3];
                                Cube_Color[1, 8] = save_Quad[4];
                                break;
                        }
                    }
                    break;
            }
        }
        else if (R == true)
        {
            switch (num)
            {
                case 0:
                    save_Quad[0] = Cube_Color[2, 0];
                    save_Quad[1] = Cube_Color[2, 1];
                    save_Quad[2] = Cube_Color[0, 0];
                    save_Quad[3] = Cube_Color[0, 3];
                    save_Quad[4] = Cube_Color[0, 6];
                    for (int c = 0; c < 4; c++)
                    {
                        switch (c)
                        {
                            case 0:
                                Cube_Color[2, 0] = Cube_Color[2, 6];
                                Cube_Color[2, 1] = Cube_Color[2, 3];
                                Cube_Color[0, 0] = Cube_Color[1, 0];
                                Cube_Color[0, 3] = Cube_Color[1, 3];
                                Cube_Color[0, 6] = Cube_Color[1, 6];
                                break;
                            case 1:
                                Cube_Color[2, 6] = Cube_Color[2, 8];
                                Cube_Color[2, 3] = Cube_Color[2, 7];
                                Cube_Color[1, 0] = Cube_Color[4, 6];
                                Cube_Color[1, 3] = Cube_Color[4, 3];
                                Cube_Color[1, 6] = Cube_Color[4, 0];
                                break;
                            case 2:
                                Cube_Color[2, 8] = Cube_Color[2, 2];
                                Cube_Color[2, 7] = Cube_Color[2, 5];
                                Cube_Color[4, 6] = Cube_Color[5, 0];
                                Cube_Color[4, 3] = Cube_Color[5, 3];
                                Cube_Color[4, 0] = Cube_Color[5, 6];
                                break;
                            case 3:
                                Cube_Color[2, 2] = save_Quad[0];
                                Cube_Color[2, 5] = save_Quad[1];
                                Cube_Color[5, 0] = save_Quad[2];
                                Cube_Color[5, 3] = save_Quad[3];
                                Cube_Color[5, 6] = save_Quad[4];
                                break;
                        }
                    }
                    break;
                case 1:
                    save_Quad[2] = Cube_Color[0, 1];
                    save_Quad[3] = Cube_Color[0, 4];
                    save_Quad[4] = Cube_Color[0, 7];
                    for (int c = 0; c < 4; c++)
                    {
                        switch (c)
                        {
                            case 0:
                                Cube_Color[0, 1] = Cube_Color[1, 1];
                                Cube_Color[0, 4] = Cube_Color[1, 4];
                                Cube_Color[0, 7] = Cube_Color[1, 7];
                                break;
                            case 1:
                                Cube_Color[1, 1] = Cube_Color[4, 7];
                                Cube_Color[1, 4] = Cube_Color[4, 4];
                                Cube_Color[1, 7] = Cube_Color[4, 1];
                                break;
                            case 2:
                                Cube_Color[4, 7] = Cube_Color[5, 1];
                                Cube_Color[4, 4] = Cube_Color[5, 4];
                                Cube_Color[4, 1] = Cube_Color[5, 7];
                                break;
                            case 3:
                                Cube_Color[5, 1] = save_Quad[2];
                                Cube_Color[5, 4] = save_Quad[3];
                                Cube_Color[5, 7] = save_Quad[4];
                                break;
                        }
                    }
                    break;
                case 2:
                    save_Quad[0] = Cube_Color[3, 0];
                    save_Quad[1] = Cube_Color[3, 1];
                    save_Quad[2] = Cube_Color[0, 2];
                    save_Quad[3] = Cube_Color[0, 5];
                    save_Quad[4] = Cube_Color[0, 8];
                    for (int c = 0; c < 4; c++)
                    {
                        switch (c)
                        {
                            case 0:
                                Cube_Color[3, 0] = Cube_Color[3, 6];
                                Cube_Color[3, 1] = Cube_Color[3, 3];
                                Cube_Color[0, 2] = Cube_Color[1, 2];
                                Cube_Color[0, 5] = Cube_Color[1, 5];
                                Cube_Color[0, 8] = Cube_Color[1, 8];
                                break;
                            case 1:
                                Cube_Color[3, 6] = Cube_Color[3, 8];
                                Cube_Color[3, 3] = Cube_Color[3, 7];
                                Cube_Color[1, 2] = Cube_Color[4, 8];
                                Cube_Color[1, 5] = Cube_Color[4, 5];
                                Cube_Color[1, 8] = Cube_Color[4, 2];
                                break;
                            case 2:
                                Cube_Color[3, 8] = Cube_Color[3, 2];
                                Cube_Color[3, 7] = Cube_Color[3, 5];
                                Cube_Color[4, 8] = Cube_Color[5, 2];
                                Cube_Color[4, 5] = Cube_Color[5, 5];
                                Cube_Color[4, 2] = Cube_Color[5, 8];
                                break;
                            case 3:
                                Cube_Color[3, 2] = save_Quad[0];
                                Cube_Color[3, 5] = save_Quad[1];
                                Cube_Color[5, 2] = save_Quad[2];
                                Cube_Color[5, 5] = save_Quad[3];
                                Cube_Color[5, 8] = save_Quad[4];
                                break;
                        }
                    }
                    break;
            }
        }

    }
    public void ChangeArrayY(int num, bool R)
    {
        if (R == false)
        {
            switch (num)
            {
                case 0:
                    save_Quad[0] = Cube_Color[5, 0];
                    save_Quad[1] = Cube_Color[5, 1];
                    save_Quad[2] = Cube_Color[0, 6];
                    save_Quad[3] = Cube_Color[0, 7];
                    save_Quad[4] = Cube_Color[0, 8];
                    for (int c = 0; c < 4; c++)
                    {
                        switch (c)
                        {
                            case 0:
                                Cube_Color[5, 0] = Cube_Color[5, 2];
                                Cube_Color[5, 1] = Cube_Color[5, 5];
                                Cube_Color[0, 6] = Cube_Color[3, 6];
                                Cube_Color[0, 7] = Cube_Color[3, 7];
                                Cube_Color[0, 8] = Cube_Color[3, 8];
                                break;
                            case 1:
                                Cube_Color[5, 2] = Cube_Color[5, 8];
                                Cube_Color[5, 5] = Cube_Color[5, 7];
                                Cube_Color[3, 6] = Cube_Color[4, 8];
                                Cube_Color[3, 7] = Cube_Color[4, 7];
                                Cube_Color[3, 8] = Cube_Color[4, 6];
                                break;
                            case 2:
                                Cube_Color[5, 8] = Cube_Color[5, 6];
                                Cube_Color[5, 7] = Cube_Color[5, 3];
                                Cube_Color[4, 8] = Cube_Color[2, 6];
                                Cube_Color[4, 7] = Cube_Color[2, 7];
                                Cube_Color[4, 6] = Cube_Color[2, 8];
                                break;
                            case 3:
                                Cube_Color[5, 6] = save_Quad[0];
                                Cube_Color[5, 3] = save_Quad[1];
                                Cube_Color[2, 6] = save_Quad[2];
                                Cube_Color[2, 7] = save_Quad[3];
                                Cube_Color[2, 8] = save_Quad[4];
                                break;
                        }
                    }
                    break;
                case 1:
                    save_Quad[2] = Cube_Color[0, 3];
                    save_Quad[3] = Cube_Color[0, 4];
                    save_Quad[4] = Cube_Color[0, 5];
                    for (int c = 0; c < 4; c++)
                    {
                        switch (c)
                        {
                            case 0:
                                Cube_Color[0, 3] = Cube_Color[3, 3];
                                Cube_Color[0, 4] = Cube_Color[3, 4];
                                Cube_Color[0, 5] = Cube_Color[3, 5];
                                break;
                            case 1:
                                Cube_Color[3, 3] = Cube_Color[4, 5];
                                Cube_Color[3, 4] = Cube_Color[4, 4];
                                Cube_Color[3, 5] = Cube_Color[4, 3];
                                break;
                            case 2:
                                Cube_Color[4, 5] = Cube_Color[2, 3];
                                Cube_Color[4, 4] = Cube_Color[2, 4];
                                Cube_Color[4, 3] = Cube_Color[2, 5];
                                break;
                            case 3:
                                Cube_Color[2, 3] = save_Quad[2];
                                Cube_Color[2, 4] = save_Quad[3];
                                Cube_Color[2, 5] = save_Quad[4];
                                break;
                        }
                    }
                    break;
                case 2:
                    save_Quad[0] = Cube_Color[1, 0];
                    save_Quad[1] = Cube_Color[1, 1];
                    save_Quad[2] = Cube_Color[0, 0];
                    save_Quad[3] = Cube_Color[0, 1];
                    save_Quad[4] = Cube_Color[0, 2];
                    for (int c = 0; c < 4; c++)
                    {
                        switch (c)
                        {
                            case 0:
                                Cube_Color[1, 0] = Cube_Color[1, 6];
                                Cube_Color[1, 1] = Cube_Color[1, 3];
                                Cube_Color[0, 0] = Cube_Color[3, 0];
                                Cube_Color[0, 1] = Cube_Color[3, 1];
                                Cube_Color[0, 2] = Cube_Color[3, 2];
                                break;
                            case 1:
                                Cube_Color[1, 6] = Cube_Color[1, 8];
                                Cube_Color[1, 3] = Cube_Color[1, 7];
                                Cube_Color[3, 0] = Cube_Color[4, 2];
                                Cube_Color[3, 1] = Cube_Color[4, 1];
                                Cube_Color[3, 2] = Cube_Color[4, 0];
                                break;
                            case 2:
                                Cube_Color[1, 8] = Cube_Color[1, 2];
                                Cube_Color[1, 7] = Cube_Color[1, 5];
                                Cube_Color[4, 2] = Cube_Color[2, 0];
                                Cube_Color[4, 1] = Cube_Color[2, 1];
                                Cube_Color[4, 0] = Cube_Color[2, 2];
                                break;
                            case 3:
                                Cube_Color[1, 2] = save_Quad[0];
                                Cube_Color[1, 5] = save_Quad[1];
                                Cube_Color[2, 0] = save_Quad[2];
                                Cube_Color[2, 1] = save_Quad[3];
                                Cube_Color[2, 2] = save_Quad[4];
                                break;
                        }
                    }
                    break;
            }

        }
        else if (R == true)
        {
            switch (num)
            {
                case 0:
                    save_Quad[0] = Cube_Color[5, 0];
                    save_Quad[1] = Cube_Color[5, 1];
                    save_Quad[2] = Cube_Color[0, 6];
                    save_Quad[3] = Cube_Color[0, 7];
                    save_Quad[4] = Cube_Color[0, 8];
                    for (int c = 0; c < 4; c++)
                    {
                        switch (c)
                        {
                            case 0:
                                Cube_Color[5, 0] = Cube_Color[5, 6];
                                Cube_Color[5, 1] = Cube_Color[5, 3];
                                Cube_Color[0, 6] = Cube_Color[2, 6];
                                Cube_Color[0, 7] = Cube_Color[2, 7];
                                Cube_Color[0, 8] = Cube_Color[2, 8];
                                break;
                            case 1:
                                Cube_Color[5, 6] = Cube_Color[5, 8];
                                Cube_Color[5, 3] = Cube_Color[5, 7];
                                Cube_Color[2, 6] = Cube_Color[4, 8];
                                Cube_Color[2, 7] = Cube_Color[4, 7];
                                Cube_Color[2, 8] = Cube_Color[4, 6];
                                break;
                            case 2:
                                Cube_Color[5, 8] = Cube_Color[5, 2];
                                Cube_Color[5, 7] = Cube_Color[5, 5];
                                Cube_Color[4, 8] = Cube_Color[3, 6];
                                Cube_Color[4, 7] = Cube_Color[3, 7];
                                Cube_Color[4, 6] = Cube_Color[3, 8];
                                break;
                            case 3:
                                Cube_Color[5, 2] = save_Quad[0];
                                Cube_Color[5, 5] = save_Quad[1];
                                Cube_Color[3, 6] = save_Quad[2];
                                Cube_Color[3, 7] = save_Quad[3];
                                Cube_Color[3, 8] = save_Quad[4];
                                break;
                        }
                    }
                    break;
                case 1:
                    save_Quad[2] = Cube_Color[0, 3];
                    save_Quad[3] = Cube_Color[0, 4];
                    save_Quad[4] = Cube_Color[0, 5];
                    for (int c = 0; c < 4; c++)
                    {
                        switch (c)
                        {
                            case 0:
                                Cube_Color[0, 3] = Cube_Color[2, 3];
                                Cube_Color[0, 4] = Cube_Color[2, 4];
                                Cube_Color[0, 5] = Cube_Color[2, 5];
                                break;
                            case 1:
                                Cube_Color[2, 3] = Cube_Color[4, 5];
                                Cube_Color[2, 4] = Cube_Color[4, 4];
                                Cube_Color[2, 5] = Cube_Color[4, 3];
                                break;
                            case 2:
                                Cube_Color[4, 5] = Cube_Color[3, 3];
                                Cube_Color[4, 4] = Cube_Color[3, 4];
                                Cube_Color[4, 3] = Cube_Color[3, 5];
                                break;
                            case 3:
                                Cube_Color[3, 3] = save_Quad[2];
                                Cube_Color[3, 4] = save_Quad[3];
                                Cube_Color[3, 5] = save_Quad[4];
                                break;
                        }
                    }
                    break;
                case 2:
                    save_Quad[0] = Cube_Color[1, 0];
                    save_Quad[1] = Cube_Color[1, 1];
                    save_Quad[2] = Cube_Color[0, 0];
                    save_Quad[3] = Cube_Color[0, 1];
                    save_Quad[4] = Cube_Color[0, 2];
                    for (int c = 0; c < 4; c++)
                    {
                        switch (c)
                        {
                            case 0:
                                Cube_Color[1, 0] = Cube_Color[1, 2];
                                Cube_Color[1, 1] = Cube_Color[1, 5];
                                Cube_Color[0, 0] = Cube_Color[2, 0];
                                Cube_Color[0, 1] = Cube_Color[2, 1];
                                Cube_Color[0, 2] = Cube_Color[2, 2];
                                break;
                            case 1:
                                Cube_Color[1, 2] = Cube_Color[1, 8];
                                Cube_Color[1, 5] = Cube_Color[1, 7];
                                Cube_Color[2, 0] = Cube_Color[4, 2];
                                Cube_Color[2, 1] = Cube_Color[4, 1];
                                Cube_Color[2, 2] = Cube_Color[4, 0];
                                break;
                            case 2:
                                Cube_Color[1, 8] = Cube_Color[1, 6];
                                Cube_Color[1, 7] = Cube_Color[1, 3];
                                Cube_Color[4, 2] = Cube_Color[3, 0];
                                Cube_Color[4, 1] = Cube_Color[3, 1];
                                Cube_Color[4, 0] = Cube_Color[3, 2];
                                break;
                            case 3:
                                Cube_Color[1, 6] = save_Quad[0];
                                Cube_Color[1, 3] = save_Quad[1];
                                Cube_Color[3, 0] = save_Quad[2];
                                Cube_Color[3, 1] = save_Quad[3];
                                Cube_Color[3, 2] = save_Quad[4];
                                break;
                        }
                    }
                    break;
            }
        }
    }
    public void ChangeArrayZ(int num, bool R)
    {
        if (R == false)
        {
            switch (num)
            {
                case 0:
                    save_Quad[0] = Cube_Color[0, 0];
                    save_Quad[1] = Cube_Color[0, 1];
                    save_Quad[2] = Cube_Color[1, 6];
                    save_Quad[3] = Cube_Color[1, 7];
                    save_Quad[4] = Cube_Color[1, 8];
                    for (int c = 0; c < 4; c++)
                    {
                        switch (c)
                        {
                            case 0:
                                Cube_Color[0, 0] = Cube_Color[0, 2];
                                Cube_Color[0, 1] = Cube_Color[0, 5];
                                Cube_Color[1, 6] = Cube_Color[3, 0];
                                Cube_Color[1, 7] = Cube_Color[3, 3];
                                Cube_Color[1, 8] = Cube_Color[3, 6];
                                break;
                            case 1:
                                Cube_Color[0, 2] = Cube_Color[0, 8];
                                Cube_Color[0, 5] = Cube_Color[0, 7];
                                Cube_Color[3, 0] = Cube_Color[5, 2];
                                Cube_Color[3, 3] = Cube_Color[5, 1];
                                Cube_Color[3, 6] = Cube_Color[5, 0];
                                break;
                            case 2:
                                Cube_Color[0, 8] = Cube_Color[0, 6];
                                Cube_Color[0, 7] = Cube_Color[0, 3];
                                Cube_Color[5, 2] = Cube_Color[2, 8];
                                Cube_Color[5, 1] = Cube_Color[2, 5];
                                Cube_Color[5, 0] = Cube_Color[2, 2];
                                break;
                            case 3:
                                Cube_Color[0, 6] = save_Quad[0];
                                Cube_Color[0, 3] = save_Quad[1];
                                Cube_Color[2, 8] = save_Quad[2];
                                Cube_Color[2, 5] = save_Quad[3];
                                Cube_Color[2, 2] = save_Quad[4];
                                break;
                        }
                    }
                    break;
                case 1:
                    save_Quad[2] = Cube_Color[1, 3];
                    save_Quad[3] = Cube_Color[1, 4];
                    save_Quad[4] = Cube_Color[1, 5];
                    for (int c = 0; c < 4; c++)
                    {
                        switch (c)
                        {
                            case 0:
                                Cube_Color[1, 3] = Cube_Color[3, 1];
                                Cube_Color[1, 4] = Cube_Color[3, 4];
                                Cube_Color[1, 5] = Cube_Color[3, 7];
                                break;
                            case 1:
                                Cube_Color[3, 1] = Cube_Color[5, 5];
                                Cube_Color[3, 4] = Cube_Color[5, 4];
                                Cube_Color[3, 7] = Cube_Color[5, 3];
                                break;
                            case 2:
                                Cube_Color[5, 5] = Cube_Color[2, 7];
                                Cube_Color[5, 4] = Cube_Color[2, 4];
                                Cube_Color[5, 3] = Cube_Color[2, 1];
                                break;
                            case 3:
                                Cube_Color[2, 7] = save_Quad[2];
                                Cube_Color[2, 4] = save_Quad[3];
                                Cube_Color[2, 1] = save_Quad[4];
                                break;
                        }
                    }
                    break;
                case 2:
                    save_Quad[0] = Cube_Color[4, 0];
                    save_Quad[1] = Cube_Color[4, 1];
                    save_Quad[2] = Cube_Color[1, 0];
                    save_Quad[3] = Cube_Color[1, 1];
                    save_Quad[4] = Cube_Color[1, 2];
                    for(int c = 0; c < 4; c++)
                    {
                        switch (c)
                        {
                            case 0:
                                Cube_Color[4, 0] = Cube_Color[4, 2];
                                Cube_Color[4, 1] = Cube_Color[4, 5];
                                Cube_Color[1, 0] = Cube_Color[3, 2];
                                Cube_Color[1, 1] = Cube_Color[3, 5];
                                Cube_Color[1, 2] = Cube_Color[3, 8];
                                break;
                            case 1:
                                Cube_Color[4, 2] = Cube_Color[4, 8];
                                Cube_Color[4, 5] = Cube_Color[4, 7];
                                Cube_Color[3, 2] = Cube_Color[5, 8];
                                Cube_Color[3, 5] = Cube_Color[5, 7];
                                Cube_Color[3, 8] = Cube_Color[5, 6];
                                break;
                            case 2:
                                Cube_Color[4, 8] = Cube_Color[4, 6];
                                Cube_Color[4, 7] = Cube_Color[4, 3];
                                Cube_Color[5, 8] = Cube_Color[2, 6];
                                Cube_Color[5, 7] = Cube_Color[2, 3];
                                Cube_Color[5, 6] = Cube_Color[2, 0];
                                break;
                            case 3:
                                Cube_Color[4, 6] = save_Quad[0];
                                Cube_Color[4, 3] = save_Quad[1];
                                Cube_Color[2, 6] = save_Quad[2];
                                Cube_Color[2, 3] = save_Quad[3];
                                Cube_Color[2, 0] = save_Quad[4];
                                break;
                        }
                    }
                    break;
            }

        }
        else if (R == true)
        {
            switch (num)
            {
                case 0:
                    save_Quad[0] = Cube_Color[0, 0];
                    save_Quad[1] = Cube_Color[0, 1];
                    save_Quad[2] = Cube_Color[1, 6];
                    save_Quad[3] = Cube_Color[1, 7];
                    save_Quad[4] = Cube_Color[1, 8];
                    for (int c = 0; c < 4; c++)
                    {
                        switch (c)
                        {
                            case 0:
                                Cube_Color[0, 0] = Cube_Color[0, 6];
                                Cube_Color[0, 1] = Cube_Color[0, 3];
                                Cube_Color[1, 6] = Cube_Color[2, 8];
                                Cube_Color[1, 7] = Cube_Color[2, 5];
                                Cube_Color[1, 8] = Cube_Color[2, 2];
                                break;
                            case 1:
                                Cube_Color[0, 6] = Cube_Color[0, 8];
                                Cube_Color[0, 3] = Cube_Color[0, 7];
                                Cube_Color[2, 8] = Cube_Color[5, 2];
                                Cube_Color[2, 5] = Cube_Color[5, 1];
                                Cube_Color[2, 2] = Cube_Color[5, 0];
                                break;
                            case 2:
                                Cube_Color[0, 8] = Cube_Color[0, 2];
                                Cube_Color[0, 7] = Cube_Color[0,5];
                                Cube_Color[5, 2] = Cube_Color[3, 0];
                                Cube_Color[5, 1] = Cube_Color[3, 3];
                                Cube_Color[5, 0] = Cube_Color[3, 6];
                                break;
                            case 3:
                                Cube_Color[0, 2] = save_Quad[0];
                                Cube_Color[0, 5] = save_Quad[1];
                                Cube_Color[3, 0] = save_Quad[2];
                                Cube_Color[3, 3] = save_Quad[3];
                                Cube_Color[3, 6] = save_Quad[4];
                                break;
                        }
                    }
                    break;
                case 1:
                    save_Quad[2] = Cube_Color[1, 3];
                    save_Quad[3] = Cube_Color[1, 4];
                    save_Quad[4] = Cube_Color[1, 5];
                    for (int c = 0; c < 4; c++)
                    {
                        switch (c)
                        {
                            case 0:
                                Cube_Color[1, 3] = Cube_Color[2, 7];
                                Cube_Color[1, 4] = Cube_Color[2, 4];
                                Cube_Color[1, 5] = Cube_Color[2, 1];
                                break;
                            case 1:
                                Cube_Color[2, 7] = Cube_Color[5, 5];
                                Cube_Color[2, 4] = Cube_Color[5, 4];
                                Cube_Color[2, 1] = Cube_Color[5, 3];
                                break;
                            case 2:
                                Cube_Color[5, 5] = Cube_Color[3, 1];
                                Cube_Color[5, 4] = Cube_Color[3, 4];
                                Cube_Color[5, 3] = Cube_Color[3, 7];
                                break;
                            case 3:
                                Cube_Color[3, 1] = save_Quad[2];
                                Cube_Color[3, 4] = save_Quad[3];
                                Cube_Color[3, 7] = save_Quad[4];
                                break;
                        }
                    }
                    break;
                case 2:
                    save_Quad[0] = Cube_Color[4, 0];
                    save_Quad[1] = Cube_Color[4, 1];
                    save_Quad[2] = Cube_Color[1, 0];
                    save_Quad[3] = Cube_Color[1, 1];
                    save_Quad[4] = Cube_Color[1, 2];
                    for (int c = 0; c < 4; c++)
                    {
                        switch (c)
                        {
                            case 0:
                                Cube_Color[4, 0] = Cube_Color[4, 6];
                                Cube_Color[4, 1] = Cube_Color[4, 3];
                                Cube_Color[1, 0] = Cube_Color[2, 6];
                                Cube_Color[1, 1] = Cube_Color[2, 3];
                                Cube_Color[1, 2] = Cube_Color[2, 0];
                                break;
                            case 1:
                                Cube_Color[4, 6] = Cube_Color[4, 8];
                                Cube_Color[4, 3] = Cube_Color[4, 7];
                                Cube_Color[2, 6] = Cube_Color[5, 8];
                                Cube_Color[2,3] = Cube_Color[5, 7];
                                Cube_Color[2, 0] = Cube_Color[5, 6];
                                break;
                            case 2:
                                Cube_Color[4, 8] = Cube_Color[4, 2];
                                Cube_Color[4, 7] = Cube_Color[4, 5];
                                Cube_Color[5, 8] = Cube_Color[3, 2];
                                Cube_Color[5, 7] = Cube_Color[3, 5];
                                Cube_Color[5, 6] = Cube_Color[3, 8];
                                break;
                            case 3:
                                Cube_Color[4, 2] = save_Quad[0];
                                Cube_Color[4, 5] = save_Quad[1];
                                Cube_Color[3, 2] = save_Quad[2];
                                Cube_Color[3, 5] = save_Quad[3];
                                Cube_Color[3, 8] = save_Quad[4];
                                break;
                        }
                    }
                    break;
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