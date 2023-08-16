using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    private static int scoreValue;
    private static int bestValue;

    [SerializeField]
    Animator scoreAnimator;
    [SerializeField]
    TextMeshProUGUI score;
    [SerializeField]
    TextMeshProUGUI best;

    private void Awake()
    {
        instance = this;
        scoreValue = 0;
        score.text = "Score : " + scoreValue;
        bestValue = PlayerPrefs.GetInt("Best", 0);
        best.text = "Best : " + bestValue;
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
