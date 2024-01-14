using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    public Slider moveSensitivity;
    public Slider powerSensitivity;
    public TextMeshProUGUI menuText1;
    public TextMeshProUGUI menuText2;

    public Button backButton;

    public bool isActive = false;
    public bool isShowing = false;

    private GameButtons buttons;


    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        isShowing = true;
        moveSensitivity.gameObject.SetActive(false);
        powerSensitivity.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        
        backButton.onClick.AddListener(BackButtonClicked);

        buttons = FindObjectOfType<GameButtons>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            ShowMenu();
 
        }
        else if (!isActive)
        {
            HideMenu();

        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            BackButtonClicked();
        }

    }

    private void BackButtonClicked()
    {
        if (buttons.isEscMenu)
        {
            buttons.ShowEscMenu();
            isActive = false;
        }
        else
        {
            buttons.ShowButtonsStartGame();
            isActive = false;
        }
    }
    private void ShowMenu()
    {
        if (!isShowing)
        {
            moveSensitivity.gameObject.SetActive(true);
            powerSensitivity.gameObject.SetActive(true);
            backButton.gameObject.SetActive(true);
            backButton.gameObject.SetActive(true);
            menuText1.gameObject.SetActive(true);
            menuText2.gameObject.SetActive(true);
            
            isShowing = true;
            //Debug.Log("Show settings");
        }
    }

    private void HideMenu()
    {
        if (isShowing)
        {
            moveSensitivity.gameObject.SetActive(false);
            powerSensitivity.gameObject.SetActive(false);
            backButton.gameObject.SetActive(false);
            backButton.gameObject.SetActive(false);
            menuText1.gameObject.SetActive(false);
            menuText2.gameObject.SetActive(false);

            isShowing = false;
            //Debug.Log("Hide settings");
        }
    }
}
