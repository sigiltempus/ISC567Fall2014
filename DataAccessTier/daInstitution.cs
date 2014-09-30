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
    public class daInstitution
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
        public static int pInsertedInstitutionID;
        public int InsertedInstitutionID()
        {
            return pInsertedInstitutionID;
        }

        #endregion

        #region " Read methods "
                
        public DataTable GetInstitutionList(string ConnectionString)
        {
            pTransactionSuccessful = true;

            DataTable dtInstName = new DataTable("InstName");

            try
            {
                DataSet dsInstName = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sp_GetInstitutionList");
                dtInstName = dsInstName.Tables[0];
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
            return dtInstName;
        }

        public DataTable GetInstitutionPeopleList(int institutionId, string connectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@institutionId", SqlDbType.Int);
            arParms[0].Value = institutionId;

            pTransactionSuccessful = true;

            DataTable dtInstitutionPeopleInfo = new DataTable("InstitutionPeople");

            try
            {
                DataSet dsInstitutionPeopleInfo = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_GetInstitutionPeopleListById", arParms);
                dtInstitutionPeopleInfo = dsInstitutionPeopleInfo.Tables[0];
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
            return dtInstitutionPeopleInfo;
        }
        
        public DataTable GetExamStatus(string connectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[0];

            pTransactionSuccessful = true;

            DataTable dtExamStatus = new DataTable("ExamStatus");

            try
            {
                DataSet dsScheduledExamsInfo = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_GetExamStatus", arParms);
                dtExamStatus = dsScheduledExamsInfo.Tables[0];
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
            return dtExamStatus;
        }
        
        public DataTable GetInstitutionExamByStatus(int institutionId, int examStatusId, string connectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@institutionId", SqlDbType.Int);
            arParms[0].Value = institutionId;
            arParms[1] = new SqlParameter("@examStatusId", SqlDbType.Int);
            arParms[1].Value = examStatusId;

            pTransactionSuccessful = true;

            DataTable dtInstitutionExamInfo = new DataTable("ExamInfo");

            try
            {
                DataSet dsScheduledExamsInfo = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_GetInstitutionExamByStatus", arParms);
                dtInstitutionExamInfo = dsScheduledExamsInfo.Tables[0];
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
            return dtInstitutionExamInfo;
        }

        public DataTable GetExamListByInstitutionId(int InstitutionID, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@InstitutionID", SqlDbType.Int);
            arParms[0].Value = InstitutionID;

            pTransactionSuccessful = true;

            DataTable dtExamInfo = new DataTable("ExamInfo");

            try
            {
                DataSet dsExamInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sp_GetExamListByInstitutionId", arParms);
                dtExamInfo = dsExamInfo.Tables[0];
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
            return dtExamInfo;
        }

        public DataTable GetNonScheduledExamList(int InstitutionID, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@InstitutionID", SqlDbType.Int);
            arParms[0].Value = InstitutionID;

            pTransactionSuccessful = true;

            DataTable dtNonScheduledExamInfo = new DataTable("NonScheduledExam");

            try
            {
                DataSet dsNonScheduledExamInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sp_GetNonScheduledExamList", arParms);
                dtNonScheduledExamInfo = dsNonScheduledExamInfo.Tables[0];
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
            return dtNonScheduledExamInfo;
        }

        public DataTable GetScheduledExamInfoById(int institutionId, int scheduledExamId, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@institutionId", SqlDbType.Int);
            arParms[0].Value = institutionId;
            arParms[1] = new SqlParameter("@scheduledexamId", SqlDbType.Int);
            arParms[1].Value = scheduledExamId;

            pTransactionSuccessful = true;

            DataTable dtScheduleExamInfo = new DataTable("ScheduleExamInfo");

            try
            {
                DataSet dsScheduleExamInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sp_GetScheduledExamInfoById", arParms);
                dtScheduleExamInfo = dsScheduleExamInfo.Tables[0];
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
            return dtScheduleExamInfo;
        }

        public DataTable GetRosterByScheduledExamId(int scheduledExamId, string connectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@scheduledExamId", SqlDbType.Int);
            arParms[0].Value = scheduledExamId;

            pTransactionSuccessful = true;

            DataTable dtExamTakersInfo = new DataTable("ExamTakersListInfo");

            try
            {
                DataSet dsExamTakersInfo = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_GetRosterByScheduledExamId", arParms);
                dtExamTakersInfo = dsExamTakersInfo.Tables[0];
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
            return dtExamTakersInfo;
        }

        #endregion

        # region " Upsert Methods "

        // Call this method with correct parameters to add or update the person and relative institutionpeople table
        public void AddEditScheduledExam(int scheduledExamId,int examid,string examname,DateTime examDate,DateTime examStartTime,DateTime examEndTime,
                                         string examlocation,int institutionpeopleid,string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[8];

            arParms[0] = new SqlParameter("@scheduledExamId", SqlDbType.Int);
            arParms[0].Value = scheduledExamId;
            arParms[1] = new SqlParameter("@institutionpeopleid", SqlDbType.Int);
            arParms[1].Value = institutionpeopleid;
            arParms[2] = new SqlParameter("@examid", SqlDbType.Int);
            arParms[2].Value = examid;
            arParms[3] = new SqlParameter("@examname", SqlDbType.NVarChar);
            arParms[3].Value = examname;
            arParms[4] = new SqlParameter("@examDate", SqlDbType.DateTime);
            arParms[4].Value = examDate;
            arParms[5] = new SqlParameter("@examStartTime", SqlDbType.DateTime);
            arParms[5].Value = examStartTime;
            arParms[6] = new SqlParameter("@examEndTime", SqlDbType.DateTime);
            arParms[6].Value = examEndTime;
            arParms[7] = new SqlParameter("@examlocation", SqlDbType.NVarChar);
            arParms[7].Value = examlocation;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "sp_UpsertScheduledExam", arParms);
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

        #endregion
    }
}
