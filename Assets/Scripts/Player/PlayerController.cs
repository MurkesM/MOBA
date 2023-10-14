using UnityEngine;

namespace MOBA
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Camera playerCamera;
        [SerializeField] private float moveSpeed = 1;
        [SerializeField] private float rotateSpeed = 1;
        [SerializeField] private LayerMask floorLayer;

        private int mouseRightClickIndex = 1;
        private Vector3 movePosition = new();
        private Quaternion rotation = Quaternion.identity;

        private Ray ray;
        private RaycastHit hit;

        private void OnEnable()
        {
            movePosition = transform.position;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(mouseRightClickIndex))
                UpdatePlayerMovePosition();

            MovePlayer();
        }

        private void UpdatePlayerMovePosition()
        {
            ray = playerCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, floorLayer))
                movePosition = new Vector3(hit.point.x,transform.position.y, hit.point.z);
        }

        private void MovePlayer()
        {
            transform.position = Vector3.MoveTowards(transform.position, movePosition, moveSpeed * Time.deltaTime);

            //rotate if the player hasn't reached the move position yet
            if (transform.position != movePosition)
            {
                rotation = Quaternion.LookRotation(movePosition - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotateSpeed);
            }
        }
    }
}