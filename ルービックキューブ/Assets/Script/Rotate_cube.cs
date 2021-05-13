using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

/// <summary>
/// Transform.RotateAroundÇópÇ¢ÇΩâ~â^ìÆ
/// </summary>
public class Rotate_cube : MonoBehaviour
{
    // íÜêSì_
    [SerializeField] private Vector3 _center = Vector3.zero;

    // âÒì]é≤
    [SerializeField] private Vector3 _axis = Vector3.up;

    // â~â^ìÆé¸ä˙
    [SerializeField] private float _period = 2;

    [SerializeField] public float Terget_Y = 0f;
    [SerializeField] public float Terget_Z = 0f;
    public Vector3 pos;
    public int x = 0;
    public int y = 0;
    public int z = 0;
    public Vector3 angles;
    public int angle_x = 0;
    public int angle_y = 0;
    public int angle_z = 0;

    public int num_x = 0;
    public int num_y = 0;
    public int num_z = 0;

    Rotation_control Stop;
    void Start()
    {
        Stop = GameObject.Find("Cube_Rotation").GetComponent<Rotation_control>();
        pos = transform.position;
        x = (int)pos.x;
        y = (int)pos.y;
        z = (int)pos.z;


    }

    private void Update()
    {
        angles = transform.localEulerAngles;
        angle_x = (int)angles.x;
        angle_y = (int)angles.y;
        angle_z = (int)angles.z;

    }

    public async void degree_rotationX(Vector3 A, int flag_num)
    {
        _center = new Vector3(1, 1, 1.5f);

        _axis = A;

        //íÜêSì_centerÇÃé¸ÇËÇÅAé≤axisÇ≈ÅAperiodé¸ä˙Ç≈â~â^ìÆ
        switch (num_x)
        {
            case 1:
                do
                {
                    transform.RotateAround(
                   _center,
                   _axis,
                   360 / _period * Time.deltaTime);
                    await Task.Delay(1);
                } while (transform.localEulerAngles.x > 360 || transform.localEulerAngles.x < 90);
                num_x += 1;
                break;
            case 2:
                do
                {
                    transform.RotateAround(
                   _center,
                   _axis,
                   360 / _period * Time.deltaTime);
                    await Task.Delay(1);
                } while (transform.localEulerAngles.x > 271);
                num_x += 1;
                break;
            case 3:
                do
                {
                    transform.RotateAround(
                   _center,
                   _axis,
                   360 / _period * Time.deltaTime);
                    await Task.Delay(1);
                } while (transform.localEulerAngles.x > 1);
                num_x += 1;
                break;
            case 0:
                do
                {
                    transform.RotateAround(
                   _center,
                   _axis,
                   360 / _period * Time.deltaTime);
                    await Task.Delay(1);
                } while (transform.localEulerAngles.x < 89);
                num_x += 1;
                break;

        }
        if (num_x == 4)
            num_x = 0;
        if (num_x == 0)
        {
            Terget_Y = 0;
            Terget_Z = 0;
        }

        if (num_x == 2)
        {
            Terget_Y = 180;
            Terget_Z = 180;
        }


        switch (y)
        {
            case 0:
                switch (z)
                {
                    case 0:
                        y = 2;
                        break;
                    case 1:
                        z = 0;
                        y = 1;
                        break;
                    case 2:
                        z = 0;
                        break;
                }
                break;
            case 1:
                switch (z)
                {
                    case 0:
                        z = 1;
                        y = 2;
                        break;
                    case 1:
                        break;
                    case 2:
                        z = 1;
                        y = 0;
                        break;
                }
                break;
            case 2:
                switch (z)
                {
                    case 0:
                        z = 2;
                        break;
                    case 1:
                        z = 2;
                        y = 1;
                        break;
                    case 2:
                        y = 0;
                        break;
                }
                break;
        }

        Stop.cubeflag[flag_num] = false;

    }

