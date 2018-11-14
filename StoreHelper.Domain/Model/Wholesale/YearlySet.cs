using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary.Extension;

namespace StoreHelper.Domain.Model.Wholesale
{
    public sealed class YearlySet<TType> : DomainHelper.IValueObject<YearlySet<TType>>
    {

        #region variable

        private Dictionary<int, TType> _months;

        #endregion

        #region property

        #endregion

        #region constructor

        public YearlySet(TType init=default(TType))
        {
            this._months = Enumerable.Range(1, 12).ToDictionary(x => x, _ => init);
        }

        #endregion

        #region method

        public TType Month(int month)
        {
            if (!this._months.ContainsKey(month)) throw new InvalidOperationException("assigned month need to be between 1 and 12");
            return this._months[month];
        }

        #endregion

        #region object method

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType()) return false;
            var other = (YearlySet<TType>)obj;
            return this._months.Equals(other._months);
        }

        public override int GetHashCode()
        {
            return this._months.GetHashCode();
        }

        public bool SameValueAs(YearlySet<TType> other)
        {
            return this.Equals(other);
        }

        #endregion

    }
}
