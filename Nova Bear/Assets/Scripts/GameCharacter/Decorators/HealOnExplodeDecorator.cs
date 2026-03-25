using UnityEngine;

public class HealOnExplodeDecorator : BaseGCDecorator
{
    GameCharacter character;
    public override GameCharacter GetGameCharRef()
    {
       return character;
    }

    public override void SetGameCharRef(GameCharacter character)
    {
        this.character = character;
    }

    public override void DestroyGameCharacter()
    {
        //Debug.Log("Destroy and heal");
        character.DestroyGameCharacter();
    }

    public override string GetDescription()
    {
        return character.GetDescription() + " heals";
    }
}