    public async void degree_rotationXR(Vector3 A, int flag_num)
    {
        _center = new Vector3(1, 1, 1.5f);

        _axis = A;

        //íÜêSì_centerÇÃé¸ÇËÇÅAé≤axisÇ≈ÅAperiodé¸ä˙Ç≈â~â^ìÆ
        switch (num_x)
        {
            case 1:
                do
                {
                    transform.RotateAround(
                   _center,
                   -_axis,
                   360 / _period * Time.deltaTime);
                    await Task.Delay(1);
                } while (transform.localEulerAngles.x > 1);
                num_x -= 1;
                break;
            case 2:
                do
                {
                    transform.RotateAround(
                   _center,
                 -_axis,
                   360 / _period * Time.deltaTime);
                    await Task.Delay(1);
                } while (transform.localEulerAngles.x < 89);
                num_x -= 1;
                break;
            case 3:
                do
                {
                    transform.RotateAround(
                   _center,
                -_axis,
                   360 / _period * Time.deltaTime);
                    await Task.Delay(1);
                } while (transform.localEulerAngles.x > 1);
                num_x -= 1;
                break;
            case 0:
                do
                {
                    transform.RotateAround(
                   _center,
                 -_axis,
                   360 / _period * Time.deltaTime);
                    await Task.Delay(1);
                } while (transform.localEulerAngles.x > 271 || transform.localEulerAngles.x < 1);
                num_x -= 1;
                break;

        }

        switch (y)
        {
            case 0:
                switch (z)
                {
                    case 0:
                        z = 2;
                        break;
                    case 1:
                        y = 1;
                        z = 2;
                        break;
                    case 2:
                        y = 2;
                        break;
                }
                break;
            case 1:
                switch (z)
                {
                    case 0:
                        z = 1;
                        y = 0;
                        break;
                    case 1:
                        break;
                    case 2:
                        z = 1;
                        y = 2;
                        break;
                }
                break;
            case 2:
                switch (z)
                {
                    case 0:
                        y = 0;
                        break;
                    case 1:
                        z = 0;
                        y = 1;
                        break;
                    case 2:
                        z = 0;
                        break;
                }
                break;
        }

        if (num_x == -1)
            num_x = 3;

        Stop.cubeflag[flag_num] = false;

    }

    public async void degree_rotationY(Vector3 A, int flag_num)
    {
        _center = new Vector3(1, 1, 1.5f);

        _axis = A;

        Terget_Y += 90;
        if (Terget_Y == 360)
            Terget_Y = 0;

        if (Terget_Y == 450)
            Terget_Y = 90;

        //íÜêSì_centerÇÃé¸ÇËÇÅAé≤axisÇ≈ÅAperiodé¸ä˙Ç≈â~â^ìÆ
        switch (num_y)
        {
            case 3:
                do
                {
                    transform.RotateAround(
                   _center,
                   _axis,
                   360 / _period * Time.deltaTime);
                    await Task.Delay(1);
                } while (transform.localEulerAngles.y > 90);
                num_y += 1;

                break;
            default:
                do
                {
                    transform.RotateAround(
                   _center,
                   _axis,
                   360 / _period * Time.deltaTime);
                    await Task.Delay(1);
                } while (transform.eulerAngles.y < Terget_Y);
                num_y += 1;

                break;


        }



        if (num_y == 4)
            num_y = 0;



        switch (z)
        {
            case 0:
                switch (x)
                {
                    case 0:
                        z = 2;
                        break;
                    case 1:
                        z = 1;
                        x = 0;
                        break;
                    case 2:
                        x = 0;
                        break;
                }
                break;
            case 1:
                switch (x)
                {
                    case 0:
                        z = 2;
                        x = 1;
                        break;
                    case 1:
                        break;
                    case 2:
                        z = 0;
                        x = 1;
                        break;
                }
                break;
            case 2:
                switch (x)
                {
                    case 0:
                        x = 2;
                        break;
                    case 1:
                        z = 1;
                        x = 2;
                        break;
                    case 2:
                        z = 0;
                        break;
                }
                break;
        }

        Stop.cubeflag[flag_num] = false;
    }

