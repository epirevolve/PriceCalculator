namespace PriceCalculator.Domain.Model.Wholesale
{
    class WholesalerIdRepository : DomainHelper.GuidRepository
    {
        internal static WholesalerId NextIdentifier()
        {
            return new WholesalerId(NextIdentifier("whsl"));
        }
    }
}
