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

        //[OperationContract]
        //String GetDistance(String start, String end);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/nav?start={start}&end={end}")]
        distance GetDistance(String start, String end);
    }

    [DataContract]
    public class distance
    {
        [DataMember]
        public string dist { get; set; }
      
    }

}