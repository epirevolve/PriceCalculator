using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHelper.Domain.Model.Ingredient
{
    public enum IngredientQuality
    {
        VeryGood,
        Good,
        Normal,
        Poor,
        VeryPoor
    }
    public enum PurchaseAvailability
    {
        Always,
        Almost,
        Rare,
        OneTime
    }
    public enum PurchasePriority
    {
        High,
        Normal,
        Low
    }

    public sealed class IngredientMonthlyProperty : DomainHelper.IValueObject<IngredientMonthlyProperty>
    {

        #region variable

        private decimal _price;
        private IngredientQuality _ingredientQuality;
        private PurchaseAvailability _purchaseAvailability;
        private PurchasePriority _purchasePriority;

        #endregion

        #region property

        #endregion

        #region constructor

        #endregion

        #region method

        internal void ChangePrice(decimal price)
        {
            this._price = price;
        }

        #endregion

        #region object method

        public bool SameValueAs(IngredientMonthlyProperty other)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
