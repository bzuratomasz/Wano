using System;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using WCCCommon.Models;
using WanoControlService.Services.SRDataService.Interfaces;

namespace WanoControlService.Services.SRDataService
{
    public class SRDataService : ISRDataService
    {

        private SendReceiveData _data;

        public SendReceiveData Data 
        {
            get { return _data; }
        }

        private readonly Subject<SRDataService> _pSubj = new Subject<SRDataService>();

        public IObservable<SRDataService> SRData
        {
            get
            {
                return _pSubj.AsObservable();
            }
        }

        public void SaveInteraction(SendReceiveData pp) 
        {
            _data = pp;
            _pSubj.OnNext(this);
        }
    }
}
