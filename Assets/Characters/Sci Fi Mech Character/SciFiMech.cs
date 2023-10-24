using UnityEngine;

namespace MOBA
{
    public class SciFiMech : CharacterBase
    {
        [Header("Sci Fi Mech Fields")]
        [SerializeField] GameObject ability1ProjectilePrefab;
        [SerializeField] Transform ability1ProjectileSpawnPoint;

        protected override void Passive() { }

        protected override void Ability1()
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

            GameObject projectile = Instantiate(ability1ProjectilePrefab, ability1ProjectileSpawnPoint.position, ability1ProjectileSpawnPoint.rotation);
            projectile.GetComponent<ProjectileBase>().Damage = attackDamage;
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

        protected override void Ability4() { }
    }
}