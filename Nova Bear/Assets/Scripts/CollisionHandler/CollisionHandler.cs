using Unity.VisualScripting;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void HandleTriggerEnter(Collider other)
    {
        //Debug.Log(this.gameObject.name + " collided with " + other.gameObject.name);
    }

    public virtual void HandleCollision(GameObject other)
    {
        // nothing, abstraction.
    }
    
}
