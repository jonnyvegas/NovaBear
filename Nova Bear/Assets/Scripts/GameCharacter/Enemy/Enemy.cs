using System;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy : GameCharacter
{
    private GameCharacter gameChar;
    [SerializeField] private BaseGCDecorator[] decorators;
    private void Awake()
    {
        description = "Enemy";
        SetCollisionHandler(gameObject.AddComponent<EnemyCollisionHandler>());
        SetupDecorators();
    }

    void SetupDecorators()
    {
        Type theType = null;
        GameCharacter tempGameChar = this;
        foreach (BaseGCDecorator decorator in decorators)
        {
            theType = decorator.GetType();
            gameChar = gameObject.AddComponent(theType) as BaseGCDecorator;
            gameChar.SetGameCharRef(tempGameChar);
            tempGameChar = gameChar;
            
            //Debug.Log("Adding " + decorator.GetType().Name);
        }
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
