using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenScript : MonoBehaviour
{
    [SerializeField] private GameObject menuButton;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private TextMeshProUGUI points;

    public void Start()
    {
        Debug.Log("anfbnf");
        Debug.Log(PlayerData.Instance.playerPoints);
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        points.text = "your points: " + PlayerData.Instance.playerPoints.ToString();
    }

    public void OnMenuClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void OnExitClicked()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
