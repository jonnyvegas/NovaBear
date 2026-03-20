using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float healthAmt = 1.0f;
    private bool isDead = false;
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

    public void SetHealth(float newHealth)
    {
        healthAmt = newHealth;
        if(healthAmt <= 0f)
        {
            HandleZeroHealth();
        }
    }

    // Pass up to the owner of this (Health).
    private void HandleZeroHealth()
    {
        this.TryGetComponent(out GameCharacter gc);
        if (gc && !isDead)
        {
            isDead = true;
            gc.HandleZeroHealth();
        }
    }

    public bool GetIsDead()
    {
        return isDead;
    }
}
