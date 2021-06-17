using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    private int _damage;
    private bool _destroyOnHit;
    private ParticleSystem _particleSystem;
    [SerializeField] private LayerMask layer = 8;

    private void OnTriggerEnter(Collider other)
    {
        Collided(other.gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        print(other.gameObject.name);
        Collided(other.gameObject);
    }

    private void Collided(GameObject gameObject)
    {
        if (gameObject.layer == layer)
        {
            Health health = gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.RemoveHealth(_damage);
            }
        }
        if(_particleSystem != null) {} //instantie partical system 
        if(_destroyOnHit) Destroy(this.gameObject);
    }

    public void Instantiate(float damage, bool destroyOnHit, ParticleSystem particleOnHit)
    {
        _damage = (int)(damage / 2);
        _destroyOnHit = destroyOnHit;
        _particleSystem = particleOnHit;
    }

    public void SetLayer(LayerMask lay)
    {
        this.layer = lay;
    }
}
