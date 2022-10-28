namespace RepoUoW.Entities
{
    public class City : BaseEntity<long>
    {
        public string Name { get; init; } = default!;
        public virtual Country Country { get; set; } = default!;
    }
}
