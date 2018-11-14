using System;

namespace StoreHelper.Domain.Model.Wholesale
{
    public sealed class Ingredient : DomainHelper.IEntity<Ingredient>
    {

        #region variable

        private readonly IngredientId _id;
        private string _name;
        private readonly WholesalerId _wholesalerId;
        private PurchaseAmount _purchaseAmount;
        private readonly YearlySet<IngredientMonthlyProperty> _monthlyProperyYearlySet;

        #endregion

        #region property

        #endregion

        #region constructor

        private Ingredient(IngredientId id, string name, WholesalerId wholesalerId, decimal price, PurchaseAmount purchaseAmount)
        {
            this._id = id ?? throw new ArgumentNullException(nameof(id));
            this._name = name ?? throw new ArgumentNullException(nameof(name));
            this._wholesalerId = wholesalerId ?? throw new ArgumentNullException(nameof(wholesalerId));
            this._purchaseAmount = purchaseAmount ?? throw new ArgumentNullException(nameof(purchaseAmount));
            this._monthlyProperyYearlySet = new YearlySet<IngredientMonthlyProperty>();
        }

        #endregion

        #region factory

        public static Ingredient UseNewIngredient(string name, WholesalerId wholesalerId, decimal price, PurchaseAmount purchaseAmount)
        {
            return new Ingredient(IngredientIdRepository.NextIdentifier(), name, wholesalerId, price, purchaseAmount);
        }

        #endregion

        #region method

        public void ChangeName(string name)
        {
            this._name = name;
        }

        public void ChangePrice(decimal price, int month)
        {
            this._monthlyProperyYearlySet.Month(month).ChangePrice(price);
        }

        #endregion

        #region object method

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType()) return false;
            var other = (Ingredient)obj;
            return this._id.Equals(other._id) && this._name.Equals(other._name) && this._wholesalerId.Equals(other._wholesalerId);
        }

        public override int GetHashCode()
        {
            return this._id.GetHashCode() ^ this._name.GetHashCode() ^ this._wholesalerId.GetHashCode();
        }

        public bool SameIdentityAs(Ingredient other)
        {
            return this.Equals(other);
        }

        #endregion

    }
}
