using System;
using System.Collections.Generic;

namespace PriceCalculator.Domain.Model.Product
{
    public sealed class Product : DomainHelper.IEntity<Product>
    {

        #region variable

        private readonly ProductId _id;
        private string _name;
        private SalesPeriod _salesPeriod;
        private readonly Dictionary<Wholesale.GoodsId, int> _recipe;

        #endregion

        #region property

        #endregion

        #region constructor

        private Product(ProductId id, string name, SalesPeriod salesPeriod, Dictionary<Wholesale.GoodsId, int> recipe)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            this._id = id ?? throw new ArgumentNullException(nameof(id));
            this._name = name;
            this._salesPeriod = salesPeriod ?? throw new ArgumentNullException(nameof(salesPeriod));
            this._recipe = recipe ?? new Dictionary<Wholesale.GoodsId, int>();
        }

        #endregion

        #region factory

        public static Product CreateANewProduct(string name, SalesPeriod salesPeriod, Dictionary<Wholesale.GoodsId, int> recipe)
        {
            return new Product(ProductRepository.NextIdentifier(), name, salesPeriod, recipe);
        }

        #endregion

        #region method

        public void SellInLimitedTime(int fromMonth, int fromDay, int tillMonth, int tillDay)
        {
            this._salesPeriod = this._salesPeriod.SellInLimitedTime(fromMonth, fromDay, tillMonth, tillDay);
        }

        public void SellYearRound()
        {
            this._salesPeriod = this._salesPeriod.SellYearRound();
        }

        public void StartSellingEarlier(int month, int day)
        {
            this._salesPeriod = this._salesPeriod.StartSellingEarlier(month, day);
        }

        public void PostponeTheEndOfSelling(int month, int day)
        {
            this._salesPeriod = this._salesPeriod.PostponeTheEndOfSelling(month, day);
        }

        public void UseAsIngradient(Wholesale.GoodsId ingredient, int amount)
        {
            this._recipe.Add(ingredient, amount);
        }

        public void StopUsingIngradient(Wholesale.GoodsId ingredient)
        {
            this._recipe.Remove(ingredient);
        }

        public void ChangeAmountOfIngradient(Wholesale.GoodsId ingredient, int amount)
        {
            this._recipe[ingredient] = amount;
        }

        #endregion

        #region object method

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType()) return false;
            var other = (Product)obj;
            return this._id.Equals(other._id) && this._name.Equals(other._name) && this._salesPeriod.Equals(other._salesPeriod);
        }

        public override int GetHashCode()
        {
            return this._id.GetHashCode() ^ this._name.GetHashCode() ^ this._salesPeriod?.GetHashCode() ?? 0;
        }

        public bool SameIdentityAs(Product other)
        {
            return other != null && this._id.SameValueAs(other._id);
        }

        #endregion

    }
}
