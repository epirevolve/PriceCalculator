using System;

namespace PriceCalculator.Domain.Model.Product
{
    public sealed class SalesPeriod : DomainHelper.IValueObject<SalesPeriod>
    {

        #region variable

        readonly MonthAndDay _from;
        readonly MonthAndDay _till;

        #endregion

        #region property

        public MonthAndDay From => this._from;
        public MonthAndDay Till => this._till;

        #endregion

        #region constructor

        private SalesPeriod(MonthAndDay from, MonthAndDay till)
        {
            this._from = from;
            this._till = till;
        }

        #endregion

        #region factory

        public static SalesPeriod SellInLimitedTime(int fromMonth, int fromDay, int tillMonth, int tillDay)
        {
            return new SalesPeriod(new MonthAndDay(fromMonth, fromDay), new MonthAndDay(tillMonth, tillDay));
        }

        public static SalesPeriod SellYearRound()
        {
            return new SalesPeriod(new MonthAndDay(1, 1), new MonthAndDay(12, 31));
        }

        public SalesPeriod StartSellingEarlier(int month, int day)
        {
            return new SalesPeriod(new MonthAndDay(month, day), this._till);
        }

        public SalesPeriod PostponeTheEndOfSelling(int month, int day)
        {
            return new SalesPeriod(this._from, new MonthAndDay(month, day));
        }

        #endregion

        #region method

        public bool IsInLimitedTime()
        {
            return this._from.IsEarlierThan(DateTime.Now.Date.Month, DateTime.Now.Date.Day)
                && (this._till.IsLaterThan(DateTime.Now.Date.Month, DateTime.Now.Date.Day) || this._till.IsEarlierThan(this._from.Month, this._from.Day));
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
            return other != null && this._from == other._from && this._till == other._till;
        }

        #endregion
    }
}
