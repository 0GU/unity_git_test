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
    public void PushButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void PushButton2()
    {
        SceneManager.LoadScene("StageselectScene");
    }

    public void PushButton3()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
