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
    public class ManageCardsPresenter
    {
        private IManageCardsPresenter _view;
        private WCCModel _model;

        public ManageCardsPresenter(WCCModel model, IManageCardsPresenter view)
        {
            this._view = view;
            this._model = model;

            this._view._presenter = this;
        }

        public ResponseRegisterCard RegisterCard(RequestRegisterCard card)
        {
            return _model.RegisterCard(card);
        }
    }
}
