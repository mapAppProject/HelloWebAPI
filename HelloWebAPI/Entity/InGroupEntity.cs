using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TM2WEB.Entity
{
    public class InGroupEntity : AbsInputEntity
    {
        [Required]
        public string GroupID { get; set; }

        public InGroupEntity()
        {

        }

        public override bool Valid(out List<string> errorMessage)
        {
            errorMessage = new List<string>();


            if (string.IsNullOrEmpty(GroupID))
            {
                errorMessage.Add("グループIDが未設定");
                return false;
            }

            return true;
        }
    }
}