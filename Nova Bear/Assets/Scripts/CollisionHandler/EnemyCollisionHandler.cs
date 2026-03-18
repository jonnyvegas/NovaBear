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
        other.transform.root.gameObject.TryGetComponent<Weapon>(out Weapon weapon);
        
        if (weapon)
        {
            this.transform.root.TryGetComponent<Health>(out Health health);
            if (health)
            {
                
                health.UpdateHealth(weapon.GetDamage() * -1);
                if(health.GetHealth() <= 0f)
                {
                    SpawnVFX();
                }
            }
        }
        //DestroyAndSpawnVFX();
    }

    public override void HandleTriggerEnter(Collider other)
    {
        base.HandleTriggerEnter(other);
        //Debug.Log("blow up?");
        other.transform.root.TryGetComponent<CollisionHandler>(out CollisionHandler ch);
        if (ch)
        {
            ch.TriggerActivated(this.GetComponent<Collider>());
        }
        //DestroyAndSpawnVFX();
    }

    private void SpawnVFX()
    {
        if (explosionParticleSys)
        {
            Instantiate(explosionParticleSys, transform.position, Quaternion.identity);
        }
        //Destroy(this.gameObject);
    }
}
