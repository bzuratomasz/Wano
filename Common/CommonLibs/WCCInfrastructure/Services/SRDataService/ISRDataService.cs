using System;
using WCCCommon.Models;

namespace WCCInfrastructure.Services.SRDataService
{
    public interface ISRDataService
    {
        IObservable<SRData> SRData { get; }
        void SaveInteraction(SendReceiveData pp);
    }
}
