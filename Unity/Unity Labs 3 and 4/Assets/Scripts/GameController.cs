using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public TMP_Text ScoreText;
    public Button PlayAgainButton;
    public GameObject OneBallPrefab;
    public int Score = 0;
    public bool GameOver = true;
    public int NumberOfBalls = 0;
    public int MaximumBalls = 15;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("AddABall", 1.5f, 1);
    }

    void Update()
    {
        ScoreText.text = Score.ToString();
    }

    // Update is called once per frame
    void AddABall()
    {
        if (!GameOver)
        {
            Instantiate(OneBallPrefab);
            NumberOfBalls++;
            if (NumberOfBalls >= MaximumBalls)
            {
                GameOver = true;
                PlayAgainButton.gameObject.SetActive(true);
            }
        }
    }

    public void ClickedOnBall()
    {
        Score++;
        NumberOfBalls--;
    }

    public void StartGame()
    {
        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("GameController")) 
        {
            Destroy(ball);
        }

        PlayAgainButton.gameObject.SetActive(false);
        Score = 0;
        NumberOfBalls = 0;
        GameOver = false;
    }
}
