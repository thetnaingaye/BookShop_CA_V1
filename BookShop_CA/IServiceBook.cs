using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BookShop_CA
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceBook" in both code and config file together.
    [ServiceContract]
    public interface IServiceBook
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Books", ResponseFormat = WebMessageFormat.Json)]
        void DoWork();
    }
}
