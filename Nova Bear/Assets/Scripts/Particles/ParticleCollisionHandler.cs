using UnityEngine;

public class LaserCollisionHandler : CollisionHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        //Debug.Log(this.gameObject.name + " collided with " + other.gameObject.name);
        CollisionHandler ch = other.GetComponent<CollisionHandler>();
        if (ch)
        {
            ch.HandleCollision(this.gameObject);
        }
    }

    public override void HandleCollision(GameObject other)
    {
        // do nothing for now.
    }
}
