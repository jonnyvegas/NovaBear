using UnityEngine;

public class PlayerCollisionHandler : CollisionHandler
{
    [SerializeField] private GameObject explosionParticle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("player handler instantiated");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void HandleCollision(Collider other)
    {
        base.HandleCollision(other);
        Debug.Log("Oh no, we blow up.");
    }


    public override void HandleTriggerEnter(Collider other)
    {
        base.HandleTriggerEnter(other);
        Debug.Log("Oh no, we blow up.");
        DestroyAndSpawnVFX();
    }

    public override void TriggerActivated(Collider other)
    {
        base.TriggerActivated(other);
        other.transform.root.gameObject.TryGetComponent<Enemy>(out Enemy enemyComp);
        // we ran into an enemy.
        if(enemyComp)
        {
            DestroyAndSpawnVFX();
        }
    }
    private void DestroyAndSpawnVFX()
    {
        if (explosionParticle)
        {
            Instantiate(explosionParticle, transform.position, Quaternion.identity);
        }
        Destroy(this.gameObject);
    }
}
