using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score;

    public void IncreaseScore() {
        Debug.Log("Score");
        score++;
    }

    public void GameOver() {
        Debug.Log("GameOver");
    }
}
