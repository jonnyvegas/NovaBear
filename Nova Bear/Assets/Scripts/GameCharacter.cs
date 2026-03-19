using UnityEngine;

public class GameCharacter : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private CollisionHandler collisionHandler;
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
    public virtual void HandleZeroHealth()
    {
        Destroy(this.transform.root.gameObject);
    }
}
