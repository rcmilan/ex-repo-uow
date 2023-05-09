namespace RepoUoW.Entities
{
    public class City : BaseEntity<long>
    {
        public string Name { get; init; } = default!;
    }
}