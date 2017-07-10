using WanoControlContracts.DataContracts.ControllerConfigure;
using WCCInfrastructure.Services.ControllerService;
using WG3000_COMM.Core;

namespace WanoControlService.Services.ControllerService
{
    public class ControllerService : IControllerService
    {
        private wgMjControllerConfigure _controller;

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

            return true;
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
