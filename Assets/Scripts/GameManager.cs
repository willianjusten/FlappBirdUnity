using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject getReady;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject highScoreText;
    private int score;

    private void Awake() {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play() {
        score = 0;
        scoreText.text = score.ToString();

        getReady.SetActive(false);
        gameOver.SetActive(false);
        playButton.SetActive(false);
        highScoreText.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause() {
        Time.timeScale = 0f;
        player.enabled = false;
    } 

    public void IncreaseScore() {
        score++;
        scoreText.text = score.ToString();
    }

    public void SaveAndShowScore() {
        if (score > PlayerPrefs.GetInt("HighScore")) {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }

        highScoreText.GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        highScoreText.SetActive(true);
    }

    public void GameOver() {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        SaveAndShowScore();

        Pause();
    }
}
