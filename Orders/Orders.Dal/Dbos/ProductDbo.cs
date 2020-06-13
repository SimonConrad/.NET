namespace Orders.Dal.Dbos
{
    public class ProductDbo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}