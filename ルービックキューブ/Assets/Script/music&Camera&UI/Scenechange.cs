using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenechange : MonoBehaviour
{

    void Start()
    {
        
    }

    //�{�^���������ꂽ��V�[���`�F���W���鏈��

    //�^�C�g����ʂɃV�[���`�F���W
    public void TitleButton()
    {
        SceneManager.LoadScene("TitleScene");
    }

    //�X�e�[�W�Z���N�g�ɃV�[���`�F���W
    public void SelectButton()
    {
        SceneManager.LoadScene("StageselectScene");
    }
    //STAGE1�ɃV�[���`�F���W
    public void PushButton1()
    {
        SceneManager.LoadScene("STAGE1");
    }

    //STAGE2�ɃV�[���`�F���W
    public void PushButton2()
    {
        SceneManager.LoadScene("STAGE2");
    }

    //STAGE3�ɃV�[���`�F���W
    public void PushButton3()
    {
        SceneManager.LoadScene("STAGE3");
    }

    //STAGE4�ɃV�[���`�F���W
    public void PushButton4()
    {
        SceneManager.LoadScene("STAGE4");
    }
}
