using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary.ApplicationHelper.Controller;

namespace StoreSupportTool.Application.Controller.Domain.Product
{
    sealed class IngredientViewModel
    {

    }

    sealed class ProductRegisterController : BaseController
    {

        #region variable

        #endregion

        #region property

        public ReactiveProperty<string> Name { get; private set; }
        public ICollection<IngredientViewModel> Ingredients { get; private set; }
        public ReactiveProperty<double> CostRate { get; private set; }
        public ReactiveProperty<decimal> Price { get; private set; }

        #endregion

        #region constructor

        #endregion

        #region method

        #endregion

        #region object method

        #endregion

    }
}
