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

        /// <summary>
        /// Returns the mouse position in screen space or world space. 
        /// You'll need to set the z position.
        /// Defaults to screen space.
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="inWorldSpace"></param>
        /// <returns></returns>
        public static Vector3 GetMousePosition(Camera camera, bool inWorldSpace = false)
        {
            return  inWorldSpace ? camera.ScreenToWorldPoint(Input.mousePosition) : Input.mousePosition;
        }

        /// <summary>
        /// Performs a physics raycast, returning true if the raycast was successful.
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="hit"></param>
        /// <param name="layerMask"></param>
        /// <returns></returns>
        public static bool GetMousePosition(Camera camera, out RaycastHit hit, int layerMask)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                return true;

            return false;
        }
    }
}