using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWebAPI.Entity
{
    public abstract class AbsInputEntity:AbsEntity
    {

        public abstract bool Valid(out List<string> errorMessage);

    }
}