
namespace Sunday.Core.Entities.Namable
{
    public interface INamableEntity<T> : IEntity<T>
        where T : class
    {
        string Name { get; set; }
    }
}
