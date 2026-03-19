using System;
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
        
        if(other.transform.root.gameObject.TryGetComponent(out CollisionHandler collisionHandler))
        {
            Debug.Log("Oh no, we blow up.");
            DestroyAndSpawnVFX();
        }
    }

    public override void TriggerActivated(Collider other)
    {
        base.TriggerActivated(other);
        Debug.Log(other.gameObject.name);
        if(other.gameObject.TryGetComponent(out Enemy enemyComp))
        {
            Debug.Log("hit enemy");
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
