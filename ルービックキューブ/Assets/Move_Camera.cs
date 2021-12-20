using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Camera : MonoBehaviour
{
    GameObject Display_UI;
    DisplayUI Stop;

    bool L_move_flag = false;
    bool R_move_flag = false;

    float save_pos_x;

    // Start is called before the first frame update
    void Start()
    {
        Display_UI = GameObject.Find("UIManeger");
        Stop = Display_UI.GetComponent<DisplayUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(L_move_flag==true&&save_pos_x-20<transform.position.x)
        {
            transform.position = new Vector3(transform.position.x-0.1f, transform.position.y , transform.position.z);
        }
        else if (L_move_flag == true)
        {
            L_move_flag = false;
            Stop.Stop(true);
        }

        if (R_move_flag ==true&& save_pos_x + 20 > transform.position.x)
        {
            transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        }
        else if (R_move_flag == true)
        {
            R_move_flag = false;
            Stop.Stop(false);
        }


    }

    public void Vertical_Move(bool L_R)
    {
        save_pos_x = transform.position.x;

        switch (L_R)
        {
            case true:
                L_move_flag = true;
                break;
            case false:
                R_move_flag = true;
                break;
        }

    }
}
