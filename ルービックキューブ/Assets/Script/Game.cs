using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Game : MonoBehaviour
{
    //Inspector�ŃL�����N�^�[�ƃS�[���I�u�W�F�N�g�̎w����o����l�ɂ��܂��B
    public GameObject chara;
    public GameObject gameclea;


    private void OnCollisionStay(Collision other)
    {
        //�����S�[���I�u�W�F�N�g�̃R���C�_�[�ɐڐG�������̏����B
        if (other.gameObject.tag== "Red Panel")
        {
            //Debug.Log(10);
            //�Q�[���N���A�e�L�X�g��\�������ăL�����N�^�[���\���ɂ��܂��B
            gameclea.SetActive(true);

        }
    }

}