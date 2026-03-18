using UnityEngine;

public class Player : GameCharacter
{

    [SerializeField] private Weapon weapon;
    [SerializeField] private Movement movement;
    

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
        if(!GetCollisionHandler())
        {
            SetCollisionHandler(gameObject.AddComponent<PlayerCollisionHandler>());
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
