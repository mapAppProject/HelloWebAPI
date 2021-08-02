using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TM2WEB.Models;

namespace TM2WEB.GyoumuModel
{
    public abstract class AbsGyomuModel : System.IDisposable
    {
        public TM2DBEntities Context { get; set; }
        public AbsGyomuModel(TM2DBEntities context_)
        {
            Context = context_;
        }

        public virtual void Dispose()
        {
            // 共通処理
            Context = null;
        }

        // 更新用のモデル
        public abstract void Init();



    }
}