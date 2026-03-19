using UnityEngine;
using UnityEngine.Events;

public class GameCharacter : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private CollisionHandler collisionHandler;
    public UnityEvent zeroHealthEvent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public CollisionHandler GetCollisionHandler()
    {
        return collisionHandler;
    }

    public void SetCollisionHandler(CollisionHandler collisionHandler)
    {
        this.collisionHandler = collisionHandler;
    }    

    public Health GetHealthComp()
    {
        return health;
    }

    // Health will call this when it reaches 0. Handle it however from here.
    // This will call OnDestroy of this item.
    public virtual void HandleZeroHealth()
    {
        zeroHealthEvent.Invoke();
        Destroy(this.transform.root.gameObject);
    }
}
