using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenechange : MonoBehaviour
{

    void Start()
    {
        
    }

    //ボタンが押されたらシーンチェンジする処理

    //タイトル画面にシーンチェンジ
    public void TitleButton()
    {
        SceneManager.LoadScene("TitleScene");
    }

    //ステージセレクトにシーンチェンジ
    public void SelectButton()
    {
        SceneManager.LoadScene("StageselectScene");
    }
    //STAGE1にシーンチェンジ
    public void PushButton1()
    {
        SceneManager.LoadScene("STAGE1");
    }

    //STAGE2にシーンチェンジ
    public void PushButton2()
    {
        SceneManager.LoadScene("STAGE2");
    }

    //STAGE3にシーンチェンジ
    public void PushButton3()
    {
        SceneManager.LoadScene("STAGE3");
    }

    //STAGE4にシーンチェンジ
    public void PushButton4()
    {
        SceneManager.LoadScene("STAGE4");
    }
}
