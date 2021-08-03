using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HelloWebAPI.Models;

namespace HelloWebAPI.Entity
{
    public class InEmployeeEntity : AbsInputEntity
    {

        [StringLength(10)]
        public string Id { get; set; }

        public List<string> Name { get; set; }

        [StringLength(10)]
        public string GroupID { get; set; }

        public InEmployeeEntity()
        {
            //コンストラクタでListは生成しておく
            Name = new List<string>();
        }

        public override bool Valid(out List<string> errorMessage)
        {
            errorMessage = new List<string>();


            if (string.IsNullOrEmpty(Id))
            {
                errorMessage.Add("社員IDが未設定");
                return false;
            }

            //サンプル
            //if (Name != null && Name.Any())
            //{
            //    if(Name.Any(n => n.Equals("TEST")))
            //    {
            //        errorMessage.Add("名前がTESTではない");
            //    }
            //}

            return true;
        }
    }
}