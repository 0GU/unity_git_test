using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManeger : MonoBehaviour
{
    //2つのPanelを格納する変数
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject helpPanel;

    // Start is called before the first frame update
    void Start()
    {
        helpPanel.SetActive(false);
    }

    //GamePanelでHelpButtonが押された時の処理
    public void SelectGameDescription()
    {
        gamePanel.SetActive(false);
        helpPanel.SetActive(true);
    }

    //HelpPanelでReturnButtonが押された時の処理
    public void SelectHelpDescription()
    {
        helpPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
}
