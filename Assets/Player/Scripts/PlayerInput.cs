using UnityEngine;

namespace MOBA
{
    public class PlayerInput : MonoBehaviour
    {
        [Header("Hotkeys")]
        [SerializeField] protected KeyCode ability1Key = KeyCode.Q;
        [SerializeField] protected KeyCode ability2Key = KeyCode.W;
        [SerializeField] protected KeyCode ability3Key = KeyCode.E;
        [SerializeField] protected KeyCode ability4Key = KeyCode.R;

        [Header("Movement")]
        [SerializeField] private LayerMask floorLayer;
        private RaycastHit hit;

        private int mouseRightClickIndex = 1;

        [Tooltip("Represents the target transform the ai pathfinding is using.")]
        public Transform pathfindingTarget;

        [SerializeField] private CharacterBase character;

        private void Update()
        {
            if (Input.GetMouseButtonDown(mouseRightClickIndex))
                UpdatePlayerMovePosition();

            HandleAbilityInput();
        }

        private void UpdatePlayerMovePosition()
        {
            if (Utilities.GetMousePosition(CameraController.PlayerCamera, out hit, floorLayer))
                pathfindingTarget.position = hit.point;
        }

        protected virtual void HandleAbilityInput()
        {
            if (Input.GetKeyDown(ability1Key))
                character.Ability1();

            if (Input.GetKeyDown(ability2Key))
                character.Ability2();

            if (Input.GetKeyDown(ability3Key))
                character.Ability3();

            if (Input.GetKeyDown(ability4Key))
                character.Ability4();
        }
    }
}