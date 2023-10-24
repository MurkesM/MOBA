using UnityEngine;

namespace MOBA
{
    public class SciFiMech : CharacterBase
    {
        [Header("Sci Fi Mech Fields")]
        [SerializeField] private bool ability1Active = false;
        [SerializeField] private float ability1ActiveTime = 3;
        [SerializeField] private float ability1StartTime = 0;
        [SerializeField] private float ability1RotateSpeed = 1000;

        protected override void Update()
        {
            base.Update();

            if (ability1Active)
                Ability1Active();
        }

        protected override void Passive() { }

        protected override void Ability1()
        {
            ability1Active = true;
            ability1StartTime = Time.time;
            //animator.Play(test, -1);

            ///mech shoots a skillshot missile in a direction
            ///skillshot/aim based
            ///play shooting anim
            ///drain mana
            ///go on cooldown
            ///can hit all enemies in path, including minions
            ///does major damage
        }

        protected override void Ability2()
        {
            ///start flamethrower
            ///shreds armor
            ///slows enemies
            ///does much less damage than abailit 1
            ///can still move
            ///drains mana
            ///goes on cooldown
        }

        protected override void Ability3()
        {
            ///dash forward
            ///use fly anaimation
            ///can damage minions
            ///if hitting an enemy, then will be stunned for 1 second
            ///use mana 
            ///go on cooldown
        }

        protected override void Ability4()
        {
            
        }

        private void Ability1Active()
        {

        }
    }
}