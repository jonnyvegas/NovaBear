using UnityEngine;

public class ExplosionDecorator : BaseGCDecorator
{
    GameCharacter gameChar;
    GameObject explosionParticle;

    private void Awake()
    {
        
    }
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
        //Debug.Log("Destroy with explosion");
        GameObject explosionMgr = GameObject.Find("ExplosionManager");
        
        if(explosionMgr.TryGetComponent(out IExplosionManager explosionMgrRef))
        {
           // Debug.Log("INSTANTIATE!!!!!");
            Instantiate(explosionMgrRef.GetExplosionVFX(this.TryGetComponent(out Player player)), gameObject.transform.position, gameObject.transform.rotation);
            //Debug.Log(gameObject.transform.position.ToString());
        }
        gameChar.DestroyGameCharacter();
    }
}
