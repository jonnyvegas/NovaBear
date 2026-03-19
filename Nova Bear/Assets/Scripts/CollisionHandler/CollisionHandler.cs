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
    private void OnTriggerEnter(Collider other)
    {
        HandleTriggerEnter(other);
    }
    public virtual void HandleTriggerEnter(Collider other)
    {
        Debug.Log(this.gameObject.name + " collided with " + other.gameObject.name);
    }
    
    // if the class has a trigger, this will be called after HandleTriggerEnter of the other object.
    // In other words, the other object will handle trigger enter, and call OnTriggerEntered on the 
    // object containing the trigger.
    public virtual void TriggerActivated(Collider other)
    {
        Debug.Log("Trigger has been activated for: " + this.gameObject.name);
    }

    // Handles collision if we have a collider. If not, HandleCollision is called w/ GameObject (see below).
    public virtual void HandleCollision(Collider other)
    {
        // nothing, abstraction.
    }

    // If no collider on other object, check if we can still do something with the game object.
    public virtual void HandleCollision(GameObject other)
    {

    }
    
}
