using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Score")]
    [SerializeField] private TMP_Text scoreText;
    [Header("Lives")]
    [SerializeField] private TMP_Text livesText;

    private void Update()
    {
        UpdateScore();
        UpdateLives();
    }
 
    private void UpdateScore()
    {
        // The Score property from Lab 4: anyone can read it
        scoreText.text = "Score: " + ScoreManager.Instance.Score;
    }

    private void UpdateLives()
    {
        // The Score property from Lab 4: anyone can read it
        livesText.text = "Lives: " + LivesManager.Instance.Lives;
    }    
}
