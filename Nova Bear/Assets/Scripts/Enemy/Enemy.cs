using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private CollisionHandler collisionHandler;
    private void Awake()
    {
        collisionHandler = gameObject.AddComponent<EnemyCollisionHandler>();
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
