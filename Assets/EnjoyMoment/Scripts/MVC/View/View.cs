/*
CreateBy:     wgy
CreateTime:   2020/08/11 22:31:37
Description:  
*/

using UnityEngine.UI;
using UnityEngine;

public class View : MonoBehaviour
{
    public static View Instance;
    StartPanel startPanel;
    GamingPanel gamingPanel;
    GameoverPanel gameoverPanel;


    private void Awake() {
        Instance = this;
    }

    void Start()
    {
        startPanel = GetComponent<StartPanel>();
        gamingPanel = GetComponent<GamingPanel>();
        gameoverPanel = GetComponent<GameoverPanel>();

    }

    public void ShowStartPanel() {
        startPanel.gameObject.SetActive(true);
    }


}


