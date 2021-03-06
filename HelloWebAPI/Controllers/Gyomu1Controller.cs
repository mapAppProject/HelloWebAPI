using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWebAPI.GyoumuModel;
using HelloWebAPI.Models;
using HelloWebAPI.Entity;
using System.Web.Http;

namespace HelloWebAPI.Controllers
{
    public class Gyomu1Controller : ApiController
    {

        private TM2DBEntities Db = new TM2DBEntities();

        // GET: Gyomu1
        public IEnumerable<OutEmployeeEntity> Gyomu1Index()
        {
            EmployeeDepartmentModel model = new EmployeeDepartmentModel(Db);
            OutEmployeeEntity List_ = model.GetEmployeeList();
            List_.JSON = List_.ToJson();
            //IEnumerableへ変換
            return new List<OutEmployeeEntity>() { List_ };
        }



    }
}