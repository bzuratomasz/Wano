﻿using WanoControlCenter.Model;
using WanoControlCenter.View.Interfaces;

namespace WanoControlCenter.Presenter
{
    public class WCCMainPresenter
    {
        private IWCCMainPresenter _view;
        private WCCModel _model;

        public WCCMainPresenter(WCCModel model, IWCCMainPresenter view)
        {
            this._view = view;
            this._model = model;

            this._view._presenter = this;
        }
    }
}
