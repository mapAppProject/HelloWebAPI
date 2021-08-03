using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWebAPI.Entity
{
    public abstract class AbsResponseEntity : AbsEntity
    {


        public string ToJson()
        {
            // thisの第二引数にフォーマットを指定も可能
            return JsonConvert.SerializeObject(this);
        }

    }
}