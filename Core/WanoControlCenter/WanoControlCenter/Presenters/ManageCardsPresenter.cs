using WanoControlCenter.Models;
using WanoControlContracts.DataContracts.RegisterCard;
using WanoControlCenter.Interfaces.Presenters;

namespace WanoControlCenter.Presenters
{
    public class ManageCardsPresenter
    {
        private IManageCardsPresenter _view;
        private ServiceModel _model;

        public ManageCardsPresenter(ServiceModel model, IManageCardsPresenter view)
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
