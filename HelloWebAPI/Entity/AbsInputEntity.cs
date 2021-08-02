using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TM2WEB.Entity
{
    public abstract class AbsInputEntity:AbsEntity
    {

        public abstract bool Valid(out List<string> errorMessage);

    }
}