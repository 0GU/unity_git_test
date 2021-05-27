using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OnTriggerSample : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        

        //接触したオブジェクトのタグが"Player"のとき
        if (other.CompareTag("Blue Panel") || other.CompareTag("Green Panel"))
        {
            Debug.Log("ok");
        }
       

    }

  
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Clamp();
    }

    void Clamp()
    {

        //自機の移動座標最小値をビューポートから取得（最小値は0,0）
        Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
        //自機の移動座標最大値ををビューポートから取得（最大値は1,1）
        Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
        //自機の座標を取得してベクトル pos に格納
        Vector3 pos = transform.position;
        //pos.x の値を最小値 min 最大値 max の範囲に制限する
        pos.x = Mathf.Clamp(pos.x, min.x +1, max.x + 8);
        //pos.y の値を最小値 min 最大値 max の範囲に制限する
        pos.y = Mathf.Clamp(pos.y, min.y - 8, max.y + 4);
        //pos.z の値を最小値 min 最大値 max の範囲に制限する
        pos.z = Mathf.Clamp(pos.z, min.z +1, max.z + 8);

        //自機の移動範囲を pos の最小値と最大値の範囲に制限する
        transform.position = pos;


    }

    


}
