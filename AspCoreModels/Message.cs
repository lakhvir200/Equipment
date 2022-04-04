using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AspCoreModels
{
    [DataContract]
   public  class Message <T>
    {

        [DataMember (Name ="IsSuccess")]
    }
}
