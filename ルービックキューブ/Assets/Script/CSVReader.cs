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

    public GameObject[] Cube_Green = new GameObject[6];
    public GameObject[] Cube_Yellow = new GameObject[6];
    public GameObject[] Cube_Blue = new GameObject[6];

    public GameObject[] Cube_Green_Yellow = new GameObject[24];
    public GameObject[] Cube_Yellow_Blue = new GameObject[24];
    public GameObject[] Cube_Blue_Green = new GameObject[24];

    public GameObject[] Cube_Blue_Green_Yellow = new GameObject[48];

    

    public int[,] Change_Cube = new int[3, 9];

    int g=0;

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
                    Change_Cube[g, (i * 3) + j] = int.Parse(csvDatas[i + h][j]);
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
                    if (Change_Cube[h, j + (i * 3)] >= 1 && Change_Cube[h, j + (i * 3)] <= 6)
                    {
                        //Instantiate(生成したいGameObject, 位置, 姿勢);
                        Instantiate(Cube_Green[(Change_Cube[h, j + (i * 3)] - 1)], new Vector3(j, 2 - i, h), Quaternion.identity);
                    }

                    else if (Change_Cube[h, j + (i * 3)] >= 7 && Change_Cube[h, j + (i * 3)] <= 12)
                    {
                        //Instantiate(生成したいGameObject, 位置, 姿勢);
                        Instantiate(Cube_Yellow[(Change_Cube[h, j + (i * 3)]) - 7], new Vector3(j, 2 - i, h), Quaternion.identity);
                    }

                    else if (Change_Cube[h, j + (i * 3)] >= 13 && Change_Cube[h, j + (i * 3)] <= 18)
                    {
                        //Instantiate(生成したいGameObject, 位置, 姿勢);
                        Instantiate(Cube_Blue[(Change_Cube[h, j + (i * 3)]) - 13], new Vector3(j, 2 - i, h), Quaternion.identity);
                    }

                    else if (Change_Cube[h, j + (i * 3)] >= 19 && Change_Cube[h, j + (i * 3)] <= 42)
                    {
                        //Instantiate(生成したいGameObject, 位置, 姿勢);
                        Instantiate(Cube_Green_Yellow[(Change_Cube[h, j + (i * 3)] - 19)], new Vector3(j, 2 - i, h), Quaternion.identity);
                    }

                    else if (Change_Cube[h, j + (i * 3)] >= 43 && Change_Cube[h, j + (i * 3)] <= 66)
                    {
                        //Instantiate(生成したいGameObject, 位置, 姿勢);
                        Instantiate(Cube_Yellow_Blue[(Change_Cube[h, j + (i * 3)]) - 43], new Vector3(j, 2 - i, h), Quaternion.identity);
                    }

                    else if (Change_Cube[h, j + (i * 3)] >= 67 && Change_Cube[h, j + (i * 3)] <= 90)
                    {
                        //Instantiate(生成したいGameObject, 位置, 姿勢);
                        Instantiate(Cube_Blue_Green[(Change_Cube[h, j + (i * 3)]) - 67], new Vector3(j, 2 - i, h), Quaternion.identity);
                    }

                    else if (Change_Cube[h, j + (i * 3)] >= 91 && Change_Cube[h, j + (i * 3)] <= 138)
                    {
                        //Instantiate(生成したいGameObject, 位置, 姿勢);
                        Instantiate(Cube_Blue_Green_Yellow[(Change_Cube[h, j + (i * 3)]) - 91], new Vector3(j, 2 - i, h), Quaternion.identity);
                    }

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
        int save_Center;
        int save_Sub;
        int save_Corner;

        if (R == false)
        {
            if (num == 1)
            {

                save_Center = Change_Cube[0, 4];
                save_Sub = Change_Cube[0, 1];

                for (int cen = 0; cen < 4; cen++)
                {
                    switch (cen)
                    {
                        case 0:
                            //Center
                            Change_Cube[0, 4] = Change_Cube[1, 7] - 5;
                            //Sub
                            switch ((Change_Cube[0, 7] - 18) % 24)
                            {
                                case 4:

                                    Change_Cube[0, 1] = Change_Cube[0, 7] + 1;

                                    break;
                                case 21:
                                    Change_Cube[0, 1] = Change_Cube[0, 7] - 20;
                                    break;
                            }
                            break;
                        case 1:
                            //Center
                            Change_Cube[1, 7] = Change_Cube[2, 4] + 1;
                            //Sub
                            switch ((Change_Cube[2, 7] - 18) % 24)
                            {
                                case 20:
                                    Change_Cube[0, 7] = Change_Cube[2, 7] + 1;
                                    break;
                                case 0:
                                    Change_Cube[0, 7] = Change_Cube[2, 7] - 20;
                                    break;
                            }
                            break;
                        case 2:
                            //Center
                            Change_Cube[2, 4] = Change_Cube[1, 1] + 3;
                            //Sub
                            switch ((Change_Cube[2, 1] - 18) % 24)
                            {
                                case 17:
                                    Change_Cube[2, 7] = Change_Cube[2, 1] + 7;
                                    break;
                                case 8:
                                    Change_Cube[2, 7] = Change_Cube[2, 1] + 12;
                                    break;
                            }
                            break;
                        case 3:
                            //Center
                            Change_Cube[1, 1] = save_Center + 1;
                            //Sub
                            switch ((save_Sub - 18) % 24)
                            {
                                case 1:
                                    Change_Cube[2, 1] = save_Sub + 7;
                                    break;
                                case 5:
                                    Change_Cube[2, 1] = save_Sub + 12;
                                    break;
                            }
                            break;
                    }
                }


            }
            else
            {
                save_Sub = Change_Cube[1, num];
                save_Corner = Change_Cube[0, num];
                for (int sub = 0; sub < 4; sub++)
                {
                    if (num == 0)
                    {
                        switch (sub)
                        {
                            case 0:
                                switch ((Change_Cube[0, 3] - 18) % 24)
                                {

                                    case 2:
                                        Change_Cube[1, 0] = Change_Cube[0, 3] + 4;
                                        break;
                                    case 9:
                                        Change_Cube[1, 0] = Change_Cube[0, 3] + 1;
                                        break;
                                }
                                break;
                            case 1:
                                switch ((Change_Cube[1, 6] - 18) % 24)
                                {

                                    case 12:
                                        Change_Cube[0, 3] = Change_Cube[1, 6] - 3;
                                        break;
                                    case 22:
                                        Change_Cube[0, 3] = Change_Cube[1, 6] - 20;
                                        break;
                                }
                                break;
                            case 2:
                                switch ((Change_Cube[2, 3] - 18) % 24)
                                {

                                    case 11:
                                        Change_Cube[1, 6] = Change_Cube[2, 3] + 1;
                                        break;
                                    case 18:
                                        Change_Cube[1, 6] = Change_Cube[2, 3] + 4;
                                        break;
                                }
                                break;
                            case 3:
                                switch ((save_Sub - 18) % 24)
                                {

                                    case 10:
                                        Change_Cube[2, 3] = save_Sub + 1;
                                        break;
                                    case 6:
                                        Change_Cube[2, 3] = save_Sub + 12;
                                        break;
                                }
                                break;
                        }

                    }
                    else if (num == 2)
                    {
                        switch (sub)
                        {
                            case 0:
                                switch ((Change_Cube[0, 5] - 18) % 24)
                                {

                                    case 3:
                                        Change_Cube[1, 2] = Change_Cube[0, 5] + 4;
                                        break;
                                    case 13:
                                        Change_Cube[1, 2] = Change_Cube[0, 5] + 1;
                                        break;
                                }
                                break;
                            case 1:
                                switch ((Change_Cube[1, 8] - 18) % 24)
                                {

                                    case 16:
                                        Change_Cube[0, 5] = Change_Cube[1, 8] - 3;
                                        break;
                                    case 23:
                                        Change_Cube[0, 5] = Change_Cube[1, 8] - 20;
                                        break;
                                }
                                break;
                            case 2:
                                switch ((Change_Cube[2, 5] - 18) % 24)
                                {

                                    case 15:
                                        Change_Cube[1, 8] = Change_Cube[2, 5] + 1;
                                        break;
                                    case 19:
                                        Change_Cube[1, 8] = Change_Cube[2, 5] + 4;
                                        break;
                                }
                                break;
                            case 3:
                                switch ((save_Sub - 18) % 24)
                                {

                                    case 14:
                                        Change_Cube[2, 5] = save_Sub + 1;
                                        break;
                                    case 7:
                                        Change_Cube[2, 5] = save_Sub + 12;
                                        break;
                                }
                                break;
                        }
                    }
                }
                for (int cor = 0; cor < 4; cor++)
                {
                    switch (cor)
                    {
                        case 0:
                            switch (Change_Cube[0, num + 6])
                            {
                                case 93:
                                case 94:
                                    Change_Cube[0, num] = Change_Cube[0, num + 6] + 6;
                                    break;
                                case 101:
                                case 102:
                                    Change_Cube[0, num] = Change_Cube[0, num + 6] - 10;
                                    break;

                                case 109:
                                case 110:
                                    Change_Cube[0, num] = Change_Cube[0, num + 6]+22;
                                    break;
                                case 133:
                                case 134:
                                    Change_Cube[0, num] = Change_Cube[0, num + 6]-26;
                                    break;

                                case 117:
                                case 118:
                                    Change_Cube[0, num] = Change_Cube[0, num + 6]+6;
                                    break;
                                case 125:
                                case 126:
                                    Change_Cube[0, num] = Change_Cube[0, num + 6]-10;
                                    break;
                            }
                            break;
                        case 1:
                            switch (Change_Cube[2, num + 6])
                            {
                                case 97:
                                case 98:
                                    Change_Cube[0, num + 6] = Change_Cube[2, num + 6] + 4;
                                    break;
                                case 105:
                                case 106:
                                    Change_Cube[0, num + 6] = Change_Cube[2, num + 6] - 12;
                                    break;

                                case 113:
                                case 114:
                                    Change_Cube[0, num + 6] = Change_Cube[2, num + 6] + 20;
                                    break;
                                case 137:
                                case 138:
                                    Change_Cube[0, num + 6] = Change_Cube[2, num + 6] - 28;
                                    break;

                                case 121:
                                case 122:
                                    Change_Cube[0, num + 6] = Change_Cube[2, num + 6] + 4;
                                    break;
                                case 129:
                                case 130:
                                    Change_Cube[0, num + 6] = Change_Cube[2, num + 6] - 12;
                                    break;
                            }
                            break;
                        case 2:
                            switch (Change_Cube[2, num])
                            {
                                case 95:
                                case 96:
                                    Change_Cube[2, num + 6] = Change_Cube[2, num] + 10;
                                    break;
                                case 103:
                                case 104:
                                    Change_Cube[2, num + 6] = Change_Cube[2, num] - 6;
                                    break;

                                case 111:
                                case 112:
                                    Change_Cube[2, num + 6] = Change_Cube[2, num] + 26;
                                    break;
                                case 135:
                                case 136:
                                    Change_Cube[2, num + 6] = Change_Cube[2, num] -22;
                                    break;

                                case 119:
                                case 120:
                                    Change_Cube[2, num + 6] = Change_Cube[2, num] + 10;
                                    break;
                                case 127:
                                case 128:
                                    Change_Cube[2, num + 6] = Change_Cube[2, num] - 6;
                                    break;
                            }
                            break;
                        case 3:
                            switch (save_Corner)
                            {
                                case 91:
                                case 92:
                                    Change_Cube[2, num] = save_Corner + 12;
                                    break;
                                case 99:
                                case 100:
                                    Change_Cube[2, num] = save_Corner - 4;
                                    break;

                                case 107:
                                case 108:                                  
                                    Change_Cube[2, num] = save_Corner + 28;
                                    break;
                                case 131:
                                case 132:
                                    Change_Cube[2, num] = save_Corner - 20;
                                    break;

                                case 115:
                                case 116:
                                    Change_Cube[2, num] = save_Corner + 12;
                                    break;
                                case 123:
                                case 124:
                                    Change_Cube[2, num] = save_Corner - 4;
                                    break;
                            }
                            break;
                    }
                }
            }
        }
        else if (R == true)
        {
            if (num == 1)
            {
                save_Center = Change_Cube[0, 4];
                save_Sub = Change_Cube[0, 1];

                for (int cen = 0; cen < 4; cen++)
                {
                    switch (cen)
                    {
                        case 0:
                            Change_Cube[0, 4] = Change_Cube[1, 1] - 1;
                            switch ((Change_Cube[2, 1] - 18) % 24)
                            {
                                case 17:
                                    Change_Cube[0, 1] = Change_Cube[2, 1] - 12;
                                    break;
                                case 8:
                                    Change_Cube[0, 1] = Change_Cube[2, 1] - 7;
                                    break;
                            }
                            break;
                        case 1:
                            Change_Cube[1, 1] = Change_Cube[2, 4] - 3;
                            //Sub
                            switch ((Change_Cube[2, 7] - 18) % 24)
                            {
                                case 20:
                                    Change_Cube[2, 1] = Change_Cube[2, 7] - 12;
                                    break;
                                case 0:
                                    Change_Cube[2, 1] = Change_Cube[2, 7] - 7;
                                    break;
                            }
                            break;
                        case 2:
                            Change_Cube[2, 4] = Change_Cube[1, 7] - 1;
                            //Sub
                            switch ((Change_Cube[0, 7] - 18) % 24)
                            {
                                case 4:
                                    Change_Cube[2, 7] = Change_Cube[0, 7] + 20;
                                    break;
                                case 21:
                                    Change_Cube[2, 7] = Change_Cube[0, 7] - 1;
                                    break;
                            }
                            break;
                        case 3:
                            Change_Cube[1, 7] = save_Center + 5;
                            //Sub
                            switch ((save_Sub - 18) % 24)
                            {
                                case 1:

                                    Change_Cube[0, 7] = save_Sub + 20;

                                    break;
                                case 5:
                                    Change_Cube[0, 7] = save_Sub - 1;
                                    break;
                            }
                            break;
                    }
                }
            }
            else
            {
                save_Sub = Change_Cube[1, num];
                save_Corner= Change_Cube[0, num];
                for (int sub = 0; sub < 4; sub++)
                {
                    if (num == 0)
                    {
                        switch (sub)
                        {
                            case 0:
                                switch ((Change_Cube[2, 3] - 18) % 24)
                                {

                                    case 11:
                                        Change_Cube[1, 0] = Change_Cube[2, 3] - 1;
                                        break;
                                    case 18:
                                        Change_Cube[1, 0] = Change_Cube[2, 3] - 12;
                                        break;
                                }
                                break;
                            case 1:
                                switch ((Change_Cube[1, 6] - 18) % 24)
                                {

                                    case 12:
                                        Change_Cube[2, 3] = Change_Cube[1, 6] - 1;
                                        break;
                                    case 22:
                                        Change_Cube[2, 3] = Change_Cube[1, 6] - 4;
                                        break;
                                }
                                break;
                            case 2:
                                switch ((Change_Cube[0, 3] - 18) % 24)
                                {

                                    case 2:
                                        Change_Cube[1, 6] = Change_Cube[0, 3] + 20;
                                        break;
                                    case 9:
                                        Change_Cube[1, 6] = Change_Cube[0, 3] + 3;
                                        break;
                                }
                                break;
                            case 3:
                                switch ((save_Sub - 18) % 24)
                                {

                                    case 10:
                                        Change_Cube[0, 3] = save_Sub - 1;
                                        break;
                                    case 6:
                                        Change_Cube[0, 3] = save_Sub - 4;
                                        break;
                                }
                                break;
                        }
                    }
                    else if (num == 2)
                    {
                        switch (sub)
                        {
                            case 0:
                                switch ((Change_Cube[2, 5] - 18) % 24)
                                {

                                    case 15:
                                        Change_Cube[1, 2] = Change_Cube[2, 5] - 1;
                                        break;
                                    case 19:
                                        Change_Cube[1, 2] = Change_Cube[2, 5] - 12;
                                        break;
                                }
                                break;
                            case 1:
                                switch ((Change_Cube[1, 8] - 18) % 24)
                                {

                                    case 16:
                                        Change_Cube[2, 5] = Change_Cube[1, 8] - 1;
                                        break;
                                    case 23:
                                        Change_Cube[2, 5] = Change_Cube[1, 8] - 4;
                                        break;
                                }
                                break;
                            case 2:
                                switch ((Change_Cube[0, 5] - 18) % 24)
                                {

                                    case 3:
                                        Change_Cube[1, 8] = Change_Cube[0, 5] + 20;
                                        break;
                                    case 13:
                                        Change_Cube[1, 8] = Change_Cube[0, 5] + 3;
                                        break;
                                }
                                break;
                            case 3:
                                switch ((save_Sub - 18) % 24)
                                {

                                    case 14:
                                        Change_Cube[0, 5] = save_Sub - 1;
                                        break;
                                    case 7:
                                        Change_Cube[0, 5] = save_Sub - 4;
                                        break;
                                }
                                break;
                        }
                    }
                }
                for (int cor = 0; cor < 4; cor++)
                {
                    switch (cor)
                    {
                        case 0:
                            switch (Change_Cube[2, num])
                            {
                                case 95:
                                case 96:
                                    Change_Cube[0, num] = Change_Cube[2, num] + 4;
                                    break;
                                case 103:
                                case 104:
                                    Change_Cube[0, num] = Change_Cube[2, num] - 12;
                                    break;

                                case 111:
                                case 112:
                                    Change_Cube[0, num] = Change_Cube[2, num] + 20;
                                    break;
                                case 135:
                                case 136:
                                    Change_Cube[0, num] = Change_Cube[2, num] - 28;
                                    break;

                                case 119:
                                case 120:
                                    Change_Cube[0, num] = Change_Cube[2, num] + 4;
                                    break;
                                case 127:
                                case 128:
                                    Change_Cube[0, num] = Change_Cube[2, num] - 12;
                                    break;
                            }
                            break;
                        case 1:
                            switch (Change_Cube[2, num + 6])
                            {
                                case 97:
                                case 98:
                                    Change_Cube[2, num] = Change_Cube[2, num + 6] + 6;
                                    break;
                                case 105:
                                case 106:
                                    Change_Cube[2, num] = Change_Cube[2, num + 6] - 10;
                                    break;

                                case 113:
                                case 114:
                                    Change_Cube[2, num] = Change_Cube[2, num + 6] + 22;
                                    break;
                                case 137:
                                case 138:
                                    Change_Cube[2, num] = Change_Cube[2, num + 6] - 26;
                                    break;

                                case 121:
                                case 122:
                                    Change_Cube[2, num] = Change_Cube[2, num + 6] + 6;
                                    break;
                                case 129:
                                case 130:
                                    Change_Cube[2, num] = Change_Cube[2, num + 6] - 10;
                                    break;
                            }
                            break;
                        case 2:
                            switch (Change_Cube[0, num + 6])
                            {
                                case 93:
                                case 94:
                                    Change_Cube[2, num + 6] = Change_Cube[0, num + 6] + 12;
                                    break;
                                case 101:
                                case 102:
                                    Change_Cube[2, num + 6] = Change_Cube[0, num + 6] - 4;
                                    break;

                                case 109:
                                case 110:
                                    Change_Cube[2, num + 6] = Change_Cube[0, num + 6] + 28;
                                    break;
                                case 133:
                                case 134:
                                    Change_Cube[2, num + 6] = Change_Cube[0, num + 6] -20;
                                    break;

                                case 117:
                                case 118:
                                    Change_Cube[2, num + 6] = Change_Cube[0, num + 6] + 12;
                                    break;
                                case 125:
                                case 126:
                                    Change_Cube[2, num + 6] = Change_Cube[0, num + 6] - 4;
                                    break;
                            }
                            break;
                        case 3:
                            switch (save_Corner)
                            {
                                case 91:
                                case 92:
                                    Change_Cube[0, num + 6] = save_Corner + 10;
                                    break;
                                case 99:
                                case 100:
                                    Change_Cube[0, num + 6] = save_Corner - 6;
                                    break;

                                case 107:
                                case 108:
                                    Change_Cube[0, num + 6] = save_Corner +26;
                                    break;
                                case 131:
                                case 132:
                                    Change_Cube[0, num + 6] = save_Corner - 22;
                                    break;

                                case 115:
                                case 116:
                                    Change_Cube[0, num + 6] = save_Corner +10;
                                    break;
                                case 123:
                                case 124:
                                    Change_Cube[0, num + 6] = save_Corner -6;
                                    break;
                            }
                            break;
                    }
                }
            }
        }

    }
    public void ChangeArrayY(int num, bool R)
    {
        int save_Center;
        int save_Sub;
        int save_Corner;
        if (R == false)
        {
            if (num == 1)
            {
                save_Sub = Change_Cube[0, 3];
                save_Center = Change_Cube[0, 4];
                for (int cen = 0; cen < 4; cen++)
                {
                    switch (cen)
                    {
                        case 0:
                            //Center
                            Change_Cube[0, 4] = Change_Cube[1, 5] - 3;
                            //Sub
                            switch ((Change_Cube[0, 5] - 18) % 24)
                            {
                                case 3:

                                    Change_Cube[0, 3] = Change_Cube[0, 5] + 6;

                                    break;
                                case 13:
                                    Change_Cube[0, 3] = Change_Cube[0, 5] - 11;
                                    break;
                            }
                            break;
                        case 1:
                            //Center
                            Change_Cube[1, 5] = Change_Cube[2, 4] - 1;
                            //Sub
                            switch ((Change_Cube[2, 5] - 18) % 24)
                            {
                                case 15:
                                    Change_Cube[0, 5] = Change_Cube[2, 5] - 12;
                                    break;
                                case 19:
                                    Change_Cube[0, 5] = Change_Cube[2, 5] - 6;
                                    break;
                            }
                            break;
                        case 2:
                            //Center
                            Change_Cube[2, 4] = Change_Cube[1, 3] + 2;
                            //Sub
                            switch ((Change_Cube[2, 3] - 18) % 24)
                            {
                                case 11:

                                    Change_Cube[2, 5] = Change_Cube[2, 3] + 8;

                                    break;
                                case 18:
                                    Change_Cube[2, 5] = Change_Cube[2, 3] - 3;
                                    break;
                            }
                            break;
                        case 3:
                            //Center
                            Change_Cube[1, 3] = save_Center + 2;
                            //Sub
                            switch ((save_Sub - 18) % 24)
                            {
                                case 9:

                                    Change_Cube[2, 3] = save_Sub + 9;

                                    break;
                                case 2:
                                    Change_Cube[2, 3] = save_Sub + 9;
                                    break;
                            }
                            break;
                    }
                }
            }
            else
            {
                save_Sub = Change_Cube[0, ((2-num)*3)+1];
                save_Corner=Change_Cube[0, (2 - num) * 3];
                for (int sub = 0; sub < 4; sub++)
                {
                    if (num == 0)
                    {
                        switch (sub)
                        {
                            case 0:
                                switch ((Change_Cube[1, 8] - 18) % 24)
                                {

                                    case 16:
                                        Change_Cube[0, 7] = Change_Cube[1, 8]-12;
                                        break;
                                    case 23:
                                        Change_Cube[0, 7] = Change_Cube[1, 8]-2;
                                        break;
                                }
                                break;
                            case 1:
                                switch ((Change_Cube[2, 7] - 18) % 24)
                                {

                                    case 20:
                                        Change_Cube[1, 8] = Change_Cube[2, 7]-4;
                                        break;
                                    case 0:
                                        Change_Cube[1, 8] = Change_Cube[2, 7]-1;
                                        break;
                                }
                                break;
                            case 2:
                                switch ((Change_Cube[1, 6] - 18) % 24)
                                {

                                    case 12:
                                        Change_Cube[2, 7] = Change_Cube[1, 6]+8;
                                        break;
                                    case 22:
                                        Change_Cube[2, 7] = Change_Cube[1, 6]+2;
                                        break;
                                }
                                break;
                            case 3:
                                switch ((save_Sub - 18) % 24)
                                {

                                    case 4:
                                        Change_Cube[1, 6] = save_Sub+8;
                                        break;
                                    case 21:
                                        Change_Cube[1, 6] = save_Sub+1;
                                        break;
                                }
                                break;
                        }
                    }
                    else if (num == 2)
                    {
                        switch (sub)
                        {
                            case 0:
                                switch ((Change_Cube[1, 2] - 18) % 24)
                                {

                                    case 7:
                                        Change_Cube[0, 1] = Change_Cube[1, 2] -2;
                                        break;
                                    case 14:
                                        Change_Cube[0, 1] = Change_Cube[1, 2] -13;
                                        break;
                                }
                                break;
                            case 1:
                                switch ((Change_Cube[2, 1] - 18) % 24)
                                {

                                    case 17:
                                        Change_Cube[1, 2] = Change_Cube[2, 1] -3;
                                        break;
                                    case 8:
                                        Change_Cube[1, 2] = Change_Cube[2, 1]-1 ;
                                        break;
                                }
                                break;
                            case 2:
                                switch ((Change_Cube[1, 0] - 18) % 24)
                                {

                                    case 6:
                                        Change_Cube[2, 1] = Change_Cube[1, 0]+2;
                                        break;
                                    case 10:
                                        Change_Cube[2, 1] = Change_Cube[1, 0]+7;
                                        break;
                                }
                                break;
                            case 3:
                                switch ((save_Sub - 18) % 24)
                                {

                                    case 1:
                                        Change_Cube[1, 0] = save_Sub+9;
                                        break;
                                    case 5:
                                        Change_Cube[1, 0] = save_Sub+1;
                                        break;
                                }
                                break;
                        }
                    }
                }
                for (int cor = 0; cor < 4; cor++)
                {
                    switch (cor)
                    {
                        case 0:
                            switch (Change_Cube[0, (2 - num) * 3+2])
                            {
                                case 92:
                                case 94:
                                    Change_Cube[0, (2 - num) * 3] = Change_Cube[0, (2 - num) * 3 + 2] + 15;
                                    break;
                                case 108:
                                case 110:
                                    Change_Cube[0, (2 - num) * 3] = Change_Cube[0, (2 - num) * 3 + 2] - 17;
                                    break;

                                case 100:
                                case 102:
                                    Change_Cube[0, (2 - num) * 3] = Change_Cube[0, (2 - num) * 3 + 2] + 23;
                                    break;
                                case 124:
                                case 126:
                                    Change_Cube[0, (2 - num) * 3] = Change_Cube[0, (2 - num) * 3 + 2] - 25;
                                    break;

                                case 116:
                                case 118:
                                    Change_Cube[0, (2 - num) * 3] = Change_Cube[0, (2 - num) * 3 + 2]+15;
                                    break;
                                case 132:
                                case 134:
                                    Change_Cube[0, (2 - num) * 3] = Change_Cube[0, (2 - num) * 3 + 2]-17;
                                    break;
                            }
                            break;
                        case 1:
                            switch (Change_Cube[2, (2 - num) * 3 + 2])
                            {
                                case 96:
                                case 98:
                                    Change_Cube[0, (2 - num) * 3 + 2] = Change_Cube[2, (2 - num) * 3 + 2] + 12;
                                    break;
                                case 112:
                                case 114:
                                    Change_Cube[0, (2 - num) * 3 + 2] = Change_Cube[2, (2 - num) * 3 + 2] - 20;
                                    break;

                                case 104:
                                case 106:
                                    Change_Cube[0, (2 - num) * 3 + 2] = Change_Cube[2, (2 - num) * 3 + 2] + 20;
                                    break;
                                case 128:
                                case 130:
                                    Change_Cube[0, (2 - num) * 3 + 2] = Change_Cube[2, (2 - num) * 3 + 2] - 28;
                                    break;

                                case 120:
                                case 122:
                                    Change_Cube[0, (2 - num) * 3 + 2] = Change_Cube[2, (2 - num) * 3 + 2]+12;
                                    break;
                                case 136:
                                case 138:
                                    Change_Cube[0, (2 - num) * 3 + 2] = Change_Cube[2, (2 - num) * 3 + 2]-20;
                                    break;
                            }
                            break;
                        case 2:
                            switch (Change_Cube[2, (2 - num) * 3])
                            {
                                case 95:
                                case 97:
                                    Change_Cube[2, (2 - num) * 3 + 2] = Change_Cube[2, (2 - num) * 3] + 17;
                                    break;
                                case 111:
                                case 113:
                                    Change_Cube[2, (2 - num) * 3 + 2] = Change_Cube[2, (2 - num) * 3] - 15;
                                    break;

                                case 103:
                                case 105:
                                    Change_Cube[2, (2 - num) * 3 + 2] = Change_Cube[2, (2 - num) * 3] + 25;
                                    break;
                                case 127:
                                case 129:
                                    Change_Cube[2, (2 - num) * 3 + 2] = Change_Cube[2, (2 - num) * 3] - 23;
                                    break;

                                case 119:
                                case 121:
                                    Change_Cube[2, (2 - num) * 3 + 2] = Change_Cube[2, (2 - num) * 3]+17;
                                    break;
                                case 135:
                                case 137:
                                    Change_Cube[2, (2 - num) * 3 + 2] = Change_Cube[2, (2 - num) * 3]-15;
                                    break;
                            }
                            break;
                        case 3:
                            switch (save_Corner)
                            {
                                case 91:
                                case 93:
                                    Change_Cube[2, (2 - num) * 3] = save_Corner + 20;
                                    break;
                                case 107:
                                case 109:
                                    Change_Cube[2, (2 - num) * 3] = save_Corner - 12;
                                    break;

                                case 99:
                                case 101:
                                    Change_Cube[2, (2 - num) * 3] = save_Corner + 28;
                                    break;
                                case 123:
                                case 125:
                                    Change_Cube[2, (2 - num) * 3] = save_Corner - 20;
                                    break;

                                case 115:
                                case 117:
                                    Change_Cube[2, (2 - num) * 3] = save_Corner+20; 
                                    break;
                                case 131:
                                case 133:
                                    Change_Cube[2, (2 - num) * 3] = save_Corner-12;
                                    break;
                            }
                            break;
                    }
                }
            }
        }
        else if (R == true)
        {
            if (num == 1)
            {
                save_Sub = Change_Cube[0, 3];
                save_Center = Change_Cube[0, 4];
                for (int cen = 0; cen < 4; cen++)
                {
                    switch (cen)
                    {
                        case 0:
                            //Center
                            Change_Cube[0, 4] = Change_Cube[1, 3] - 2;
                            //Sub
                            switch ((Change_Cube[2, 3] - 18) % 24)
                            {
                                case 11:

                                    Change_Cube[0, 3] = Change_Cube[2, 3] - 9;

                                    break;
                                case 18:
                                    Change_Cube[0, 3] = Change_Cube[2, 3] - 9;
                                    break;
                            }
                            break;
                        case 1:
                            //Center
                            Change_Cube[1, 3] = Change_Cube[2, 4] - 2;
                            //Sub
                            switch ((Change_Cube[2, 5] - 18) % 24)
                            {
                                case 15:
                                    Change_Cube[2, 3] = Change_Cube[2, 5] + 3;
                                    break;
                                case 19:
                                    Change_Cube[2, 3] = Change_Cube[2, 5] - 8;
                                    break;
                            }
                            break;
                        case 2:
                            //Center
                            Change_Cube[2, 4] = Change_Cube[1, 5] + 1;
                            //Sub
                            switch ((Change_Cube[0, 5] - 18) % 24)
                            {
                                case 3:

                                    Change_Cube[2, 5] = Change_Cube[0, 5] + 12;

                                    break;
                                case 13:
                                    Change_Cube[2, 5] = Change_Cube[0, 5] + 6;
                                    break;
                            }

                            break;
                        case 3:
                            //Center
                            Change_Cube[1, 5] = save_Center + 3;
                            switch ((save_Sub - 18) % 24)
                            {
                                case 9:

                                    Change_Cube[0, 5] = save_Sub - 6;

                                    break;
                                case 2:
                                    Change_Cube[0, 5] = save_Sub + 11;
                                    break;
                            }
                            break;
                    }
                }
            }
            else
            {
                save_Sub = Change_Cube[0, ((2 - num) * 3) + 1];
                save_Corner = Change_Cube[0, (2 - num) * 3];
                for (int sub = 0; sub < 4; sub++)
                {
                    if (num == 0)
                    {
                        switch (sub)
                        {
                            case 0:
                                switch ((Change_Cube[1, 6] - 18) % 24)
                                {

                                    case 12:
                                        Change_Cube[0, 7] = Change_Cube[1, 6] -8;
                                        break;
                                    case 22:
                                        Change_Cube[0, 7] = Change_Cube[1, 6] -1;
                                        break;
                                }
                                break;
                               
                            case 1:
                                switch ((Change_Cube[2, 7] - 18) % 24)
                                {

                                    case 20:
                                        Change_Cube[1, 6] = Change_Cube[2, 7] - 8;
                                        break;
                                    case 0:
                                        Change_Cube[1, 6] = Change_Cube[2, 7] - 2;
                                        break;
                                }
                                break;
                            case 2:
                                switch ((Change_Cube[1, 8] - 18) % 24)
                                {

                                    case 16:
                                        Change_Cube[2, 7] = Change_Cube[1, 8] +4;
                                        break;
                                    case 23:
                                        Change_Cube[2, 7] = Change_Cube[1, 8] +1;
                                        break;
                                }
                                break;

                            case 3:
                                switch ((save_Sub - 18) % 24)
                                {

                                    case 4:
                                        Change_Cube[1, 8] = save_Sub + 12;
                                        break;
                                    case 21:
                                        Change_Cube[1, 8] = save_Sub + 2;
                                        break;
                                }
                                break;
                        }
                    }
                    else if (num == 2)
                    {
                        switch (sub)
                        {
                            case 0:
                                switch ((Change_Cube[1, 0] - 18) % 24)
                                {

                                    case 6:
                                        Change_Cube[0, 1] = Change_Cube[1, 0] - 1;
                                        break;
                                    case 10:
                                        Change_Cube[0, 1] = Change_Cube[1, 0] - 9;
                                        break;
                                }
                                break;
                            case 1:
                                switch ((Change_Cube[2, 1] - 18) % 24)
                                {

                                    case 17:
                                        Change_Cube[1, 0] = Change_Cube[2, 1] - 7;
                                        break;
                                    case 8:
                                        Change_Cube[1, 0] = Change_Cube[2, 1] - 2;
                                        break;
                                }
                                break;
                            case 2:
                                switch ((Change_Cube[1, 2] - 18) % 24)
                                {

                                    case 7:
                                        Change_Cube[2, 1] = Change_Cube[1, 2] + 1;
                                        break;
                                    case 14:
                                        Change_Cube[2, 1] = Change_Cube[1, 2] + 3;
                                        break;
                                }
                                break;
                            case 3:
                                switch ((save_Sub - 18) % 24)
                                {

                                    case 1:
                                        Change_Cube[1, 2] = save_Sub + 13;
                                        break;
                                    case 5:
                                        Change_Cube[1, 2] = save_Sub + 2;
                                        break;
                                }
                                break;
                        }
                    }
                }
                for (int cor = 0; cor < 4; cor++)
                {
                    switch (cor)
                    {
                        case 0:
                            switch (Change_Cube[2, (2 - num) * 3])
                            {
                                case 95:
                                case 97:
                                    Change_Cube[0, (2 - num) * 3] = Change_Cube[2, (2 - num) * 3] + 12;
                                    break;
                                case 111:
                                case 113:
                                    Change_Cube[0, (2 - num) * 3] = Change_Cube[2, (2 - num) * 3] - 20;
                                    break;

                                case 103:
                                case 105:
                                    Change_Cube[0, (2 - num) * 3] = Change_Cube[2, (2 - num) * 3] + 20;
                                    break;
                                case 127:
                                case 129:
                                    Change_Cube[0, (2 - num) * 3] = Change_Cube[2, (2 - num) * 3] - 28;
                                    break;

                                case 119:
                                case 121:
                                    Change_Cube[0, (2 - num) * 3] = Change_Cube[2, (2 - num) * 3] + 12;
                                    break;
                                case 135:
                                case 137:
                                    Change_Cube[0, (2 - num) * 3] = Change_Cube[2, (2 - num) * 3] - 20;
                                    break;
                            }
                            break;
                        case 1:
                            switch (Change_Cube[2, (2 - num) * 3 + 2])
                            {
                                case 96:
                                case 98:
                                    Change_Cube[2, (2 - num) * 3] = Change_Cube[2, (2 - num) * 3 + 2] + 15;
                                    break;
                                case 112:
                                case 114:
                                    Change_Cube[2, (2 - num) * 3] = Change_Cube[2, (2 - num) * 3 + 2] - 17;
                                    break;

                                case 104:
                                case 106:
                                    Change_Cube[2, (2 - num) * 3] = Change_Cube[2, (2 - num) * 3 + 2] + 23;
                                    break;
                                case 128:
                                case 130:
                                    Change_Cube[2, (2 - num) * 3] = Change_Cube[2, (2 - num) * 3 + 2] - 25;
                                    break;

                                case 120:
                                case 122:
                                    Change_Cube[2, (2 - num) * 3] = Change_Cube[2, (2 - num) * 3 + 2] + 15;
                                    break;
                                case 136:
                                case 138:
                                    Change_Cube[2, (2 - num) * 3] = Change_Cube[2, (2 - num) * 3 + 2] - 17;
                                    break;
                            }
                            break;
                        case 2:
                            switch (Change_Cube[0, (2 - num) * 3 + 2])
                            {
                                case 92:
                                case 94:
                                    Change_Cube[2, (2 - num) * 3 + 2] = Change_Cube[0, (2 - num) * 3 + 2] + 20;
                                    break;
                                case 108:
                                case 110:
                                    Change_Cube[2, (2 - num) * 3 + 2] = Change_Cube[0, (2 - num) * 3 + 2] - 12;
                                    break;

                                case 100:
                                case 102:
                                    Change_Cube[2, (2 - num) * 3 + 2] = Change_Cube[0, (2 - num) * 3 + 2] + 28;
                                    break;
                                case 124:
                                case 126:
                                    Change_Cube[2, (2 - num) * 3 + 2] = Change_Cube[0, (2 - num) * 3 + 2] - 20;
                                    break;

                                case 116:
                                case 118:
                                    Change_Cube[2, (2 - num) * 3 + 2] = Change_Cube[0, (2 - num) * 3 + 2] + 20;
                                    break;
                                case 132:
                                case 134:
                                    Change_Cube[2, (2 - num) * 3 + 2] = Change_Cube[0, (2 - num) * 3 + 2] - 12;
                                    break;
                            }
                            break;                           
                        case 3:
                            switch (save_Corner)
                            {
                                case 91:
                                case 93:
                                    Change_Cube[0, (2 - num) * 3 + 2] = save_Corner + 17;
                                    break;
                                case 107:
                                case 109:
                                    Change_Cube[0, (2 - num) * 3 + 2] = save_Corner - 15;
                                    break;

                                case 99:
                                case 101:
                                    Change_Cube[0, (2 - num) * 3 + 2] = save_Corner + 25;
                                    break;
                                case 123:
                                case 125:
                                    Change_Cube[0, (2 - num) * 3 + 2] = save_Corner - 23;
                                    break;

                                case 115:
                                case 117:
                                    Change_Cube[0, (2 - num) * 3 + 2] = save_Corner + 17;
                                    break;
                                case 131:
                                case 133:
                                    Change_Cube[0, (2 - num) * 3 + 2] = save_Corner - 15;
                                    break;
                            }
                            break;
                    }
                }
            }
        }
    }
    public void ChangeArrayZ(int num, bool R)
    {
        int save_Center;
        int save_Sub;
        int save_Corner;
        int count = 5;
        if (R == false)
        {
            if (num == 1)
            {
                save_Center = Change_Cube[num, 1];
                save_Sub = Change_Cube[num, 0];
                for (int cen = 0; cen < 4; cen++)
                {
                    switch (cen)
                    {
                        case 0:
                            //Center
                            Change_Cube[num, 1] = Change_Cube[num, 5] - 2;

                            //Sub
                            switch ((Change_Cube[num, 2] - 18) % 24)
                            {
                                case 7:
                                    Change_Cube[num, 0] = Change_Cube[num, 2] + 3;
                                    break;
                                case 14:
                                    Change_Cube[num, 0] = Change_Cube[num, 2] - 8;
                                    break;
                            }
                            break;

                        case 1:
                            //Center
                            Change_Cube[num, 5] = Change_Cube[num, 7] - 2;

                            //Sub
                            switch ((Change_Cube[num, 8] - 18) % 24)
                            {
                                case 16:
                                    Change_Cube[num, 2] = Change_Cube[num, 8] - 9;
                                    break;
                                case 23:
                                    Change_Cube[num, 2] = Change_Cube[num, 8] - 9;
                                    break;
                            }
                            break;

                        case 2:
                            //Center
                            Change_Cube[num, 7] = Change_Cube[num, 3] + 3;

                            //Sub
                            switch ((Change_Cube[num, 6] - 18) % 24)
                            {
                                case 12:
                                    Change_Cube[num, 8] = Change_Cube[num, 6] + 11;
                                    break;

                                case 22:
                                    Change_Cube[num, 8] = Change_Cube[num, 6] - 6;
                                    break;
                            }
                            break;

                        case 3:
                            //Center
                            Change_Cube[num, 3] = save_Center + 1;

                            //Sub
                            switch ((save_Sub - 18) % 24)
                            {
                                case 6:
                                    Change_Cube[num, 6] = save_Sub + 6;
                                    break;
                                case 10:
                                    Change_Cube[num, 6] = save_Sub + 12;
                                    break;
                            }

                            break;
                    }
                }
            }
            else
            {
                save_Sub = Change_Cube[num, 1];
                save_Corner = Change_Cube[num, 0];
                for (int sub = 0; sub < 3; sub++)
                {

                    switch ((Change_Cube[num, count] - 18) % 24)
                    {
                        case 3:
                        case 19:
                            Change_Cube[num, 1] = Change_Cube[num, count] - 2;
                            count = 7;
                            break;
                        case 4:
                        case 20:
                            Change_Cube[num, 5] = Change_Cube[num, count] - 1;
                            count = 3;
                            break;
                        case 2:
                        case 18:
                            Change_Cube[num, 7] = Change_Cube[num, count] + 2;
                            break;

                        case 13:
                            Change_Cube[num, 1] = Change_Cube[num, count] - 8;
                            count = 7;
                            break;
                        case 15:
                            Change_Cube[num, 1] = Change_Cube[num, count] - 7;
                            count = 7;
                            break;
                        case 21:
                            Change_Cube[num, 5] = Change_Cube[num, count] - 8;
                            count = 3;
                            break;
                        case 0:
                            Change_Cube[num, 5] = Change_Cube[num, count] - 9;
                            count = 3;
                            break;
                        case 9:
                            Change_Cube[num, 7] = Change_Cube[num, count] + 12;
                            break;
                        case 11:
                            Change_Cube[num, 7] = Change_Cube[num, count] + 13;
                            break;

                    }


                }

                if ((save_Sub - 18) % 24 == 1 || (save_Sub - 18) % 24 == 17)
                {
                    Change_Cube[num, 3] = save_Sub + 1;
                }
                else if ((save_Sub - 18) % 24 == 5)
                {
                    Change_Cube[num, 3] = save_Sub + 4;
                }
                else if ((save_Sub - 18) % 24 == 8)
                {
                    Change_Cube[num, 3] = save_Sub + 3;
                }


                for (int cor = 0; cor < 4; cor++)
                {
                    switch (cor)
                    {
                        case 0:
                            switch (Change_Cube[num,2])
                            {
                                case 92:
                                case 96:
                                    Change_Cube[num, 0] = Change_Cube[num, 2]+23;
                                    break;
                                case 116:
                                case 120:
                                    Change_Cube[num, 0] = Change_Cube[num, 2]-25;
                                    break;

                                case 108:
                                case 112:
                                    Change_Cube[num, 0] = Change_Cube[num, 2] + 15;
                                    break;
                                case 124:
                                case 128:
                                    Change_Cube[num, 0] = Change_Cube[num, 2]-17;
                                    break;

                                case 100:
                                case 104:
                                    Change_Cube[num, 0] = Change_Cube[num, 2]+31;
                                    break;
                                case 132:
                                case 136:
                                    Change_Cube[num, 0] = Change_Cube[num, 2]-33;
                                    break;
                            }
                            break;
                        case 1:
                            switch (Change_Cube[num, 8])
                            {
                                case 94:
                                case 98:
                                    Change_Cube[num, 2] = Change_Cube[num, 8]+22;
                                    break;
                                case 118:
                                case 122:
                                    Change_Cube[num, 2] = Change_Cube[num, 8]-26;
                                    break;

                                case 110:
                                case 114:
                                    Change_Cube[num, 2] = Change_Cube[num, 8]+14;
                                    break;
                                case 126:
                                case 130:
                                    Change_Cube[num, 2] = Change_Cube[num, 8]-18;
                                    break;

                                case 102:
                                case 106:
                                    Change_Cube[num, 2] = Change_Cube[num, 8]+30;
                                    break;
                                case 134:
                                case 138:
                                    Change_Cube[num, 2] = Change_Cube[num, 8]-34;
                                    break;
                            }
                            break;
                        case 2:
                            switch (Change_Cube[num, 6])
                            {
                                case 93:
                                case 97:
                                    Change_Cube[num, 8] = Change_Cube[num, 6]+25 ;
                                    break;
                                case 117:
                                case 121:
                                    Change_Cube[num, 8] = Change_Cube[num, 6]-23;
                                    break;

                                case 109:
                                case 113:
                                    Change_Cube[num, 8] = Change_Cube[num, 6]+17;
                                    break;
                                case 125:
                                case 129:
                                    Change_Cube[num, 8] = Change_Cube[num, 6]-15;
                                    break;

                                case 101:
                                case 105:
                                    Change_Cube[num, 8] = Change_Cube[num, 6]+33;
                                    break;
                                case 133:
                                case 137:
                                    Change_Cube[num, 8] = Change_Cube[num, 6]-31;
                                    break;
                            }
                            break;
                        case 3:
                            switch (save_Corner)
                            {
                                case 91:
                                case 95:
                                    Change_Cube[num, 6] = save_Corner+26;
                                    break;
                                case 115:
                                case 119:
                                    Change_Cube[num, 6] = save_Corner-22;
                                    break;

                                case 107:
                                case 111:
                                    Change_Cube[num, 6] = save_Corner+18;
                                    break;
                                case 123:
                                case 127:
                                    Change_Cube[num, 6] = save_Corner-14;
                                    break;

                                case 99:
                                case 103:
                                    Change_Cube[num, 6] = save_Corner+34;
                                    break;
                                case 131:
                                case 135:
                                    Change_Cube[num, 6] = save_Corner-30;
                                    break;
                            }
                            break;
                    }
                }
            }

        }
        else if (R == true)
        {
            if (num == 1)
            {
                save_Center = Change_Cube[num, 1];
                save_Sub = Change_Cube[num, 0];
                for (int cen = 0; cen < 4; cen++)
                {
                    switch (cen)
                    {
                        case 0:
                            //Center
                            Change_Cube[num, 1] = Change_Cube[num, 3] - 1;

                            //Sub
                            switch ((Change_Cube[num, 6] - 18) % 24)
                            {
                                case 12:
                                    Change_Cube[num, 0] = Change_Cube[num, 6] - 6;
                                    break;

                                case 22:
                                    Change_Cube[num, 0] = Change_Cube[num, 6] - 12;
                                    break;
                            }
                            break;

                        case 1:
                            //Center
                            Change_Cube[num, 3] = Change_Cube[num, 7] - 3;

                            //Sub
                            switch ((Change_Cube[num, 8] - 18) % 24)
                            {
                                case 16:
                                    Change_Cube[num, 6] = Change_Cube[num, 8] + 6;
                                    break;
                                case 23:
                                    Change_Cube[num, 6] = Change_Cube[num, 8] - 11;
                                    break;
                            }
                            break;

                        case 2:
                            //Center
                            Change_Cube[num, 7] = Change_Cube[num, 5] + 2;

                            //Sub
                            switch ((Change_Cube[num, 2] - 18) % 24)
                            {
                                case 7:
                                    Change_Cube[num, 8] = Change_Cube[num, 2] + 9;
                                    break;
                                case 14:
                                    Change_Cube[num, 8] = Change_Cube[num, 2] + 9;
                                    break;
                            }
                            break;

                        case 3:
                            //Center
                            Change_Cube[num, 5] = save_Center + 2;

                            //Sub
                            switch ((save_Sub - 18) % 24)
                            {
                                case 6:
                                    Change_Cube[num, 2] = save_Sub + 8;
                                    break;
                                case 10:
                                    Change_Cube[num, 2] = save_Sub - 3;
                                    break;
                            }
                            break;
                    }
                }
            }

            else
            {
                count = 3;
                save_Sub = Change_Cube[num, 1];
                save_Corner = Change_Cube[num, 0];
                for (int sub = 0; sub < 3; sub++)
                {

                    switch ((Change_Cube[num, count] - 18) % 24)
                    {
                        case 3:
                        case 19:
                            Change_Cube[num, 7] = Change_Cube[num, count] + 1;

                            break;
                        case 4:
                        case 20:
                            Change_Cube[num, 3] = Change_Cube[num, count] - 2;
                            count = 5;
                            break;
                        case 2:
                        case 18:
                            Change_Cube[num, 1] = Change_Cube[num, count] - 1;
                            count = 7;
                            break;

                        case 13:
                            Change_Cube[num, 7] = Change_Cube[num, count] + 8;
                            break;
                        case 15:
                            Change_Cube[num, 7] = Change_Cube[num, count] + 9;
                            break;
                        case 21:
                            Change_Cube[num, 3] = Change_Cube[num, count] - 12;
                            count = 5;
                            break;
                        case 0:
                            Change_Cube[num, 3] = Change_Cube[num, count] - 13;
                            count = 5;
                            break;
                        case 9:
                            Change_Cube[num, 1] = Change_Cube[num, count] - 4;
                            count = 7;
                            break;
                        case 11:
                            Change_Cube[num, 1] = Change_Cube[num, count] - 3;
                            count = 7;
                            break;

                    }


                }

                if ((save_Sub - 18) % 24 == 1 || (save_Sub - 18) % 24 == 17)
                {
                    Change_Cube[num, 5] = save_Sub + 2;
                }
                else if ((save_Sub - 18) % 24 == 5)
                {
                    Change_Cube[num, 5] = save_Sub + 8;
                }
                else if ((save_Sub - 18) % 24 == 8)
                {
                    Change_Cube[num, 5] = save_Sub + 7;
                }


                for (int cor = 0; cor < 4; cor++)
                {
                    switch (cor)
                    {
                        case 0:
                            switch (Change_Cube[num, 6])
                            {
                                case 93:
                                case 97:
                                    Change_Cube[num, 0] = Change_Cube[num, 6] + 22;
                                    break;
                                case 117:
                                case 121:
                                    Change_Cube[num, 0] = Change_Cube[num, 6] - 26;
                                    break;

                                case 109:
                                case 113:
                                    Change_Cube[num, 0] = Change_Cube[num, 6] + 14;
                                    break;
                                case 125:
                                case 129:
                                    Change_Cube[num, 0] = Change_Cube[num, 6] - 18;
                                    break;

                                case 101:
                                case 105:
                                    Change_Cube[num, 0] = Change_Cube[num, 6] + 30;
                                    break;
                                case 133:
                                case 137:
                                    Change_Cube[num, 0] = Change_Cube[num, 6] - 34;
                                    break;
                            }
                            break;
                        case 1:
                            switch (Change_Cube[num, 8])
                            {
                                case 94:
                                case 98:
                                    Change_Cube[num, 6] = Change_Cube[num, 8] + 23;
                                    break;
                                case 118:
                                case 122:
                                    Change_Cube[num, 6] = Change_Cube[num, 8] - 25;
                                    break;

                                case 110:
                                case 114:
                                    Change_Cube[num, 6] = Change_Cube[num, 8] + 15;
                                    break;
                                case 126:
                                case 130:
                                    Change_Cube[num, 6] = Change_Cube[num, 8] - 17;
                                    break;

                                case 102:
                                case 106:
                                    Change_Cube[num, 6] = Change_Cube[num, 8] + 31;
                                    break;
                                case 134:
                                case 138:
                                    Change_Cube[num, 6] = Change_Cube[num, 8] - 33;
                                    break;
                            }
                            break;
                        case 2:
                            switch (Change_Cube[num, 2])
                            {
                                case 92:
                                case 96:
                                    Change_Cube[num, 8] = Change_Cube[num, 2] + 26;
                                    break;
                                case 116:
                                case 120:
                                    Change_Cube[num, 8] = Change_Cube[num, 2] - 22;
                                    break;

                                case 108:
                                case 112:
                                    Change_Cube[num, 8] = Change_Cube[num, 2] + 18;
                                    break;
                                case 124:
                                case 128:
                                    Change_Cube[num, 8] = Change_Cube[num, 2] - 14;
                                    break;

                                case 100:
                                case 104:
                                    Change_Cube[num, 8] = Change_Cube[num, 2] + 34;
                                    break;
                                case 132:
                                case 136:
                                    Change_Cube[num, 8] = Change_Cube[num, 2] - 30;
                                    break;
                            }                         
                            break;
                        case 3:
                            switch (save_Corner)
                            {
                                case 91:
                                case 95:
                                    Change_Cube[num, 2] = save_Corner + 25;
                                    break;
                                case 115:
                                case 119:
                                    Change_Cube[num, 2] = save_Corner - 23;
                                    break;

                                case 107:
                                case 111:
                                    Change_Cube[num, 2] = save_Corner + 17;
                                    break;
                                case 123:
                                case 127:
                                    Change_Cube[num, 2] = save_Corner - 15;
                                    break;

                                case 99:
                                case 103:
                                    Change_Cube[num, 2] = save_Corner + 33;
                                    break;
                                case 131:
                                case 135:
                                    Change_Cube[num, 2] = save_Corner - 31;
                                    break;
                            }
                            break;
                    }
                }
            }
        }
    }
}