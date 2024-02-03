using UnityEngine;

namespace MOBA
{
    public class SciFiMech : CharacterBase
    {
        [Header("Sci Fi Mech Fields")]
        [SerializeField] GameObject ability1ProjectilePrefab;
        [SerializeField] Transform ability1ProjectileSpawnPoint;
        [SerializeField] int ability1ManaCost = 60;
        [SerializeField] float ability1Cooldown = 2;
        private float timeOfAbility1Used = 0;

        public override void Passive() { }

        public override void Ability1()
        {
            ///mech shoots a skillshot missile in a direction
            ///skillshot/aim based
            ///spawn projectile primitive object
            ///shoot in direction of mouse
            ///play shooting anim (animator.Play(test, -1);)
            ///drain mana
            ///go on cooldown
            ///can hit all enemies in path, including minions
            ///does major damage

            if (mana < ability1ManaCost || Time.time < timeOfAbility1Used + ability1Cooldown)
                return;

            //stop the character at current location
            playerController.pathfindingTarget.position = transform.position;

            //transform.forward = Vector3.RotateTowards(transform.forward, Utilities.GetMousePosition(CameraController.PlayerCamera, true, transform.position.z), 
            //    aiPathExtended.rotationSpeed, 0);

            ProjectileCreator.CreateProjectile(ability1ProjectilePrefab, attackDamage,
                ability1ProjectileSpawnPoint.position, ability1ProjectileSpawnPoint.rotation);

            mana -= ability1ManaCost;

            timeOfAbility1Used = Time.time;
        }

        public override void Ability2()
        {
            ///start flamethrower
            ///shreds armor
            ///slows enemies
            ///does much less damage than abailit 1
            ///can still move
            ///drains mana
            ///goes on cooldown
        }

        public override void Ability3()
        {
            ///dash forward
            ///use fly anaimation
            ///can damage minions
            ///if hitting an enemy, then will be stunned for 1 second
            ///use mana 
            ///go on cooldown
        }

        public override void Ability4() { }
    }
}