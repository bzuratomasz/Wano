﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanoControlCenter.Model;
using WanoControlCenter.View.Interfaces;
using WanoControlContracts.DataContracts.ControllerConfigure;

namespace WanoControlCenter.Presenter
{
    public class WCCConfigurationPresenter
    {
        private IWCCConfigurationPresenter _view;
        private WCCModel _model;

        public WCCConfigurationPresenter(WCCModel model, IWCCConfigurationPresenter view)
        {
            this._view = view;
            this._model = model;

            this._view._presenter = this;
        }

        public void Register(RequestControllerConfigure conf) 
        {
            _model.Register(conf);
        }
    }
}
