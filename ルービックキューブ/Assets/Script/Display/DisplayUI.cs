using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUI : MonoBehaviour
{
    //2つのPanelを格納する変数
    [SerializeField] GameObject SelectPanel1;
    [SerializeField] GameObject SelectPanel2;

    GameObject Camera; //代入用のゲームオブジェクト配列を用意

    Move_Camera Move;

    bool L_move_flag = false;
    bool R_move_flag = false;

    // Start is called before the first frame update
    void Start()
    {
        SelectPanel2.SetActive(false);
        Camera = GameObject.Find("Main Camera");
        Move = Camera.GetComponent<Move_Camera>();
    }

    void Update()
    {
    
    }

    public void Rbutton1Description()
    {
        SelectPanel1.SetActive(false);
        Move.Vertical_Move(false);
    }

    public void Lbutton1Description()
    {
        SelectPanel2.SetActive(false);
        Move.Vertical_Move(true);
    }

   public void Stop(bool L_R)
    {
        switch (L_R)
        {
            case true:
                SelectPanel1.SetActive(true);
                break;
            case false:
                SelectPanel2.SetActive(true);
                break;
        }
    }
}
