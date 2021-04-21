using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ue : MonoBehaviour
{
    public Vector3 acceleration;    //加速度。これがないと物理シミュレーションは始まらない。

    public Vector3 velocity;    //速度。微小時間dtの間の加速度を、積分でいっぱい集めると速度になる

    public Vector3 position;	//位置は速度の時間積分

    public float mass;  //質量に相当。
    public Vector3 gravityScale;    //重力加速度

    const float dt = 1f / 60f;  //微小時間dtに相当する部分
    public void AddForce(Vector3 force)
    {
        //変更部分開始------------------------------------
        acceleration += force / mass;
    }
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Physics.gravity = new Vector3(0, -9.8f, 0);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Physics.gravity = new Vector3(100.8f, 0, 0);
        }




        void FixedUpdate()
        {
            acceleration += gravityScale;   //運動方程式から、両辺m（mass)で割った結果を使います！

            velocity += acceleration * Time.fixedDeltaTime; //積分に使う微小時間を、デルタタイムに変更！
            position += velocity * Time.fixedDeltaTime;

            if (position.y < 5.0f)
            {
                velocity = -velocity;
            }
            transform.position = position;
            acceleration = Vector3.zero;
        }
    }
}