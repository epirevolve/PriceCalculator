namespace PriceCalculator.Domain.Model.Product
{
    public sealed class MonthAndDate : DomainHelper.IValueObject<MonthAndDate>
    {

        #region variable

        private readonly int _month;
        private readonly int _day;

        #endregion

        #region property

        public int Month => _month;
        public int Day => _day;

        #endregion

        #region constructor

        public MonthAndDate(int month, int day)
        {
            this._month = month;
            this._day = day;
        }

        #endregion

        #region method

        public bool IsEarlierThan(int month, int day)
        {
            return this._month < month || this._month == month && this._day <= day;
        }

        public bool IsLaterThan(int month, int day)
        {
            return this._month > month || this._month == month && this._day >= day;
        }

        #endregion

        #region object method

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType()) return false;
            var other = (MonthAndDate)obj;
            return this._month == other._month && this._day == other._day;
        }

        public override int GetHashCode()
        {
            return this._month.GetHashCode() ^ this._day.GetHashCode();
        }

        public bool SameValueAs(MonthAndDate other)
        {
            return other != null && this._month == other._month && this._day == other._day;
        }

        #endregion

    }
}
