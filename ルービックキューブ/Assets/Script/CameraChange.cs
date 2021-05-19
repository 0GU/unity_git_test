using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{

    private GameObject MainCamera;      //���C���J�����i�[�p

    private GameObject Camera2;       //�J����2�i�[�p 
    private GameObject Camera3;       //�J����3�i�[�p 
    private GameObject Camera4;       //�J����4�i�[�p 

    //�Ăяo�����Ɏ��s�����֐�
    void Start()
    {
        //���C���J�������擾
        MainCamera = GameObject.Find("Main Camera");

        Camera2 = GameObject.Find("Camera2");
        Camera3 = GameObject.Find("Camera3");
        Camera4 = GameObject.Find("Camera4");

        //�J����2�ȍ~���A�N�e�B�u��
        Camera2.SetActive(false);
        Camera3.SetActive(false);
        Camera4.SetActive(false);
    
    }

    //�P�ʎ��Ԃ��ƂɎ��s�����֐�
    void Update()
    {

        //�L�[�{�[�h��T�L�[�������ꂽ��A���C���J�������A�N�e�B�u��
        if (Input.GetKeyDown(KeyCode.T))
        {
            //���C���J�������A�N�e�B�u�ɐݒ�
            MainCamera.SetActive(true);

            //���̃J�������A�N�e�B�u��
            Camera2.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(false);
        }

        //�L�[�{�[�h��Y�L�[�������ꂽ��A�J����2���A�N�e�B�u��
        if (Input.GetKeyDown(KeyCode.Y))
        {
            //�J����2���A�N�e�B�u�ɐݒ�
            Camera2.SetActive(true);

            //���̃J�������A�N�e�B�u��
            MainCamera.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(false);
        }
        
        //�L�[�{�[�h��U�L�[�������ꂽ��A�J����3���A�N�e�B�u��
        if (Input.GetKeyDown(KeyCode.U))
        {
            //�J����3���A�N�e�B�u�ɐݒ�
            Camera3.SetActive(true);

            //���̃J�������A�N�e�B�u��
            MainCamera.SetActive(false);
            Camera2.SetActive(false);
            Camera4.SetActive(false);
        }
        
        //�L�[�{�[�h��I�L�[�������ꂽ��A�J����4���A�N�e�B�u��
        if (Input.GetKeyDown(KeyCode.I))
        {
            //�J����4���A�N�e�B�u�ɐݒ�
            Camera4.SetActive(true);

            //���̃J�������A�N�e�B�u��
            MainCamera.SetActive(false);
            Camera2.SetActive(false);
            Camera3.SetActive(false);
        }
    }
}