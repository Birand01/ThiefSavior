using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class HealthBase : MonoBehaviour, IDamageable
{
    protected float health;
    [SerializeField] public Slider healthBarSlider;
    [SerializeField] protected Image healthBarFillImage;
    [SerializeField] protected Color maxHealthColor, minHealthColor;
    protected abstract void CheckIfDead();

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    private void Awake()
    {
        SetHealthBarUI();
    }

    protected virtual void Update()
    {
        SetHealthBarUI();
    }
    public virtual Transform GetTransform()
    {
        return transform;
    }

    public virtual void TakeDamage(float damage)
    {
        Health -= damage;
        Health = Mathf.Clamp(Health, 0, healthBarSlider.value);
        CheckIfDead();
        SetHealthBarUI();
    }
    private void SetHealthBarUI()
    {
        float healthPercentage = CalculateHealthPercentage();
        healthBarSlider.value = healthPercentage;
        healthBarFillImage.color = Color.Lerp(minHealthColor, maxHealthColor, healthPercentage / healthBarSlider.maxValue);


    }
    private float CalculateHealthPercentage()
    {
        return (Health / healthBarSlider.maxValue) * healthBarSlider.maxValue;
    }
}
