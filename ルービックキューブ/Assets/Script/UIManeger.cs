using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManeger : MonoBehaviour
{
    private float time = 10.0f;
    public Text timerText;

    //3‚Â‚ÌPanel‚ğŠi”[‚·‚é•Ï”
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject helpPanel;
    [SerializeField] GameObject gameoverPanel;

    // Start is called before the first frame update
    void Start()
    {
        helpPanel.SetActive(false);
        gameoverPanel.SetActive(false);
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
