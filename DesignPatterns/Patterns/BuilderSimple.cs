namespace DesignPatterns.Patterns;
  
// Głównym celem wzorca Builder jest oddzielenie procesu konstrukcji obiektu od jego reprezentacji.
// Pozwala to na produkcję różnych typów i reprezentacji obiektów, używając tego samego kodu konstrukcyjnego.

public static class BuilderSimple
{
    private class Product
    {
        public string Columns { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return $"{Author} - {Title}: {Columns}";
        }
    }

    private interface IBuilder
    {
        IBuilder BuildColumns();
        IBuilder BuildAuthor();
        IBuilder BuildTitle();
        Product GetProduct();
    }

    private class ConcreteBuilder : IBuilder
    {
        private readonly Product _product = new();

        public IBuilder BuildColumns()
        {
            _product.Columns = "BuildColumns";
            return this;
        }

        public IBuilder BuildTitle()
        {
            _product.Title = "BuildTitle";
            return this;
        }

        public IBuilder BuildAuthor()
        {
            _product.Author = "BuildAuthor";
            return this;
        }

        public Product GetProduct() => _product;
    }

    public static class PatternProgram
    {
        public static void Call()
        {
            var builder = new ConcreteBuilder();
            var product = builder
                .BuildAuthor()
                .BuildTitle()
                .BuildColumns()
                .GetProduct();
            
            Console.WriteLine(product.ToString());
        }
    }
}
