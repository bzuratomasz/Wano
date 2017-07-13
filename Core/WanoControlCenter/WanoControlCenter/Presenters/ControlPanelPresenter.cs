using System.Collections.Generic;
using WanoControlCenter.Interfaces.Presenters;
using WanoControlCenter.Models;
using WanoControlCenter.Views;
using WanoControlContracts.DataContracts.RegisterCard;

namespace WanoControlCenter.Presenters
{
    public class ControlPanelPresenter
    {
        private IControlPanelPresenter _view;
        private ServiceModel _model;
        private ControlPanelUiModel _ui;

        public ControlPanelPresenter(ServiceModel model, ControlPanelUiModel _ui, IControlPanelPresenter view)
        {
            this._view = view;
            this._model = model;
            this._ui = _ui;

            this._view._presenter = this;
        }

        public List<RequestRegisterCard> GetCards()
        {
            return _model.GetCards();
        }

        public ManageCards GetManageCards() 
        {
            return _ui.GetManageCards();
        }
    }
}
