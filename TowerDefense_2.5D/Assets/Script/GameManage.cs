using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    // Scipt about UI and Game Control

    [SerializeField] private Camera mainCamera;

    // Create TowerUI
    [SerializeField] private Canvas createTowerCanvas;
    [SerializeField] private RectTransform createTowerImage;

    // PauseUI
    [SerializeField] private GameObject pauseUI;

    // OtherUI which run while playing
    [SerializeField] private Text moneyUI;
    private int money;

    public enum GameUI
    {
        playing,
        createTowerUI,
        pause
    };

    public static GameUI currentGameUI = GameUI.playing;
    public static Vector3 clickPos;


    private void Update()
    {
        CheckEscButton();
        CheckUI();
        ShowMoney();

        if(Input.GetKey(KeyCode.M))
        {
            money += 10;
        }
    }

    private void CheckUI()
    {
        if (currentGameUI == GameUI.pause)
        {
            pauseUI.SetActive(true);
            createTowerCanvas.gameObject.SetActive(false);
        }
        else if (currentGameUI == GameUI.createTowerUI)
        {
            MoveCanvas();
            createTowerCanvas.gameObject.SetActive(true);
        }
        else
        {
            pauseUI.SetActive(false);
            createTowerCanvas.gameObject.SetActive(false);
        }
    }

    private void CheckEscButton()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManage.currentGameUI == GameManage.GameUI.createTowerUI)
            {
                GameManage.currentGameUI = GameManage.GameUI.playing;
            }
            else if(GameManage.currentGameUI == GameManage.GameUI.pause)
            {
                GameManage.currentGameUI = GameManage.GameUI.playing;
            }
            else
            {
                GameManage.currentGameUI = GameManage.GameUI.pause;
            }
        }
    }


    // UI Script
    private void ShowMoney()
    {
        moneyUI.text = "$ " + money.ToString();
    }

    private void MoveCanvas()
    {
        // Show Canvas to the position that was click
        Vector3 viewPos = mainCamera.WorldToViewportPoint(clickPos);
        createTowerImage.GetComponent<RectTransform>().anchorMin = viewPos;
        createTowerImage.GetComponent<RectTransform>().anchorMax = viewPos;
    }
}
