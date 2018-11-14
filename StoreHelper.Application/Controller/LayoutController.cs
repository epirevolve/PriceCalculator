using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using WpfLibrary.ApplicationHelper.Messenger;

namespace StoreHelper.Application.Controller
{
    sealed class LayoutController : WpfLibrary.ApplicationHelper.Controller.BaseController
    {
        #region variable

        #endregion

        #region viewmodel

        #endregion

        #region eventhandler

        public ReactiveCommand ShowProductListEventHandler { get; private set; }
        public ReactiveCommand RegisterProductEventHandler { get; private set; }

        #endregion

        #region constructor

        public LayoutController()
        {
            #region set event handler

            this.ShowProductListEventHandler = new ReactiveCommand().AddTo(this.CompositeDisposable);
            this.ShowProductListEventHandler.Subscribe(this.ShowProductList);
            this.RegisterProductEventHandler = new ReactiveCommand().AddTo(this.CompositeDisposable);
            this.RegisterProductEventHandler.Subscribe(this.RegisterProduct);

            #endregion

        }

        #endregion

        #region event

        private void ShowProductList()
        {
            this.Messenger.Raise(new TransitionMessage(new Domain.Product.ProductListController(), "ShowProductList"));
        }

        private void RegisterProduct()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
