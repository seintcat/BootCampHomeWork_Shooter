using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> sprites;
    [SerializeField]
    private Image image;
    [SerializeField]
    private TextMeshProUGUI score;
    [SerializeField]
    private ScoreManager scoreManager;
    [SerializeField]
    private BeforePlayUI beforePlayUI;

    private static GameOverUI instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayerDeath()
    {
        instance.gameObject.SetActive(true);
        instance.image.sprite = instance.sprites[BeforePlayUI.modelIndex];
        instance.score.text = ScoreManager.lastScore + " Points";
    }

    public void Restart()
    {
        FxHandler.playerDeath = false;
        scoreManager.Init();

        beforePlayUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void GameOff()
    {

    }
}
