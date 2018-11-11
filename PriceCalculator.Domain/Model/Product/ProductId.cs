using System;

namespace PriceCalculator.Domain.Model.Product
{
    public sealed class ProductId : DomainHelper.IValueObject<ProductId>
    {

        #region variable

        private string _id;

        #endregion

        #region property

        public string IdString { get => this._id; }

        #endregion

        #region constructor

        public ProductId(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException("id");

            this._id = id;
        }

        #endregion

        #region method

        #endregion

        #region object method

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType()) return false;
            var other = (ProductId)obj;
            return this._id.Equals(other._id);
        }

        public override int GetHashCode()
        {
            return this._id.GetHashCode();
        }

        public bool SameValueAs(ProductId other)
        {
            return other != null && this._id.Equals(other._id);
        }

        #endregion

    }
}
