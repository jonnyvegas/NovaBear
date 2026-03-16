using UnityEngine;

public class PlayerCollisionHandler : CollisionHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void HandleCollision(GameObject other)
    {
        base.HandleCollision(other);
        Debug.Log("Oh no, we blow up.");
    }
}
