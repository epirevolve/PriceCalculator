namespace PriceCalculator.Domain.Model.Product
{
    class ProductRepository : DomainHelper.GuidRepository
    {
        internal static ProductId NextIdentifier()
        {
            return new ProductId(NextIdentifier("prct"));
        }
    }
}
