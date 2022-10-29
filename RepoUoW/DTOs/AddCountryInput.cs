namespace RepoUoW.DTOs
{
    public class AddCountryInput
    {
        public string Name { get; set; }
        public IList<AddCityInput> Cities { get; set; }
    }
}
