using System;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using WCCCommon.Models;
using WCCInfrastructure.Services.SRDataService;

namespace WanoControlService.Services.SRDataService
{
    public class SRDataService : ISRDataService
    {

        private readonly Subject<SRData> _pSubj = new Subject<SRData>();

        public IObservable<SRData> SRData
        {
            get
            {
                return _pSubj.AsObservable();
            }
        }

        public void SaveInteraction(SendReceiveData pp) 
        {
            _pSubj.OnNext(new SRData(pp));
        }
    }
}
