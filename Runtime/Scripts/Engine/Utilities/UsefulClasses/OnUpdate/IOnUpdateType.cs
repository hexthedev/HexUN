namespace Hex.UN.Runtime.Engine.Utilities.UsefulClasses.OnUpdate
{
    /// <summary>
    /// This type can be created as an update variable to track changes
    /// </summary>
    public interface IOnUpdateType<T>
    {
        OnUpdateVariable<T> AsUpdateVariable();
    }
}
