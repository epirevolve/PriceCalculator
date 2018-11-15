using System.Linq;

namespace StoreHelper.Domain.Model.Product
{
    public enum RoughDay
    {
        beginning,
        middle,
        end
    }

    public sealed class RoughDate : DomainHelper.IValueObject<RoughDate>
    {

        #region variable

        private readonly int _month;
        private readonly RoughDay _roughDay;

        #endregion

        #region property

        public int Month => _month;
        public RoughDay RoughDay => _roughDay;

        #endregion

        #region constructor

        public RoughDate(int month, RoughDay roughDay)
        {
            this._month = month;
            this._roughDay = roughDay;
        }

        #endregion

        #region method

        RoughDay DayToRoughDay(int day)
        {
            return Enumerable.Range(1, 10).Contains(day) ? RoughDay.beginning :
                Enumerable.Range(11, 20).Contains(day) ? RoughDay.middle :
                RoughDay.end;
        }

        public bool IsEarlierThan(int month, RoughDay roughDay)
        {
            return this._month < month || this._month == month && this._roughDay <= roughDay;
        }
        public bool IsEarlierThan(int month, int day)
        {
            return this.IsEarlierThan(month, this.DayToRoughDay(day));
        }

        public bool IsLaterThan(int month, RoughDay roughDay)
        {
            return this._month > month || this._month == month && this._roughDay >= roughDay;
        }
        public bool IsLaterThan(int month, int day)
        {
            return this.IsLaterThan(month, this.DayToRoughDay(day));
        }

        #endregion

        #region object method

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType()) return false;
            var other = (RoughDate)obj;
            return this._month == other._month && this._roughDay == other._roughDay;
        }

        public override int GetHashCode()
        {
            return this._month.GetHashCode() ^ this._roughDay.GetHashCode();
        }

        public bool SameValueAs(RoughDate other)
        {
            return other != null && this._month == other._month && this._roughDay == other._roughDay;
        }

        #endregion

    }
}
