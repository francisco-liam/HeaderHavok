using UnityEngine.UI;
using UnityEngine;
using TMPro;// Don't forget this line
using Unity.VisualScripting;

public class ScoreAndLivesMgr : MonoBehaviour
{
    public TextMeshPro scoreText;
    public TextMeshPro liveText;
    public static int livesCounter;
    public static int scoreCounter;
    public static bool running = false;

    public static ScoreAndLivesMgr inst;

    public void Awake()
    {
        inst = this;
    }

    public void Update()
    {
        scoreText.text =  "Score: " + scoreCounter.ToString();
        liveText.text =  "Lives: " + livesCounter.ToString();
    }

    public static void UpdateLives()
    {
        livesCounter--;
    }

    public static void UpdateScore()
    {
        scoreCounter++;
    }

    public static void ResetLivesAndScore()
    {
        livesCounter = 3;
        scoreCounter = 0;
    }
}
