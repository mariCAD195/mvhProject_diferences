using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject exitButton;

    public void OnPlayClicked()
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
