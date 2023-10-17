using Pathfinding;
using System;

namespace MOBA
{
    public class AIPathExtended : AIPath
    {
        public event Action OnTargetReachedEvent;

        /// <summary>
        /// Called whenever movement starts after not moving.
        /// </summary>
        public event Action OnStartMovingEvent;

        private bool isMoving = false;

        protected override void Update()
        {
            base.Update();

            if (reachedEndOfPath && isMoving)
            {
                OnTargetReachedEvent?.Invoke();
                isMoving = false;
            }
            else if (!reachedEndOfPath && !isMoving)
            {
                OnStartMovingEvent?.Invoke();
                isMoving = true;
            }
        }
    }
}