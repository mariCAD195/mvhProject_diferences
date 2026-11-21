
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnvironmentTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float countdownTime = 30f;
    
    [SerializeField] private GameObject correct;
    [SerializeField] private GameObject incorrect;
    private void Start()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        yield return StartCoroutine(RunTimer());
        ChangeEnvironment();
        
        yield return StartCoroutine(RunTimer());
        SceneManager.LoadScene(2);
    }

    private IEnumerator RunTimer()
    {
        float remainingTime = countdownTime;

        while (remainingTime > 0)
        {
            timerText.text = Mathf.CeilToInt(remainingTime).ToString();

            yield return new WaitForSeconds(1f);

            remainingTime--;
        }

        timerText.text = "00:00";
    }

    private void ChangeEnvironment()
    {
        correct.SetActive(false);
        incorrect.SetActive(true);
    }
}


