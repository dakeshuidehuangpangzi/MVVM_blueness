using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public abstract class IDatabase
    {
        /// <summary> 执行增,删,改</summary>
        public abstract int Update(string sql);
        /// <summary>    执行SQL语句，返回影响的记录数    </summary>    
        public abstract int Update(string sql, DbParameter[] param);
        /// <summary>获取单一结果 </summary>
        public abstract object GetSingleResult(string SQLString);
        /// <summary>获取单一结果 </summary>
        public abstract object GetSingleResult(string SQLString, params DbParameter[] cmdParms);
        /// <summary>返回结果集</summary>
        public abstract DbDataReader ExecuteReader(string sql);
        public abstract DataSet GetDataSet(string sql);
        /// <summary>启用事务执行多条SQL语句</summary>
        public abstract bool UpdateByTran(IEnumerable sqlList);//list<String>



    }
}
