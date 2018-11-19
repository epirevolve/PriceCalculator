using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary.ApplicationHelper.Controller;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive.Linq;
using System.Collections.ObjectModel;
using StoreHelper.Domain.Model.Product;
using StoreHelper.Infrastructure.Repository;

namespace StoreHelper.Application.Controller.Domain.Product
{
    using StoreHelper.Domain.Model.Product;

    sealed class IngredientViewModel : BaseController
    {
        #region variable

        #endregion

        #region viewmodel

        public ReactiveProperty<string> Name { get; private set; }
        public ReactiveProperty<double> Amount { get; private set; }

        #endregion
    }

    sealed class ProductViewModel : BaseController
    {

        #region varibale

        private readonly string _productId;

        #endregion

        #region viewmodel

        public ReactiveProperty<string> Name { get; private set; }
        public ReactiveProperty<double> CostRate { get; private set; }
        public ReactiveProperty<decimal> Price { get; private set; }
        public ObservableCollection<IngredientViewModel> Ingredients { get; private set; }
        public ReactiveProperty<bool> IsSellingYearRound { get; private set; }
        public ReactiveProperty<int> SellingFromMonth { get; private set; }
        public ReactiveProperty<RoughDay> SellingFromDay { get; private set; }
        public ReactiveProperty<int> SellingTillMonth { get; private set; }
        public ReactiveProperty<RoughDay> SellingTillDay { get; private set; }

        #endregion

        #region constructor

        public ProductViewModel(Product.Description description)
        {
            this._productId = description.Id;
            this.Name = new ReactiveProperty<string>(description.Name).AddTo(this.CompositeDisposable);
            this.CostRate = new ReactiveProperty<double>(description.CostRate).AddTo(this.CompositeDisposable);
            this.Price = new ReactiveProperty<decimal>(description.Price).AddTo(this.CompositeDisposable);
            this.IsSellingYearRound = new ReactiveProperty<bool>(description.IsSellingYearRound).AddTo(this.CompositeDisposable);
            this.SellingFromMonth = new ReactiveProperty<int>(description.SellingFromMonth).AddTo(this.CompositeDisposable);
            this.SellingFromDay = new ReactiveProperty<RoughDay>(description.SellingFromDay).AddTo(this.CompositeDisposable);
            this.SellingTillMonth = new ReactiveProperty<int>(description.SellingTillMonth).AddTo(this.CompositeDisposable);
            this.SellingTillDay = new ReactiveProperty<RoughDay>(description.SellingTillDay).AddTo(this.CompositeDisposable);
        }

        #endregion

    }

    sealed class ProductListController : BaseController
    {

        #region variable

        #endregion

        #region viewmodel

        public ObservableCollection<ProductViewModel> Products { get; private set; }
        public ReactiveProperty<ProductViewModel> SelectedProduct { get; private set; }

        #endregion

        #region eventhandler

        #endregion

        #region constructor

        public ProductListController()
        {
            this.Products = new ObservableCollection<ProductViewModel>(
                from product in new ProductRepository().Products()
                select new ProductViewModel(product.Describe()));
            this.SelectedProduct = new ReactiveProperty<ProductViewModel>().AddTo(this.CompositeDisposable);
        }

        #endregion

        #region event

        #endregion

    }
}
