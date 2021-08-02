using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using TM2WEB.Common;
using TM2WEB.Entity;
using TM2WEB.GyoumuModel;
using TM2WEB.Models;
using System.Web.Http;

namespace TM2WEB.Controllers
{
    public class GroupController : ApiController
    {
        private TM2DBEntities context_ = new TM2DBEntities();
        private EmployeeDepartmentModel model_;
        private List<string> ErrorMessage_ = new List<string>();

        // GET: GroupIndex
        public IEnumerable<M_GROUP> GroupIndex()
        {
            model_ = new EmployeeDepartmentModel(context_);
            List<M_GROUP> List_ = model_.Select_M_GROUP();

            return List_;
        }

        // GET: Group/GroupDetails/5
        public IHttpActionResult GroupDetails(string id_)
        {
            //Entity_クラスとリクエストパラメータの名前を一致させておくこと
            //Requestの配列は名前がないので紐づけられないのでJSONで渡してもらうと紐づけられる
            InGroupEntity Entity_ = new InGroupEntity();
            Entity_.GroupID = id_;
            //validチェック
            if (!Entity_.Valid(out ErrorMessage_))
            {
                //TODO エラー処理
                //logにエラーメッセージを渡す
                return StatusCode(HttpStatusCode.BadRequest);
            }

            // Model処理
            model_ = new EmployeeDepartmentModel(context_);
            M_SHAIN Row_ = model_.Select_M_SHAIN(Entity_.GroupID).SingleOrDefault();

            // Model結果判定
            if (Row_ == null)
            {
                //todo エラー画面に遷移
                return NotFound();
            }

            return Ok(Row_);
        }

        // GET: Group/GroupCreate
        public IHttpActionResult GroupCreate()
        {
            return Ok();
        }

        // POST: Group/GroupCreate
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IHttpActionResult GroupCreate([Bind(Include = "GroupID,MemberID,GroupName,GLEmpID,UpdateDate")] M_GROUP Row_)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("GroupIndex");
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
                            model_.Regist_M_GROUP(Row_);
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

            return Redirect("GroupIndex");

        }

        // GET: Group/GroupEdit/5
        public IHttpActionResult GroupEdit(InGroupEntity Entity_)
        {

            //validチェック
            if (!Entity_.Valid(out ErrorMessage_))
            {
                //TODO エラー処理
                //logにエラーメッセージを渡す
                return StatusCode(HttpStatusCode.BadRequest);
            }

            // Model処理
            M_GROUP Row_;
            using (context_)
            {
                using (var dbContextTransaction = context_.Database.BeginTransaction())
                {
                    try
                    {
                        using (model_ = new EmployeeDepartmentModel(context_))
                        {
                            Row_ = model_.Select_M_GROUP(Entity_.GroupID).SingleOrDefault();
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

        // POST: Group/GroupEdit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IHttpActionResult GroupEdit([Bind(Include = "GroupID,MemberID,GroupName,GLEmpID,UpdateDate")] M_GROUP Row_)
        {

            if (!ModelState.IsValid)
            {
                return Redirect("GroupIndex");
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
                            model_.Update_M_GROUP(Row_);
                            dbContextTransaction.Commit();
                        }
                    }
                    catch (GyomuException)
                    {
                        throw;
                    }
                }
            }
            return Redirect("GroupIndex");

        }

        // GET: Group/GroupDelete/5
        public IHttpActionResult GroupDelete(InGroupEntity Entity_)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("GroupIndex");
            }
            // Model処理
            model_ = new EmployeeDepartmentModel(context_);
            M_GROUP Row_ = model_.Select_M_GROUP(Entity_.GroupID).SingleOrDefault();

            if (Row_ == null)
            {
                return NotFound();
            }
            return Ok(Row_);

        }

        // POST: Group/GroupDeleteConfirmed/5
        [HttpPost, ActionName("GroupDelete")]
        // [ValidateAntiForgeryToken]
        public IHttpActionResult GroupDeleteConfirmed(InGroupEntity Entity_)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("GroupIndex");
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
                            model_.Delete_M_GROUP(Entity_.GroupID);
                            dbContextTransaction.Commit();
                        }
                    }
                    catch (GyomuException)
                    {
                        throw;
                    }
                }
            }

            return Redirect("GroupIndex");
        }
    }
}
