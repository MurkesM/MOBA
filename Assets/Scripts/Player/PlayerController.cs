using UnityEngine;

namespace MOBA
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Camera playerCamera;
        [SerializeField] private float playerMovedSpeed = 1;
        [SerializeField] private float rotateSpeed = 1;
        [SerializeField] private float cameraMoveSpeed = 1;
        [SerializeField] private LayerMask floorLayer;

        private int mouseRightClickIndex = 1;
        private Vector3 movePosition = new();
        private Quaternion rotation = new();

        private Ray ray;
        private RaycastHit hit;

        private Vector3 mousePosition = new();
        private float deltaTime;

        private void OnEnable()
        {
            movePosition = transform.position;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(mouseRightClickIndex))
                UpdatePlayerMovePosition();

            mousePosition = Input.mousePosition;
            deltaTime = Time.deltaTime;

            MovePlayer();
            MoveCamera();
        }

        private void UpdatePlayerMovePosition()
        {
            ray = playerCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, floorLayer))
                movePosition = new Vector3(hit.point.x,transform.position.y, hit.point.z);
        }

        private void MovePlayer()
        {
            transform.position = Vector3.MoveTowards(transform.position, movePosition, playerMovedSpeed * deltaTime);

            //rotate if the player hasn't reached the move position yet
            if (transform.position != movePosition)
            {
                rotation = Quaternion.LookRotation(movePosition - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * deltaTime);
            }
        }

        /// <summary>
        /// Move camera whenever the users mouse is at the edge of the screens.
        /// </summary>
        private void MoveCamera()
        {
            if (mousePosition.x <= 0)
                playerCamera.transform.position -= Vector3.right * deltaTime * cameraMoveSpeed;

            else if (mousePosition.x >= Screen.width)
                playerCamera.transform.position += Vector3.right * deltaTime * cameraMoveSpeed;

            if (mousePosition.y <= 0)
                playerCamera.transform.position -= Vector3.forward * deltaTime * cameraMoveSpeed;

            else if (mousePosition.y >= Screen.height)
                playerCamera.transform.position += Vector3.forward * deltaTime * cameraMoveSpeed;
        }
    }
}