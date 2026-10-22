using UnityEngine;
using TMPro; // TMP_Text
 
// Shows the speed boost icon and seconds left while the boost is on.
public class PowerUpHUD : MonoBehaviour
{
    [SerializeField] private PlayerPowerUps powerUps;
    [SerializeField] private GameObject speedIndicator; // icon + time
    [SerializeField] private GameObject doubleJumpIndicator; // icon + time
    [SerializeField] private GameObject doubleScoreIndicator; // icon + time
    [SerializeField] private TMP_Text speedTimeText;
    [SerializeField] private TMP_Text doubleJumpTimeText;
    [SerializeField] private TMP_Text doubleScoreTimeText;
    
    private void Update()
    {
        float speedTimeLeft = powerUps.SpeedTimeLeft;
        float scoreTimeLeft = powerUps.ScoreBoostTimeLeft;
        float jumpTimeLeft = powerUps.JumpForceTimeLeft;

        // Show each indicator while its power-up is active
        speedIndicator.SetActive(speedTimeLeft > 0f);
        doubleScoreIndicator.SetActive(scoreTimeLeft > 0f);
        doubleJumpIndicator.SetActive(jumpTimeLeft > 0f);

        // Update each timer
        speedTimeText.text = Mathf.CeilToInt(speedTimeLeft) + "s";
        doubleJumpTimeText.text = Mathf.CeilToInt(jumpTimeLeft) + "s";
        doubleScoreTimeText.text = Mathf.CeilToInt(scoreTimeLeft) + "s";
    }
}
