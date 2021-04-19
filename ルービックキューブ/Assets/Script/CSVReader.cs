using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{

    TextAsset csvFile; // CSVファイル
    public int height; // CSVの行数
    List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;
    public GameObject obj5;
    public GameObject obj6;
    public GameObject obj7;
    public GameObject obj8;
    public GameObject obj9;
    public GameObject obj10;
    public GameObject obj11;
    public GameObject obj12;
    public GameObject obj13;
    public GameObject obj15;
    public GameObject obj16;
    public GameObject obj17;
    public GameObject obj18;
    public GameObject obj19;
    public GameObject obj20;
    public GameObject obj21;
    public GameObject obj22;
    public GameObject obj23;
    public GameObject obj24;
    public GameObject obj25;
    public GameObject obj26;
    public GameObject obj27;


    void Start()
    {
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
                    switch (csvDatas[i + h][j])
                    {

                        case "1":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj1, new Vector3(j, 2-i, h / 4), Quaternion.identity);
                            break;
                        case "2":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj2, new Vector3(j, 2 - i , h / 4), Quaternion.identity);
                            break;
                        case "3":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj3, new Vector3(j, 2 - i, h / 4), Quaternion.identity);
                            break;
                        case "4":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj4, new Vector3(j, 2 - i, h / 4), Quaternion.identity);
                            break;
                        case "5":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj5, new Vector3(j, 2 - i, h / 4), Quaternion.identity);
                            break;
                        case "6":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj6, new Vector3(j, 2 - i, h / 4), Quaternion.identity);
                            break;
                        case "7":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj7, new Vector3(j, 2 - i, h / 4), Quaternion.identity);
                            break;
                        case "8":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj8, new Vector3(j, 2 - i, h / 4), Quaternion.identity);
                            break;
                        case "9":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj9, new Vector3(j, 2 - i, h / 4), Quaternion.identity);
                            break;
                        case "10":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj10, new Vector3(j, 2 - i, h / 4), Quaternion.identity);
                            break;
                        case "11":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj11, new Vector3(j, 2 - i, h / 4), Quaternion.identity);
                            break;
                        case "12":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj12, new Vector3(j, 2 - i, h / 4), Quaternion.identity);
                            break;
                        case "13":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj13, new Vector3(j, 2 - i, h / 4), Quaternion.identity);
                            break;
                        case "15":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj15, new Vector3(j, 2 - i, h / 4), Quaternion.identity);
                            break;
                        case "16":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj16, new Vector3(j, 2 - i, h / 4), Quaternion.identity);
                            break;
                        case "17":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj17, new Vector3(j, 2 - i, h / 4), Quaternion.identity);
                            break;
                        case "18":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj18, new Vector3(j, 2 - i, h / 4), Quaternion.identity);
                            break;
                        case "19":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj19, new Vector3(j, 2 - i, h / 4), Quaternion.identity);
                            break;
                        case "20":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj20, new Vector3(j, 2 - i, h / 4), Quaternion.identity);
                            break;
                        case "21":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj21, new Vector3(j, 2 - i, h / 4), Quaternion.identity);
                            break;
                        case "22":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj22, new Vector3(j, 2 - i, h / 4), Quaternion.identity);
                            break;
                        case "23":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj23, new Vector3(j, 2 - i, h / 4), Quaternion.identity);
                            break;
                        case "24":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj24, new Vector3(j, 2 - i, h / 4), Quaternion.identity);
                            break;
                        case "25":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj25, new Vector3(j, 2 - i, h / 4), Quaternion.identity);
                            break;
                        case "26":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj26, new Vector3(j, 2 - i, h / 4), Quaternion.identity);
                            break;
                        case "27":
                            //Instantiate(生成したいGameObject, 位置, 姿勢);
                            Instantiate(obj27, new Vector3(j, 2 - i, h / 4), Quaternion.identity);
                            break;

                        default:
                            break;

                    }


                }


            }

        }
    }
}
    // 疑問
    // TextAssetはナニモン？
    // StringReaderはナニモン？
    // わざわざリストに入れてるけどTextAssetのままでは使えないの？


