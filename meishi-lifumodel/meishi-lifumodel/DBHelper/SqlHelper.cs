﻿using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace meishi_lifumodel.DBHelper
{
    public class SqlHelper
    {
        /*
       * 数据库连接字符串(web.config来配置)
       * <add key="ConnectionString" value="server=127.0.0.1;database=DATABASE;uid=sa;pwd=" />
       */
        private string connectionString;
        public string ConntionString
        {
            get
            {
                return (connectionString);
            }
            set
            {
                connectionString = value;
            }
        }


        public SqlHelper(string strConnect, string dataType)
        {
            this.ConntionString = strConnect;
            this.DbType = dataType;
        }


        public SqlHelper()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["mysqlconn"].ToString();
            this.dbType = ConfigurationManager.ConnectionStrings["DataType"].ToString();
        }


        /**/
        /* / <summary> */
        /*
         * / 数据库类型
         * / </summary>
         */
        private string dbType;
        public string DbType
        {
            get
            {
                if (dbType == string.Empty || dbType == null)
                {
                    return ("Access");
                }
                else
                {
                    return (dbType);
                }
            }
            set
            {
                if (value != string.Empty && value != null)
                {
                    dbType = value;
                }
                if (dbType == string.Empty || dbType == null)
                {
                    dbType = ConfigurationManager.ConnectionStrings["DataType"].ToString();
                }
                if (dbType == string.Empty || dbType == null)
                {
                    dbType = "Access";
                }
            }
        }


        #region 转换参数
        private System.Data.IDbDataParameter iDbPara(string ParaName, string DataType)
        {
            switch (this.DbType)
            {
                case "SqlServer":
                    return (GetSqlPara(ParaName, DataType));

                /* case "Oracle": */
                /* return GetOleDbPara(ParaName,DataType); */

                case "Access":
                    return (GetOleDbPara(ParaName, DataType));
                case "MySql":
                    return (GetMySqlPara(ParaName, DataType));
                default:
                    return (GetSqlPara(ParaName, DataType));
            }
        }


        private System.Data.SqlClient.SqlParameter GetSqlPara(string ParaName, string DataType)
        {
            switch (DataType)
            {
                case "Decimal":
                    return (new System.Data.SqlClient.SqlParameter(ParaName, System.Data.SqlDbType.Decimal));
                case "Varchar":
                    return (new System.Data.SqlClient.SqlParameter(ParaName, System.Data.SqlDbType.VarChar));
                case "DateTime":
                    return (new System.Data.SqlClient.SqlParameter(ParaName, System.Data.SqlDbType.DateTime));
                case "Image":
                    return (new System.Data.SqlClient.SqlParameter(ParaName, System.Data.SqlDbType.Image));
                case "Int":
                    return (new System.Data.SqlClient.SqlParameter(ParaName, System.Data.SqlDbType.Int));
                case "Text":
                    return (new System.Data.SqlClient.SqlParameter(ParaName, System.Data.SqlDbType.NText));
                default:
                    return (new System.Data.SqlClient.SqlParameter(ParaName, System.Data.SqlDbType.VarChar));
            }
        }

        private MySql.Data.MySqlClient.MySqlParameter GetMySqlPara(string ParaName, string DataType)
        {
            switch (DataType)
            {
                case "Decimal":
                    return (new MySql.Data.MySqlClient.MySqlParameter(ParaName, MySql.Data.MySqlClient.MySqlDbType.Decimal));
                case "Varchar":
                    return (new MySql.Data.MySqlClient.MySqlParameter(ParaName, MySql.Data.MySqlClient.MySqlDbType.VarChar));
                case "Time":
                    return (new MySql.Data.MySqlClient.MySqlParameter(ParaName, MySql.Data.MySqlClient.MySqlDbType.Time));
                case "DateTime":
                    return (new MySql.Data.MySqlClient.MySqlParameter(ParaName, MySql.Data.MySqlClient.MySqlDbType.DateTime));
                case "Image":
                    return (new MySql.Data.MySqlClient.MySqlParameter(ParaName, MySql.Data.MySqlClient.MySqlDbType.Blob));
                case "Int":
                    return (new MySql.Data.MySqlClient.MySqlParameter(ParaName, MySql.Data.MySqlClient.MySqlDbType.Int32));
                case "Text":
                    return (new MySql.Data.MySqlClient.MySqlParameter(ParaName, MySql.Data.MySqlClient.MySqlDbType.Text));
                default:
                    return (new MySql.Data.MySqlClient.MySqlParameter(ParaName, MySql.Data.MySqlClient.MySqlDbType.VarChar));
            }
        }


        /*
         * private System.Data.OracleClient.OracleParameter GetOraclePara( string ParaName , string DataType)
         * {
         * switch(DataType)
         * {
         * case "Decimal":
         * return new System.Data.OracleClient.OracleParameter( ParaName, System.Data.OracleClient.OracleType.Double);
         */

        /*
         * case "Varchar":
         * return new System.Data.OracleClient.OracleParameter ( ParaName, System.Data.OracleClient.OracleType.VarChar );
         */

        /*
         * case "DateTime":
         * return new System.Data.OracleClient.OracleParameter ( ParaName, System.Data.OracleClient.OracleType.DateTime );
         */

        /*
         * case "Iamge":
         * return new System.Data.OracleClient.OracleParameter ( ParaName, System.Data.OracleClient.OracleType.BFile );
         */

        /*
         * case "Int":
         * return new System.Data.OracleClient.OracleParameter ( ParaName, System.Data.OracleClient.OracleType.Int32 );
         */

        /*
         * case "Text":
         * return new System.Data.OracleClient.OracleParameter ( ParaName, System.Data.OracleClient.OracleType.LongVarChar );
         */

        /*
         * default:
         * return new System.Data.OracleClient.OracleParameter ( ParaName, System.Data.OracleClient.OracleType.VarChar );
         */

        /*
         * }
         * }
         */

        private System.Data.OleDb.OleDbParameter GetOleDbPara(string ParaName, string DataType)
        {
            switch (DataType)
            {
                case "Decimal":
                    return (new System.Data.OleDb.OleDbParameter(ParaName, System.Data.DbType.Decimal));

                case "Varchar":
                    return (new System.Data.OleDb.OleDbParameter(ParaName, System.Data.DbType.String));

                case "DateTime":
                    return (new System.Data.OleDb.OleDbParameter(ParaName, System.Data.DbType.DateTime));

                case "Iamge":
                    return (new System.Data.OleDb.OleDbParameter(ParaName, System.Data.DbType.Binary));

                case "Int":
                    return (new System.Data.OleDb.OleDbParameter(ParaName, System.Data.DbType.Int32));

                case "Text":
                    return (new System.Data.OleDb.OleDbParameter(ParaName, System.Data.DbType.String));

                default:
                    return (new System.Data.OleDb.OleDbParameter(ParaName, System.Data.DbType.String));
            }
        }


        #endregion

        #region 创建 Connection 和 Command

        private IDbConnection GetConnection()
        {
            switch (this.DbType)
            {
                case "SqlServer":
                    return (new System.Data.SqlClient.SqlConnection(this.ConntionString));

                /* case "Oracle": */
                /* return new System.Data.OracleClient.OracleConnection(this.ConntionString); */

                case "Access":
                    return (new System.Data.OleDb.OleDbConnection(this.ConntionString));
                case "MySql":
                    return (new MySql.Data.MySqlClient.MySqlConnection(this.ConntionString));
                default:
                    return (new System.Data.SqlClient.SqlConnection(this.ConntionString));
            }
        }


        private IDbCommand GetCommand(string Sql, IDbConnection iConn)
        {
            switch (this.DbType)
            {
                case "SqlServer":
                    return (new System.Data.SqlClient.SqlCommand(Sql, (SqlConnection)iConn));

                /* case "Oracle": */
                /* return new System.Data.OracleClient.OracleCommand(Sql,(OracleConnection)iConn); */

                case "Access":
                    return (new System.Data.OleDb.OleDbCommand(Sql, (OleDbConnection)iConn));
                case "MySql":
                    return (new MySql.Data.MySqlClient.MySqlCommand(Sql, (MySqlConnection)iConn));
                default:
                    return (new System.Data.SqlClient.SqlCommand(Sql, (SqlConnection)iConn));
            }
        }


        private IDbCommand GetCommand()
        {
            switch (this.DbType)
            {
                case "SqlServer":
                    return (new System.Data.SqlClient.SqlCommand());

                /* case "Oracle": */
                /* return new System.Data.OracleClient.OracleCommand(); */

                case "Access":
                    return (new System.Data.OleDb.OleDbCommand());
                case "MySql":
                    return (new MySql.Data.MySqlClient.MySqlCommand());
                default:
                    return (new System.Data.SqlClient.SqlCommand());
            }
        }


        private IDataAdapter GetAdapater(string Sql, IDbConnection iConn)
        {
            switch (this.DbType)
            {
                case "SqlServer":
                    return (new System.Data.SqlClient.SqlDataAdapter(Sql, (SqlConnection)iConn));

                /* case "Oracle": */
                /* return new System.Data.OracleClient.OracleDataAdapter(Sql,(OracleConnection)iConn); */

                case "Access":
                    return (new System.Data.OleDb.OleDbDataAdapter(Sql, (OleDbConnection)iConn));
                case "MySql":
                    return (new MySql.Data.MySqlClient.MySqlDataAdapter(Sql, (MySqlConnection)iConn));

                default:
                    return (new System.Data.SqlClient.SqlDataAdapter(Sql, (SqlConnection)iConn)); ;
            }
        }


        private IDataAdapter GetAdapater()
        {
            switch (this.DbType)
            {
                case "SqlServer":
                    return (new System.Data.SqlClient.SqlDataAdapter());

                /* case "Oracle": */
                /* return new System.Data.OracleClient.OracleDataAdapter(); */

                case "Access":
                    return (new System.Data.OleDb.OleDbDataAdapter());
                case "MySql":
                    return (new MySql.Data.MySqlClient.MySqlDataAdapter());
                default:
                    return (new System.Data.SqlClient.SqlDataAdapter());
            }
        }


        private IDataAdapter GetAdapater(IDbCommand iCmd)
        {
            switch (this.DbType)
            {
                case "SqlServer":
                    return (new System.Data.SqlClient.SqlDataAdapter((SqlCommand)iCmd));

                /* case "Oracle": */
                /* return new System.Data.OracleClient.OracleDataAdapter((OracleCommand)iCmd); */

                case "Access":
                    return (new System.Data.OleDb.OleDbDataAdapter((OleDbCommand)iCmd));
                case "MySql":
                    return (new MySql.Data.MySqlClient.MySqlDataAdapter((MySqlCommand)iCmd));
                default:
                    return (new System.Data.SqlClient.SqlDataAdapter((SqlCommand)iCmd));
            }
        }


        #endregion

        #region 执行简单SQL语句
        /**/
        /* / <summary> */
        /*
         * / 执行SQL语句，返回影响的记录数
         * / </summary>
         * / <param name="SQLString">SQL语句</param>
         * / <returns>影响的记录数</returns>
         */
        public int ExecuteSql2(string SQLString)
        {

            if (SQLString == null || SQLString == "")
                return 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        connection.Close();
                        return rows;
                    }
                    catch (MySql.Data.MySqlClient.MySqlException e)
                    {
                        connection.Close();
                        //WriteLogFile(SQLString + "  -->>  " + connectionString, "DbHelperMySQL", "ExecuteSql", "webDb_001", "", "", "");

                        //throw e;
                    }
                }
            }
            return 0;
        }
        public int ExecuteSql(string SqlString)
        {
            using (System.Data.IDbConnection iConn = this.GetConnection())
            {
                using (System.Data.IDbCommand iCmd = GetCommand(SqlString, iConn))
                {
                    iConn.Open();
                    try
                    {
                        int rows = iCmd.ExecuteNonQuery();
                        return (rows);
                    }
                    catch (System.Exception E)
                    {
                        throw new Exception(E.Message);
                    }
                    finally
                    {
                        if (iConn.State != ConnectionState.Closed)
                        {
                            iConn.Close();
                        }
                    }
                }
            }
        }


        /**/
        /* / <summary> */
        /*
         * / 执行多条SQL语句，实现数据库事务。
         * / </summary>
         * / <param name="SQLStringList">多条SQL语句</param>
         */
        public void ExecuteSqlTran(ArrayList SQLStringList)
        {
            using (System.Data.IDbConnection iConn = this.GetConnection())
            {
                iConn.Open();
                using (System.Data.IDbCommand iCmd = GetCommand())
                {
                    iCmd.Connection = iConn;
                    using (System.Data.IDbTransaction iDbTran = iConn.BeginTransaction())
                    {
                        iCmd.Transaction = iDbTran;
                        try
                        {
                            for (int n = 0; n < SQLStringList.Count; n++)
                            {
                                string strsql = SQLStringList[n].ToString();
                                if (strsql.Trim().Length > 1)
                                {
                                    iCmd.CommandText = strsql;
                                    iCmd.ExecuteNonQuery();
                                }
                            }
                            iDbTran.Commit();
                        }
                        catch (System.Exception E)
                        {
                            iDbTran.Rollback();
                            throw new Exception(E.Message);
                        }
                        finally
                        {
                            if (iConn.State != ConnectionState.Closed)
                            {
                                iConn.Close();
                            }
                        }
                    }
                }
            }
        }
        /**/
        /* / <summary> */
        /*
         * / 执行查询语句，返回List
         * / </summary>
         * / <param name="SQLString">查询语句</param>
         * / <returns>List</returns>
         */
        public IList<T> ExcuteQuery<T>(String sql) where T : class,new()
        {

            DataSet ds = new DataSet();
            using (System.Data.IDbConnection iConn = this.GetConnection())
            {

                try
                {
                    System.Data.IDataAdapter iAdapter = this.GetAdapater(sql, iConn);
                    iAdapter.Fill(ds);

                }
                catch (System.Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (iConn.State != ConnectionState.Closed)
                    {
                        iConn.Close();
                    }
                }
            }
            IList<T> modelist = new List<T>();
            //获取类T中所有属性
            PropertyInfo[] pros = typeof(T).GetProperties();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                T model = new T();
                foreach (PropertyInfo pro in pros)
                {
                    //用来设置类T中对应的公共属性的值为记录中对应属性名的值
                    //例如把UserInfo的Number属性值=row【“NUmber”】
                    //要求类T中的公共公共属性名必须和数据表中的字段名一致（包括大小写）
                 
                    if (row[pro.Name] is DBNull)
                    { pro.SetValue(model, "", null); }
                    else if (row[pro.Name] is String )
                    {
                        pro.SetValue(model, row[pro.Name], null);
                    }
                    else if (row[pro.Name] is int)
                    {
                        pro.SetValue(model, row[pro.Name], null);
                    }
                    else
                    {
                        pro.SetValue(model, row[pro.Name].ToString(), null);
                    }
                    

                }
                modelist.Add(model);
            }

            return modelist;

        }


        /**/
        /* / <summary> */
        /*
         * / 执行带一个存储过程参数的的SQL语句。
         * / </summary>
         * / <param name="SQLString">SQL语句</param>
         * / <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
         * / <returns>影响的记录数</returns>
         */
        public int ExecuteSql(string SqlString, string content)
        {
            using (System.Data.IDbConnection iConn = this.GetConnection())
            {
                using (System.Data.IDbCommand iCmd = GetCommand(SqlString, iConn))
                {
                    System.Data.IDataParameter myParameter = this.iDbPara("@content", "Text");
                    myParameter.Value = content;
                    iCmd.Parameters.Add(myParameter);
                    iConn.Open();
                    try
                    {
                        int rows = iCmd.ExecuteNonQuery();
                        return (rows);
                    }
                    catch (System.Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                    finally
                    {
                        if (iConn.State != ConnectionState.Closed)
                        {
                            iConn.Close();
                        }
                    }
                }
            }
        }


        /**/
        /* / <summary> */
        /*
         * / 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
         * / </summary>
         * / <param name="strSQL">SQL语句</param>
         * / <param name="fs">图像字节,数据库的字段类型为image的情况</param>
         * / <returns>影响的记录数</returns>
         */
        public int ExecuteSqlInsertImg(string SqlString, byte[] fs)
        {
            using (System.Data.IDbConnection iConn = this.GetConnection())
            {
                using (System.Data.IDbCommand iCmd = GetCommand(SqlString, iConn))
                {
                    System.Data.IDataParameter myParameter = this.iDbPara("@content", "Image");
                    myParameter.Value = fs;
                    iCmd.Parameters.Add(myParameter);
                    iConn.Open();
                    try
                    {
                        int rows = iCmd.ExecuteNonQuery();
                        return (rows);
                    }
                    catch (System.Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                    finally
                    {
                        if (iConn.State != ConnectionState.Closed)
                        {
                            iConn.Close();
                        }
                    }
                }
            }
        }


        /**/
        /* / <summary> */
        /*
         * / 执行一条计算查询结果语句，返回查询结果（object）。
         * / </summary>
         * / <param name="SQLString">计算查询结果语句</param>
         * / <returns>查询结果（object）</returns>
         */
        public object GetSingle(string SqlString)
        {
            using (System.Data.IDbConnection iConn = GetConnection())
            {
                using (System.Data.IDbCommand iCmd = GetCommand(SqlString, iConn))
                {
                    iConn.Open();
                    try
                    {
                        object obj = iCmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return (null);
                        }
                        else
                        {
                            return (obj);
                        }
                    }
                    catch (System.Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                    finally
                    {
                        if (iConn.State != ConnectionState.Closed)
                        {
                            iConn.Close();
                        }
                    }
                }
            }
        }


        /**/
        /* / <summary> */
        /*
         * / 执行查询语句，返回IDataAdapter
         * / </summary>
         * / <param name="strSQL">查询语句</param>
         * / <returns>IDataAdapter</returns>
         */
        public IDataAdapter ExecuteReader(string strSQL)
        {
            using (System.Data.IDbConnection iConn = this.GetConnection())
            {
                iConn.Open();
                try
                {
                    System.Data.IDataAdapter iAdapter = this.GetAdapater(strSQL, iConn);
                    return (iAdapter);
                }
                catch (System.Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    if (iConn.State != ConnectionState.Closed)
                    {
                        iConn.Close();
                    }
                }
            }
        }


        /**/
        /* / <summary> */
        /*
         * / 执行查询语句，返回DataSet
         * / </summary>
         * / <param name="SQLString">查询语句</param>
         * / <returns>DataSet</returns>
         */
        public DataSet Query(string sqlString)
        {
            using (System.Data.IDbConnection iConn = this.GetConnection())
            {
                using (System.Data.IDbCommand iCmd = GetCommand(sqlString, iConn))
                {
                    DataSet ds = new DataSet();
                    iConn.Open();
                    try
                    {
                        System.Data.IDataAdapter iAdapter = this.GetAdapater(sqlString, iConn);
                        iAdapter.Fill(ds);
                        return (ds);
                    }
                    catch (System.Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        if (iConn.State != ConnectionState.Closed)
                        {
                            iConn.Close();
                        }
                    }
                }
            }
        }


        /**/
        /* / <summary> */
        /*
         * / 执行查询语句，返回DataSet
         * / </summary>
         * / <param name="sqlString">查询语句</param>
         * / <param name="dataSet">要填充的DataSet</param>
         * / <param name="tableName">要填充的表名</param>
         * / <returns>DataSet</returns>
         */
        public DataSet Query(string sqlString, DataSet dataSet, string tableName)
        {
            using (System.Data.IDbConnection iConn = this.GetConnection())
            {
                using (System.Data.IDbCommand iCmd = GetCommand(sqlString, iConn))
                {
                    iConn.Open();
                    try
                    {
                        System.Data.IDataAdapter iAdapter = this.GetAdapater(sqlString, iConn);
                        ((OleDbDataAdapter)iAdapter).Fill(dataSet, tableName);
                        return (dataSet);
                    }
                    catch (System.Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        if (iConn.State != ConnectionState.Closed)
                        {
                            iConn.Close();
                        }
                    }
                }
            }
        }


        /**/
        /* / <summary> */
        /*
         * / 执行SQL语句 返回存储过程
         * / </summary>
         * / <param name="sqlString">Sql语句</param>
         * / <param name="dataSet">要填充的DataSet</param>
         * / <param name="startIndex">开始记录</param>
         * / <param name="pageSize">页面记录大小</param>
         * / <param name="tableName">表名称</param>
         * / <returns>DataSet</returns>
         */
        public DataSet Query(string sqlString, DataSet dataSet, int startIndex, int pageSize, string tableName)
        {
            using (System.Data.IDbConnection iConn = this.GetConnection())
            {
                iConn.Open();
                try
                {
                    System.Data.IDataAdapter iAdapter = this.GetAdapater(sqlString, iConn);

                    ((OleDbDataAdapter)iAdapter).Fill(dataSet, startIndex, pageSize, tableName);

                    return (dataSet);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (iConn.State != ConnectionState.Closed)
                    {
                        iConn.Close();
                    }
                }
            }
        }


        /**/
        /* / <summary> */
        /*
         * / 执行查询语句，向XML文件写入数据
         * / </summary>
         * / <param name="sqlString">查询语句</param>
         * / <param name="xmlPath">XML文件路径</param>
         */
        public void WriteToXml(string sqlString, string xmlPath)
        {
            Query(sqlString).WriteXml(xmlPath);
        }


        /**/
        /* / <summary> */
        /*
         * / 执行查询语句
         * / </summary>
         * / <param name="SqlString">查询语句</param>
         * / <returns>DataTable </returns>
         */
        public DataTable ExecuteQuery(string sqlString)
        {
            using (System.Data.IDbConnection iConn = this.GetConnection())
            {
                /* System.Data.IDbCommand iCmd = GetCommand(sqlString,iConn); */
                DataSet ds = new DataSet();
                try
                {
                    System.Data.IDataAdapter iAdapter = this.GetAdapater(sqlString, iConn);
                    iAdapter.Fill(ds);
                }
                catch (System.Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    if (iConn.State != ConnectionState.Closed)
                    {
                        iConn.Close();
                    }
                }
                return (ds.Tables[0]);
            }
        }


        /**/
        /* / <summary> */
        /*
         * / 执行查询语句
         * / </summary>
         * / <param name="SqlString">查询语句</param>
         * / <returns>DataTable </returns>
         */
        public DataTable ExecuteQuery(string SqlString, string Proc)
        {
            using (System.Data.IDbConnection iConn = this.GetConnection())
            {
                using (System.Data.IDbCommand iCmd = GetCommand(SqlString, iConn))
                {
                    iCmd.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    try
                    {
                        System.Data.IDataAdapter iDataAdapter = this.GetAdapater(SqlString, iConn);
                        iDataAdapter.Fill(ds);
                    }
                    catch (System.Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                    finally
                    {
                        if (iConn.State != ConnectionState.Closed)
                        {
                            iConn.Close();
                        }
                    }
                    return (ds.Tables[0]);
                }
            }
        }


        /**/
        /* / <summary> */
        /*
         * /
         * / </summary>
         * / <param name="Sql"></param>
         * / <returns></returns>
         */
        public DataView ExeceuteDataView(string Sql)
        {
            using (System.Data.IDbConnection iConn = this.GetConnection())
            {
                using (System.Data.IDbCommand iCmd = GetCommand(Sql, iConn))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        System.Data.IDataAdapter iDataAdapter = this.GetAdapater(Sql, iConn);
                        iDataAdapter.Fill(ds);
                        return (ds.Tables[0].DefaultView);
                    }
                    catch (System.Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                    finally
                    {
                        if (iConn.State != ConnectionState.Closed)
                        {
                            iConn.Close();
                        }
                    }
                }
            }
        }


        #endregion


        /// <summary>
        /// 执行查询语句，返回一条记录对应的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strSQL">查询语句</param>
        /// <returns></returns>
        public T query<T>(string strSQL, params IDataParameter[] iParms) where T : class,new()
        {
            System.Data.IDbConnection iConn = this.GetConnection();
            {
                System.Data.IDbCommand iCmd = GetCommand();
                {
                    try
                    {
                        PrepareCommand(out iCmd, iConn, null, strSQL, iParms);
                        System.Data.IDataReader iReader = iCmd.ExecuteReader();
                        iCmd.Parameters.Clear();
                        if (iReader.Read())
                        {
                            PropertyInfo[] pis = typeof(T).GetProperties();
                            T model = new T();
                            foreach (PropertyInfo pi in pis)
                            {
                                pi.SetValue(model, iReader[pi.Name], null);
                            }
                            return model;
                        }
                    }
                    catch (System.Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                    finally
                    {
                        iCmd.Dispose();
                        if (iConn.State != ConnectionState.Closed)
                        {
                            iConn.Close();
                        }
                    }
                }
            }
            return null;
        }

        #region 执行带参数的SQL语句
        /**/
        /* / <summary> */
        /*
         * / 执行SQL语句，返回影响的记录数
         * / </summary>
         * / <param name="SQLString">SQL语句</param>
         * / <returns>影响的记录数</returns>
         */
        public int ExecuteSql(string SQLString, params IDataParameter[] iParms)
        {
            using (System.Data.IDbConnection iConn = this.GetConnection())
            {
                System.Data.IDbCommand iCmd = GetCommand();
                {
                    try
                    {
                        PrepareCommand(out iCmd, iConn, null, SQLString, iParms);
                        int rows = iCmd.ExecuteNonQuery();
                        iCmd.Parameters.Clear();
                        return (rows);
                    }
                    catch (System.Exception E)
                    {
                        throw new Exception(E.Message);
                    }
                    finally
                    {
                        iCmd.Dispose();
                        if (iConn.State != ConnectionState.Closed)
                        {
                            iConn.Close();
                        }
                    }
                }
            }
        }


        /**/
        /* / <summary> */
        /*
         * / 执行多条SQL语句，实现数据库事务。
         * / </summary>
         * / <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
         */
        public void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (System.Data.IDbConnection iConn = this.GetConnection())
            {
                iConn.Open();
                using (IDbTransaction iTrans = iConn.BeginTransaction())
                {
                    System.Data.IDbCommand iCmd = GetCommand();
                    try
                    {
                        /* 循环 */
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            IDataParameter[] iParms = (IDataParameter[])myDE.Value;
                            PrepareCommand(out iCmd, iConn, iTrans, cmdText, iParms);
                            int val = iCmd.ExecuteNonQuery();
                            iCmd.Parameters.Clear();
                        }
                        iTrans.Commit();
                    }
                    catch
                    {
                        iTrans.Rollback();
                        throw;
                    }
                    finally
                    {
                        iCmd.Dispose();
                        if (iConn.State != ConnectionState.Closed)
                        {
                            iConn.Close();
                        }
                    }
                }
            }
        }


        /**/
        /* / <summary> */
        /*
         * / 执行一条计算查询结果语句，返回查询结果（object）。
         * / </summary>
         * / <param name="SQLString">计算查询结果语句</param>
         * / <returns>查询结果（object）</returns>
         */
        public object GetSingle(string SQLString, params IDataParameter[] iParms)
        {
            using (System.Data.IDbConnection iConn = this.GetConnection())
            {
                System.Data.IDbCommand iCmd = GetCommand();
                {
                    try
                    {
                        PrepareCommand(out iCmd, iConn, null, SQLString, iParms);
                        object obj = iCmd.ExecuteScalar();
                        iCmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return (null);
                        }
                        else
                        {
                            return (obj);
                        }
                    }
                    catch (System.Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                    finally
                    {
                        iCmd.Dispose();
                        if (iConn.State != ConnectionState.Closed)
                        {
                            iConn.Close();
                        }
                    }
                }
            }
        }


        /**/
        /* / <summary> */
        /*
         * / 执行查询语句，返回IDataReader
         * / </summary>
         * / <param name="strSQL">查询语句</param>
         * / <returns> IDataReader </returns>
         */
        public IDataReader ExecuteReader(string SQLString, params IDataParameter[] iParms)
        {
            System.Data.IDbConnection iConn = this.GetConnection();
            {
                System.Data.IDbCommand iCmd = GetCommand();
                {
                    try
                    {
                        PrepareCommand(out iCmd, iConn, null, SQLString, iParms);
                        System.Data.IDataReader iReader = iCmd.ExecuteReader();
                        iCmd.Parameters.Clear();
                        return (iReader);
                    }
                    catch (System.Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                    finally
                    {
                        iCmd.Dispose();
                        if (iConn.State != ConnectionState.Closed)
                        {
                            iConn.Close();
                        }
                    }
                }
            }
        }


        /**/
        /* / <summary> */
        /*
         * / 执行查询语句，返回DataSet
         * / </summary>
         * / <param name="SQLString">查询语句</param>
         * / <returns>DataSet</returns>
         */
        public DataSet Query(string sqlString, params IDataParameter[] iParms)
        {
            using (System.Data.IDbConnection iConn = this.GetConnection())
            {
                IDbCommand iCmd = GetCommand();
                {
                    PrepareCommand(out iCmd, iConn, null, sqlString, iParms);
                    try
                    {
                        IDataAdapter iAdapter = this.GetAdapater(sqlString, iConn);
                        DataSet ds = new DataSet();
                        iAdapter.Fill(ds);
                        iCmd.Parameters.Clear();
                        return (ds);
                    }
                    catch (System.Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        iCmd.Dispose();
                        if (iConn.State != ConnectionState.Closed)
                        {
                            iConn.Close();
                        }
                    }
                }
            }
        }


        /**/
        /* / <summary> */
        /*
         * / 初始化Command
         * / </summary>
         * / <param name="iCmd"></param>
         * / <param name="iConn"></param>
         * / <param name="iTrans"></param>
         * / <param name="cmdText"></param>
         * / <param name="iParms"></param>
         */
        private void PrepareCommand(out IDbCommand iCmd, IDbConnection iConn, System.Data.IDbTransaction iTrans, string cmdText, IDataParameter[] iParms)
        {
            if (iConn.State != ConnectionState.Open)
                iConn.Open();
            iCmd = this.GetCommand();
            iCmd.Connection = iConn;
            iCmd.CommandText = cmdText;
            if (iTrans != null)
                iCmd.Transaction = iTrans;
            iCmd.CommandType = CommandType.Text; /* cmdType; */
            if (iParms != null)
            {
                foreach (IDataParameter parm in iParms)
                    iCmd.Parameters.Add(parm);
            }
        }


        #endregion

        #region 存储过程操作

        /**/
        /* / <summary> */
        /*
         * / 执行存储过程
         * / </summary>
         * / <param name="storedProcName">存储过程名</param>
         * / <param name="parameters">存储过程参数</param>
         * / <returns>SqlDataReader</returns>
         */
        public SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            System.Data.IDbConnection iConn = this.GetConnection();
            {
                iConn.Open();

                using (SqlCommand sqlCmd = BuildQueryCommand(iConn, storedProcName, parameters))
                {
                    return (sqlCmd.ExecuteReader(CommandBehavior.CloseConnection));
                }
            }
        }


        /**/
        /* / <summary> */
        /*
         * / 执行存储过程
         * / </summary>
         * / <param name="storedProcName">存储过程名</param>
         * / <param name="parameters">存储过程参数</param>
         * / <param name="tableName">DataSet结果中的表名</param>
         * / <returns>DataSet</returns>
         */
        public DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (System.Data.IDbConnection iConn = this.GetConnection())
            {
                DataSet dataSet = new DataSet();
                iConn.Open();
                System.Data.IDataAdapter iDA = this.GetAdapater();
                iDA = this.GetAdapater(BuildQueryCommand(iConn, storedProcName, parameters));

                ((SqlDataAdapter)iDA).Fill(dataSet, tableName);
                if (iConn.State != ConnectionState.Closed)
                {
                    iConn.Close();
                }
                return (dataSet);
            }
        }


        /**/
        /* / <summary> */
        /*
         * / 执行存储过程
         * / </summary>
         * / <param name="storedProcName">存储过程名</param>
         * / <param name="parameters">存储过程参数</param>
         * / <param name="tableName">DataSet结果中的表名</param>
         * / <param name="startIndex">开始记录索引</param>
         * / <param name="pageSize">页面记录大小</param>
         * / <returns>DataSet</returns>
         */
        public DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, int startIndex, int pageSize, string tableName)
        {
            using (System.Data.IDbConnection iConn = this.GetConnection())
            {
                DataSet dataSet = new DataSet();
                iConn.Open();
                System.Data.IDataAdapter iDA = this.GetAdapater();
                iDA = this.GetAdapater(BuildQueryCommand(iConn, storedProcName, parameters));

                ((SqlDataAdapter)iDA).Fill(dataSet, startIndex, pageSize, tableName);
                if (iConn.State != ConnectionState.Closed)
                {
                    iConn.Close();
                }
                return (dataSet);
            }
        }


        /**/
        /* / <summary> */
        /*
         * / 执行存储过程 填充已经存在的DataSet数据集
         * / </summary>
         * / <param name="storeProcName">存储过程名称</param>
         * / <param name="parameters">存储过程参数</param>
         * / <param name="dataSet">要填充的数据集</param>
         * / <param name="tablename">要填充的表名</param>
         * / <returns></returns>
         */
        public DataSet RunProcedure(string storeProcName, IDataParameter[] parameters, DataSet dataSet, string tableName)
        {
            using (System.Data.IDbConnection iConn = this.GetConnection())
            {
                iConn.Open();
                System.Data.IDataAdapter iDA = this.GetAdapater();
                iDA = this.GetAdapater(BuildQueryCommand(iConn, storeProcName, parameters));

                ((SqlDataAdapter)iDA).Fill(dataSet, tableName);

                if (iConn.State != ConnectionState.Closed)
                {
                    iConn.Close();
                }

                return (dataSet);
            }
        }


        /**/
        /* / <summary> */
        /*
         * / 执行存储过程并返回受影响的行数
         * / </summary>
         * / <param name="storedProcName"></param>
         * / <param name="parameters"></param>
         * / <returns></returns>
         */
        public int RunProcedureNoQuery(string storedProcName, IDataParameter[] parameters)
        {
            int result = 0;
            using (System.Data.IDbConnection iConn = this.GetConnection())
            {
                iConn.Open();
                using (SqlCommand scmd = BuildQueryCommand(iConn, storedProcName, parameters))
                {
                    result = scmd.ExecuteNonQuery();
                }

                if (iConn.State != ConnectionState.Closed)
                {
                    iConn.Close();
                }
            }

            return (result);
        }


        public string RunProcedureExecuteScalar(string storeProcName, IDataParameter[] parameters)
        {
            string result = string.Empty;
            using (System.Data.IDbConnection iConn = this.GetConnection())
            {
                iConn.Open();
                using (SqlCommand scmd = BuildQueryCommand(iConn, storeProcName, parameters))
                {
                    object obj = scmd.ExecuteScalar();
                    if (obj == null)
                        result = null;
                    else
                        result = obj.ToString();
                }

                if (iConn.State != ConnectionState.Closed)
                {
                    iConn.Close();
                }
            }

            return (result);
        }

        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="iConn">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private SqlCommand BuildQueryCommand(IDbConnection iConn, string storedProcName, IDataParameter[] parameters)
        {
            IDbCommand iCmd = GetCommand(storedProcName, iConn);
            iCmd.CommandType = CommandType.StoredProcedure;
            if (parameters == null)
            {
                return ((SqlCommand)iCmd);
            }
            foreach (IDataParameter parameter in parameters)
            {
                iCmd.Parameters.Add(parameter);
            }
            return ((SqlCommand)iCmd);
        }


        /**/
        /* / <summary> */
        /*
         * / 执行存储过程，返回影响的行数
         * / </summary>
         * / <param name="storedProcName">存储过程名</param>
         * / <param name="parameters">存储过程参数</param>
         * / <param name="rowsAffected">影响的行数</param>
         * / <returns></returns>
         */
        public int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (System.Data.IDbConnection iConn = this.GetConnection())
            {
                int result;
                iConn.Open();
                using (SqlCommand sqlCmd = BuildIntCommand(iConn, storedProcName, parameters))
                {
                    rowsAffected = sqlCmd.ExecuteNonQuery();
                    result = (int)sqlCmd.Parameters["ReturnValue"].Value;

                    if (iConn.State != ConnectionState.Closed)
                    {
                        iConn.Close();
                    }
                    return (result);
                }
            }
        }


        /**/
        /* / <summary> */
        /*
         * / 创建 SqlCommand 对象实例(用来返回一个整数值)
         * / </summary>
         * / <param name="storedProcName">存储过程名</param>
         * / <param name="parameters">存储过程参数</param>
         * / <returns>SqlCommand 对象实例</returns>
         */
        private SqlCommand BuildIntCommand(IDbConnection iConn, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand sqlCmd = BuildQueryCommand(iConn, storedProcName, parameters);
            sqlCmd.Parameters.Add(new SqlParameter("ReturnValue",
                                 SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                                 false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return (sqlCmd);
        }


        #endregion
    }
}