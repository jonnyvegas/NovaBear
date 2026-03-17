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
            Collider collider = other.gameObject.GetComponent<Collider>();
            if (collider)
            {
                ch.HandleCollision(collider);
            }
            else
            {
                ch.HandleCollision(other);
            }
        }
    }

    public override void HandleCollision(Collider other)
    {
        // do nothing for now.
    }
}
