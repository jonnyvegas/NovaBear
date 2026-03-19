using UnityEngine;

public class ParticleCollisionHandler : CollisionHandler
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
        other.gameObject.TryGetComponent(out CollisionHandler ch);
        if (ch)
        {
            this.gameObject.transform.root.TryGetComponent(out Collider collider);
            if (collider)
            {
                //Debug.Log("hit");
                ch.HandleCollision(collider);
            }
            else
            {
                //Debug.Log("no collider on " + this.transform.root.gameObject.name);
                ch.HandleCollision(this.transform.root.gameObject);
            }
        }
    }

    public override void HandleCollision(Collider other)
    {
        // do nothing for now.
    }
}
