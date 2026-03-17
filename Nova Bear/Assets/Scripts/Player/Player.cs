using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Weapon weapon;
    [SerializeField] private Movement movement;
    [SerializeField] private CollisionHandler collisionHandler;

    private void Awake()
    {
        if (!weapon)
        {
            weapon = gameObject.AddComponent<PlayerWeapon>();
        }
        if(!movement)
        {
            movement = gameObject.AddComponent<PlayerMovement>();
        }
        if(!collisionHandler)
        {
            collisionHandler = gameObject.AddComponent<PlayerCollisionHandler>();
            Debug.Log("adding player collision handler");
        }
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
