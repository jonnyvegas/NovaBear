using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    private float score = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(float deltaScore)
    {
        score += deltaScore;
        Debug.Log("Current score: " + score);
    }
}
