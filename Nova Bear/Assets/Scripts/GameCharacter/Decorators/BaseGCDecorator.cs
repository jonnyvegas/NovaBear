using UnityEngine;

public abstract class BaseGCDecorator : GameCharacter
{
    public override abstract void DestroyGameCharacter();
    public new abstract string GetDescription();
}
