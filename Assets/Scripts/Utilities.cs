using UnityEngine;

namespace MOBA
{
    public static class Utilities
    {
        public static Vector3 FindNearestPointOnLine(Vector3 lineOrigin, Vector3 lineDirection, Vector3 pointToCheck)
        {
            lineDirection.Normalize();
            Vector3 directionOfPoint = pointToCheck - lineOrigin;

            float dotP = Vector3.Dot(directionOfPoint, lineDirection);
            return lineOrigin + lineDirection * dotP;
        }
    }
}