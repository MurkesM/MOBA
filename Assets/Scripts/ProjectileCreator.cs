using UnityEngine;

namespace MOBA
{
    public static class ProjectileCreator
    {
        public static void CreateProjectile(GameObject projectilePrefab, int damage, Vector3 spawnPosition, Quaternion spawnRotation)
        {
            GameObject projectileObject = GameObject.Instantiate(projectilePrefab, spawnPosition, spawnRotation);
            projectileObject.GetComponent<ProjectileBase>().damage = damage;
        }
    }
}