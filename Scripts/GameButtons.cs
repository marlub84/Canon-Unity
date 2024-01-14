using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameButtons : MonoBehaviour
{
    public Button startButton;
    public Button restartButton;
    public Button exitButton;
    public Button settingButton;

    private GameManager gameManager;

    public MenuSettings menuSettings;

    public bool isEscMenu;
    public bool isSetting;

    // Start is called before the first frame update
    void Start()
    {
        isEscMenu = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        startButton.onClick.AddListener(gameManager.StartGame);
        restartButton.onClick.AddListener(gameManager.RestartGame);
        exitButton.onClick.AddListener(gameManager.ExitGame);
        settingButton.onClick.AddListener(gameManager.SettingGame);

        menuSettings = gameManager.GetComponent<MenuSettings>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowButtonsStartGame()
    {
        startButton.gameObject.SetActive(true);
        settingButton.gameObject.SetActive(true);
        exitButton .gameObject.SetActive(true);
    }

    public void ShowEndGame()
    {
        restartButton.gameObject.SetActive(true);
        exitButton .gameObject.SetActive(true);
    }

    public void ShowSettingGame()
    {
        HideButtons();
        menuSettings.isActive = true;
    }

    public void ShowEscMenu()
    {
        gameManager.gameStart = false;
        isEscMenu  = true;
        restartButton .gameObject.SetActive(true);
        settingButton .gameObject.SetActive(true);
        exitButton .gameObject.SetActive(true);
    }

    public void HideButtons()
    {
        startButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        exitButton .gameObject.SetActive(false);
        settingButton.gameObject.SetActive(false);
    }
}
