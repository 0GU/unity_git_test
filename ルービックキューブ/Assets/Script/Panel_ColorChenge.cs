using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_ColorChenge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("unitychan step cube is yellow");
        GameObject[] cube = GameObject.FindGameObjectsWithTag("Yellow Panel");

        Debug.Log("unitychan step cube is blue");
        GameObject[] cube1 = GameObject.FindGameObjectsWithTag("Blue Panel");

        Debug.Log("unitychan step cube is green");
        GameObject[] cube2 = GameObject.FindGameObjectsWithTag("Green Panel");

    }

    
    void Update()
    {
        
    }

    // 他のオブジェクトとの衝突開始
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Yellow Panel")
        {
            collision.gameObject.GetComponent<Renderer>().material.color = Color.red;//yellow;
        }

        if (collision.gameObject.tag == "Blue Panel")
        {
            collision.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }

        if (collision.gameObject.tag == "Green Panel")
        {
            collision.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }

        //if (collision.gameObject.tag == "Yellow Panel")
        //{

        //    collision.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        //}
        // foreachは配列の要素の数だけループします。
        //foreach (GameObject block in blocks)
        //{
        //    // 消す！
        //    Destroy(block);
        //}
    }
}
