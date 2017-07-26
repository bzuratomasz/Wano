using WanoControlCenter.Models;
using WanoControlContracts.DataContracts.ControllerConfigure;
using WanoControlCenter.Interfaces.Presenters;

namespace WanoControlCenter.Presenters
{
    public class WCCConfigurationPresenter
    {
        private IWCCConfigurationPresenter _view;
        private ServiceModel _model;

        public WCCConfigurationPresenter(ServiceModel model, IWCCConfigurationPresenter view)
        {
            this._view = view;
            this._model = model;

            this._view._presenter = this;
        }

        public void Register(RequestControllerConfigure conf) 
        {
            _model.Register(conf);
        }

        public ResponseControllerConfigure GetController()
        {
            return _model.GetController();
        }
    }
}
