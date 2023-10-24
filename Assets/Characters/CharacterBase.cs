using UnityEngine;

namespace MOBA
{
    public class CharacterBase : MonoBehaviour
    {
        [Header("Hotkeys")]
        [SerializeField] protected KeyCode ability1Key = KeyCode.Q;
        [SerializeField] protected KeyCode ability2Key = KeyCode.W;
        [SerializeField] protected KeyCode ability3Key = KeyCode.E;
        [SerializeField] protected KeyCode ability4Key = KeyCode.R;

        [Header("General")]
        [SerializeField] protected AIPathExtended aiPathExtended;
        [SerializeField] protected Animator animator;
        [SerializeField] protected CameraController cameraController;

        [Header("Character Stats")]
        [SerializeField] private int health = 700;
        [SerializeField] private int mana = 500;
        [SerializeField] private int attackDamage = 70;
        [SerializeField] private int attackSpeed = 20;
        [SerializeField] private int magicDamage = 70;
        [SerializeField] private int armor = 20;
        [SerializeField] private int magicResist = 20;
        [SerializeField] private int moveSpeed = 50;
        [SerializeField] private float cooldDownReduction = 0;
        [SerializeField] private float armorPen = 0;
        [SerializeField] private float magicPen = 0;

        protected virtual void OnEnable()
        {
            aiPathExtended.OnTargetReachedEvent += StopMoving;
            aiPathExtended.OnStartMovingEvent += StartMoving;
        }

        protected virtual void OnDisable()
        {
            aiPathExtended.OnTargetReachedEvent -= StopMoving;
        }

        protected virtual void Update()
        {
            Passive();
            HandleAbilityInput();
        }

        protected virtual void HandleAbilityInput()
        {
            if (Input.GetKeyDown(ability1Key))
                Ability1();

            if (Input.GetKeyDown(ability2Key))
                Ability2();

            if (Input.GetKeyDown(ability3Key))
                Ability3();

            if (Input.GetKeyDown(ability4Key))
                Ability4();
        }

        protected virtual void Passive() { }

        protected virtual void Ability1()
        {
            print("Ablility 1 Called");
        }

        protected virtual void Ability2()
        {
            print("Ablility 2 Called");
        }

        protected virtual void Ability3()
        {
            print("Ablility 3 Called");
        }

        protected virtual void Ability4()
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

        protected virtual void Damage()
        {
            print("Damaged");
        }
    }
}