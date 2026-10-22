using UnityEngine;

// Gives the player a speed boost for a limited time.
public class PlayerPowerUps : MonoBehaviour
{
    [SerializeField] private float boostMultiplier = 1.5f; // 50% faster
    [SerializeField] private int scoreBoostMultiplier = 2;
 
    // Seconds of boost left. The HUD reads it; only this script changes it.
    public float SpeedTimeLeft { get; private set; }
    public float JumpForceTimeLeft { get; private set; }

    public float ScoreBoostTimeLeft { get; private set; }    
 
    private CharacterMovement movement;
 
    private void Start()
    {
        movement = GetComponent<CharacterMovement>();
    }
 
    // Called by the pickup. Collecting another boost restarts the timer.
    public void ActivateSpeedBoost(float duration)
    {
        SpeedTimeLeft = duration;
        movement.SpeedMultiplier = boostMultiplier;
    }

    public void ActivateJumpBoost(float duration)
    {
        JumpForceTimeLeft = duration;
        movement.canDoubleJump = true;
    }    

    public void ActivateScoreBoost(float duration)
    {
        ScoreBoostTimeLeft = duration;
        ScoreManager.ScoreBoostMultiplier = scoreBoostMultiplier;
    }        
 
    private void Update()
    {
        // Speed boost timer
        if (SpeedTimeLeft > 0f)
        {
            SpeedTimeLeft -= Time.deltaTime;

            if (SpeedTimeLeft <= 0f)
            {
                SpeedTimeLeft = 0f;
                movement.SpeedMultiplier = 1f;
            }
        }

        // Double jump timer
        if (JumpForceTimeLeft > 0f)
        {
            JumpForceTimeLeft -= Time.deltaTime;

            if (JumpForceTimeLeft <= 0f)
            {
                JumpForceTimeLeft = 0f;
                movement.canDoubleJump = false;
            }
        }

        // Double score timer
        if (ScoreBoostTimeLeft > 0f)
        {
            ScoreBoostTimeLeft -= Time.deltaTime;

            if (ScoreBoostTimeLeft <= 0f)
            {
                ScoreBoostTimeLeft = 0f;
                ScoreManager.ScoreBoostMultiplier = 1;
            }
        }
    }
}
