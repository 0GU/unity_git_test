using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_control : MonoBehaviour
{

    // Start is called before the first frame update
    GameObject[] tag1_Objects; //代入用のゲームオブジェクト配列を用意

    Rotate_cube Front;

    GameObject[] Change_G; //代入用のゲームオブジェクト配列を用意
    CSVReader Change;

    GameObject[] Rotato_Active; //代入用のゲームオブジェクト配列を用意
    BlockControl Act;


    Vector3 Axis = new Vector3(0, 1, 0);
    [SerializeField] public bool flag = false;
    public bool[] cubeflag = new bool[27];

    int c_num = 0;

    Vector3 CharaPos;

    void Start()
    {
        Change_G = GameObject.FindGameObjectsWithTag("Generater");
        Change = Change_G[0].GetComponent<CSVReader>();

        Rotato_Active = GameObject.FindGameObjectsWithTag("Block_cont");
        Act = Rotato_Active[0].GetComponent<BlockControl>();

        for (int init = 0; init < 27; init++)
        {
            cubeflag[init] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 CharaPos = GameObject.Find("unitychan").transform.position;

        //右回転
        if (Input.GetKeyDown(KeyCode.Alpha1) && Input.GetKey(KeyCode.Alpha0) && flag_check(cubeflag) == false && CharaPos.x > 0.745f)
        {
            flag = true;

            Act.Rotato_Active_trueX(0);
            Change.ChangeArrayX(0, true);

            tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");

            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Front = tag1_Objects[i].GetComponent<Rotate_cube>();
                if (Front.x == 0)
                {
                    Axis = new Vector3(1, 0, 0);
                    cubeflag[c_num] = true;

                    Front.degree_rotationXR(Axis, c_num);
                    c_num++;
                }

            }

            c_num = 0;
        }

        //左回転
        if (Input.GetKeyDown(KeyCode.Alpha1) && !(Input.GetKey(KeyCode.Alpha0)) && flag_check(cubeflag) == false && CharaPos.x > 0.745f)
        {
            flag = true;


            Act.Rotato_Active_trueX(0);
            Change.ChangeArrayX(0, false);

            tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");

            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Front = tag1_Objects[i].GetComponent<Rotate_cube>();
                if (Front.x == 0)
                {
                    Axis = new Vector3(1, 0, 0);
                    cubeflag[c_num] = true;
                    Front.degree_rotationX(Axis, c_num);
                    c_num++;
                }

            }

            c_num = 0;
        }
        //右回転
        if (Input.GetKeyDown(KeyCode.Alpha2) && (Input.GetKey(KeyCode.Alpha0)) && flag_check(cubeflag) == false && (CharaPos.x < 0.25f || CharaPos.x > 1.745f))
        {
            flag = true;

            Act.Rotato_Active_trueX(1);
            Change.ChangeArrayX(1, true);

            tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");

            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Front = tag1_Objects[i].GetComponent<Rotate_cube>();
                if (Front.x == 1)
                {
                    Axis = new Vector3(1, 0, 0);
                    cubeflag[c_num] = true;
                    Front.degree_rotationXR(Axis, c_num);
                    c_num++;
                }

            }

            c_num = 0;
        }

        //左回転
        if (Input.GetKeyDown(KeyCode.Alpha2) && !(Input.GetKey(KeyCode.Alpha0)) && flag_check(cubeflag) == false && (CharaPos.x < 0.25f || CharaPos.x > 1.745f))
        {
            flag = true;

            Act.Rotato_Active_trueX(1);
            Change.ChangeArrayX(1, false);

            tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");

            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Front = tag1_Objects[i].GetComponent<Rotate_cube>();
                if (Front.x == 1)
                {
                    Axis = new Vector3(1, 0, 0);
                    cubeflag[c_num] = true;
                    Front.degree_rotationX(Axis, c_num);
                    c_num++;
                }

            }

            c_num = 0;
        }


        //右回転
        if (Input.GetKeyDown(KeyCode.Alpha3) && (Input.GetKey(KeyCode.Alpha0)) && flag_check(cubeflag) == false && CharaPos.x < 1.25f)
        {
            flag = true;

            Act.Rotato_Active_trueX(2);
            Change.ChangeArrayX(2, true);

            tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");

            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Front = tag1_Objects[i].GetComponent<Rotate_cube>();
                if (Front.x == 2)
                {
                    Axis = new Vector3(1, 0, 0);
                    cubeflag[c_num] = true;
                    Front.degree_rotationXR(Axis, c_num);
                    c_num++;
                }

            }

            c_num = 0;
        }


        //左回転
        if (Input.GetKeyDown(KeyCode.Alpha3) && !(Input.GetKey(KeyCode.Alpha0)) && flag_check(cubeflag) == false && CharaPos.x < 1.25f)
        {
            flag = true;

            Act.Rotato_Active_trueX(2);
            Change.ChangeArrayX(2, false);

            tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");

            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Front = tag1_Objects[i].GetComponent<Rotate_cube>();
                if (Front.x == 2)
                {
                    Axis = new Vector3(1, 0, 0);
                    cubeflag[c_num] = true;
                    Front.degree_rotationX(Axis, c_num);
                    c_num++;
                }

            }

            c_num = 0;
        }

        //右回転
        if (Input.GetKeyDown(KeyCode.Alpha4) && !(Input.GetKey(KeyCode.Alpha0)) && flag_check(cubeflag) == false)
        {
            flag = true;

            Change.ChangeArrayY(0, false);

            tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");

            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Front = tag1_Objects[i].GetComponent<Rotate_cube>();
                if (Front.y == 0)
                {
                    Axis = new Vector3(0, 1, 0);
                    cubeflag[c_num] = true;
                    Front.degree_rotationY(Axis, c_num);
                    c_num++;
                }

            }

            c_num = 0;
        }
        //左回転
        if (Input.GetKeyDown(KeyCode.Alpha4) && Input.GetKey(KeyCode.Alpha0) && flag_check(cubeflag) == false)
        {
            flag = true;

            Change.ChangeArrayY(0, true);

            tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");

            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Front = tag1_Objects[i].GetComponent<Rotate_cube>();
                if (Front.y == 0)
                {
                    Axis = new Vector3(0, 1, 0);
                    cubeflag[c_num] = true;
                    Front.degree_rotationYR(Axis, c_num);
                    c_num++;
                }

            }

            c_num = 0;
        }

        //右回転
        if (Input.GetKeyDown(KeyCode.Alpha5) && !(Input.GetKey(KeyCode.Alpha0)) && flag_check(cubeflag) == false)
        {
            flag = true;

            Change.ChangeArrayY(1, false);

            tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");

            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Front = tag1_Objects[i].GetComponent<Rotate_cube>();
                if (Front.y == 1)
                {
                    Axis = new Vector3(0, 1, 0);
                    cubeflag[c_num] = true;
                    Front.degree_rotationY(Axis, c_num);
                    c_num++;
                }

            }

            c_num = 0;
        }
        //左回転
        if (Input.GetKeyDown(KeyCode.Alpha5) && Input.GetKey(KeyCode.Alpha0) && flag_check(cubeflag) == false)
        {
            flag = true;

            Change.ChangeArrayY(1, true);

            tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");

            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Front = tag1_Objects[i].GetComponent<Rotate_cube>();
                if (Front.y == 1)
                {
                    Axis = new Vector3(0, 1, 0);
                    cubeflag[c_num] = true;
                    Front.degree_rotationYR(Axis, c_num);
                    c_num++;
                }

            }

            c_num = 0;
        }



        //左回転
        if (Input.GetKeyDown(KeyCode.Alpha6) && !(Input.GetKey(KeyCode.Alpha0)) && flag_check(cubeflag) == false && CharaPos.z > 1.25f)
        {
            flag = true;

            Act.Rotato_Active_trueZ(0);
            Change.ChangeArrayZ(0, false);

            tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");

            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Front = tag1_Objects[i].GetComponent<Rotate_cube>();
                if (Front.z == 0)
                {


                    Axis = new Vector3(0, 0, 1);
                    cubeflag[c_num] = true;
                    Front.degree_rotationZ(Axis, c_num);
                    c_num++;
                }

            }

            c_num = 0;
        }

        //右回転
        if (Input.GetKeyDown(KeyCode.Alpha6) && Input.GetKey(KeyCode.Alpha0) && flag_check(cubeflag) == false && CharaPos.z > 1.25f)
        {
            flag = true;

            Act.Rotato_Active_trueZ(0);
            Change.ChangeArrayZ(0, true);

            tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");

            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Front = tag1_Objects[i].GetComponent<Rotate_cube>();
                if (Front.z == 0)
                {

                    cubeflag[c_num] = true;

                    Axis = new Vector3(0, 0, 1);
                    Front.degree_rotationZR(Axis, c_num);

                }

                c_num = 0;
            }
        }

        //左回転
        if (Input.GetKeyDown(KeyCode.Alpha7) && !(Input.GetKey(KeyCode.Alpha0)) && flag_check(cubeflag) == false && (CharaPos.z < 0.4f || CharaPos.z > 1.99f))
        {
            flag = true;

            Act.Rotato_Active_trueZ(1);
            Change.ChangeArrayZ(1, false);

            tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");

            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Front = tag1_Objects[i].GetComponent<Rotate_cube>();
                if (Front.z == 1)
                {

                    cubeflag[c_num] = true;

                    Axis = new Vector3(0, 0, 1);
                    Front.degree_rotationZ(Axis, c_num);


                    c_num++;
                }

            }

            c_num = 0;
        }

        //右回転
        if (Input.GetKeyDown(KeyCode.Alpha7) && Input.GetKey(KeyCode.Alpha0) && flag_check(cubeflag) == false && (CharaPos.z < 0.4f || CharaPos.z > 1.99f))
        {
            flag = true;

            Act.Rotato_Active_trueZ(1);
            Change.ChangeArrayZ(1, true);

            tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");

            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Front = tag1_Objects[i].GetComponent<Rotate_cube>();
                if (Front.z == 1)
                {

                    cubeflag[c_num] = true;
                    Axis = new Vector3(0, 0, 1);
                    Front.degree_rotationZR(Axis, c_num);

                }

                c_num = 0;
            }
        }

        //左回転
        if (Input.GetKeyDown(KeyCode.Alpha8) && !(Input.GetKey(KeyCode.Alpha0)) && flag_check(cubeflag) == false && CharaPos.z < 1.45f)
        {
            flag = true;

            Act.Rotato_Active_trueZ(2);
            Change.ChangeArrayZ(2, false);

            tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");

            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Front = tag1_Objects[i].GetComponent<Rotate_cube>();
                if (Front.z == 2)
                {

                    cubeflag[c_num] = true;

                    Axis = new Vector3(0, 0, 1);
                    Front.degree_rotationZ(Axis, c_num);

                    c_num++;
                }

            }

            c_num = 0;
        }

        //右回転
        if (Input.GetKeyDown(KeyCode.Alpha8) && Input.GetKey(KeyCode.Alpha0) && flag_check(cubeflag) == false && CharaPos.z < 1.45f)
        {
            flag = true;

            Act.Rotato_Active_trueZ(2);
            Change.ChangeArrayZ(2, true);

            tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");

            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Front = tag1_Objects[i].GetComponent<Rotate_cube>();
                if (Front.z == 2)
                {

                    cubeflag[c_num] = true;

                    Axis = new Vector3(0, 0, 1);
                    Front.degree_rotationZR(Axis, c_num);

                }

                c_num = 0;
            }
        }

        if (flag_check(cubeflag) == false && flag == true)
        {
            flag = false;
            Change.ChangeGenerate();
        }


    }
    static bool flag_check(bool[] c_flag)
    {
        for (int c = 0; c < 9; c++)
        {
            if (c_flag[c] == true)
            {

                return true;


            }
        }
        return false;
    }



}