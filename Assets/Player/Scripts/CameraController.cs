using UnityEngine;

namespace MOBA
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerController;

        public static Camera PlayerCamera { get => playerCamera; }
        [SerializeField]  private static Camera playerCamera;

        [SerializeField] private float cameraMoveSpeed = 1;

        [Tooltip("The x offset applied to the cameras position whenever its snapped to the user.")]
        [SerializeField] private float cameraSnapXOffset = 0;

        [Tooltip("The y offset applied to the cameras position whenever its snapped to the user.")]
        [SerializeField] private float cameraSnapYOffset = 0;

        [Tooltip("Toggle camera controls on or off.")]
        public bool cameraControlsActive = true;

        /// <summary>
        /// Returns true if the camera is snapped to the player this frame.
        /// </summary>
        public bool CameraSnappedToPlayer { get => cameraSnappedToPlayer; }
        private bool cameraSnappedToPlayer = false;

        private Vector3 verticalPoint = new();
        private Vector3 horizontalPoint = new();
        private Vector3 mousePosition = new();
        private float deltaTime;

        private void Awake()
        {
            playerCamera = Camera.main;
        }

        private void Update()
        {
            mousePosition = Input.mousePosition;
            deltaTime = Time.deltaTime;

            if (Input.GetKey(KeyCode.Space))
                SnapCameraToPlayer();
            else
                cameraSnappedToPlayer = false;

            MoveCamera();
        }

        /// <summary>
        /// Move camera whenever the users mouse is at the edges of the screen.
        /// </summary>
        private void MoveCamera()
        {
            if (cameraSnappedToPlayer || !cameraControlsActive)
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

        /// <summary>
        /// Locks the camera to the player.
        /// </summary>
        private void SnapCameraToPlayer()
        {
            if (!cameraControlsActive)
                return;

            cameraSnappedToPlayer = true;

            verticalPoint = Utilities.FindNearestPointOnLine(playerController.transform.position, Vector3.forward, playerCamera.transform.position);
            horizontalPoint = Utilities.FindNearestPointOnLine(playerController.transform.position, Vector3.right, playerCamera.transform.position);

            playerCamera.transform.position = new Vector3(
                verticalPoint.x + cameraSnapXOffset,
                playerCamera.transform.position.y,
                horizontalPoint.z + cameraSnapYOffset);
        }
    }
}