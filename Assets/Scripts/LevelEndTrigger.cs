using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTrigger : MonoBehaviour
{
    private string endSceneName = "EndScene";
 
    private void OnTriggerEnter(Collider other)
    {
        // Only the player can finish the level
        if (!other.CompareTag("Player")) return;
 
        // Save the score BEFORE loading: the ScoreManager is about
        // to be destroyed together with the rest of SampleScene
        ScoreManager.Instance.SaveFinalScore();
        // LivesManager.Instance.SaveFinalLives();

        if (SceneManager.GetActiveScene().name == "LevelThreeScene")
        {
            SceneManager.LoadScene(endSceneName); // Game finished
        }
        else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Next level
        }
    }

}