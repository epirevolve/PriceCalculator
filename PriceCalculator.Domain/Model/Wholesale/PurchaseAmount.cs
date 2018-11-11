namespace PriceCalculator.Domain.Model.Wholesale
{
    public enum AmountUnit
    {
        Gram,
        Litter,
        Item
    }

    public sealed class PurchaseAmount : DomainHelper.IValueObject<PurchaseAmount>
    {

        #region variable

        private readonly double _digit;
        private readonly AmountUnit _amountUnit;

        #endregion

        #region property

        #endregion

        #region constructor

        public PurchaseAmount(double digit, AmountUnit amountUnit)
        {
            this._digit = digit;
            this._amountUnit = amountUnit;
        }

        #endregion

        #region method

        #endregion

        #region object method

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType()) return false;
            var other = (PurchaseAmount)obj;
            return this._digit == other._digit && this._amountUnit == other._amountUnit;
        }

        public override int GetHashCode()
        {
            return this._digit.GetHashCode() ^ this._amountUnit.GetHashCode();
        }

        public bool SameValueAs(PurchaseAmount other)
        {
            return this.Equals(other);
        }

        #endregion

    }
}
