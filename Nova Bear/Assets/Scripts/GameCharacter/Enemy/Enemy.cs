using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : GameCharacter
{
    private GameCharacter gameChar;
    private void Awake()
    {
        //BaseGCDecorator gcDec;
        GameCharacter tempGameChar = this;
        description = "Enemy";
        SetCollisionHandler(gameObject.AddComponent<EnemyCollisionHandler>());
        gameChar = this;
        gameChar = this.AddComponent<ExplosionDecorator>();
        gameChar.SetGameCharRef(tempGameChar);
        tempGameChar = gameChar;
        gameChar = this.AddComponent<HealOnExplodeDecorator>();
        gameChar.SetGameCharRef(tempGameChar);
        //BaseGCDecorator dec = decorators[0];
        //gameChar = gameObject.AddComponent(typeof(ExplosionDecorator)) as ExplosionDecorator;
    }

    public override void SetGameCharRef(GameCharacter character)
    {
        gameChar = character;
    }

    public override GameCharacter GetGameCharRef()
    {
        return gameChar;
    }

    public override void HandleZeroHealth()
    {
        base.HandleZeroHealth();
        //DestroyGameCharacter();
    }

    public override void DestroyGameCharacter()
    {
        //Debug.Log("Destroy Enemy");
        Destroy(this.gameObject);
    }
}
