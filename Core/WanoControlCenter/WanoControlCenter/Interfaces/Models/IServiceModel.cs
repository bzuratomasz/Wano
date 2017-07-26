using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanoControlContracts.DataContracts.ControllerConfigure;
using WanoControlContracts.DataContracts.RegisterCard;
using WCCCommon.Models;

namespace WanoControlCenter.Interfaces.Models
{
    public interface IServiceModel
    {
        ResponseRegisterCard RegisterCard(RequestRegisterCard card);
        void Register(RequestControllerConfigure controller);
        List<RequestRegisterCard> GetCards();
        bool UpdateCardsPermissions(List<List<Status>> permissions, int cardId);
        ResponseControllerConfigure GetController();
    }
}
