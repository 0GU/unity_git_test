using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

/// <summary>
/// Transform.RotateAround‚ğ—p‚¢‚½‰~‰^“®
/// </summary>
public class Rotate_cube : MonoBehaviour
{
    // ’†S“_
    [SerializeField] private Vector3 _center = Vector3.zero;

    // ‰ñ“]²
    [SerializeField] private Vector3 _axis = Vector3.up;

    // ‰~‰^“®üŠú
    [SerializeField] private float _period = 2;

    [SerializeField] public float Terget_Y = 0f;
    [SerializeField] public float Terget_Z = 0f;

    public Quaternion rot;

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
        rot = transform.rotation;
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

        //’†S“_center‚Ìü‚è‚ğA²axis‚ÅAperiodüŠú‚Å‰~‰^“®
        do
        {
            transform.RotateAround(
            _center,
            _axis,
            360 / _period * Time.deltaTime);
            await Task.Delay(1);

        } while (transform.localEulerAngles.x < 89);

        Stop.cubeflag[flag_num] = false;

    }

    public async void degree_rotationXR(Vector3 A, int flag_num)
    {
        _center = new Vector3(1, 1, 1.5f);

        _axis = A;

        //’†S“_center‚Ìü‚è‚ğA²axis‚ÅAperiodüŠú‚Å‰~‰^“®
        do
        {
            transform.RotateAround(
           _center,
         -_axis,
           360 / _period * Time.deltaTime);
            await Task.Delay(1);
        } while (transform.localEulerAngles.x > 271 || transform.localEulerAngles.x < 1);


        Stop.cubeflag[flag_num] = false;

    }

    public async void degree_rotationY(Vector3 A, int flag_num)
    {
        _center = new Vector3(1, 1, 1.5f);

        _axis = A;

        //’†S“_center‚Ìü‚è‚ğA²axis‚ÅAperiodüŠú‚Å‰~‰^“®
        do
        {
            transform.RotateAround(
           _center,
           _axis,
           360 / _period * Time.deltaTime);
            await Task.Delay(1);
        } while (transform.eulerAngles.y < 90);

        Stop.cubeflag[flag_num] = false;
    }

    public async void degree_rotationYR(Vector3 A, int flag_num)
    {
        _center = new Vector3(1, 1, 1.5f);


        _axis = A;

        //’†S“_center‚Ìü‚è‚ğA²axis‚ÅAperiodüŠú‚Å‰~‰^“®

        do
        {
            transform.RotateAround(
           _center,
           -_axis,
           360 / _period * Time.deltaTime);
            await Task.Delay(1);
        } while (transform.localEulerAngles.y > 270 || transform.localEulerAngles.y < 90);

        Stop.cubeflag[flag_num] = false;


    }

    public async void degree_rotationZ(Vector3 A, int flag_num)
    {
        _center = new Vector3(1, 1, 1);

        _axis = A;


        //’†S“_center‚Ìü‚è‚ğA²axis‚ÅAperiodüŠú‚Å‰~‰^“®

        do
        {
            transform.RotateAround(
           _center,
           _axis,
           360 / _period * Time.deltaTime);
            await Task.Delay(1);
        } while (transform.eulerAngles.z < 90);

        Stop.cubeflag[flag_num] = false;


    }

    public async void degree_rotationZR(Vector3 A, int flag_num)
    {
        _center = new Vector3(1, 1, 1); ;

        _axis = A;


        //’†S“_center‚Ìü‚è‚ğA²axis‚ÅAperiodüŠú‚Å‰~‰^“®

        do
        {
            transform.RotateAround(
           _center,
           -_axis,
           360 / _period * Time.deltaTime);
            await Task.Delay(1);
        } while (transform.localEulerAngles.z > 270 || transform.localEulerAngles.z < 90);

        Stop.cubeflag[flag_num] = false;


    }
}