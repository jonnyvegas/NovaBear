using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TMP_Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int deltaScore)
    {
        score += deltaScore;
        scoreText.text = "Score: " + score.ToString("D6");
        //Debug.Log("Current score: " + score);
    }
}
