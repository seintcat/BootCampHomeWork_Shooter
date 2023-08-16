using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    private static int scoreValue;
    private static int bestValue;

    public static int lastScore
    {
        get { return scoreValue; }
    }

    [SerializeField]
    Animator scoreAnimator;
    [SerializeField]
    TextMeshProUGUI score;
    [SerializeField]
    TextMeshProUGUI best;

    public void Init()
    {
        scoreValue = 0;
        score.text = "Score : " + scoreValue;
        bestValue = PlayerPrefs.GetInt("Best", 0);
        best.text = "Best : " + bestValue;
    }
    public static void PlayerDeath()
    {
        instance.gameObject.SetActive(false);
    }

    private void Awake()
    {
        instance = this;
        Init();
    }

    public static void ScoreUp(int scoreIn)
    {
        instance.scoreAnimator.Play("Idle");

        scoreValue += scoreIn;
        instance.score.text = "Score : " + scoreValue;

        if(scoreValue > bestValue)
        {
            bestValue = scoreValue;
            PlayerPrefs.SetInt("Best", bestValue);
            instance.best.text = "Best : " + bestValue;
            instance.scoreAnimator.Play("BestUp");
        }
        else
        {
            instance.scoreAnimator.Play("ScoreUp");
        }
    }
}
