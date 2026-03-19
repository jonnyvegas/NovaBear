using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float healthAmt = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void UpdateHealth(float deltaHealth)
    {
        healthAmt += deltaHealth;
        if(healthAmt <= 0.0f)
        {
            HandleZeroHealth();
        }
    }

    public float GetHealth()
    {
        return healthAmt;
    }

    // Pass up to the owner of this (Health).
    private void HandleZeroHealth()
    {
        this.transform.root.gameObject.TryGetComponent<GameCharacter>(out GameCharacter gc);
        if(gc)
        {
            gc.HandleZeroHealth();
        }

        
    }
}
