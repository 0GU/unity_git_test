using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManeger : MonoBehaviour
{
    private float time = 180.0f;
    public Text timerText;

    //4��Panel���i�[����ϐ�
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject helpPanel;
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] GameObject creditPanel;
    [SerializeField] GameObject SelectPanel1;
    [SerializeField] GameObject SelectPanel2;

    // Start is called before the first frame update
    void Start()
    {
        helpPanel.SetActive(false);
        gameoverPanel.SetActive(false);
        creditPanel.SetActive(false);
        SelectPanel2.SetActive(false);
    }

    void Update()
    {
        if (0 < time)
        {
            time -= Time.deltaTime;
           timerText.text = time.ToString("F1");
        }
        else if (time < 0)
        {
            gameoverPanel.SetActive(true);
        }
    }

       //GamePanel��HelpButton�������ꂽ���̏���
       public void SelectGameDescription()
       {
            gamePanel.SetActive(false);
            helpPanel.SetActive(true);
       }

    //HelpPanel��ReturnButton�������ꂽ���̏���
    public void SelectHelpDescription()
    {
        helpPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void CreditDescription()
    {
        gamePanel.SetActive(false);
        creditPanel.SetActive(true);
    }

    public void TitleDescription()
    {
        creditPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void Rbutton1Description()
    {
        SelectPanel1.SetActive(false);
        SelectPanel2.SetActive(true);
    }

    public void Lbutton1Description()
    {
        SelectPanel2.SetActive(false);
        SelectPanel1.SetActive(true);
    }
}
