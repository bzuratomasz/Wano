using System.Collections;
using WanoControlContracts.DataContracts.ControllerConfigure;
using WCCInfrastructure.Services.ControllerService;
using WG3000_COMM.Core;

namespace WanoControlService.Services.ControllerService
{
    public class ControllerService : IControllerService
    {

        private ArrayList _arrControllers = new ArrayList();
        private wgMjController _control;

        public bool ConnectToController(RequestControllerConfigure request)
        {

            _control = new wgMjController() 
            {
                ControllerSN = request.SN,
                IP = request.Ip.ToString(),
                PORT = request.Port
            };

            var x1 = _control.RemoteOpenDoorIP(1);
            var x2 = _control.RemoteOpenDoorIP(2);
            var x3 = _control.RemoteOpenDoorIP(3);
            var x4 = _control.RemoteOpenDoorIP(4);
            
            return true;
        }

        public wgMjControllerConfigure GetController()
        {
            return Search();
        }

        private wgMjControllerConfigure Search()
        {
            wgMjControllerConfigure conf = new wgMjControllerConfigure();

            using (wgMjController control = new wgMjController())
            {
                control.SearchControlers(ref _arrControllers);
            }
            if (_arrControllers != null)
            {
                if (_arrControllers.Count > 0)
                {
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

            return conf;
        }
    }
}
