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
        [SerializeField] private float cameraCenterXOffset = 0;
        [SerializeField] private float cameraCenterYOffset = 0;

        private int mouseRightClickIndex = 1;
        private Vector3 movePosition = new();
        private Quaternion rotation = new();

        private Ray ray;
        private RaycastHit hit;

        private Vector3 mousePosition = new();
        private float deltaTime;

        private Vector3 verticalPoint = new();
        private Vector3 horizontalPoint = new();

        private bool cameraLockedOnPlayer = false;

        private void OnEnable()
        {
            movePosition = transform.position;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(mouseRightClickIndex))
                UpdatePlayerMovePosition();

            if (Input.GetKey(KeyCode.Space))
                LockCameraOnPlayer();
            else
                cameraLockedOnPlayer = false;

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
            if (cameraLockedOnPlayer)
                return;

            if (mousePosition.x <= 0)
                playerCamera.transform.position -= Vector3.right * deltaTime * cameraMoveSpeed;

            else if (mousePosition.x >= Screen.width)
                playerCamera.transform.position += Vector3.right * deltaTime * cameraMoveSpeed;

            if (mousePosition.y <= 0)
                playerCamera.transform.position -= Vector3.forward * deltaTime * cameraMoveSpeed;

            else if (mousePosition.y >= Screen.height)
                playerCamera.transform.position += Vector3.forward * deltaTime * cameraMoveSpeed;
        }

        private void LockCameraOnPlayer()
        {
            cameraLockedOnPlayer = true;

            verticalPoint = Utilities.FindNearestPointOnLine(transform.position, Vector3.forward, playerCamera.transform.position);
            horizontalPoint = Utilities.FindNearestPointOnLine(transform.position, Vector3.right, playerCamera.transform.position);

            playerCamera.transform.position = new Vector3(
                verticalPoint.x + cameraCenterXOffset, 
                playerCamera.transform.position.y, 
                horizontalPoint.z + cameraCenterYOffset);
        }
    }
}