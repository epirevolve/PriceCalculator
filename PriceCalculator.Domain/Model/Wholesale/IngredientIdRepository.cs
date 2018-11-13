namespace PriceCalculator.Domain.Model.Wholesale
{
    class IngredientIdRepository : DomainHelper.GuidRepository
    {
        internal static IngredientId NextIdentifier()
        {
            return new IngredientId(NextIdentifier("good"));
        }
    }
}
