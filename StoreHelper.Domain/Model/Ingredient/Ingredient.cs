using System;

namespace StoreHelper.Domain.Model.Ingredient
{
    public sealed class Ingredient : DomainHelper.IEntity<Ingredient>
    {

        #region variable

        private readonly IngredientId _id;
        private string _name;
        private readonly YearlySet<IngredientMonthlyProperty> _monthlyProperyYearlySet;

        #endregion

        #region property

        #endregion

        #region constructor

        private Ingredient(IngredientId id, string name, decimal price)
        {
            this._id = id ?? throw new ArgumentNullException(nameof(id));
            this._name = name ?? throw new ArgumentNullException(nameof(name));
            this._monthlyProperyYearlySet = new YearlySet<IngredientMonthlyProperty>();
        }

        #endregion

        #region factory

        public static Ingredient UseNewIngredient(string name, decimal price)
        {
            return new Ingredient(IngredientIdRepository.NextIdentifier(), name, price);
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
            return this._id.Equals(other._id) && this._name.Equals(other._name) && this._monthlyProperyYearlySet.Equals(other._monthlyProperyYearlySet);
        }

        public override int GetHashCode()
        {
            return this._id.GetHashCode() ^ this._name.GetHashCode() ^ this._monthlyProperyYearlySet.GetHashCode();
        }

        public bool SameIdentityAs(Ingredient other)
        {
            return this.Equals(other);
        }

        #endregion

    }
}
