namespace PriceCalculator.Domain.Model.Wholesale
{
    class GoodsIdRepository : DomainHelper.GuidRepository
    {
        internal static GoodsId NextIdentifier()
        {
            return new GoodsId(NextIdentifier("good"));
        }
    }
}
