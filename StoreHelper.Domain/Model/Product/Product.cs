using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreHelper.Domain.Model.Product
{
    public sealed class Product : DomainHelper.IEntity<Product>
    {

        #region class

        public sealed class Description
        {
            public string Id { get; }
            public string Name { get; }
            public double CostRate { get; }
            public decimal Price { get; }
            public Dictionary<string, int> IngredientsTable { get; }
            public bool IsSellingYearRound{ get; }
            public int SellingFromMonth { get; }
            public int SellingFromDay { get; }
            public int SellingTillMonth { get; }
            public int SellingTillDay { get; }

            public Description(Product product)
            {
                this.Id = product._id.IdString;
                this.Name = product._name;
                this.CostRate = product._costRate;
                this.Price = product._price;
                this.IngredientsTable = product._ingredientsTable.ToDictionary(x => x.Key.IdString, x => x.Value);
                this.IsSellingYearRound = SalesPeriod.SellYearRound().SameValueAs(product._salesPeriod);
                this.SellingFromMonth = product._salesPeriod.From.Month;
                this.SellingFromDay = product._salesPeriod.From.Day;
                this.SellingTillMonth = product._salesPeriod.Till.Month;
                this.SellingTillDay = product._salesPeriod.Till.Day;
            }
        }

        #endregion

        #region variable

        private readonly ProductId _id;
        private string _name;
        private double _costRate;
        private decimal _price;
        private readonly Dictionary<Wholesale.IngredientId, int> _ingredientsTable;
        private SalesPeriod _salesPeriod;

        #endregion

        #region property

        #endregion

        #region constructor

        private Product(ProductId id, string name, SalesPeriod salesPeriod,
            Dictionary<Wholesale.IngredientId, int> recipe, double costRate)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            this._id = id ?? throw new ArgumentNullException(nameof(id));
            this._name = name;
            this._salesPeriod = salesPeriod ?? throw new ArgumentNullException(nameof(salesPeriod));
            this._ingredientsTable = recipe ?? new Dictionary<Wholesale.IngredientId, int>();
            this._costRate = costRate;

            this.CalculatePrice();
        }

        #endregion

        #region factory

        public static Product CreateANewProduct(string name, SalesPeriod salesPeriod,
            Dictionary<Wholesale.IngredientId, int> recipe, double costRate)
        {
            return new Product(ProductIdRepository.NextIdentifier(), name, salesPeriod, recipe, costRate);
        }

        public Description Describe()
        {
            return new Description(this);
        }

        #endregion

        #region method

        public void SellInLimitedTime(int fromMonth, int fromDay, int tillMonth, int tillDay)
        {
            this._salesPeriod = SalesPeriod.SellInLimitedTime(fromMonth, fromDay, tillMonth, tillDay);
        }

        public void SellYearRound()
        {
            this._salesPeriod = SalesPeriod.SellYearRound();
        }

        public void StartSellingEarlier(int month, int day)
        {
            this._salesPeriod = this._salesPeriod.StartSellingEarlier(month, day);
        }

        public void PostponeTheEndOfSelling(int month, int day)
        {
            this._salesPeriod = this._salesPeriod.PostponeTheEndOfSelling(month, day);
        }

        public void UseAsIngradient(Wholesale.IngredientId ingredient, int amount)
        {
            this._ingredientsTable.Add(ingredient, amount);
        }

        public void StopUsingIngradient(Wholesale.IngredientId ingredient)
        {
            this._ingredientsTable.Remove(ingredient);
        }

        public void ChangeAmountOfIngradient(Wholesale.IngredientId ingredient, int amount)
        {
            this._ingredientsTable[ingredient] = amount;
        }

        public void CalculatePrice()
        {
            this._price = 0;
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
