using System;
using System.Collections.Generic;
using UnityEngine;
public class HealthBase : MonoBehaviour, IDamageable

{
    public float startLife = 50f;
    public bool destroyOnKill = false;
    public float _currentLife;
    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;
    public List<FlashColor> flashColors;

    private void Awake()
    {

        Init();
    }

    protected virtual void Init()
    {
        ResetLife();

    }

    public void ResetLife()
    {

        _currentLife = startLife;
    }
    public virtual void Kill()

    {
        if (destroyOnKill)
            Destroy(gameObject, 3f);

        OnKill?.Invoke(this);
      

    }
   
    [NaughtyAttributes.Button]
    public void Damage(GameObject gameObject)
    {
        Damage(5);
    }
    public void Damage(float f)
    {

        _currentLife = -f;
        if (_currentLife <= 0)
        {
            Kill();
        }
        OnDamage?.Invoke(this);

    }
    public void Damage(float damage, Vector3 dir)
    {
        Damage(damage);
    }

}