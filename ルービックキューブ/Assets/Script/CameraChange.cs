using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{

    private GameObject MainCamera;      //メインカメラ格納用

    private GameObject Camera2;       //カメラ2格納用 
    private GameObject Camera3;       //カメラ3格納用 
    private GameObject Camera4;       //カメラ4格納用 

    //呼び出し時に実行される関数
    void Start()
    {
        //メインカメラを取得
        MainCamera = GameObject.Find("Main Camera");

        Camera2 = GameObject.Find("Camera2");
        Camera3 = GameObject.Find("Camera3");
        Camera4 = GameObject.Find("Camera4");

        //カメラ2以降を非アクティブに
        Camera2.SetActive(false);
        Camera3.SetActive(false);
        Camera4.SetActive(false);
    
    }

    //単位時間ごとに実行される関数
    void Update()
    {

        //キーボード上Tキーが押されたら、メインカメラをアクティブに
        if (Input.GetKeyDown(KeyCode.T))
        {
            //メインカメラをアクティブに設定
            MainCamera.SetActive(true);

            //他のカメラを非アクティブに
            Camera2.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(false);
        }

        //キーボード上Yキーが押されたら、カメラ2をアクティブに
        if (Input.GetKeyDown(KeyCode.Y))
        {
            //カメラ2をアクティブに設定
            Camera2.SetActive(true);

            //他のカメラを非アクティブに
            MainCamera.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(false);
        }
        
        //キーボード上Uキーが押されたら、カメラ3をアクティブに
        if (Input.GetKeyDown(KeyCode.U))
        {
            //カメラ3をアクティブに設定
            Camera3.SetActive(true);

            //他のカメラを非アクティブに
            MainCamera.SetActive(false);
            Camera2.SetActive(false);
            Camera4.SetActive(false);
        }
        
        //キーボード上Iキーが押されたら、カメラ4をアクティブに
        if (Input.GetKeyDown(KeyCode.I))
        {
            //カメラ4をアクティブに設定
            Camera4.SetActive(true);

            //他のカメラを非アクティブに
            MainCamera.SetActive(false);
            Camera2.SetActive(false);
            Camera3.SetActive(false);
        }
    }
}