    public async void degree_rotationYR(Vector3 A, int flag_num)
    {
        _center = new Vector3(1, 1, 1.5f);


        _axis = A;

        Terget_Y -= 90;

        if (Terget_Y == 0)
            Terget_Y = 360;


        if (Terget_Y == -90)
            Terget_Y = 270;


        //íÜêSì_centerÇÃé¸ÇËÇÅAé≤axisÇ≈ÅAperiodé¸ä˙Ç≈â~â^ìÆ
        switch (num_y)
        {
            case 1:
                do
                {
                    transform.RotateAround(
                   _center,
                   -_axis,
                   360 / _period * Time.deltaTime);
                    await Task.Delay(1);
                } while (transform.localEulerAngles.y > 360 || transform.localEulerAngles.y < 90);
                num_y -= 1;

                break;
            default:
                do
                {
                    transform.RotateAround(
                   _center,
                  -_axis,
                   360 / _period * Time.deltaTime);
                    await Task.Delay(1);
                } while (transform.eulerAngles.y > Terget_Y);
                num_y -= 1;

                break;


        }
        if (num_y == -1)
            num_y = 3;



        switch (z)
        {
            case 0:
                switch (x)
                {
                    case 0:
                        x = 2;
                        break;
                    case 1:
                        z = 1;
                        x = 2;
                        break;
                    case 2:
                        z = 2;
                        break;
                }
                break;
            case 1:
                switch (x)
                {
                    case 0:
                        x = 1;
                        z = 0;
                        break;
                    case 1:
                        break;
                    case 2:
                        x = 1;
                        z = 2;
                        break;
                }
                break;
            case 2:
                switch (x)
                {
                    case 0:
                        z = 0;
                        break;
                    case 1:
                        x = 0;
                        z = 1;
                        break;
                    case 2:
                        x = 0;
                        break;
                }
                break;
        }
        Stop.cubeflag[flag_num] = false;


    }

    public async void degree_rotationZ(Vector3 A, int flag_num)
    {
        _center = new Vector3(1, 1, 1);

        _axis = A;

        Terget_Z += 90;

        if (Terget_Z == 360)
            Terget_Z = 0;

        if (Terget_Z == 450)
            Terget_Z = 90;
        //if (num_y == 2)
        //{
        //    _axis.z *= -1;
        //}

        //íÜêSì_centerÇÃé¸ÇËÇÅAé≤axisÇ≈ÅAperiodé¸ä˙Ç≈â~â^ìÆ
        switch (num_z)
        {
            case 3:
                do
                {
                    transform.RotateAround(
                   _center,
                   _axis,
                   360 / _period * Time.deltaTime);
                    await Task.Delay(1);
                } while (transform.localEulerAngles.z > 90);
                num_z += 1;

                break;
            default:
                do
                {
                    transform.RotateAround(
                   _center,
                   _axis,
                   360 / _period * Time.deltaTime);
                    await Task.Delay(1);
                } while (transform.eulerAngles.z < Terget_Z);
                num_z += 1;

                break;


        }
        if (num_z == 4)
            num_z = 0;



        switch (x)
        {
            case 0:
                switch (y)
                {
                    case 0:
                        x = 2;
                        break;
                    case 1:
                        x = 1;
                        y = 0;
                        break;
                    case 2:
                        y = 0;
                        break;
                }
                break;
            case 1:
                switch (y)
                {
                    case 0:
                        x = 2;
                        y = 1;
                        break;
                    case 1:
                        break;
                    case 2:
                        x = 0;
                        y = 1;
                        break;
                }
                break;
            case 2:
                switch (y)
                {
                    case 0:
                        y = 2;
                        break;
                    case 1:
                        x = 1;
                        y = 2;
                        break;
                    case 2:
                        x = 0;
                        break;
                }
                break;
        }
        Stop.cubeflag[flag_num] = false;


    }

