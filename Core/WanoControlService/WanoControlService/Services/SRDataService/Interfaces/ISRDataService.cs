using System;
using WCCCommon.Models;

namespace WanoControlService.Services.SRDataService.Interfaces
{
    public interface ISRDataService
    {
        IObservable<SRDataService> SRData { get; }
        void SaveInteraction(SendReceiveData pp);
    }
}
