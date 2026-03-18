using UnityEngine;

public class Enemy : GameCharacter
{
    private void Awake()
    {
        SetCollisionHandler(gameObject.AddComponent<EnemyCollisionHandler>());
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
