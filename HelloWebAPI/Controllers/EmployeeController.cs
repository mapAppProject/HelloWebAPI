using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using TM2WEB.Models;
using TM2WEB.GyoumuModel;
using TM2WEB.Common;
using TM2WEB.Entity;
using System.Web.Http;

namespace TM2WEB.Controllers
{
    public class EmployeeController : AbsAPIController
    {
        //todo 親クラスに持つ？
        private TM2DBEntities context_ = new TM2DBEntities();
        private EmployeeDepartmentModel model_;
        private List<string> ErrorMessage_ = new List<string>();


        // GET: Employee
        public IEnumerable<M_SHAIN> Index()
        {
            // Model処理
            model_ = new EmployeeDepartmentModel(context_);
            List<M_SHAIN> List_ = model_.Select_M_SHAIN();

            return List_;
        }

        // GET: Employee/Details/5
        public IHttpActionResult Details(InEmployeeEntity Entity_)
        {

            //Entity_クラスとリクエストパラメータの名前を一致させておくこと
            //Requestの配列は名前がないので紐づけられないのでJSONで渡してもらうと紐づけられる

            //validチェック
            if (!Entity_.Valid(out ErrorMessage_))
            {
                //TODO エラー処理
                //logにエラーメッセージを渡す
                return StatusCode(HttpStatusCode.BadRequest);
            }

            // Model処理
            model_ = new EmployeeDepartmentModel(context_);
            M_SHAIN Row_ = model_.Select_M_SHAIN(Entity_.Id).SingleOrDefault();

            // Model結果判定
            if (Row_ == null)
            {
                //todo エラー画面に遷移
                return NotFound();
            }

            return Ok(Row_);
        }

        // GET: Employee/Create
        public IHttpActionResult Create()
        {
            return Ok();
        }

        // POST: Employee/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IHttpActionResult Create([Bind(Include = "EmpID,NameKJ1,NameKJ2,NameKN,StartDate,EndDate,EmployeeKbn,BaseDate,AdYear,BaseAge,AdCareerYear,CareerYear,Mail,Station,Phone,Sex,BreakNum,DaysWorked,College,Department1,Department2,InsMark,InsNum,Job,GroupID,TraGroup,UpdateDate")] M_SHAIN Row_)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("Index");
            }

            // Model処理
            using (context_)
            {
                // 排他選択可能
                using (var dbContextTransaction = context_.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        using (model_ = new EmployeeDepartmentModel(context_))
                        {
                            model_.Regist_M_SHAIN(Row_);
                            dbContextTransaction.Commit();
                        }
                    }
                    catch (GyomuException)
                    {
                        //ロールバックのみであればtry catchは不要。
                        throw;
                    }
                }
            }

            return Redirect("Index");
        }

        // GET: Employee/Edit/5
        public IHttpActionResult Edit(InEmployeeEntity Entity_)
        {

            //validチェック
            if (!Entity_.Valid(out ErrorMessage_))
            {
                //TODO エラー処理
                //logにエラーメッセージを渡す
                return StatusCode(HttpStatusCode.BadRequest);
            }

            // Model処理
            M_SHAIN Row_;
            using (context_)
            {
                using (var dbContextTransaction = context_.Database.BeginTransaction())
                {
                    try
                    {
                        using (model_ = new EmployeeDepartmentModel(context_))
                        {
                            Row_ = model_.Select_M_SHAIN(Entity_.Id).SingleOrDefault();
                            if (Row_ == null)
                            {
                                //TODO エラー処理
                                return NotFound();
                            }
                            dbContextTransaction.Commit();
                        }
                    }
                    catch (GyomuException)
                    {
                        throw;
                    }
                }
            }

            return Ok(Row_);
        }

        // POST: Employee/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IHttpActionResult Edit([Bind(Include = "EmpID,NameKJ1,NameKJ2,NameKN,StartDate,EndDate,EmployeeKbn,BaseDate,AdYear,BaseAge,AdCareerYear,CareerYear,Mail,Station,Phone,Sex,BreakNum,DaysWorked,College,Department1,Department2,InsMark,InsNum,Job,GroupID,TraGroup,UpdateDate")] M_SHAIN Row_)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("Index");
            }

            // Model処理
            using (context_)
            {
                using (var dbContextTransaction = context_.Database.BeginTransaction())
                {
                    try
                    {
                        using (model_ = new EmployeeDepartmentModel(context_))
                        {
                            model_.Update_M_SHAIN(Row_);
                            dbContextTransaction.Commit();
                        }
                    }
                    catch (GyomuException)
                    {
                        throw;
                    }
                }
            }
            return Redirect("Index");
        }

        // GET: Employee/Delete/5
        public IHttpActionResult Delete(InEmployeeEntity Entity_)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("Index");
            }
            // Model処理
            model_ = new EmployeeDepartmentModel(context_);
            M_SHAIN Row_ = model_.Select_M_SHAIN(Entity_.Id).SingleOrDefault();

            if (Row_ == null)
            {
                return NotFound();
            }
            return Ok(Row_);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        public IHttpActionResult DeleteConfirmed(InEmployeeEntity Entity_)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("Index");
            }

            // Model処理
            using (context_)
            {
                using (var dbContextTransaction = context_.Database.BeginTransaction())
                {
                    try
                    {
                        using (model_ = new EmployeeDepartmentModel(context_))
                        {
                            model_.Delete_M_SHAIN(Entity_.Id);
                            dbContextTransaction.Commit();
                        }
                    }
                    catch (GyomuException)
                    {
                        throw;
                    }
                }
            }

            return Redirect("Index");
        }


    }
}
