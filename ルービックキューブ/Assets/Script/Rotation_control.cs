using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_control : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] tag1_Objects; //ë„ì¸ópÇÃÉQÅ[ÉÄÉIÉuÉWÉFÉNÉgîzóÒÇópà”

    Rotate_cube Front;

    Vector3 Axis = new Vector3(0, 1, 0);
    [SerializeField] public bool flag = false;
     public bool[] cubeflag = new bool[27];

    int c_num = 0;
    void Start()
    {
        for (int init = 0; init < 27; init++)
        {
            cubeflag[init] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //âEâÒì]
        if (Input.GetKeyDown(KeyCode.Alpha1) && !(Input.GetKey(KeyCode.Alpha0)) && flag_check(cubeflag) == false)
        {
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

        if (Input.GetKeyDown(KeyCode.Alpha2) && !(Input.GetKey(KeyCode.Alpha0)) && flag_check(cubeflag) == false)
        {
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

        if (Input.GetKeyDown(KeyCode.Alpha3) && !(Input.GetKey(KeyCode.Alpha0)) && flag_check(cubeflag) == false)
        {
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

        //âEâÒì]
        if (Input.GetKeyDown(KeyCode.Alpha4) && !(Input.GetKey(KeyCode.Alpha0)) && flag_check(cubeflag) == false)
        {
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
        //ç∂âÒì]
        if (Input.GetKeyDown(KeyCode.Alpha4) && Input.GetKey(KeyCode.Alpha0) && flag_check(cubeflag) == false)
        {
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

        //âEâÒì]
        if (Input.GetKeyDown(KeyCode.Alpha5) && !(Input.GetKey(KeyCode.Alpha0)) && flag_check(cubeflag) == false)
        {
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
        //ç∂âÒì]
        if (Input.GetKeyDown(KeyCode.Alpha5) && Input.GetKey(KeyCode.Alpha0) && flag_check(cubeflag) == false)
        {
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

        //âEâÒì]
        if (Input.GetKeyDown(KeyCode.Alpha6) && !(Input.GetKey(KeyCode.Alpha0)) && flag_check(cubeflag) == false)
        {
            tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");

            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Front = tag1_Objects[i].GetComponent<Rotate_cube>();
                if (Front.y == 2)
                {
                    Axis = new Vector3(0, 1, 0);
                    cubeflag[c_num] = true;
                    Front.degree_rotationY(Axis, c_num);
                    c_num++;
                }

            }

            c_num = 0;
        }
        //ç∂âÒì]
        if (Input.GetKeyDown(KeyCode.Alpha6) && Input.GetKey(KeyCode.Alpha0) && flag_check(cubeflag) == false)
        {
            tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");

            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Front = tag1_Objects[i].GetComponent<Rotate_cube>();
                if (Front.y == 2)
                {
                    Axis = new Vector3(0, 1, 0);
                    cubeflag[c_num] = true;
                    Front.degree_rotationYR(Axis, c_num);
                    c_num++;
                }

            }

            c_num = 0;
        }

        //ç∂âÒì]
        if (Input.GetKeyDown(KeyCode.Alpha7) && !(Input.GetKey(KeyCode.Alpha0)) && flag_check(cubeflag) == false)
        {
            tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");

            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Front = tag1_Objects[i].GetComponent<Rotate_cube>();
                if (Front.z == 0)
                {

                    cubeflag[c_num] = true;
                    if (Front.num_y == 0)
                    {
                        Axis = new Vector3(0, 0, 1);
                        Front.degree_rotationZ(Axis, c_num);
                    }

                    else if (Front.num_y == 2)
                    {
                        Axis = new Vector3(0, 0, 1);
                        Front.degree_rotationZR(-Axis, c_num);
                    }

                    c_num++;
                }

            }

            c_num = 0;
        }

        //âEâÒì]
        if (Input.GetKeyDown(KeyCode.Alpha7) && Input.GetKey(KeyCode.Alpha0) && flag_check(cubeflag) == false)
        {
            tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");

            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Front = tag1_Objects[i].GetComponent<Rotate_cube>();
                if (Front.z == 0)
                {

                    cubeflag[c_num] = true;
                    if (Front.num_y == 0)
                    {
                        Axis = new Vector3(0, 0, 1);
                        Front.degree_rotationZR(Axis, c_num);
                    }

                    else if (Front.num_y == 2)
                    {
                        Axis = new Vector3(0, 0, 1);
                        Front.degree_rotationZ(-Axis, c_num);
                    }
                }

                c_num = 0;
            }
        }

        //ç∂âÒì]
        if (Input.GetKeyDown(KeyCode.Alpha8) && !(Input.GetKey(KeyCode.Alpha0)) && flag_check(cubeflag) == false)
        {
            tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");

            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Front = tag1_Objects[i].GetComponent<Rotate_cube>();
                if (Front.z == 1)
                {

                    cubeflag[c_num] = true;
                    if (Front.num_y == 0)
                    {
                        Axis = new Vector3(0, 0, 1);
                        Front.degree_rotationZ(Axis, c_num);
                    }

                    else if (Front.num_y == 2)
                    {
                        Axis = new Vector3(0, 0, 1);
                        Front.degree_rotationZR(-Axis, c_num);
                    }

                    c_num++;
                }

            }

            c_num = 0;
        }

        //âEâÒì]
        if (Input.GetKeyDown(KeyCode.Alpha8) && Input.GetKey(KeyCode.Alpha0) && flag_check(cubeflag) == false)
        {
            tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");

            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Front = tag1_Objects[i].GetComponent<Rotate_cube>();
                if (Front.z == 1)
                {

                    cubeflag[c_num] = true;
                    if (Front.num_y == 0)
                    {
                        Axis = new Vector3(0, 0, 1);
                        Front.degree_rotationZR(Axis, c_num);
                    }

                    else if (Front.num_y == 2)
                    {
                        Axis = new Vector3(0, 0, 1);
                        Front.degree_rotationZ(-Axis, c_num);
                    }
                }

                c_num = 0;
            }
        }

        //ç∂âÒì]
        if (Input.GetKeyDown(KeyCode.Alpha9) && !(Input.GetKey(KeyCode.Alpha0)) && flag_check(cubeflag) == false)
        {
            tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");

            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Front = tag1_Objects[i].GetComponent<Rotate_cube>();
                if (Front.z == 2)
                {

                    cubeflag[c_num] = true;
                    if (Front.num_y == 0)
                    {
                        Axis = new Vector3(0, 0, 1);
                        Front.degree_rotationZ(Axis, c_num);
                    }

                    else if (Front.num_y == 2)
                    {
                        Axis = new Vector3(0, 0, 1);
                        Front.degree_rotationZR(-Axis, c_num);
                    }

                    c_num++;
                }

            }

            c_num = 0;
        }

        //âEâÒì]
        if (Input.GetKeyDown(KeyCode.Alpha9) && Input.GetKey(KeyCode.Alpha0) && flag_check(cubeflag) == false)
        {
            tag1_Objects = GameObject.FindGameObjectsWithTag("Cube");

            for (int i = 0; i < tag1_Objects.Length; i++)
            {
                Front = tag1_Objects[i].GetComponent<Rotate_cube>();
                if (Front.z == 2)
                {

                    cubeflag[c_num] = true;
                    if (Front.num_y == 0)
                    {
                        Axis = new Vector3(0, 0, 1);
                        Front.degree_rotationZR(Axis, c_num);
                    }

                    else if (Front.num_y == 2)
                    {
                        Axis = new Vector3(0, 0, 1);
                        Front.degree_rotationZ(-Axis, c_num);
                    }
                }

                c_num = 0;
            }
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