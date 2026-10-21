using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapTrigger : MonoBehaviour
{
    public Transform respawnPoint;
 
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            if (LivesManager.Instance.Lives > 1) {
                LivesManager.Instance.TakeLives(1);
                other.transform.position = respawnPoint.position;
                Debug.Log("You hit a trap! Back to the checkpoint.");                
            } else {
                SceneManager.LoadScene("LevelOneScene");
                Debug.Log("You're out of lives! Back to the beginning.");                    
            }
        }
    }
}