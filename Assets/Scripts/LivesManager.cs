using UnityEngine;


// Keeps track of the player's score.
// It's a singleton: there is only ever one, reachable from any script
// through ScoreManager.Instance.
public class LivesManager : MonoBehaviour
{
    // The single shared instance that any script can reach.
    // "static" means it belongs to the class, not to one object.
    public static LivesManager Instance { get; private set; }

    // Anyone can read the score, only LivesManager can change it
    public int Lives { get; private set; } = 3;

    public static int FinalLives { get; private set; }

    // Awake runs before any Start(), so Instance is ready before coins need it
    private void Awake()
    {
        // If a ScoreManager already exists, remove this extra component
        // (only the script, not the whole Player)
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }


        // Otherwise, this is the one and only ScoreManager
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void AddLives(int amount)
    {
        Lives += amount;


        // Print the new total to the Console window
        Debug.Log("Lives: " + Lives);
    }

    public void TakeLives(int amount)
    {
        Lives -= amount;


        // Print the new total to the Console window
        Debug.Log("Lives: " + Lives);
    }    

    public void SaveFinalLives()
    {
        FinalLives = Lives;
    }

}