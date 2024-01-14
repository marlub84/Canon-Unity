using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;

    public bool gameStart;
    public bool isGameActive;
    public bool isGamePaused;

    private GameButtons buttons;

    public GameObject menu;
    private MenuSettings menuSettings;
    

    // Start is called before the first frame update
    void Start()
    {
        buttons = FindObjectOfType<GameButtons>();
        buttons.ShowButtonsStartGame();
        gameOverText.gameObject.SetActive(false);

        menu.SetActive(true);
        menuSettings = FindObjectOfType<MenuSettings>();

        gameStart = true;
        isGameActive = true;
        isGamePaused = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameActive)
        {
            buttons.HideButtons();
            
        }
        
        if (Input.GetKeyDown(KeyCode.Escape) && !buttons.isEscMenu && !menuSettings.isActive && !isGameActive)
        {
            buttons.ShowEscMenu();
            isGameActive = true;
            isGamePaused = true;
        }
        
        else if (Input.GetKeyDown(KeyCode.Escape) && isGamePaused && !menuSettings.isActive)
        {
            buttons.HideButtons();
            buttons.isEscMenu = false;
            isGameActive = false;
            isGamePaused = false;
        }
    }

    public void StartGame()
    {
        isGameActive = false;
        gameStart = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    { 
        Application.Quit();
    }

    public void SettingGame()
    {
        buttons.ShowSettingGame();
    }
}
