using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    // Start is called before the first frame update
    float pos;
    [SerializeField] Vector3 pos_set;
    bool flag = false;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(flag==false)
        {
            flag = true;
            transform.position = pos_set;
            pos = transform.position.y;

        }

        transform.position = new Vector3(transform.position.x, pos+(Mathf.PingPong(Time.time,1.0f)), transform.position.z);
    }
}
