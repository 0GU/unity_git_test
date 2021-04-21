using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ue : MonoBehaviour
{
    public Vector3 acceleration;    //�����x�B���ꂪ�Ȃ��ƕ����V�~�����[�V�����͎n�܂�Ȃ��B

    public Vector3 velocity;    //���x�B��������dt�̊Ԃ̉����x���A�ϕ��ł����ς��W�߂�Ƒ��x�ɂȂ�

    public Vector3 position;	//�ʒu�͑��x�̎��Ԑϕ�

    public float mass;  //���ʂɑ����B
    public Vector3 gravityScale;    //�d�͉����x

    const float dt = 1f / 60f;  //��������dt�ɑ������镔��
    public void AddForce(Vector3 force)
    {
        //�ύX�����J�n------------------------------------
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
            acceleration += gravityScale;   //�^������������A����m�imass)�Ŋ��������ʂ��g���܂��I

            velocity += acceleration * Time.fixedDeltaTime; //�ϕ��Ɏg���������Ԃ��A�f���^�^�C���ɕύX�I
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