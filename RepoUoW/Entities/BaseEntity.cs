namespace RepoUoW.Entities
{
    public abstract class BaseEntity
    {
    }

    public abstract class BaseEntity<TId> : BaseEntity
    {
        public TId Id { get; init; } = default!;
    }
}