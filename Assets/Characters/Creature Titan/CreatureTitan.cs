namespace MOBA
{
    public class CreatureTitan : CharacterBase
    {
        protected override void StartMoving()
        {
            base.StartMoving();

            animator.SetBool("Walk", true);
        }

        protected override void StopMoving()
        {
            base.StopMoving();

            animator.SetBool("Walk", false);
        }
    }
}