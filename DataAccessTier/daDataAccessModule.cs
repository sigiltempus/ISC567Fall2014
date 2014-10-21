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
    public class daDataAccessModule 
    {

        #region " Error handling properties "
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
        public static int pInsertedUserID;
        public int InsertedUserID() 
        {
            return pInsertedUserID;
        }
        #endregion


        #region " Refactored code "
        // Refactoring for fun, profit, sanity, and the DRY principle

        /// <summary>
        /// Execute a given stored procedure that will not return a result.
        /// </summary>
        /// <param name="parameters">Array of SQL parameters</param>
        /// <param name="procedurename">Name of stored procedure to execute</param>
        /// <param name="connectionstring">Connection string to use</param>
        public void ExecuteWithoutResult(SqlParameter[] parameters, string procedurename, string connectionstring) {
            pTransactionSuccessful = true;
            try 
            {
                SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, procedurename, parameters);
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
        }

        /// <summary>
        /// Execute a given stored procedure that will return a dataset.
        /// </summary>
        /// <param name="parameters">Array of SQL parameters</param>
        /// <param name="procedurename">Name of stored procedure to execute</param>
        /// <param name="connectionstring">Connection string to use</param>
        /// <param name="tablename">Optional name of the datatable.</param>
        /// <returns>A datatable with the result set. Will be empty if the transaction failed.</returns>
        public DataTable GetTable(string procedurename, string connectionstring, string tablename = "Result", SqlParameter[] parameters = null) 
        {
            pTransactionSuccessful = true;
            DataTable result = new DataTable(tablename);
            try 
            {
                DataSet dsUserProfile = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, procedurename, parameters);
                result = dsUserProfile.Tables[0];
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
            return result;
        }

        #endregion
    }
}
