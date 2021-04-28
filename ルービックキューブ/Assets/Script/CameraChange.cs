using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{

    private GameObject MainCamera;      //���C���J�����i�[�p

    //�g��Ȃ��J�����̓R�����g�A�E�g���Ă�
    private GameObject Camera2;       //�J����2�i�[�p 
    private GameObject Camera3;       //�J����3�i�[�p 
    private GameObject Camera4;       //�J����4�i�[�p 
    private GameObject Camera5;       //�J����5�i�[�p 
    private GameObject Camera6;       //�J����6�i�[�p


    //�Ăяo�����Ɏ��s�����֐�
    void Start()
    {
        //���C���J�������擾
        MainCamera = GameObject.Find("Main Camera");

        //�g��Ȃ��J�����̓R�����g�A�E�g���Ă�
        Camera2 = GameObject.Find("Camera2");
        Camera3 = GameObject.Find("Camera3");
        Camera4 = GameObject.Find("Camera4");
        Camera5 = GameObject.Find("Camera5");
        Camera6 = GameObject.Find("Camera6");


        //�J����2�ȍ~���A�N�e�B�u��
        Camera2.SetActive(false);
        Camera3.SetActive(false);
        Camera4.SetActive(false);
        Camera5.SetActive(false);
        Camera6.SetActive(false);
    }


    //�P�ʎ��Ԃ��ƂɎ��s�����֐�
    void Update()
    {

        //�L�[�{�[�h��1�L�[�������ꂽ��A���C���J�������A�N�e�B�u��
        if (Input.GetKeyDown(KeyCode.T))
        {
            //���C���J�������A�N�e�B�u�ɐݒ�
            MainCamera.SetActive(true);

            //���̃J�������A�N�e�B�u��
            Camera2.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(false);
            Camera5.SetActive(false);
            Camera6.SetActive(false);
        }


        //�y�J����2���g��Ȃ��ꍇ�R�����g�A�E�g��������z
        //�L�[�{�[�h��2�L�[�������ꂽ��A�J����2���A�N�e�B�u��
        if (Input.GetKeyDown(KeyCode.Y))
        {
            //�J����2���A�N�e�B�u�ɐݒ�
            Camera2.SetActive(true);

            //���̃J�������A�N�e�B�u��
            MainCamera.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(false);
            Camera5.SetActive(false);
            Camera6.SetActive(false);
        }
        //�y�J����2���g��Ȃ��ꍇ�R�����g�A�E�g�����܂Łz


        //�y�J����3���g��Ȃ��ꍇ�R�����g�A�E�g��������z
        //�L�[�{�[�h��3�L�[�������ꂽ��A�J����3���A�N�e�B�u��
        if (Input.GetKeyDown(KeyCode.U))
        {
            //�J����3���A�N�e�B�u�ɐݒ�
            Camera3.SetActive(true);

            //���̃J�������A�N�e�B�u��
            MainCamera.SetActive(false);
            Camera2.SetActive(false);
            Camera4.SetActive(false);
            Camera5.SetActive(false);
            Camera6.SetActive(false);
        }
        //�y�J����3���g��Ȃ��ꍇ�R�����g�A�E�g�����܂Łz


        //�y�J����4���g��Ȃ��ꍇ�R�����g�A�E�g��������z
        //�L�[�{�[�h��4�L�[�������ꂽ��A�J����4���A�N�e�B�u��
        if (Input.GetKeyDown(KeyCode.I))
        {
            //�J����4���A�N�e�B�u�ɐݒ�
            Camera4.SetActive(true);

            //���̃J�������A�N�e�B�u��
            MainCamera.SetActive(false);
            Camera2.SetActive(false);
            Camera3.SetActive(false);
            Camera5.SetActive(false);
            Camera6.SetActive(false);
        }
        //�y�J����4���g��Ȃ��ꍇ�R�����g�A�E�g�����܂Łz


        //�y�J����5���g��Ȃ��ꍇ�R�����g�A�E�g��������z
        //�L�[�{�[�h��5�L�[�������ꂽ��A�J����5���A�N�e�B�u��
        if (Input.GetKeyDown(KeyCode.O))
        {
            //�J����5���A�N�e�B�u�ɐݒ�
            Camera5.SetActive(true);

            //���̃J�������A�N�e�B�u��
            MainCamera.SetActive(false);
            Camera2.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(false);
            Camera6.SetActive(false);
        }
        //�y�J����5���g��Ȃ��ꍇ�R�����g�A�E�g�����܂Łz


        if (Input.GetKeyDown(KeyCode.P))
        {
            //�J����6���A�N�e�B�u�ɐݒ�
            Camera6.SetActive(true);

            //���̃J�������A�N�e�B�u��
            MainCamera.SetActive(false);
            Camera2.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(false);
            Camera5.SetActive(false);
        }
    }
}