using Unity.VisualScripting;
using UnityEngine;

public class Enemy : GameCharacter
{
    private GameCharacter gameChar;
    private void Awake()
    {
        GameCharacter tempGameChar = this;
        description = "Enemy";
        SetCollisionHandler(gameObject.AddComponent<EnemyCollisionHandler>());
        gameChar = this;
        gameChar = this.AddComponent<ExplosionDecorator>();
        gameChar.SetGameCharRef(tempGameChar);
        tempGameChar = gameChar;
        gameChar = this.AddComponent<HealOnExplodeDecorator>();
        gameChar.SetGameCharRef(tempGameChar);
    }

    public override void SetGameCharRef(GameCharacter character)
    {
        gameChar = character;
    }

    public override GameCharacter GetGameCharRef()
    {
        return gameChar;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void HandleZeroHealth()
    {
        base.HandleZeroHealth();
        //DestroyGameCharacter();
    }

    public override void DestroyGameCharacter()
    {
        Debug.Log("Destroy Enemy");
    }
}
