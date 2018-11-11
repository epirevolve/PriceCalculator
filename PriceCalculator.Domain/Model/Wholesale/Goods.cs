using System;

namespace PriceCalculator.Domain.Model.Wholesale
{
    public sealed class Goods : DomainHelper.IEntity<Goods>
    {

        #region variable

        private readonly GoodsId _id;
        private string _name;
        private readonly WholesalerId _wholesalerId;
        private decimal _price;
        private PurchaseAmount _purchaseAmount;

        #endregion

        #region property

        #endregion

        #region constructor

        private Goods(GoodsId id, string name, WholesalerId wholesalerId, decimal price, PurchaseAmount purchaseAmount)
        {
            this._id = id ?? throw new ArgumentNullException(nameof(id));
            this._name = name ?? throw new ArgumentNullException(nameof(name));
            this._wholesalerId = wholesalerId ?? throw new ArgumentNullException(nameof(wholesalerId));
            this._price = price;
            this._purchaseAmount = purchaseAmount ?? throw new ArgumentNullException(nameof(purchaseAmount));
        }

        #endregion

        #region factory

        public static Goods TreatNewGoods(string name, WholesalerId wholesalerId, decimal price, PurchaseAmount purchaseAmount)
        {
            return new Goods(GoodsIdRepository.NextIdentifier(), name, wholesalerId, price, purchaseAmount);
        }

        #endregion

        #region method

        public void ChangeName(string name)
        {
            this._name = name;
        }

        public void ChangePrice(decimal price)
        {
            this._price = price;
        }

        #endregion

        #region object method

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType()) return false;
            var other = (Goods)obj;
            return this._id.Equals(other._id) && this._name.Equals(other._name) && this._wholesalerId.Equals(other._wholesalerId);
        }

        public override int GetHashCode()
        {
            return this._id.GetHashCode() ^ this._name.GetHashCode() ^ this._wholesalerId.GetHashCode();
        }

        public bool SameIdentityAs(Goods other)
        {
            return this.Equals(other);
        }

        #endregion
    }
}
