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
        //Debug.Log("Hit an enemy");
        DestroyAndSpawnVFX();
    }

    public override void HandleTriggerEnter(Collider other)
    {
        base.HandleTriggerEnter(other);
        //Debug.Log("blow up?");
        other.transform.root.TryGetComponent<CollisionHandler>(out CollisionHandler ch);
        if (ch)
        {
            ch.HandleTriggerEnter(this.GetComponent<Collider>());
        }
        DestroyAndSpawnVFX();
    }

    private void DestroyAndSpawnVFX()
    {
        if (explosionParticleSys)
        {
            Instantiate(explosionParticleSys, transform.position, Quaternion.identity);
        }
        Destroy(this.gameObject);
    }
}
