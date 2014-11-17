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
   public class dasponsor
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
        public DataTable GetSponsorList(string connectionString, int societyid)
        {
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@societyid", SqlDbType.Int);
            arParms[0].Value = societyid;
            pTransactionSuccessful = true;

            DataTable dtsponsorList = new DataTable("sponsorList");

            try
            {
                DataSet dssponsorList = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetsponsorList", arParms);
                dtsponsorList = dssponsorList.Tables[0];
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

            return dtsponsorList;
        }
        public DataTable GetSponsorInfo(string connectionString, int sponsorid)
        {
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@sponsorid", SqlDbType.Int);
            arParms[0].Value = sponsorid;
            pTransactionSuccessful = true;

            DataTable dtsponsorinfo = new DataTable("sponsorinfo");

            try
            {
                DataSet dssponsorinfo = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetsponsorsInfo", arParms);
                dtsponsorinfo = dssponsorinfo.Tables[0];
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

            return dtsponsorinfo;
        }

        public void insertSponsor(int societyid, int curriculumid, int sponsored_date, string connectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@societyid", SqlDbType.NVarChar);
            arParms[0].Value = societyid;
            arParms[1] = new SqlParameter("@curriculumid", SqlDbType.NVarChar);
            arParms[1].Value = curriculumid;
            arParms[2] = new SqlParameter("@sponsored_date", SqlDbType.NVarChar);
            arParms[2].Value = sponsored_date;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Insertsponsor", arParms);
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
        public void editSponsorInfo(int sponsorid,int societyid, int curriculumid, int sponsored_date, string connectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[4];

            arParms[0] = new SqlParameter("@societyid", SqlDbType.NVarChar);
            arParms[0].Value = societyid;
            arParms[1] = new SqlParameter("@curriculumid", SqlDbType.NVarChar);
            arParms[1].Value = curriculumid;
            arParms[2] = new SqlParameter("@sponsored_date", SqlDbType.NVarChar);
            arParms[2].Value = sponsored_date;
            arParms[3] = new SqlParameter("@sponsorid", SqlDbType.NVarChar);
            arParms[3].Value = sponsorid;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "EditsponsorInfo", arParms);
            }
            catch (SqlException UpdateError)
            {
                pErrorMessage = UpdateError.Message.ToString();
                pErrorNumber = UpdateError.Number;
                pErrorClass = UpdateError.Class;
                pErrorState = UpdateError.State;
                pErrorLineNumber = UpdateError.LineNumber;

                pTransactionSuccessful = false;
            }
        }
    
   }
}
