namespace DDDTW.SharedModules.BaseClasses
{
    public abstract class ValueObject<T> : PropertyComparer<T>
        where T : ValueObject<T>
    {
    }
}