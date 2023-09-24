namespace TDS.Game.EnemyScripts
{
    public abstract class EnemyDefaultBehaviour : EnemyComponents
    {
        #region Unity lifecycle

        private void Awake()
        {
            Activate();
        }

        #endregion
    }
}