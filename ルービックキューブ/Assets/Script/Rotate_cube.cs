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

    [SerializeField] public float Terget = 0f;
    public bool flag = false;
    [SerializeField] public float z = 0f;
    private void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            degree_rotation();
        }

        z = transform.eulerAngles.z;
    }

    public async void degree_rotation()
    {

        //’†S“_center‚Ìü‚è‚ğA²axis‚ÅAperiodüŠú‚Å‰~‰^“®
        transform.RotateAround(
       _center,
       _axis,
       360 / _period * Time.deltaTime);
    }
}
