using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Game : MonoBehaviour
{
    //Inspectorでキャラクターとゴールオブジェクトの指定を出来る様にします。
    public GameObject chara;
    public GameObject gameclea;
    public GameObject uiObject;
    UIManeger timestop;



    private void OnCollisionStay(Collision other)
    {
        //もしゴールオブジェクトのコライダーに接触した時の処理。
        if (other.gameObject.tag == "Red Panel")
        {
            uiObject = GameObject.FindWithTag("UI");
            timestop = uiObject.GetComponent<UIManeger>();

            //Debug.Log(10);
            //ゲームクリアテキストを表示させてキャラクターを非表示にします。
            gameclea.SetActive(true);
            timestop.ClearTimeStop();

        }
    }

}