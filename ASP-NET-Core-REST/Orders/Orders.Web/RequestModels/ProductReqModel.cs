namespace Orders.Web.RequestModels
{
    public class ProductReqModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}