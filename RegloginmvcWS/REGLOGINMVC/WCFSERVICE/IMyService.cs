using CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFSERVICE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMyService" in both code and config file together.
    [ServiceContract]
    public interface IMyService
    {
       // [OperationContract]
       // void DoWork();
        [OperationContract]
        bool AddDbData(CommonClass custom);
        [OperationContract]
        bool verifyDbUser(CommonClass c);
        [OperationContract]
        IEnumerable<CommonClass1> userDbDetails();
        [OperationContract]
        bool verifyDbEmail(string email);
        [OperationContract]
        IEnumerable<CommonClass1> Edit(int id);
        [OperationContract]
        bool editDbUser(CommonClass1 c);

    }
}
