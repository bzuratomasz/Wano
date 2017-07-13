using System.Collections.Generic;
using System.Windows.Controls;
using WanoControlCenter.Models;
using WCCCommon.Models;
using WanoControlCenter.Models.Schemas;
using WanoControlCenter.Interfaces.Presenters;

namespace WanoControlCenter.Presenters
{
    public class WCCSupervisorPresenter
    {
        private IWCCSupervisorPresenter _view;
        private ServiceModel _model;
        private SupervisorUiModel _uimodel;

        public WCCSupervisorPresenter(ServiceModel model, SupervisorUiModel uimodel, IWCCSupervisorPresenter view)
        {
            this._view = view;
            this._model = model;
            this._uimodel = uimodel;

            this._view._presenter = this;
        }

        public bool UpdateCardsPermissions(List<List<Status>> permissions, int cardId)
        {
            return _model.UpdateCardsPermissions(permissions, cardId);
        }

        public void AddToContext(ControlEntity item)
        {
            _uimodel.AddToContext(item);
        }

        public List<ControlEntity> GetContext()
        {
            return _uimodel.GetContext();
        }

        public void AddGroupBox(GroupBox item)
        {
            _uimodel.AddGroupBox(item);
        }

        public List<GroupBox> GetGroupBoxes()
        {
            return _uimodel.GetGroupBoxes();
        }

        public void ClearButtonsBackground()
        {
            _uimodel.ClearButtonsBackground();
        }
    }
}
