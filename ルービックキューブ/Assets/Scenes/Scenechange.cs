using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenechange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //�{�^���������ꂽ��V�[���`�F���W���鏈��

    //STAGE1�ɃV�[���`�F���W
    public void PushButton()
    {
        SceneManager.LoadScene("STAGE1");
    }

    //�X�e�[�W�Z���N�g�ɃV�[���`�F���W
    public void PushButton2()
    {
        SceneManager.LoadScene("StageselectScene");
    }

    //�^�C�g����ʂɃV�[���`�F���W
    public void PushButton3()
    {
        SceneManager.LoadScene("TitleScene");
    }

    //STAGE2�ɃV�[���`�F���W
    public void PushButton4()
    {
        SceneManager.LoadScene("STAGE2");
    }

    //STAGE3�ɃV�[���`�F���W
    public void PushButton5()
    {
        SceneManager.LoadScene("STAGE3");
    }

    //STAGE4�ɃV�[���`�F���W
    public void PushButton6()
    {
        SceneManager.LoadScene("STAGE4");
    }
}
