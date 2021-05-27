using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManeger : MonoBehaviour
{
    //2��Panel���i�[����ϐ�
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject helpPanel;

    // Start is called before the first frame update
    void Start()
    {
        helpPanel.SetActive(false);
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
}
