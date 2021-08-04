using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HelloWebAPI.Entity;
using HelloWebAPI.Models;

namespace HelloWebAPI.GyoumuModel
{
    public class EmployeeDepartmentModel : AbsGyomuModel
    {
        public override void Init()
        {
            throw new NotImplementedException();
        }

        public EmployeeDepartmentModel(TM2DBEntities context_) : base(context_)
        {
            ;
        }

        public override void Dispose()
        {
            base.Dispose();

            // 個別でやりたい内容
            // Fileオブジェクトにnullにしたり、プロパティ,Entityのでかいのをnullするとか
        }

        // 社員マスタ:社員ID検索・指定なしは全量取得
        public List<M_SHAIN> Select_M_SHAIN(string EmpId_ = null)
        {

            if (EmpId_ == null)
            {
                return Context.M_SHAIN.AsNoTracking().ToList();
            }

            List<M_SHAIN> EmpList = new List<M_SHAIN>();
            EmpList.Add(Context.M_SHAIN.Where(n => n.EmpID.Equals(EmpId_)).SingleOrDefault());

            return EmpList;
        }

        // 社員マスタ:登録処理
        public void Regist_M_SHAIN(M_SHAIN Row_)
        {

            // todo バリデーションチェック
            // todo トランザクション処理
            // todo 排他制御 排他ロジック用の管理テーブル
            // ユーザトランザクションテーブル

            // ユーザ間の場合、親テーブルの行ロック
            // SingleOrDefault…行を1意にとる明示的な命令。readLock参照もまたされる。　whereでやるのはダメ。
            // バッチ中などの長期的な場合は？PK単位でのコミット（リラン設計？）　複数件まとめてロックするならTBLを別で作る
            // TBLロック。
            // トークンは更新日時の変わりに使うか。トリガーは使わない。持たせるのは排他ロックする親のみ
            // トークン生成・・・Guid guidValue = Guid.NewGuid(); //toStringは毎回おなじ
            // tabl.guid = Guid.NewGuid().ToString();///SQLServer GUID
            // using しないとautoCommitになるよ
            // 人事管理モデル　コントローラーはusingないで多少呼び出してりようか1個にするのか。

            //var target = context.tbl * **.SingleOrDefault(row => row.id == prm.id && row.LastUpdated == "2021/07/25 17.56.10.999999");

            //if (target == null)
            //    Exception("排他エラー");

            //target.LastUpdated = DateTime.Now();

            //context.SaveChanges();

            // 業務処理をする

            if (Row_ == null)
            {
                //TODO エラー処理
            }

            // todo バリデーションチェック

            Context.M_SHAIN.Add(Row_);
            Context.SaveChanges();
            return;

        }


        // 社員マスタ:更新処理
        public void Update_M_SHAIN(M_SHAIN Row_)
        {

            if (Row_ == null)
            {
                //TODO エラー処理
            }

            // TODO　バリデーションチェック

            Context.Entry(Row_).State = EntityState.Modified;
            Context.SaveChanges();
            return;
        }

        // 社員マスタ:削除処理
        public void Delete_M_SHAIN(string EmpID_)
        {

            // todo バリデーションチェック
            if (EmpID_ == null)
            {
                //TODO　エラー処理
            }

            //Findだと主キー変更のリスクがあるためwhereにしておく
            Context.M_SHAIN.Remove(Context.M_SHAIN.Where(n => n.EmpID.Equals(EmpID_)).SingleOrDefault());
            Context.SaveChanges();
            return;

        }


        // グループマスタ:グループID検索・指定なしは全量取得
        public List<M_GROUP> Select_M_GROUP(string GroupId_ = null)
        {
            if (GroupId_ == null)
            {
                return Context.M_GROUP.AsNoTracking().ToList();
            }
            List<M_GROUP> GroupList = new List<M_GROUP>();
            GroupList.Add(Context.M_GROUP.Where(m => m.GroupID.Equals(GroupId_)).SingleOrDefault());
            return GroupList;
        }

        // グループマスタ:登録処理
        public void Regist_M_GROUP(M_GROUP Row_)
        {

            if (Row_ == null)
            {
                //TODO エラー処理
            }
            // todo バリデーションチェック
            Guid GuidValue = Guid.NewGuid();
            Row_.Token = GuidValue.ToString();
            Context.M_GROUP.Add(Row_);
            Context.SaveChanges();
            return;

        }


        // グループマスタ:更新処理
        public void Update_M_GROUP(M_GROUP Row_)
        {

            if (Row_ == null)
            {
                //TODO エラー処理
            }
            // todo バリデーションチェック

            Context.Entry(Row_).State = EntityState.Modified;
            Context.SaveChanges();
            return;

        }

        // グループマスタ:削除処理
        public void Delete_M_GROUP(string GroupId_)
        {

            if (GroupId_ == null)
            {
                //TODO エラー処理
            }
            // todo バリデーションチェック

            //Findだと主キー変更のリスクがあるためwhereにしておく
            Context.M_GROUP.Remove(Context.M_GROUP.Where(m => m.GroupID.Equals(GroupId_)).SingleOrDefault());
            Context.SaveChanges();
            return;

        }

        //グループに紐づく社員情報一覧取得
        public OutEmployeeEntity GetEmployeeList(string GroupID = null, string EmpID = null)
        {

            //↓これはメモリ展開後に操作してるが、DB取得時からやるべし
            //DB上のフォーリンキーがあればデータがとれちゃう
            //親をとれば子がとれる
            //var gJoho = gmodel.SelectList();
            //var sJoho = emodel.SelectList();
            //foreach(M_SHAIN  in sJoho)
            //{
            //    var row = gJoho.Where(m => m.MemberID.Equals(n.EmpID)).FirstOrDefault();
            //    if (row != null)
            //    {
            //        sList.Add(new shainJoho() { GroupName = row.GroupName, Mshain = n });
            //}
            //}

            List<M_GROUP> GJoho_ = this.Select_M_GROUP();
            List<M_SHAIN> SJoho_ = this.Select_M_SHAIN();
            OutEmployeeEntity List_ = new OutEmployeeEntity();

            //foreach (M_GROUP n in GJoho_)
            //{
            //    List<M_SHAIN> list = SJoho_.Where(m => m.GroupID.Equals(n.GroupID)).ToList();
            //    if (list != null)
            //    {
            //        List_.Mgroup = n;
            //        List_.Mshain = list;
            //        List_.SJoho.Add(List_.Mgroup, List_.Mshain);
            //    }

            //}

            foreach (M_GROUP n in Context.M_GROUP)
            {

                List<M_SHAIN> list_ = new List<M_SHAIN>(Context.M_SHAIN.Where(m => m.GroupID.Equals(n.GroupID)).ToList());
                if (list_ != null)
                {
                    List_.SJoho.Add(n, new List<M_SHAIN>(Context.M_SHAIN.Where(m => m.GroupID.Equals(n.GroupID)).ToList()));
                }

                //List<M_SHAIN> list = SJoho_.Where(m => m.GroupID.Equals(n.GroupID)).ToList();
                //if (list != null)
                //{
                //    List_.Mgroup = GJoho_.First();
                //    List_.Mshain = SJoho_.ToList();
                //}

            }


            return List_;
        }

    }
}