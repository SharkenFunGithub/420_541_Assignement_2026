using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapTrigger : MonoBehaviour
{
    public Transform respawnPoint;

    public Transform basePoint;
 
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            if (LivesManager.Instance.Lives > 1) {
                LivesManager.Instance.TakeLives(1);
                ScoreManager.Instance.RemovePoints(100);
                other.transform.position = respawnPoint.position;
                Debug.Log("You hit a trap! Back to the checkpoint.");                
            } else {
                if (basePoint == null)
                {
                    other.transform.position = respawnPoint.position;                    
                } else
                {
                    other.transform.position = basePoint.position;                       
                }
                LivesManager.Instance.ResetLives(); 
                ScoreManager.Instance.ResetScore();               
            }
        }
    }
}