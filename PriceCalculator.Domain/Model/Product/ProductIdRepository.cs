namespace PriceCalculator.Domain.Model.Product
{
    class ProductIdRepository : DomainHelper.GuidRepository
    {
        internal static ProductId NextIdentifier()
        {
            return new ProductId(NextIdentifier("prct"));
        }
    }
}
