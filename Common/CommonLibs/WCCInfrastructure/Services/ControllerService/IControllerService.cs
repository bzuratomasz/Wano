
using WanoControlContracts.DataContracts.ControllerConfigure;
using WG3000_COMM.Core;
namespace WCCInfrastructure.Services.ControllerService
{
    public interface IControllerService
    {
        bool ConnectToController(RequestControllerConfigure request);
        wgMjControllerConfigure GetController();
    }
}
