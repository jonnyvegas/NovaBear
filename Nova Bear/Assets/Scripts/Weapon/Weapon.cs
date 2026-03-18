using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float damage = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void UseWeapon(bool bUse = true)
    {
        Debug.Log("Base Weapon UseWeapon");
    }

    public float GetDamage()
    {
        return damage;
    }

    public void SetDamage(float newDmg)
    {
        damage = newDmg;
    }
}
