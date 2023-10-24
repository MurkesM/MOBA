using UnityEngine;

namespace MOBA
{
    public class ProjectileBase : MonoBehaviour
    {
        public float moveSpeed = 1;

        public int Damage { get => damage; set => damage = value; }
        private int damage = 0;

        private void Update()
        {
            transform.position += moveSpeed * Time.deltaTime * transform.forward;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageable iDamageable))
            {
                iDamageable.Damage(damage);
                Destroy(gameObject);
            }
        }
    }
}