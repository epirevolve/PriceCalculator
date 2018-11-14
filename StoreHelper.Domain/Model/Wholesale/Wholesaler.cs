using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreHelper.Domain.Model.Wholesale
{
    public enum WholesalerQuality
    {
        VeryGood,
        Good,
        Normal,
        Poor,
        VeryPoor
    }

    public sealed class Wholesaler : DomainHelper.IEntity<Wholesaler>
    {

        #region variable

        private readonly WholesalerId _id;
        private string _name;
        private string _personInCharge;
        private string _contact;
        private readonly IList<IngredientId> _goods;
        private WholesalerQuality _wholesalerQuality;

        #endregion

        #region property

        #endregion

        #region constructor

        private Wholesaler(WholesalerId id, string name, string personInCharge, string contact, IList<IngredientId> goods)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("wholesaler name is required", nameof(name));
            }

            this._id = id ?? throw new ArgumentNullException(nameof(id));
            this._name = name;
            this._personInCharge = personInCharge;
            this._contact = contact;
            this._goods = goods ?? new List<IngredientId>();
        }

        #endregion

        #region factory

        #endregion

        #region method

        #endregion

        #region object method

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType()) return false;
            var other = (Wholesaler)obj;
            return this._id.Equals(other._id) && this._name.Equals(other._name) && this._personInCharge.Equals(other._personInCharge) && this._contact.Equals(other._contact)
                && this._goods.Count == other._goods.Count && this._goods.All(x => other._goods.Contains(x));
        }

        public override int GetHashCode()
        {
            return this._id.GetHashCode() ^ this._name.GetHashCode() ^ this._personInCharge.GetHashCode() ^ this._contact.GetHashCode()
                ^ this._goods.Select(x => x.GetHashCode()).Aggregate((x, y) => x ^ y);
        }

        public bool SameIdentityAs(Wholesaler other)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