    public async void degree_rotationZR(Vector3 A, int flag_num)
    {
        _center = new Vector3(1, 1, 1); ;

        _axis = A;

        Terget_Z -= 90;

        if (Terget_Z == 0)
            Terget_Z = 360;


        if (Terget_Z == -90)
            Terget_Z = 270;
        //if (num_y == 2)
        //{
        //    _axis.z *= -1;
        //}

        //íÜêSì_centerÇÃé¸ÇËÇÅAé≤axisÇ≈ÅAperiodé¸ä˙Ç≈â~â^ìÆ
        switch (num_z)
        {
            case 1:
                do
                {
                    transform.RotateAround(
                   _center,
                   -_axis,
                   360 / _period * Time.deltaTime);
                    await Task.Delay(1);
                } while (transform.localEulerAngles.z > 360 || transform.localEulerAngles.z < 90);
                num_z -= 1;

                break;
            default:
                do
                {
                    transform.RotateAround(
                   _center,
                  -_axis,
                   360 / _period * Time.deltaTime);
                    await Task.Delay(1);
                } while (transform.eulerAngles.z > Terget_Z);
                num_z -= 1;

                break;


        }
        if (num_z == -1)
            num_z = 3;



        switch (x)
        {
            case 0:
                switch (y)
                {
                    case 0:
                        y = 2;
                        break;
                    case 1:
                        y = 2;
                        x = 1;
                        break;
                    case 2:
                        x = 2;
                        break;
                }
                break;
            case 1:
                switch (y)
                {
                    case 0:
                        y = 1;
                        x = 0;
                        break;
                    case 1:
                        break;
                    case 2:
                        y = 1;
                        x = 2;
                        break;
                }
                break;
            case 2:
                switch (y)
                {
                    case 0:
                        x = 0;
                        break;
                    case 1:
                        y = 0;
                        x = 1;
                        break;
                    case 2:
                        y = 0;
                        break;
                }
                break;
        }
        Stop.cubeflag[flag_num] = false;


    }

    public async void degree_rotationZT(Vector3 A, int flag_num)
    {
        _center = new Vector3(1, 1, 1);

        _axis = A;


        Terget_Z -= 90;

        if (Terget_Z == 0)
            Terget_Z = 360;


        if (Terget_Z == -90)
            Terget_Z = 270;
        //if (num_y == 2)
        //{
        //    _axis.z *= -1;
        //}

        //íÜêSì_centerÇÃé¸ÇËÇÅAé≤axisÇ≈ÅAperiodé¸ä˙Ç≈â~â^ìÆ
        switch (num_z)
        {
            case 1:
                do
                {
                    transform.RotateAround(
                   _center,
                   _axis,
                   360 / _period * Time.deltaTime);
                    await Task.Delay(1);
                } while (transform.localEulerAngles.z > 360 || transform.localEulerAngles.z < 90);
                num_z += 1;

                break;
            default:
                do
                {
                    transform.RotateAround(
                   _center,
                   _axis,
                   360 / _period * Time.deltaTime);
                    await Task.Delay(1);
                } while (transform.eulerAngles.z > Terget_Z);
                num_z += 1;

                break;


        }
        if (num_z == 4)
            num_z = 0;



        switch (x)
        {
            case 0:
                switch (y)
                {
                    case 0:
                        x = 2;
                        break;
                    case 1:
                        x = 1;
                        y = 0;
                        break;
                    case 2:
                        y = 0;
                        break;
                }
                break;
            case 1:
                switch (y)
                {
                    case 0:
                        x = 2;
                        y = 1;
                        break;
                    case 1:
                        break;
                    case 2:
                        x = 0;
                        y = 1;
                        break;
                }
                break;
            case 2:
                switch (y)
                {
                    case 0:
                        y = 2;
                        break;
                    case 1:
                        x = 1;
                        y = 2;
                        break;
                    case 2:
                        x = 0;
                        break;
                }
                break;
        }
        Stop.cubeflag[flag_num] = false;


    }
}
