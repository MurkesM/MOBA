using UnityEngine;

namespace MOBA
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Camera playerCamera;
        [SerializeField] float moveSpeed = 1;
        [SerializeField] private LayerMask floorLayer;

        private int mouseRightClickIndex = 1;
        private Vector3 movePosition = new();

        private void Awake()
        {
            movePosition = transform.position;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(mouseRightClickIndex))
                UpdateMovePosition();

            Move();
        }

        private void UpdateMovePosition()
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, floorLayer))
                movePosition = new Vector3(hit.point.x,transform.position.y, hit.point.z);
        }

        private void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, movePosition, moveSpeed * Time.deltaTime);
        }
    }
}