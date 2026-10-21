using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTrigger : MonoBehaviour
{
    [SerializeField] private string endSceneName;
 
    private void OnTriggerEnter(Collider other)
    {
        // Only the player can finish the level
        if (!other.CompareTag("Player")) return;
 
        // // Save the score BEFORE loading: the ScoreManager is about
        // // to be destroyed together with the rest of SampleScene
        ScoreManager.Instance.SaveFinalScore();
        LivesManager.Instance.SaveFinalLives();
 
        SceneManager.LoadScene(endSceneName);
    }

}