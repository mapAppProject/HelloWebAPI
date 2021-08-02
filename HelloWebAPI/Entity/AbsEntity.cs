using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TM2WEB.Entity
{
    public abstract class AbsEntity
    {

        //Logger Objectをプロパティで持つ　→　廃止
        public string Log { get; set; }


        public AbsEntity(string str_=null)
        {
            //プロパティのLoggerを渡す
            Log = str_;

        }


    }
}