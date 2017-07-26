using System.Collections;
using WanoControlContracts.DataContracts.ControllerConfigure;
using WCCInfrastructure.Services.ControllerService;
using WG3000_COMM.Core;

namespace WanoControlService.Services.ControllerService
{
    public class ControllerService : IControllerService
    {

        private wgMjControllerConfigure _controller = new wgMjControllerConfigure();
        private ArrayList _arrControllers = new ArrayList();
        private wgMjController _control = new wgMjController();

        public bool ConnectToController(RequestControllerConfigure request)
        {
            wgMjControllerConfigure conf = new wgMjControllerConfigure()
            {
                gateway = request.Gateway,
                holidayControl = request.HolidayControl,
                ip = request.Ip,
                mask = request.Mask,
                pcIPAddr = request.PcIPAddr,
                port = request.Port
            };

            Search();

            var _controllerInstance = (wgMjControllerConfigure)_arrControllers[0];

            _control.NetIPConfigure(_controllerInstance.controllerSN.ToString(),
                _controllerInstance.MACAddr, _controllerInstance.ip.ToString(),
                _controllerInstance.mask.ToString(), _controllerInstance.gateway.ToString(),
                _controllerInstance.port.ToString(), _controllerInstance.pcIPAddr);

            //TEST
            _control.RemoteOpenDoorIP(1);
            _control.RemoteOpenDoorIP(2);
            _control.RemoteOpenDoorIP(3);
            _control.RemoteOpenDoorIP(4);

            _control.RestoreAllSwipeInTheControllersIP();

            return true;
        }

        private void Search()
        {
            using (wgMjController control = new wgMjController())
            {
                control.SearchControlers(ref _arrControllers);
            }
            if (_arrControllers != null)
            {
                if (_arrControllers.Count <= 0)
                {
                    return;
                }
                wgMjControllerConfigure conf;
                for (int i = 0; i < _arrControllers.Count; i++)
                {
                    conf = (wgMjControllerConfigure)_arrControllers[i];
                    string[] subItems = new string[] {
                        conf.controllerSN.ToString(), 
                        conf.ip.ToString(),
                        conf.mask.ToString(),
                        conf.gateway.ToString(),
                        conf.port.ToString(),
                        conf.MACAddr,
                        conf.pcIPAddr 
                    };
                }
            }
        }

        public wgMjControllerConfigure Controller
        {
            get
            {
                return _controller;
            }
        }
    }
}
