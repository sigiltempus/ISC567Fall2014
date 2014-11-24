using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace DataAccessTier
{
  public  class dasociety
    {
        #region " Public properties "

        public static bool pTransactionSuccessful;
        public bool TransactionSuccessful()
        {
            return pTransactionSuccessful;
        }
        public static string pErrorMessage;
        public string ErrorMessage()
        {
            return pErrorMessage;
        }
        public static int pErrorNumber;
        public int ErrorNumber()
        {
            return pErrorNumber;
        }
        public static int pErrorClass;
        public int ErrorClass()
        {
            return pErrorClass;
        }
        public static int pErrorState;
        public int ErrorState()
        {
            return pErrorState;
        }
        public static int pErrorLineNumber;
        public int ErrorLineNumber()
        {
            return pErrorLineNumber;
        }
        public static bool pIsFound;
        public bool IsFound()
        {
            return pIsFound;
        }
        public static int pInsertedPersonID;
        public int InsertedPersonID()
        {
            return pInsertedPersonID;
        }
        #endregion

      public DataTable GetsocietyList(string connectionString)
      {
          pTransactionSuccessful = true;

          DataTable dtsocietyList = new DataTable("societyList");

          try
          {
              DataSet dsProgramList = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetsocietyList");
              dtsocietyList = dsProgramList.Tables[0];
          }
          catch (SqlException ReadError)
          {
              pErrorMessage = ReadError.Message.ToString();
              pErrorNumber = ReadError.Number;
              pErrorClass = ReadError.Class;
              pErrorState = ReadError.State;
              pErrorLineNumber = ReadError.LineNumber;

              pTransactionSuccessful = false;
          }

          return dtsocietyList;
      }

      public DataTable GetsocietyInfo(int societyId, string connectionString)
      {
          // Set up parameters in parameter array 
          SqlParameter[] arParms = new SqlParameter[1];

          arParms[0] = new SqlParameter("@societyid", SqlDbType.Int);
          arParms[0].Value = societyId;


          pTransactionSuccessful = true;

          DataTable dtsocietyInfo = new DataTable("societyInfo");

          try
          {
              DataSet dssocietyInfo = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetsocietyInfo", arParms);
              dtsocietyInfo = dssocietyInfo.Tables[0];
          }
          catch (SqlException ReadError)
          {
              pErrorMessage = ReadError.Message.ToString();
              pErrorNumber = ReadError.Number;
              pErrorClass = ReadError.Class;
              pErrorState = ReadError.State;
              pErrorLineNumber = ReadError.LineNumber;

              pTransactionSuccessful = false;
          }
          return dtsocietyInfo;
      }


      public void insertsocietyinfo(string shortName, string longName,string connectionString)
      {
          // Set up parameters in parameter array 
          SqlParameter[] arParms = new SqlParameter[2];

          
          arParms[0] = new SqlParameter("@society_shortname", SqlDbType.NVarChar);
          arParms[0].Value = shortName;
          arParms[1] = new SqlParameter("@society_longname", SqlDbType.NVarChar);
          arParms[1].Value = longName;
          
          pTransactionSuccessful = true;

          try
          {
              SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Insertsociety", arParms);
          }
          catch (SqlException InsertError)
          {
              pErrorMessage = InsertError.Message.ToString();
              pErrorNumber = InsertError.Number;
              pErrorClass = InsertError.Class;
              pErrorState = InsertError.State;
              pErrorLineNumber = InsertError.LineNumber;

              pTransactionSuccessful = false;
          }
      }

      public void EditsocietyInformation(int societyId, string shortName, string longName, string connectionString)
      {
          // Set up parameters in parameter array 
          SqlParameter[] arParms = new SqlParameter[3];

          arParms[0] = new SqlParameter("@societyid", SqlDbType.NVarChar);
          arParms[0].Value = societyId;
          arParms[1] = new SqlParameter("@society_shortname", SqlDbType.NVarChar);
          arParms[1].Value = shortName;
          arParms[2] = new SqlParameter("@society_longname", SqlDbType.NVarChar);
          arParms[2].Value = longName;

          pTransactionSuccessful = true;

          try
          {
              SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "EditsocietyInfo", arParms);
          }
          catch (SqlException InsertError)
          {
              pErrorMessage = InsertError.Message.ToString();
              pErrorNumber = InsertError.Number;
              pErrorClass = InsertError.Class;
              pErrorState = InsertError.State;
              pErrorLineNumber = InsertError.LineNumber;

              pTransactionSuccessful = false;
          }
      }
         
  }
}
