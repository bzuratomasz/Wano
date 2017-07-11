using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanoControlCenter.Model;
using WanoControlCenter.View.Interfaces;
using WanoControlContracts.DataContracts.RegisterCard;

namespace WanoControlCenter.Presenter
{
    public class WCCSupervisorPresenter
    {
        private IWCCSupervisorPresenter _view;
        private WCCModel _model;

        public WCCSupervisorPresenter(WCCModel model, IWCCSupervisorPresenter view)
        {
            this._view = view;
            this._model = model;

            this._view._presenter = this;
        }

        public List<RequestRegisterCard> GetCards()
        {
            return _model.GetCards();
        }
    }
}
