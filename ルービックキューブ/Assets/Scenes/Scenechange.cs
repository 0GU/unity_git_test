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

    //ボタンが押されたらシーンチェンジする処理

    //STAGE1にシーンチェンジ
    public void PushButton()
    {
        SceneManager.LoadScene("STAGE1");
    }

    //ステージセレクトにシーンチェンジ
    public void PushButton2()
    {
        SceneManager.LoadScene("StageselectScene");
    }

    //タイトル画面にシーンチェンジ
    public void PushButton3()
    {
        SceneManager.LoadScene("TitleScene");
    }

    //STAGE2にシーンチェンジ
    public void PushButton4()
    {
        SceneManager.LoadScene("STAGE2");
    }

    //STAGE3にシーンチェンジ
    public void PushButton5()
    {
        SceneManager.LoadScene("STAGE3");
    }

    //STAGE4にシーンチェンジ
    public void PushButton6()
    {
        SceneManager.LoadScene("STAGE4");
    }
}
