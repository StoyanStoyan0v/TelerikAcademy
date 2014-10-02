using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BullsAndCows.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsers" in both code and config file together.
    [ServiceContract]
    public interface IUsers
    {
        [WebGet(UriTemplate = "users")]
        [OperationContract]
        ICollection<User> All();
        
        [WebGet(UriTemplate = "users?page={id}")]
        [OperationContract]
        ICollection<User> AllPage(int id);

        [WebGet(UriTemplate = "users/{id}")]
        [OperationContract]
        User ById(string id);
    }
}