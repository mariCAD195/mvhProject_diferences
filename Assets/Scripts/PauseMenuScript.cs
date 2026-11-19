using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static Action<bool>  OnPaused;
    [SerializeField] private GameObject _pauseMenu;

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
    }
    
    public void ToggleMenu()
    {
        _pauseMenu.SetActive(!_pauseMenu.activeSelf);
        if (_pauseMenu.activeSelf)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }

        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
    }
    
    public void OnExitClicked()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
    
    public void OnEscapePressed(InputAction.CallbackContext ctx) 
    {
        ToggleMenu();
    }
}
