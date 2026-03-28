using UnityEngine;
using TMPro;

public class PlayerReward : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText; // Assign your Score UI here

    void Start()
    {
        UpdateScoreUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        // --- Coins ---
        if (other.CompareTag("Coin"))
        {
            Coin coin = other.GetComponent<Coin>();
            if (coin != null)
            {
                score += coin.pointValue;      // Add points based on coin type
                Destroy(other.gameObject);     // Remove coin
            }
        }

        // --- Penalty Objects ---
        if (other.CompareTag("Penalty"))
        {
            score -= 1;                        // Subtract points (can be customized)
            if (score < 0) score = 0;          // Prevent negative score
        }

        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}


