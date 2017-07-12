using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WanoControlCenter.Models;
using WanoControlCenter.Interfaces;
using WanoControlContracts.DataContracts.RegisterCard;
using WCCCommon.Models;

namespace WanoControlCenter.Presenters
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

        public bool UpdateCardsPermissions(List<List<Status>> permissions, int cardId)
        {
            return _model.UpdateCardsPermissions(permissions, cardId);
        }
    }
}
