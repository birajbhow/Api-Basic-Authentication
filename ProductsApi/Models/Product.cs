namespace ProductsApi.Models
{
    public class Product
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Colour { get; private set; }

        public Product(string name, string colour)
        {
            this.Name = name;
            this.Colour = colour;
        }
    }
}
