namespace RepoUoW.Entities
{
    public class Country : BaseEntity<int>
    {
        public string Name { get; init; } = default!;
    }
}