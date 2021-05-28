using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControl : MonoBehaviour
{
    public GameObject blockPrefab1;

    GameObject[] blue;
     GameObject[] green;
    GameObject[] yellow;
    GameObject[] red;

    GameObject[] ActiveCube;

    public bool[] cubeflag = new bool[27];

    public int[,] color_save = new int[3,3];//0・・・Blue 1・・・Green 2・・・Yellow

    Vector3 Green_trans;
    Vector3 Blue_trans;
    Vector3 Yellow_trans;
    Vector3 Red_trans;

    GameObject[] Cube_flag; //代入用のゲームオブジェクト配列を用意
    Rotation_control Check;

    Vector3 Active_pos;


    //Transform
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 pos = transfrom.position;

        for (int i = 0; i < 27; i++)
        {
            cubeflag[i]= false;
        }

        //配置する座標を設定

        Vector3 placePosition1 = new Vector3(0, 3, 2.5f);
        Vector3 placePosition2 = new Vector3(0, 3, 0.5f);
        Vector3 placePosition3 = new Vector3(0, 3, 1.5f);
        Vector3 placePosition4 = new Vector3(2, 3, 2.5f);
        Vector3 placePosition5 = new Vector3(2, 3, 0.5f);
        Vector3 placePosition6 = new Vector3(2, 3, 1.5f);
        Vector3 placePosition7 = new Vector3(1, 3, 2.5f);
        Vector3 placePosition8 = new Vector3(1, 3, 0.5f);
        Vector3 placePosition9 = new Vector3(1, 3, 1.5f);

        //配置する回転角を設定
        Quaternion q = new Quaternion();

        q = Quaternion.identity;

        //配置
        Instantiate(blockPrefab1, placePosition1, q);
        Instantiate(blockPrefab1, placePosition2, q);
        Instantiate(blockPrefab1, placePosition3, q);
        Instantiate(blockPrefab1, placePosition4, q);
        Instantiate(blockPrefab1, placePosition5, q);
        Instantiate(blockPrefab1, placePosition6, q);
        Instantiate(blockPrefab1, placePosition7, q);
        Instantiate(blockPrefab1, placePosition8, q);
        Instantiate(blockPrefab1, placePosition9, q);

        ActiveCube = GameObject.FindGameObjectsWithTag("Active");

        Cube_flag = GameObject.FindGameObjectsWithTag("Cube_Rotato");
       Check=Cube_flag[0].GetComponent<Rotation_control>();

        for (int i = 0; i < ActiveCube.Length; i++)
        {
            ActiveCube[i].SetActive(false);
        }



    }


    // Update is called once per frame
    void Update()
    {

    

        ////条件を変えること
        //if (Input.GetKeyDown(KeyCode.P))
        //{

        //     for (int i = 0; i < ActiveCube.Length; i++)
        //     {
        //         ActiveCube[i].SetActive(true);
        //     }




        //    Debug.LogWarning(10);

        //}

        //gameObject.SetActive(false);
        /*
            for (int i = 0; i < 9; i++)
            {
               
                    placePosition1.x += blockPrefab1.transform.localScale.x;

                    placePosition2.x += blockPrefab2.transform.localScale.x;

                    placePosition3.x += blockPrefab3.transform.localScale.x;

                    placePosition4.x += blockPrefab4.transform.localScale.x;

                    placePosition5.x += blockPrefab5.transform.localScale.x;

                    placePosition6.x += blockPrefab6.transform.localScale.x;

                    placePosition7.x += blockPrefab7.transform.localScale.x;

                    placePosition8.x += blockPrefab8.transform.localScale.x;

                    placePosition9.x += blockPrefab9.transform.localScale.x;
            }
        */

    }
    public void Color_Save()
    {
        
        blue = GameObject.FindGameObjectsWithTag("Blue Panel");
        green = GameObject.FindGameObjectsWithTag("Green Panel");
        yellow = GameObject.FindGameObjectsWithTag("Yellow Panel");
        red = GameObject.FindGameObjectsWithTag("Red Panel");
        for (int g = 0; g < green.Length; g++)
        {
            switch (green[g].name)
            {

                case "Quad2":
                    Green_trans = green[g].transform.position;
                    
                    color_save[(int)Green_trans.z, (int)Green_trans.x] = 1;
                    break;


                default:
                    break;
            }

        }
        for (int b = 0; b < blue.Length; b++)
        {

            switch (blue[b].name)
            {
                case "Quad2":
                    Blue_trans = blue[b].transform.position;
                   
                    color_save[(int)Blue_trans.z, (int)Blue_trans.x] = 0;
                    break;

                default:
                    break;
            }
        }
        for (int y = 0; y < yellow.Length; y++)
        {
            switch (yellow[y].name)
            {
                case "Quad2":
                    Yellow_trans = yellow[y].transform.position;
                   
                    color_save[(int)Yellow_trans.z, (int)Yellow_trans.x] = 2;
                    break;


                default:
                    break;
            }
        }
        for (int r = 0; r < red.Length; r++)
        {

            switch (red[r].name)
            {
                case "Quad2":
                    Red_trans = red[r].transform.position;

                    color_save[(int)Red_trans.z, (int)Red_trans.x] = 3;
                    break;

                default:
                    break;
            }
        }
    }
    public void Active_true()
    {
        
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Active_pos = ActiveCube[(i * 3) + j].transform.position;
                
                if (color_save[(int)Active_pos.z, (int)Active_pos.x] !< 2)
                    ActiveCube[(i * 3) + j].SetActive(true);
            }
        }
      
    }

    public void Active_false()
    {
        for (int i = 0; i < ActiveCube.Length; i++)
        {
            ActiveCube[i].SetActive(false);
        }
    }
}

