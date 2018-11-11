using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using WpfLibrary.ApplicationHelper.Messenger;

namespace PriceCalculation.Application.Controller
{
    sealed class LoginController : WpfLibrary.ApplicationHelper.Controller.BaseController
    {
        #region variable

        #endregion

        #region viewmodel

        #endregion

        #region eventhandler

        public ReactiveCommand LoginEventHandler { get; private set; }

        #endregion

        #region constructor

        public LoginController()
        {
            this.LoginEventHandler = new ReactiveCommand().AddTo(this.CompositeDisposable);
            this.LoginEventHandler.Subscribe(this.Login);
        }

        #endregion

        #region event

        void Login()
        {
            this.Messenger.Raise(new TransitionMessage(new LayoutController(), TransitionMode.Normal, "ShowHome"));

            this.Close = true;
        }

        #endregion
    }
}
