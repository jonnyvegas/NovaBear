using UnityEngine;

public class EnemyCollisionHandler : CollisionHandler
{
    [SerializeField] private GameObject explosionParticleSys;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void HandleCollision(Collider other)
    {
        base.HandleCollision(other);
        if(other.transform.root.gameObject.TryGetComponent<Weapon>(out Weapon weapon))
        { 
            Debug.Log("hit");
            this.TryGetComponent(out Health health);
            if (health)
            {
                health.UpdateHealth(weapon.GetDamage() * -1);
                if(health.GetHealth() <= 0f)
                {
                    //SpawnVFX();
                    DestroyAndSpawnVFX();
                }
            }
        }
        //DestroyAndSpawnVFX();
    }

    public override void HandleTriggerEnter(Collider other)
    {
        base.HandleTriggerEnter(other);
        //Debug.Log("blow up?");
        if(other.transform.root.TryGetComponent(out CollisionHandler ch))
        { 
            ch.TriggerActivated(this.GetComponent<Collider>());
        }
        // Something entered us but we don't want to set the health to 0 and trigger the
        // on zero health event because we technically didn't lose health, we
        // had a trigger enter our collision.
        DestroyAndSpawnVFX();
    }

    private void SpawnVFX()
    {
        if (explosionParticleSys)
        {
            Instantiate(explosionParticleSys, transform.position, Quaternion.identity);
        }
        //Destroy(this.gameObject);
    }

    private void DestroyAndSpawnVFX()
    {
        //SpawnVFX();
        if (this.TryGetComponent(out GameCharacter gameCharacter))
        {
            gameCharacter.GetGameCharRef().DestroyGameCharacter();
        }
    }
}
