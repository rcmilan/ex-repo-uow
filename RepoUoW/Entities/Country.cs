namespace RepoUoW.Entities
{
    public class Country : BaseEntity<int>
    {
        public string Name { get; init; } = default!;
        public virtual IList<City> Cities { get; set; } = default!;
    }
}