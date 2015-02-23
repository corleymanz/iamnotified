using System;
using System.Runtime.Remoting.Messaging;
using System.ServiceProcess;
using System.Threading.Tasks;
using IAmNotified.IAmNotifiedService.Implementation;

namespace IAmNotified.IAmNotifiedService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class IAmNotified_v1 : ServiceBase, IIAmNotified_v1
    {
        protected override void OnStart(string[] args)
        {
            base.OnStart(args);

            // start listening
            // TODO : exception handeling onderzoeken
            var c = new Controller();
            Task.Run( () => c.Receive());

        }

        public string Start()
        {
            return string.Format("Started");
        }

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}
    }
}
