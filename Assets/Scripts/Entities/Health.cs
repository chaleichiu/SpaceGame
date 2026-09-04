using UnityEngine;
using System;
// Good example of Encapsulation
[DefaultExecutionOrder(-10)]
public class Health 
{
    private float currentHealth;
    private float maxHealth;
    private float healthRegenRate;

    public Action<float> OnHealthUpdate;

    //constructor ment for adding health to a new object

    public float GetHealth()
    {
        return currentHealth;
    }

    public Health(float _maxHealth, float _healthRengenRate, float _currentHealth = 100f)
    {
        currentHealth = _currentHealth;
        maxHealth = _maxHealth;
        healthRegenRate= _healthRengenRate;

        OnHealthUpdate?.Invoke(currentHealth); // broadcasts if your subscribed to this action, then here is current health
    }

    public Health(float _maxHealth)
    {
        maxHealth= _maxHealth;
    }

    public Health() { }

    public void AddHealth(float value)
    {
        currentHealth += value;
        OnHealthUpdate?.Invoke(currentHealth);
    }
    public void RemoveHealth(float value)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth - value);
        OnHealthUpdate?.Invoke(currentHealth);
    }
}
