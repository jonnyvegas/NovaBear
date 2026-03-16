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

    public override void HandleCollision(GameObject other)
    {
        base.HandleCollision(other);
        Debug.Log("Hit an enemy");
        if(explosionParticleSys)
        {
            Debug.Log("Should instantiate");
            Instantiate(explosionParticleSys, transform.position, explosionParticleSys.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
