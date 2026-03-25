using UnityEngine;

public interface IExplosionManager
{
    GameObject GetExplosionVFX(bool player);
}

public class ExplosionManager : MonoBehaviour, IExplosionManager
{
    [SerializeField] GameObject explosionVFXPlayer; 
    [SerializeField] GameObject explosionVFXEnemy;

    public GameObject GetExplosionVFX(bool player)
    {
        return player ? explosionVFXPlayer : explosionVFXEnemy;
    }
}
