using UnityEngine;

public class Player : GameCharacter
{
    GameCharacter gameCharacter;
    [SerializeField] private Movement movement;
    private void Awake()
    {
        if (!GetWeapon())
        {
            SetWeapon(gameObject.AddComponent<PlayerWeapon>());
        }
        if(!movement)
        {
            movement = gameObject.AddComponent<PlayerMovement>();
        }
        if(!GetCollisionHandler())
        {
            SetCollisionHandler(gameObject.AddComponent<PlayerCollisionHandler>());
            //Debug.Log("adding player collision handler");
        }
    }

    public override void HandleZeroHealth()
    {
        base.HandleZeroHealth();
        //DestroyGameCharacter();
    }

    public override void DestroyGameCharacter()
    {
        Debug.Log("Destroy player");
    }

    public override void SetGameCharRef(GameCharacter character)
    {
        this.gameCharacter = character;
    }

    public override GameCharacter GetGameCharRef()
    {
        return gameCharacter;
    }
}
