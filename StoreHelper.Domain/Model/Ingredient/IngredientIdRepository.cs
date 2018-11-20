namespace StoreHelper.Domain.Model.Ingredient
{
    class IngredientIdRepository : DomainHelper.GuidRepository
    {
        internal static IngredientId NextIdentifier()
        {
            return new IngredientId(NextIdentifier("good"));
        }
    }
}
