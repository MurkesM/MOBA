using UnityEngine;

namespace MOBA
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Camera playerCamera;
        [SerializeField] private LayerMask floorLayer;

        private int mouseRightClickIndex = 1;

        private Ray ray;
        private RaycastHit hit;

        [Tooltip("Represents the target transform the ai pathfinding is using.")]
        public Transform moveTarget;

        private void Update()
        {
            if (Input.GetMouseButtonDown(mouseRightClickIndex))
                UpdatePlayerMovePosition();
        }

        private void UpdatePlayerMovePosition()
        {
            ray = playerCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, floorLayer))
                moveTarget.position = hit.point;
        }
    }
}