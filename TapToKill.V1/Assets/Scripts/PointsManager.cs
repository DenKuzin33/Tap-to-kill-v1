using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    private int points = 0, timeLimit = 60;
    [SerializeField]
    private Text score, timer, finalScore;
    [SerializeField]
    public GameObject gameoverPanel;

    private void Start() 
    {
        StartCoroutine(GameTimer());
        gameoverPanel.SetActive(false);
    }

    public void RefreshPoints(int point)
    {
        points += point;
        score.text = "Points: " + points;
    }

    private void Update() 
    {
        if(ButtonsHandle.isPaused) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    IEnumerator GameTimer()
    {
        while(Time.timeSinceLevelLoad < timeLimit)
        {
            yield return new WaitForSeconds(1);
            timer.text = ((int)Time.timeSinceLevelLoad).ToString();
        }
        ButtonsHandle.isPaused = true;
        gameoverPanel.SetActive(true);
        finalScore.text += points;
    }
}