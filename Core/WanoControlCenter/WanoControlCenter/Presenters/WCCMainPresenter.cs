using WanoControlCenter.Models;
using WanoControlCenter.Interfaces.Presenters;

namespace WanoControlCenter.Presenters
{
    public class WCCMainPresenter
    {
        private IWCCMainPresenter _view;
        private ServiceModel _model;

        public WCCMainPresenter(ServiceModel model, IWCCMainPresenter view)
        {
            this._view = view;
            this._model = model;

            this._view._presenter = this;
        }
    }
}
