using UnityEngine;

public class ExplosionDecorator : BaseGCDecorator
{
    GameCharacter gameChar;

    public override void SetGameCharRef(GameCharacter gameChar)
    {
        this.gameChar = gameChar;
    }

    public override GameCharacter GetGameCharRef()
    {
        return this.gameChar;
    }

    public override string GetDescription()
    {
        return  gameChar.GetDescription() + "Explosion";
    }
    public override void DestroyGameCharacter()
    {
        Debug.Log("Destroy with explosion");
        
        gameChar.DestroyGameCharacter();
    }
}
