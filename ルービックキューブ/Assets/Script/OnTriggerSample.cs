using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OnTriggerSample : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        

        //�ڐG�����I�u�W�F�N�g�̃^�O��"Player"�̂Ƃ�
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

        //���@�̈ړ����W�ŏ��l���r���[�|�[�g����擾�i�ŏ��l��0,0�j
        Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
        //���@�̈ړ����W�ő�l�����r���[�|�[�g����擾�i�ő�l��1,1�j
        Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
        //���@�̍��W���擾���ăx�N�g�� pos �Ɋi�[
        Vector3 pos = transform.position;
        //pos.x �̒l���ŏ��l min �ő�l max �͈̔͂ɐ�������
        pos.x = Mathf.Clamp(pos.x, min.x +1, max.x + 8);
        //pos.y �̒l���ŏ��l min �ő�l max �͈̔͂ɐ�������
        pos.y = Mathf.Clamp(pos.y, min.y - 8, max.y + 4);
        //pos.z �̒l���ŏ��l min �ő�l max �͈̔͂ɐ�������
        pos.z = Mathf.Clamp(pos.z, min.z +1, max.z + 8);

        //���@�̈ړ��͈͂� pos �̍ŏ��l�ƍő�l�͈̔͂ɐ�������
        transform.position = pos;


    }

    


}
