using UnityEngine;
using UnityEngine.Events;

public abstract class GameCharacter : MonoBehaviour
{
    protected string description;
    [SerializeField] private Health health;
    [SerializeField] private CollisionHandler collisionHandler;
    [SerializeField] private Weapon weapon;
    public UnityEvent zeroHealthEvent;

    private void Awake()
    {
        description = "GameCharacter";
    }
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
        //DestroyGameCharacter();
    }

    public Weapon GetWeapon()
    {
        return weapon;
    }

    public void SetWeapon(Weapon newWeapon)
    {
        weapon = newWeapon;
    }

    public string GetDescription()
    {
        return description;
    }

    public abstract void SetGameCharRef(GameCharacter character);
    public abstract GameCharacter GetGameCharRef();
    public abstract void DestroyGameCharacter();
}
