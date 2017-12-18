namespace Data.Interface
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
    }
}
