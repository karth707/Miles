using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NavigationWcfService
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        String GetDistance(String start, String end);

    }
}