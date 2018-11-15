using System;

namespace StoreHelper.Domain.Model.Product
{
    public sealed class SalesPeriod : DomainHelper.IValueObject<SalesPeriod>
    {

        #region variable

        readonly RoughDate _from;
        readonly RoughDate _till;

        #endregion

        #region property

        public RoughDate From => this._from;
        public RoughDate Till => this._till;

        #endregion

        #region constructor

        private SalesPeriod(RoughDate from, RoughDate till)
        {
            this._from = from;
            this._till = till;
        }

        #endregion

        #region factory

        public static SalesPeriod SellInLimitedTime(int fromMonth, RoughDay fromDay, int tillMonth, RoughDay tillDay)
        {
            return new SalesPeriod(new RoughDate(fromMonth, fromDay), new RoughDate(tillMonth, tillDay));
        }

        public static SalesPeriod SellYearRound()
        {
            return new SalesPeriod(new RoughDate(1, RoughDay.beginning), new RoughDate(12, RoughDay.end));
        }

        public SalesPeriod StartSellingEarlier(int month, RoughDay day)
        {
            return new SalesPeriod(new RoughDate(month, day), this._till);
        }

        public SalesPeriod PostponeTheEndOfSelling(int month, RoughDay day)
        {
            return new SalesPeriod(this._from, new RoughDate(month, day));
        }

        #endregion

        #region method

        public bool IsInLimitedTime()
        {
            return this._from.IsEarlierThan(DateTime.Now.Date.Month, DateTime.Now.Date.Day)
                && (this._till.IsLaterThan(DateTime.Now.Date.Month, DateTime.Now.Date.Day) || this._till.IsEarlierThan(this._from.Month, this._from.RoughDay));
        }

        #endregion

        #region object method

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType()) return false;
            var other = (SalesPeriod)obj;
            return this._from == other._from && this._till == other._till;
        }

        public override int GetHashCode()
        {
            return this._from.GetHashCode() ^ this._till.GetHashCode();
        }

        public bool SameValueAs(SalesPeriod other)
        {
            return other != null && this._from.SameValueAs(other._from) && this._till.SameValueAs(other._till);
        }

        #endregion
    }
}
