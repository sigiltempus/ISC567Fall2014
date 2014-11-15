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
    public class daUser
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

        #region " Read methods "



        public DataTable GetAnswer(int examitemid, int rosterid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@examitemid", SqlDbType.Int);
            arParms[0].Value = examitemid;
            arParms[1] = new SqlParameter("@rosterid", SqlDbType.Int);
            arParms[1].Value = rosterid;

            pTransactionSuccessful = true;

            DataTable dtExamInfo = new DataTable("Exam");

            try
            {
                DataSet dsExamInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sp_GetAnswer", arParms);
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


        public void ValidateUser(String username, String password, String ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@username", SqlDbType.VarChar);
            arParms[0].Value = username;
            arParms[1] = new SqlParameter("@password", SqlDbType.VarChar);
            arParms[1].Value = password;
            arParms[2] = new SqlParameter("@IsFound", SqlDbType.Bit);
            arParms[2].Direction = ParameterDirection.Output;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "sp_ValidateUser", arParms);
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
            if (pTransactionSuccessful == true)
            {
                pIsFound = (bool)arParms[2].Value;
            }
            else
            {
                pIsFound = false;
            }

        }

        public DataTable GetUserProfileByID(int personid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@personid", SqlDbType.Int);
            arParms[0].Value = personid;


            pTransactionSuccessful = true;

            DataTable dtUserInfo = new DataTable("UserInfo");

            try
            {
                DataSet dsUserInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sp_GetUserProfileByID", arParms);
                dtUserInfo = dsUserInfo.Tables[0];
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
            return dtUserInfo;
        }

        public DataTable GetUserProfile(String username, String password, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@username", SqlDbType.VarChar);
            arParms[0].Value = username;
            arParms[1] = new SqlParameter("@password", SqlDbType.VarChar);
            arParms[1].Value = password;

            pTransactionSuccessful = true;

            DataTable dtUserInfo = new DataTable("UserInfo");

            try
            {
                DataSet dsUserInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetUserProfile", arParms);
                dtUserInfo = dsUserInfo.Tables[0];
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
            return dtUserInfo;
        }


        public DataTable GetProviderNames(string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[0];

            pTransactionSuccessful = true;

            DataTable dtProviderNames = new DataTable("GetProviderNames");

            try
            {
                DataSet dsProviderNames = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetProviderNames", arParms);
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


        public DataTable GetProviderListforEdit(int providerid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@providerid", SqlDbType.Int);
            arParms[0].Value = providerid;


            pTransactionSuccessful = true;

            DataTable dtInstInfo = new DataTable("InstInfo");

            try
            {
                DataSet dsInstInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sp_GetProviderListforEdit", arParms);
                dtInstInfo = dsInstInfo.Tables[0];
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
            return dtInstInfo;
        }


        public DataTable GetPersonList(string ConnectionString)
        {
            pTransactionSuccessful = true;

            DataTable dtPersonList = new DataTable("PersonList");

            try
            {
                DataSet dsPersonList = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sp_GetPersonList");
                dtPersonList = dsPersonList.Tables[0];
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

            return dtPersonList;
        }

        public DataTable GetInstitutionName(int Institutionid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@Institutionid", SqlDbType.Int);
            arParms[0].Value = Institutionid;


            pTransactionSuccessful = true;

            DataTable dtInstInfo = new DataTable("InstInfo");

            try
            {
                DataSet dsInstInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetInstitutionName", arParms);
                dtInstInfo = dsInstInfo.Tables[0];
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
            return dtInstInfo;
        }

        public DataTable GetInstitutionNames(string ConnectionString)
        {
            // Set up parameters in parameter array 
            //SqlParameter[] arParms = new SqlParameter[0];

            //arParms[0] = new SqlParameter("@Institutionid", SqlDbType.Int);
            //arParms[0].Value = Institutionid;


            pTransactionSuccessful = true;

            DataTable dtInstName = new DataTable("InstName");

            try
            {
                DataSet dsInstName = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetInstitutionNames");
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

        public DataTable GetAllScheduleExams(int InstitutionID, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@InstitutionID", SqlDbType.Int);
            arParms[0].Value = InstitutionID;


            pTransactionSuccessful = true;

            DataTable dtScheduleExamsInfo = new DataTable("AllScheduleExamsInfo");

            try
            {
                DataSet dsScheduleExamsInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetAllScheduleExams", arParms);
                dtScheduleExamsInfo = dsScheduleExamsInfo.Tables[0];
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
            return dtScheduleExamsInfo;
        }

        public DataTable GetInProgressScheduleExams(int InstitutionID, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@InstitutionID", SqlDbType.Int);
            arParms[0].Value = InstitutionID;


            pTransactionSuccessful = true;

            DataTable dtScheduleExamsInfo = new DataTable("ScheduleExamsInfo");

            try
            {
                DataSet dsScheduleExamsInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetInProgressScheduleExams", arParms);
                dtScheduleExamsInfo = dsScheduleExamsInfo.Tables[0];
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
            return dtScheduleExamsInfo;
        }

        public DataTable GetExamTakersList(int scheduledexamid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@scheduledexamid", SqlDbType.Int);
            arParms[0].Value = scheduledexamid;


            pTransactionSuccessful = true;

            DataTable dtExamTakersInfo = new DataTable("ExamTakersListInfo");

            try
            {
                DataSet dsExamTakersInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetExamTakersList", arParms);
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

        public DataTable GetScheduleExamInfo(int InstitutionID, int scheduledexamid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@InstitutionID", SqlDbType.Int);
            arParms[0].Value = InstitutionID;
            arParms[1] = new SqlParameter("@scheduledexamid", SqlDbType.Int);
            arParms[1].Value = scheduledexamid;

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

        public DataTable GetProviderId(int providerid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@providerid", SqlDbType.Int);
            arParms[0].Value = providerid;



            pTransactionSuccessful = true;

            DataTable dtGetProviderId = new DataTable("GetProviderId");

            try
            {
                DataSet dsGetProviderId = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetProviderId", arParms);
                dtGetProviderId = dsGetProviderId.Tables[0];
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
            return dtGetProviderId;
        }

        public DataTable GetInstitutionStaffByInstitutionID(int institutionid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@institutionid", SqlDbType.Int);
            arParms[0].Value = institutionid;


            pTransactionSuccessful = true;

            DataTable dtUserInfo = new DataTable("UserInfo");

            try
            {
                DataSet dsUserInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetInstitutionStaffByInstitutionID", arParms);
                dtUserInfo = dsUserInfo.Tables[0];
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
            return dtUserInfo;

        }

        public void ValidateEmail(String email, String ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@email", SqlDbType.NVarChar);
            arParms[0].Value = email;
            //arParms[1] = new SqlParameter("@password", SqlDbType.VarChar);
            //arParms[1].Value = password;
            arParms[1] = new SqlParameter("@IsFound", SqlDbType.Bit);
            arParms[1].Direction = ParameterDirection.Output;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "ValidateEmail", arParms);
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
            if (pTransactionSuccessful == true)
            {
                pIsFound = (bool)arParms[1].Value;
            }
            else
            {
                pIsFound = false;
            }

        }

        public DataTable GetInstitutionPeopleByPersonID(int personid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@personid", SqlDbType.Int);
            arParms[0].Value = personid;


            pTransactionSuccessful = true;

            DataTable dtPersonInfo = new DataTable("GetInstitutionPeopleByPersonID");

            try
            {
                DataSet dsPersonInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetInstitutionPeopleByPersonID", arParms);
                dtPersonInfo = dsPersonInfo.Tables[0];
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
            return dtPersonInfo;

        }

        public DataTable GetPersonIDByEmail(string email, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@email", SqlDbType.NVarChar);
            arParms[0].Value = email;

            pTransactionSuccessful = true;

            DataTable dtGetPersonIDByEmail = new DataTable("GetPersonIDByEmail");

            try
            {
                DataSet dsGetPersonIDByEmail = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetPersonIDByEmail", arParms);
                dtGetPersonIDByEmail = dsGetPersonIDByEmail.Tables[0];
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
            return dtGetPersonIDByEmail;
        }


        public DataTable getPersonAsExamProviderStaff(int examproviderstaffid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@examproviderstaffid", SqlDbType.Int);
            arParms[0].Value = examproviderstaffid;


            pTransactionSuccessful = true;

            DataTable dtproviderStaff = new DataTable("providerStaff");

            try
            {
                DataSet dsproviderStaff = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sp_getPersonAsExamProviderStaff", arParms);
                dtproviderStaff = dsproviderStaff.Tables[0];
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
            return dtproviderStaff;
        }



        public DataTable GetRosterlist(int PersonID, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@PersonID", SqlDbType.Int);
            arParms[0].Value = PersonID;

            pTransactionSuccessful = true;

            DataTable dtRosterList = new DataTable("RosterList");

            try
            {
                DataSet dsRosterList = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetRosterList", arParms);
                dtRosterList = dsRosterList.Tables[0];
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
            return dtRosterList;
        }

        public DataTable GetCompletedExams(int examid, string examname, string examdate, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@examid", SqlDbType.Int);
            arParms[0].Value = examid;
            arParms[1] = new SqlParameter("@examname", SqlDbType.NVarChar);
            arParms[1].Value = examname;
            arParms[2] = new SqlParameter("@examdate", SqlDbType.NVarChar);
            arParms[2].Value = examdate;

            pTransactionSuccessful = true;

            DataTable dtGetCompletedExams = new DataTable("GetCompletedExams");

            try
            {
                DataSet dsGetCompletedExams = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetCompletedExams", arParms);
                dtGetCompletedExams = dsGetCompletedExams.Tables[0];
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
            return dtGetCompletedExams;
        }


        public DataTable getExamProviderStaffName(int examproviderstaffid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@examProviderStaffId", SqlDbType.Int);
            arParms[0].Value = examproviderstaffid;

            pTransactionSuccessful = true;

            DataTable dtGetExamProviderStaffNames = new DataTable("getExamProviderStaffNames");

            try
            {
                DataSet dsGetExamProviderStaffNames = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sp_getExamProviderStaffName", arParms);
                dtGetExamProviderStaffNames = dsGetExamProviderStaffNames.Tables[0];
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
            return dtGetExamProviderStaffNames;
        }


        public void addOrUpdateProviderStaff(int examproviderstaffid, int providerid, int personid, bool isEPSA, bool isDeveloper, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[5];

            arParms[0] = new SqlParameter("@examProviderStaffId", SqlDbType.Int);
            arParms[0].Value = examproviderstaffid;
            arParms[1] = new SqlParameter("@providerid", SqlDbType.Int);
            arParms[1].Value = providerid;
            arParms[2] = new SqlParameter("@personid", SqlDbType.Int);
            arParms[2].Value = personid;
            arParms[3] = new SqlParameter("@isEPSA", SqlDbType.Bit);
            arParms[3].Value = isEPSA;
            arParms[4] = new SqlParameter("@isdeveloper", SqlDbType.Bit);
            arParms[4].Value = isDeveloper;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "sp_AddorUpdateProviderStaff", arParms);
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

        //public DataTable GetExam(string ConnectionString)
        //{
        //    SqlParameter[] arParms = new SqlParameter[0];

        //    pTransactionSuccessful = true;

        //    DataTable dtExam = new DataTable("ExamList");

        //    try
        //    {
        //        DataSet dsRoleList = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetExam", arParms);
        //        dtExam = dsRoleList.Tables[0];
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
        //    return dtExam;
        //}

        public DataTable GetExambyID(int SEID, string ConnectionString)
        {
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@examid", SqlDbType.Int);
            arParms[0].Value = SEID;

            pTransactionSuccessful = true;

            DataTable dtExam = new DataTable("ExamList");

            try
            {
                DataSet dsRoleList = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetScheduleExambyID", arParms);
                dtExam = dsRoleList.Tables[0];
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
            return dtExam;
        }

        public void ScheduleExam(int PersonID, string examname, string status, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@PersonID", SqlDbType.Int);
            arParms[0].Value = PersonID;
            arParms[1] = new SqlParameter("@examname", SqlDbType.NVarChar);
            arParms[1].Value = examname;
            arParms[2] = new SqlParameter("@status", SqlDbType.NVarChar);
            arParms[2].Value = status;


            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "InsertScheduleExamForTaker", arParms);
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

        public DataTable GetExamProviderPeopleByProviderID(int providerid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@provider", SqlDbType.Int);
            arParms[0].Value = providerid;


            pTransactionSuccessful = true;

            DataTable dtProviderInfo = new DataTable("GetExamProviderPeoplebyProviderID");

            try
            {
                DataSet dsProviderInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetExamProviderPeoplebyProviderID", arParms);
                dtProviderInfo = dsProviderInfo.Tables[0];
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
            return dtProviderInfo;

        }

        public DataTable GetInstitutionPeopleId(int Personid, int Institutionid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@personid", SqlDbType.Int);
            arParms[0].Value = Personid;
            arParms[1] = new SqlParameter("@institutionid", SqlDbType.Int);
            arParms[1].Value = Institutionid;
            pTransactionSuccessful = true;

            DataTable dtInstitutionPeopleInfo = new DataTable("ExamInfo");

            try
            {
                DataSet dsInstitutionPeopleInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetInstitutionPeopleId", arParms);
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

        public DataTable GetExamList(int InstitutionID, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@InstitutionID", SqlDbType.Int);
            arParms[0].Value = InstitutionID;

            pTransactionSuccessful = true;

            DataTable dtExamInfo = new DataTable("ExamInfo");

            try
            {
                DataSet dsExamInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetExamList", arParms);
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

        public DataTable GetExamPermitStatusDetails(int InstitutionID, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@InstitutionID", SqlDbType.Int);
            arParms[0].Value = InstitutionID;


            pTransactionSuccessful = true;

            DataTable dtPermitExamsInfo = new DataTable("PermitExamsInfo");

            try
            {
                DataSet dsPermitExamsInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetExamPermitStatusDetails", arParms);
                dtPermitExamsInfo = dsPermitExamsInfo.Tables[0];
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
            return dtPermitExamsInfo;
        }

        public DataTable GetExam(string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[0];

            //arParms[0] = new SqlParameter("@Parameter1", SqlDbType.Int);
            //arParms[0].Value = Parameter1;

            pTransactionSuccessful = true;

            DataTable dtExam = new DataTable("ExamList");

            try
            {
                DataSet dsRoleList = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetExam", arParms);
                dtExam = dsRoleList.Tables[0];
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
            return dtExam;
        }

        public DataTable GetQuestionanswers(int examid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@examid", SqlDbType.Int);
            arParms[0].Value = examid;


            pTransactionSuccessful = true;

            DataTable dtExamInfo = new DataTable("Exam");

            try
            {
                DataSet dsExamInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sp_GetQuestions", arParms);
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

        public DataTable GetPersonDetails(int personid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@personid", SqlDbType.Int);
            arParms[0].Value = personid;

            pTransactionSuccessful = true;

            DataTable dtUserInfo = new DataTable("UserInfo");

            try
            {
                DataSet dsUserInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetPersonDetails", arParms);
                dtUserInfo = dsUserInfo.Tables[0];
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
            return dtUserInfo;
        }

        public DataTable GetPersonName(int personid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@personid", SqlDbType.Int);
            arParms[0].Value = personid;


            pTransactionSuccessful = true;

            DataTable dtUserInfo = new DataTable("PersonNameInfo");

            try
            {
                DataSet dsUserInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetPersonName", arParms);
                dtUserInfo = dsUserInfo.Tables[0];
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
            return dtUserInfo;
        }

        public DataTable GetExamDetails(int examid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@examid", SqlDbType.Int);
            arParms[0].Value = examid;


            pTransactionSuccessful = true;

            DataTable dtExamInfo = new DataTable("ExamInfo");

            try
            {
                DataSet dsExamInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ExamConfDetails", arParms);
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


        public DataTable getExamProviderStaff(int providerid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@providerid", SqlDbType.Int);
            arParms[0].Value = providerid;


            pTransactionSuccessful = true;

            DataTable dtproviderStaff = new DataTable("providerStaff");

            try
            {
                DataSet dsproviderStaff = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sp_getExamProviderStaff", arParms);
                dtproviderStaff = dsproviderStaff.Tables[0];
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
            return dtproviderStaff;
        }

        public DataTable getExamNames(int examid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@ExamID", SqlDbType.Int);
            arParms[0].Value = examid;

            pTransactionSuccessful = true;

            DataTable dtGetExamNames = new DataTable("dtGetExamNames");

            try
            {
                DataSet dsGetExamNames = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetExamDetailsForItemScreen", arParms);
                dtGetExamNames = dsGetExamNames.Tables[0];
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
            return dtGetExamNames;
        }

        public DataTable getExamNamesForEditScreen(int examid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@ExamID", SqlDbType.Int);
            arParms[0].Value = examid;

            pTransactionSuccessful = true;

            DataTable dtgetExamNamesForEditScreen = new DataTable("dtgetExamNamesForEditScreen");

            try
            {
                DataSet dsgetExamNamesForEditScreen = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetExamDetailsForItemEditScreen", arParms);
                dtgetExamNamesForEditScreen = dsgetExamNamesForEditScreen.Tables[0];
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
            return dtgetExamNamesForEditScreen;
        }
		

        public DataTable getPersonsNotAsProviderStaff(int providerid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@providerid", SqlDbType.Int);
            arParms[0].Value = providerid;


            pTransactionSuccessful = true;

            DataTable dtproviderStaff = new DataTable("personsList");

            try
            {
                DataSet dsproviderStaff = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sp_getPersonsNotAsProviderStaff", arParms);
                dtproviderStaff = dsproviderStaff.Tables[0];
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
            return dtproviderStaff;
        }



        //public DataTable GetProviderNames(string ConnectionString)
        //{
        //    // Set up parameters in parameter array 
        //    SqlParameter[] arParms = new SqlParameter[0];

        //    pTransactionSuccessful = true;

        //    DataTable dtProviderNames = new DataTable("GetProviderNames");

        //    try
        //    {
        //        DataSet dsProviderNames = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetProviderNames", arParms);
        //        dtProviderNames = dsProviderNames.Tables[0];
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
        //    return dtProviderNames;
        //}

        public DataTable GetList1(string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[0];

            pTransactionSuccessful = true;

            DataTable dtExamInfo = new DataTable("Key1");

            try
            {
                DataSet dsExamInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ListKey1", arParms);
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

        public DataTable GetList2(int key1, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@key1id", SqlDbType.VarChar);
            arParms[0].Value = key1;

            pTransactionSuccessful = true;

            DataTable dtExamInfo = new DataTable("Key2");

            try
            {
                DataSet dsExamInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ListKey2", arParms);
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

        public DataTable GetList3(int key1, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@key1id", SqlDbType.VarChar);
            arParms[0].Value = key1;

            pTransactionSuccessful = true;

            DataTable dtExamInfo = new DataTable("Key3");

            try
            {
                DataSet dsExamInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ListKey3", arParms);
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


        #endregion

        #region " Insert methods "

        public void InsertPersonRow(string firstname, string lastname, string address1, string address2, 
            string city, string st, string zip, string username, string password, string dob, string phonenumber1, 
            string phonenumber1type, string phonenumber2, string phonenumber2type, string email, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[15];

            arParms[0] = new SqlParameter("@firstname", SqlDbType.NVarChar);
            arParms[0].Value = firstname;
            arParms[1] = new SqlParameter("@lastname", SqlDbType.NVarChar);
            arParms[1].Value = lastname;

            arParms[2] = new SqlParameter("@address1", SqlDbType.NVarChar);
            arParms[2].Value = address1;
            arParms[3] = new SqlParameter("@address2", SqlDbType.NVarChar);
            arParms[3].Value = address2;
            arParms[4] = new SqlParameter("@city", SqlDbType.NVarChar);
            arParms[4].Value = city;
            arParms[5] = new SqlParameter("@st", SqlDbType.NVarChar);
            arParms[5].Value = st;
            arParms[6] = new SqlParameter("@zip", SqlDbType.NVarChar);
            arParms[6].Value = zip;
            arParms[7] = new SqlParameter("@username", SqlDbType.NChar);
            arParms[7].Value = username;
            arParms[8] = new SqlParameter("@password", SqlDbType.NChar);
            arParms[8].Value = password;

            arParms[9] = new SqlParameter("@dob", SqlDbType.NVarChar);
            arParms[9].Value = dob;
            arParms[10] = new SqlParameter("@phonenumber1", SqlDbType.NVarChar);
            arParms[10].Value = phonenumber1;
            arParms[11] = new SqlParameter("@phonenumber1type", SqlDbType.NVarChar);
            arParms[11].Value = phonenumber1type;
            arParms[12] = new SqlParameter("@phonenumber2", SqlDbType.NVarChar);
            arParms[12].Value = phonenumber2;
            arParms[13] = new SqlParameter("@phonenumber2type", SqlDbType.NVarChar);
            arParms[13].Value = phonenumber2type;

            arParms[14] = new SqlParameter("@email", SqlDbType.NVarChar);
            arParms[14].Value = email;

            //Example of an output paramter
            // arParms[n] = new SqlParameter("@Paramtern", SqlDbType.Bit);
            // arParms[n].Direction = ParameterDirection.Output;
            //Remember to adjust the array dimension when adding or subtracting elements.

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "InsertPerson", arParms);
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

            //If using output paramters
            //pSomeParameter = (bool)arParms[n].Value;


        }

        public void AddorUpdateProvider(int providerID, string name, string address1, string address2, string city, string st, int zip, string country,
            string weburl, bool isdeleted, bool isaccredited, DateTime createdate, int createdbywhom, DateTime modifieddate, int modifiedbywhom, string ConnectionString)
        {

            SqlParameter[] arParms = new SqlParameter[15];

            arParms[0] = new SqlParameter("@name", SqlDbType.NVarChar);
            arParms[0].Value = name;
            arParms[1] = new SqlParameter("@address1", SqlDbType.NVarChar);
            arParms[1].Value = address1;
            arParms[2] = new SqlParameter("@address2", SqlDbType.NVarChar);
            arParms[2].Value = address2;
            arParms[3] = new SqlParameter("@city", SqlDbType.NVarChar);
            arParms[3].Value = city;
            arParms[4] = new SqlParameter("@st", SqlDbType.NVarChar);
            arParms[4].Value = st;
            arParms[5] = new SqlParameter("@zip", SqlDbType.Int);
            arParms[5].Value = zip;
            arParms[6] = new SqlParameter("@country", SqlDbType.NChar);
            arParms[6].Value = country;
            arParms[7] = new SqlParameter("@weburl", SqlDbType.NChar);
            arParms[7].Value = weburl;
             arParms[13] = new SqlParameter("@isdeleted", SqlDbType.Bit);
            arParms[13].Value = isdeleted;
             arParms[14] = new SqlParameter("@isaccredited", SqlDbType.Bit);
            arParms[14].Value = isaccredited;
   
            arParms[8] = new SqlParameter("@createdate", SqlDbType.DateTime);
            arParms[8].Value = createdate;
            arParms[9] = new SqlParameter("@createdbywhom", SqlDbType.Int);
            arParms[9].Value = createdbywhom;
            arParms[10] = new SqlParameter("@modifieddate", SqlDbType.DateTime);
            arParms[10].Value = modifieddate;
            arParms[11] = new SqlParameter("@modifiedbywhom", SqlDbType.Int);
            arParms[11].Value = modifiedbywhom;
            arParms[12] = new SqlParameter("@providerid", SqlDbType.Int);
            arParms[12].Value = providerID;


            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "sp_AddorUpdateProvider", arParms);
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


        public void InsertScheduleExamDetails(int examid, string examname, DateTime examDate, DateTime examStartTime, 
            DateTime examEndTime, string examlocation, int institutionpeopleid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[7];

            arParms[0] = new SqlParameter("@examid", SqlDbType.Int);
            arParms[0].Value = examid;
            arParms[1] = new SqlParameter("@examname", SqlDbType.NVarChar);
            arParms[1].Value = examname;
            arParms[2] = new SqlParameter("@examdate", SqlDbType.DateTime);
            arParms[2].Value = examDate;
            arParms[3] = new SqlParameter("@examstarttime", SqlDbType.DateTime);
            arParms[3].Value = examStartTime;
            arParms[4] = new SqlParameter("@examendtime", SqlDbType.DateTime);
            arParms[4].Value = examEndTime;
            arParms[5] = new SqlParameter("@examlocation", SqlDbType.NVarChar);
            arParms[5].Value = examlocation;
            arParms[6] = new SqlParameter("@institutionpeopleid", SqlDbType.Int);
            arParms[6].Value = institutionpeopleid;
            //Remember to adjust the array dimension when adding or subtracting elements.

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "InsertScheduleExamDetails", arParms);
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

            //If using output paramters



        }


        public void InsertScheduleExamForTaker(int personid, string examname,
             string status, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@personid", SqlDbType.Int);
            arParms[0].Value = personid;
            arParms[1] = new SqlParameter("@examname", SqlDbType.NVarChar);
            arParms[1].Value = examname;
            arParms[2] = new SqlParameter("@status", SqlDbType.NVarChar);
            arParms[2].Value = status;

            //Remember to adjust the array dimension when adding or subtracting elements.

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "InsertScheduleExamForTaker", arParms);
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

            //If using output paramters



        }



        public DataTable GetExamItem(int examid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@examid", SqlDbType.Int);
            arParms[0].Value = examid;

            pTransactionSuccessful = true;

            DataTable dtExamItem = new DataTable("ExamItem");

            try
            {
                DataSet dsExamItem = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetExamItem", arParms);
                dtExamItem = dsExamItem.Tables[0];
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
            return dtExamItem;
        }


        public DataTable GetExamItemForEdit(int examitemid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@examitemid", SqlDbType.Int);
            arParms[0].Value = examitemid;

            pTransactionSuccessful = true;

            DataTable dtExamItem = new DataTable("ExamItem");

            try
            {
                DataSet dsExamItem = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sp_GetExamItemForEdit", arParms);
                dtExamItem = dsExamItem.Tables[0];
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
            return dtExamItem;
        }


        public DataTable GetExamItemByExam(int examid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@examid", SqlDbType.Int);
            arParms[0].Value = examid;

            pTransactionSuccessful = true;

            DataTable dtExamItem = new DataTable("ExamItemByExam");

            try
            {
                DataSet dsExamItem = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetExamItemByExam", arParms);
                dtExamItem = dsExamItem.Tables[0];
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
            return dtExamItem;
        }


        public DataTable GetETypeExamInfo(string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[0];

            pTransactionSuccessful = true;

            DataTable dtexamdescription = new DataTable("Etype");

            try
            {
                DataSet dsetypeStaff = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sp_GetETypeExamInfo", arParms);
                dtexamdescription = dsetypeStaff.Tables[0];
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
            return dtexamdescription;
        }

        public DataTable GetExamListforEdit(int examid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@examid", SqlDbType.Int);
            arParms[0].Value = examid;


            pTransactionSuccessful = true;

            DataTable dtExamInfo = new DataTable("ExamInfo");

            try
            {
                DataSet dsExamInfo = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sp_GetexamListforEdit", arParms);
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



        #endregion

        #region " Update methods "


        public void UpdateUser(int PersonID, string FirstName, string LastName, string Address1, string Address2,
                               string city, string st, string zip, string phonenumber1, string username,
                               string password, string email, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[12];
            arParms[0] = new SqlParameter("@PersonID", SqlDbType.Int);
            arParms[0].Value = PersonID;
            arParms[1] = new SqlParameter("@FirstName", SqlDbType.NVarChar);
            arParms[1].Value = FirstName;
            arParms[2] = new SqlParameter("@LastName", SqlDbType.NVarChar);
            arParms[2].Value = LastName;
            arParms[3] = new SqlParameter("@address1", SqlDbType.NVarChar);
            arParms[3].Value = Address1;
            arParms[4] = new SqlParameter("@address2", SqlDbType.NVarChar);
            arParms[4].Value = Address2;
            arParms[5] = new SqlParameter("@city", SqlDbType.NVarChar);
            arParms[5].Value = city;
            arParms[6] = new SqlParameter("@st", SqlDbType.NVarChar);
            arParms[6].Value = st;
            arParms[7] = new SqlParameter("@zip", SqlDbType.NVarChar);
            arParms[7].Value = zip;
            arParms[8] = new SqlParameter("@phonenumber1", SqlDbType.NVarChar);
            arParms[8].Value = phonenumber1;
            arParms[9] = new SqlParameter("@username", SqlDbType.NVarChar);
            arParms[9].Value = username;
            arParms[10] = new SqlParameter("@password", SqlDbType.NVarChar);
            arParms[10].Value = password;
            arParms[11] = new SqlParameter("@email", SqlDbType.NVarChar);
            arParms[11].Value = email;


            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "UpdatePerson", arParms);
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
            //If using output paramters
            //pUpdateedPersonID = (int)arParms[5].Value;
        }


        public void UpdatePermissions(int PersonID, int institutionid, bool isISA, bool isProctor, bool isReports, 
            string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@PersonID", SqlDbType.Int);
            arParms[0].Value = PersonID;
            arParms[1] = new SqlParameter("@institutionid", SqlDbType.Int);
            arParms[1].Value = institutionid;
            arParms[2] = new SqlParameter("@isISA", SqlDbType.Bit);
            arParms[2].Value = isISA;
            arParms[3] = new SqlParameter("@isProctor", SqlDbType.Bit);
            arParms[3].Value = isProctor;
            arParms[4] = new SqlParameter("@isReports", SqlDbType.Bit);
            arParms[4].Value = isReports;


            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "UpdatePermissions", arParms);
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

        public void ResetPermissions(int PersonID, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@PersonID", SqlDbType.Int);
            arParms[0].Value = PersonID;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "ResetPermissions", arParms);
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

        public void UpdateIsInstitution(int PersonID, bool isInstitution, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@PersonID", SqlDbType.Int);
            arParms[0].Value = PersonID;
            arParms[1] = new SqlParameter("@isInstitution", SqlDbType.Bit);
            arParms[1].Value = isInstitution;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "UpdateisInstitution", arParms);
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

        public void ResetIsInstitution(int PersonID, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@PersonID", SqlDbType.Int);
            arParms[0].Value = PersonID;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "ResetIsInstitution", arParms);
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

        public void UpdateScheduledExam(int scheduledexamid, int examid, string examname, DateTime examDate, 
            DateTime examStartTime, DateTime examEndTime, string examlocation, int institutionpeopleid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[8];

            arParms[0] = new SqlParameter("@scheduledexamid", SqlDbType.Int);
            arParms[0].Value = scheduledexamid;
            arParms[1] = new SqlParameter("@examid", SqlDbType.Int);
            arParms[1].Value = examid;
            arParms[2] = new SqlParameter("@examname", SqlDbType.NVarChar);
            arParms[2].Value = examname;
            arParms[3] = new SqlParameter("@examdate", SqlDbType.DateTime);
            arParms[3].Value = examDate;
            arParms[4] = new SqlParameter("@examstarttime", SqlDbType.DateTime);
            arParms[4].Value = examStartTime;
            arParms[5] = new SqlParameter("@examendtime", SqlDbType.DateTime);
            arParms[5].Value = examEndTime;
            arParms[6] = new SqlParameter("@examlocation", SqlDbType.NVarChar);
            arParms[6].Value = examlocation;
            arParms[7] = new SqlParameter("@institutionpeopleid", SqlDbType.Int);
            arParms[7].Value = institutionpeopleid;


            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "UpdateScheduledExam", arParms);
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
            //If using output paramters
            //pUpdateedPersonID = (int)arParms[5].Value;
        }

        public void UpdatePermitStatus(int permitid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@permitid", SqlDbType.Int);
            arParms[0].Value = permitid;
            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "UpdatePermitStatus", arParms);
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




        #endregion

        #region " Delete methods "

        public void DeleteItemById(int examitemid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@examitemid", SqlDbType.Int);
            arParms[0].Value = examitemid;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "sp_DeleteItemById", arParms);
            }
            catch (SqlException DeleteError)
            {
                pErrorMessage = DeleteError.Message.ToString();
                pErrorNumber = DeleteError.Number;
                pErrorClass = DeleteError.Class;
                pErrorState = DeleteError.State;
                pErrorLineNumber = DeleteError.LineNumber;

                pTransactionSuccessful = false;
            }
        }


        public void DeletePersonById(int PersonID, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@PersonID", SqlDbType.Int);
            arParms[0].Value = PersonID;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "sp_DeletePersonById", arParms);
            }
            catch (SqlException DeleteError)
            {
                pErrorMessage = DeleteError.Message.ToString();
                pErrorNumber = DeleteError.Number;
                pErrorClass = DeleteError.Class;
                pErrorState = DeleteError.State;
                pErrorLineNumber = DeleteError.LineNumber;

                pTransactionSuccessful = false;
            }
        }

        #endregion

        #region " Upsert methods "

        
        // Call this method with correct parameters to add or update the person and relative institutionpeople table
        public void AddEditPersonInformation(int personId, int institutionId, int providerId, string firstName, string lastName,
                                             DateTime dob, string email, string address1, string address2,
                                             string city, string state, string zip, string phoneNumber1, string phoneNumber1Type,
                                             string phoneNumber2, string phoneNumber2Type, string username, string password, Boolean isTaker,
                                             Boolean isProvider, Boolean isInstitution, Boolean isSA, Boolean isISA, Boolean isProctor,
                                             Boolean isReports, Boolean isEPSA, Boolean isDeveloper, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[27];

            arParms[0] = new SqlParameter("@personId", SqlDbType.NVarChar);
            arParms[0].Value = personId;
            arParms[1] = new SqlParameter("@institutionId", SqlDbType.NVarChar);
            arParms[1].Value = institutionId;
            arParms[2] = new SqlParameter("@providerId", SqlDbType.NVarChar);
            arParms[2].Value = providerId;
            arParms[3] = new SqlParameter("@firstName", SqlDbType.NVarChar);
            arParms[3].Value = firstName;
            arParms[4] = new SqlParameter("@lastName", SqlDbType.NVarChar);
            arParms[4].Value = lastName;
            arParms[5] = new SqlParameter("@dob", SqlDbType.Date);
            arParms[5].Value = dob;
            arParms[6] = new SqlParameter("@email", SqlDbType.NVarChar);
            arParms[6].Value = email;
            arParms[7] = new SqlParameter("@address1", SqlDbType.NVarChar);
            arParms[7].Value = address1;
            arParms[8] = new SqlParameter("@address2", SqlDbType.NVarChar);
            arParms[8].Value = address2;
            arParms[9] = new SqlParameter("@city", SqlDbType.NVarChar);
            arParms[9].Value = city;
            arParms[10] = new SqlParameter("@state", SqlDbType.NVarChar);
            arParms[10].Value = state;
            arParms[11] = new SqlParameter("@zip", SqlDbType.NVarChar);
            arParms[11].Value = zip;
            arParms[12] = new SqlParameter("@phoneNumber1", SqlDbType.NVarChar);
            arParms[12].Value = phoneNumber1;
            arParms[13] = new SqlParameter("@phoneNumber1Type", SqlDbType.NVarChar);
            arParms[13].Value = phoneNumber1Type;
            arParms[14] = new SqlParameter("@phoneNumber2", SqlDbType.NVarChar);
            arParms[14].Value = phoneNumber2;
            arParms[15] = new SqlParameter("@phoneNumber2Type", SqlDbType.NVarChar);
            arParms[15].Value = phoneNumber2Type;
            arParms[16] = new SqlParameter("@username", SqlDbType.NChar);
            arParms[16].Value = username;
            arParms[17] = new SqlParameter("@password", SqlDbType.NChar);
            arParms[17].Value = password;
            arParms[18] = new SqlParameter("@isTaker", SqlDbType.Bit);
            arParms[18].Value = isTaker;
            arParms[19] = new SqlParameter("@isProvider", SqlDbType.Bit);
            arParms[19].Value = isProvider;
            arParms[20] = new SqlParameter("@isInstitution", SqlDbType.Bit);
            arParms[20].Value = isInstitution;
            arParms[21] = new SqlParameter("@isSA", SqlDbType.Bit);
            arParms[21].Value = isSA;
            arParms[22] = new SqlParameter("@isISA", SqlDbType.Bit);
            arParms[22].Value = isISA;
            arParms[23] = new SqlParameter("@isProctor", SqlDbType.Bit);
            arParms[23].Value = isProctor;
            arParms[24] = new SqlParameter("@isReports", SqlDbType.Bit);
            arParms[24].Value = isReports;
            arParms[25] = new SqlParameter("@isEPSA", SqlDbType.Bit);
            arParms[25].Value = isEPSA;
            arParms[26] = new SqlParameter("@isDeveloper", SqlDbType.Bit);
            arParms[26].Value = isDeveloper;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "sp_UpsertPersonInstitution", arParms);
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


        public void InsertAnswers(int rosterid, int examitemid, string answer, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@rosterid", SqlDbType.Int);
            arParms[0].Value = rosterid;
            arParms[1] = new SqlParameter("@examitemid", SqlDbType.Int);
            arParms[1].Value = examitemid;
            arParms[2] = new SqlParameter("@answer", SqlDbType.NVarChar);
            arParms[2].Value = answer;

            //Remember to adjust the array dimension when adding or subtracting elements.

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "sp_UpsertAnswers", arParms);
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

        public void addOrUpdateExam(int examid, String examname, Decimal duration, int etypeid, 
                                    string exampurpose, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[5];

            arParms[0] = new SqlParameter("@examId", SqlDbType.Int);
            arParms[0].Value = examid;
            arParms[1] = new SqlParameter("@examname", SqlDbType.NVarChar);
            arParms[1].Value = examname;
            arParms[2] = new SqlParameter("@duration", SqlDbType.Decimal);
            arParms[2].Value = duration;
            arParms[3] = new SqlParameter("@etypeid", SqlDbType.Int);
            arParms[3].Value = etypeid;
            arParms[4] = new SqlParameter("@exampurpose", SqlDbType.NVarChar);
            arParms[4].Value = exampurpose;



            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "sp_AddorUpdateExam", arParms);
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

        public void AddorUpdateExamItem(int examitemid, int examid, int key1id, int key2id, int key3id, string questionobjective, string stem,
    string destractor1, string destractor2, string destractor3, string destractor4, string correctanswer, string ConnectionString)
        {

            SqlParameter[] arParms = new SqlParameter[12];

            arParms[0] = new SqlParameter("@key1id", SqlDbType.Int);
            arParms[0].Value = key1id;
            arParms[1] = new SqlParameter("@key2id", SqlDbType.Int);
            arParms[1].Value = key2id;
            arParms[2] = new SqlParameter("@key3id", SqlDbType.Int);
            arParms[2].Value = key3id;
            arParms[3] = new SqlParameter("@questionobjective", SqlDbType.NVarChar);
            arParms[3].Value = questionobjective;
            arParms[4] = new SqlParameter("@stem", SqlDbType.NVarChar);
            arParms[4].Value = stem;
            arParms[5] = new SqlParameter("@destractor1", SqlDbType.NVarChar);
            arParms[5].Value = destractor1;
            arParms[6] = new SqlParameter("@destractor2", SqlDbType.NVarChar);
            arParms[6].Value = destractor2;
            arParms[7] = new SqlParameter("@destractor3", SqlDbType.NChar);
            arParms[7].Value = destractor3;
            arParms[8] = new SqlParameter("@destractor4", SqlDbType.NChar);
            arParms[8].Value = destractor4;
            arParms[9] = new SqlParameter("@correctanswer", SqlDbType.NChar);
            arParms[9].Value = correctanswer;
            arParms[10] = new SqlParameter("@examitemid", SqlDbType.Int);
            arParms[10].Value = examitemid;
            arParms[11] = new SqlParameter("@examid", SqlDbType.Int);
            arParms[11].Value = examid;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "sp_UpsertExamItem", arParms);
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
