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
    public class daProvider
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
        public static int pInsertedProviderID;
        public int InsertedProviderID()
        {
            return pInsertedProviderID;
        }

        #endregion

        #region " Read methods "

        public DataTable GetProvidersList(string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[0];

            pTransactionSuccessful = true;

            DataTable dtProviderNames = new DataTable("ProviderList");

            try
            {
                DataSet dsProviderNames = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sp_GetProvidersList", arParms);
                dtProviderNames = dsProviderNames.Tables[0];
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
            return dtProviderNames;
        }

        //public DataTable GetProviderId(int providerid, string ConnectionString)
        //{
        //    // Set up parameters in parameter array 
        //    SqlParameter[] arParms = new SqlParameter[1];

        //    arParms[0] = new SqlParameter("@providerid", SqlDbType.Int);
        //    arParms[0].Value = providerid;

        //    pTransactionSuccessful = true;

        //    DataTable dtGetProviderId = new DataTable("GetProviderId");

        //    try
        //    {
        //        DataSet dsGetProviderId = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetProviderId", arParms);
        //        dtGetProviderId = dsGetProviderId.Tables[0];
        //    }
        //    catch (SqlException ReadError)
        //    {
        //        pErrorMessage = ReadError.Message.ToString();
        //        pErrorNumber = ReadError.Number;
        //        pErrorClass = ReadError.Class;
        //        pErrorState = ReadError.State;
        //        pErrorLineNumber = ReadError.LineNumber;

        //        pTransactionSuccessful = false;
        //    }
        //    return dtGetProviderId;
        //}

        #endregion
    }
}
