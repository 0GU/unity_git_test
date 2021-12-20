using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

/// <summary>
/// Transform.RotateAround‚ğ—p‚¢‚½‰~‰^“®
/// </summary>
public class DisplayRotate : MonoBehaviour
{
    // ’†S“_
    [SerializeField] private Vector3 _center = Vector3.zero;

    // ‰ñ“]²
    [SerializeField] private Vector3 _axis = Vector3.up;

    // ‰~‰^“®üŠú
    [SerializeField] private float _period = 2;
    Vector3 save;
    bool flag = false;
    void Start()
    {
      
    }

    private void Update()
    {
  if(flag==false)
        {
            save = transform.position;
            save.x += 1;
            degree_rotationYR(new Vector3(0, 1, 0));
            flag = true;
        }
        degree_rotationYR(new Vector3(0, 1, 0));
    }

    public async void degree_rotationYR(Vector3 A)
    {
        await Task.Delay(10);
        _center = new Vector3(save.x, save.y+1, save.z+1.5f);


        _axis = A;

        //’†S“_center‚Ìü‚è‚ğA²axis‚ÅAperiodüŠú‚Å‰~‰^“®

       
            transform.RotateAround(
           _center,
           -_axis,
           360 / _period * Time.deltaTime);
            


     //   degree_rotationYR(A);

    }
}