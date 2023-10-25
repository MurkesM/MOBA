using UnityEngine;

namespace MOBA
{
    public class CharacterBase : MonoBehaviour, IDamageable
    {
        [Header("General")]
        [SerializeField] protected AIPathExtended aiPathExtended;
        [SerializeField] protected Animator animator;
        [SerializeField] protected CameraController cameraController;
        [SerializeField] protected PlayerInput playerController;

        [Header("Character Stats")]
        [SerializeField] protected int health = 700;
        [SerializeField] protected int mana = 500;
        [SerializeField] protected int attackDamage = 70;
        [SerializeField] protected int attackSpeed = 20;
        [SerializeField] protected int magicDamage = 70;
        [SerializeField] protected int moveSpeed = 50;

        protected virtual void OnEnable()
        {
            aiPathExtended.OnStartMovingEvent += StartMoving;
            aiPathExtended.OnTargetReachedEvent += StopMoving;
        }

        protected virtual void OnDisable()
        {
            aiPathExtended.OnStartMovingEvent -= StartMoving;
            aiPathExtended.OnTargetReachedEvent -= StopMoving;
        }

        protected virtual void Update()
        {
            Passive();
        }

        public virtual void Passive() { }

        public virtual void Ability1()
        {
            print("Ablility 1 Called");
        }

        public virtual void Ability2()
        {
            print("Ablility 2 Called");
        }

        public virtual void Ability3()
        {
            print("Ablility 3 Called");
        }

        public virtual void Ability4()
        {
            print("Ablility 4 Called");
        }

        protected virtual void StartMoving()
        {
            print("Start Moving");

            animator.SetBool("Walk", true);
        }

        protected virtual void StopMoving()
        {
            print("Stop Moving");

            animator.SetBool("Walk", false);
        }

        public virtual void Damage(int damage)
        {
            print($"Damaged. Damage Amount {damage}");
        }
    }
}