namespace DesignPatterns.Patterns;
    
// Głównym celem wzorca Builder jest oddzielenie procesu konstrukcji obiektu od jego reprezentacji.
// Pozwala to na produkcję różnych typów i reprezentacji obiektów, używając tego samego kodu konstrukcyjnego.
// Budowniczy z kierownikiem różni się tylko dodatkową klasą kierownika. 
// Konstruujemy produkt poprzez przekazanie odpowiedniego kierownika do budowniczego,
// który ustali kolejność wywoływanych instrukcji.  

public static class BuilderExtended
{
    public class Product
    {
        public string Columns { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return $"{Author} - {Title}: {Columns}";
        }
    }

    public interface IBuilder
    {
        IBuilder BuildColumns();
        IBuilder BuildAuthor();
        IBuilder BuildTitle();
        Product GetProduct();
    }

    public class ConcreteBuilder : IBuilder
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
    
    public class Director
    {
        public Product Construct(IBuilder builder)
        {
            return builder
                .BuildAuthor()
                .BuildTitle()
                .BuildColumns()
                .GetProduct();
        }
    }

    public static class PatternProgram
    {
        public static void Call()
        {
            var director = new Director();
            var builder = new ConcreteBuilder();
            var product = director.Construct(builder);
            
            Console.WriteLine(product.ToString());
        }
    }
}
