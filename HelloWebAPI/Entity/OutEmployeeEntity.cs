using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWebAPI.Models;

namespace HelloWebAPI.Entity
{
    public class OutEmployeeEntity : AbsResponseEntity
    {
        public Dictionary<M_GROUP, List<M_SHAIN>> SJoho { get; set; }

        //public M_GROUP Mgroup { get; set; }

        //public List<M_SHAIN> Mshain { get; set; }

        public string JSON { get; set; }


        public OutEmployeeEntity()
        {
            //Listは初期化
            SJoho = new Dictionary<M_GROUP, List<M_SHAIN>>();
            //Mshain = new List<M_SHAIN>();
        }

    }
}