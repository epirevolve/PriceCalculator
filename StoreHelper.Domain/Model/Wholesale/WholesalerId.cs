using System;

namespace StoreHelper.Domain.Model.Wholesale
{
    public sealed class WholesalerId : DomainHelper.IValueObject<WholesalerId>
    {

        #region variable

        private string _id;

        #endregion

        #region property

        public string IdString { get => this._id; }

        #endregion

        #region constructor

        public WholesalerId(string id)
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
            var other = (WholesalerId)obj;
            return this._id.Equals(other._id);
        }

        public override int GetHashCode()
        {
            return this._id.GetHashCode();
        }

        public bool SameValueAs(WholesalerId other)
        {
            return other != null && this._id.Equals(other._id);
        }

        #endregion

    }
}
