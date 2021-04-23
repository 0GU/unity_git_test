using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManeger : MonoBehaviour
{
    //2‚Â‚ÌPanel‚ğŠi”[‚·‚é•Ï”
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject helpPanel;

    // Start is called before the first frame update
    void Start()
    {
        helpPanel.SetActive(false);
    }

    //GamePanel‚ÅHelpButton‚ª‰Ÿ‚³‚ê‚½‚Ìˆ—
    public void SelectGameDescription()
    {
        gamePanel.SetActive(false);
        helpPanel.SetActive(true);
    }

    //HelpPanel‚ÅReturnButton‚ª‰Ÿ‚³‚ê‚½‚Ìˆ—
    public void SelectHelpDescription()
    {
        helpPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
}
