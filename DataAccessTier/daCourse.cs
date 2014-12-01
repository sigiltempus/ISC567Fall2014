using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace DataAccessTier
{
   public class daCourse : daDataAccessModule
    {
        #region " Read methods "
        //Get List of ProgramList with searchargument
        public DataTable GetCourseList(int ProgramId, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@Programid", SqlDbType.Int);
            arParms[0].Value = ProgramId;

            pTransactionSuccessful = true;

            DataTable dtProgram = new DataTable("CourseList");

            try
            {
                DataSet dsProgram = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ListCourse", arParms);

                dtProgram = dsProgram.Tables[0];

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
            return dtProgram;
        }

        //Get List of CourseList with searchargument
        public DataTable GetCourse(int CourseId, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@courseid", SqlDbType.Int);
            arParms[0].Value = CourseId;

            pTransactionSuccessful = true;

            DataTable dtProgram = new DataTable("CourseList");

            try
            {
                DataSet dsProgram = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetCourse", arParms);

                dtProgram = dsProgram.Tables[0];

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
            return dtProgram;
        }

        //Get List of Course Outcome without searchargument
        public DataTable GetCourseOutcomesList(int CourseId, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@CourseId", SqlDbType.Int);
            arParms[0].Value = CourseId;

            pTransactionSuccessful = true;

            DataTable dtProgramOutcomes = new DataTable("CourseOutcomesList");

            try
            {
                DataSet dsProgramoutcomes = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ListCourseOutComes", arParms);
                dtProgramOutcomes = dsProgramoutcomes.Tables[0];

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
            return dtProgramOutcomes;
        }

        //Get  Course Outcome with searchargument
        public DataTable GetCourseOutcome(int crsoutcomesid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@crsoutcomesid", SqlDbType.NVarChar);
            arParms[0].Value = crsoutcomesid;

            pTransactionSuccessful = true;
            DataTable dtProgramOutcome = new DataTable("CourseOutcome");
            try
            {
                DataSet dsProgramOutcome = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetCourseOutComes", arParms);
                dtProgramOutcome = dsProgramOutcome.Tables[0];
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
            return dtProgramOutcome;
        }

        //Get List of Participating Society without Argument
        public DataTable GetCourseProgram(int ProgramId, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@ProgramId", SqlDbType.Int);
            arParms[0].Value = ProgramId;
            pTransactionSuccessful = true;

            DataTable dtPerson = new DataTable("CourseProgramList");

            try
            {
                DataSet dsProgram = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ListCourseProgram", arParms);
                dtPerson = dsProgram.Tables[0];
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
            return dtPerson;
        }

        //Get  Program Outcome with searchargument
        public DataTable GetCourseOutcomesforProgramoutcomes(int CourseOutcomeId, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@crsoutcomesid ", SqlDbType.Int);
            arParms[0].Value = CourseOutcomeId;

            pTransactionSuccessful = true;
            DataTable dtProgramOutcome = new DataTable("ProgramOutcomes");
            try
            {
                DataSet dsProgramOutcome = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetCourseOutcometforPrgOutcome", arParms);
                dtProgramOutcome = dsProgramOutcome.Tables[0];
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
            return dtProgramOutcome;
        }

        //Get  Program Outcome with searchargument
        public DataTable GetCourseOutcomesforsubskill(string @CourseShorttitle, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@CourseShorttitle", SqlDbType.NVarChar);
            arParms[0].Value = @CourseShorttitle;

            pTransactionSuccessful = true;
            DataTable dtProgramOutcome = new DataTable("CourseOutcome");
            try
            {
                DataSet dsProgramOutcome = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "CourseOutcomesforsubskill", arParms);
                dtProgramOutcome = dsProgramOutcome.Tables[0];
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
            return dtProgramOutcome;
        }

        /// <summary>
        /// Returns a list of all course outcomes, with their short descriptions.
        /// </summary>
        /// <param name="ConnectionString">Connection string to use</param>
        /// <returns>DataTable listing short descriptions for all course outcomes</returns>
        public DataTable GetCourseOutcomeShortlist(string ConnectionString)
        {
            return this.GetTable("sp_CourseOutcomesShortList", ConnectionString, "CourseOutcomes");
        }

       
        #endregion

        #region "Insert Methods"
        //For Inserting Course
        public void InsertCourse(string shorttitle, int progid, string longtitle, string catdesc, string topics, string discussion, string yearinprog, int sequencenum, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[9];
            arParms[0] = new SqlParameter("@courseid", SqlDbType.Int);
            arParms[0].Value = sequencenum;
            arParms[1] = new SqlParameter("@shorttitle", SqlDbType.NVarChar );
            arParms[1].Value = shorttitle;
            arParms[2] = new SqlParameter("@progid", SqlDbType.Int );
            arParms[2].Value = progid;
            arParms[3] = new SqlParameter("@longtitle", SqlDbType.NVarChar);
            arParms[3].Value = longtitle;
            arParms[4] = new SqlParameter("@catdesc", SqlDbType.NVarChar );
            arParms[4].Value = catdesc;
            arParms[5] = new SqlParameter("@topics", SqlDbType.NVarChar);
            arParms[5].Value = topics;
            arParms[6] = new SqlParameter("@discussion", SqlDbType.NVarChar);
            arParms[6].Value = discussion;
            arParms[7] = new SqlParameter("@yearinprog", SqlDbType.NVarChar);
            arParms[7].Value = yearinprog;
            arParms[8] = new SqlParameter("@sequencenum", SqlDbType.Int );
            arParms[8].Value = sequencenum;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "InsertCourse", arParms);
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

        //For Inserting CourseOutcome
        public void InsertCourseOutcomes(int programid, int CourseId, string crsoutcometext, string crsshortoutcome, int crssequencenum, string crsoutcomenum, int crsoutcomesid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[7];

            arParms[0] = new SqlParameter("@programid", SqlDbType.Int);
            arParms[0].Value = programid;
            arParms[1] = new SqlParameter("@courseid", SqlDbType.Int );
            arParms[1].Value = CourseId;
            arParms[2] = new SqlParameter("@crsoutcometext", SqlDbType.NVarChar);
            arParms[2].Value = crsoutcometext;
            arParms[3] = new SqlParameter("@crsshortoutcome", SqlDbType.NVarChar);
            arParms[3].Value = crsshortoutcome;
            arParms[4] = new SqlParameter("@crssequencenum", SqlDbType.Int);
            arParms[4].Value = crssequencenum;
            arParms[5] = new SqlParameter("@crsoutcomenum", SqlDbType.NVarChar);
            arParms[5].Value = crsoutcomenum;
            arParms[6] = new SqlParameter("@crsoutcomesid", SqlDbType.Int);
            arParms[6].Value = crsoutcomesid;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "InsertCourseOutcomes", arParms);
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

        //For Inserting 
        public void InsertCourseOutcometoProgOutcome(string prgoutcomesid, string crsoutcomesid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@ProgOutcomeId", SqlDbType.Int);
            arParms[0].Value = prgoutcomesid;
            arParms[1] = new SqlParameter("@CourseOutcomeId", SqlDbType.Int);
            arParms[1].Value = crsoutcomesid;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "InsertCourseOutcometoProgOutcome", arParms);
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


        //For InsertingParticipating Society
        public void InsertCourseOuctomeSubskill(string CourseShorttitle, string subskillcomb, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@CourseShorttitle", SqlDbType.NVarChar);
            arParms[0].Value = CourseShorttitle;
            arParms[1] = new SqlParameter("@subskillcomb", SqlDbType.NVarChar);
            arParms[1].Value = subskillcomb;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "InsertCourseOuctomeSubskill", arParms);
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

        #region "Update Methods
        //For Updating Course
        public void UpdateCourse(int CourseId,string shorttitle, int progid, string longtitle, string catdesc, string topics, string discussion, string yearinprog, int sequencenum, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[9];
            arParms[0] = new SqlParameter("@courseid", SqlDbType.Int);
            arParms[0].Value = CourseId;
            arParms[1] = new SqlParameter("@shorttitle", SqlDbType.NVarChar);
            arParms[1].Value = shorttitle;
            arParms[2] = new SqlParameter("@progid", SqlDbType.Int);                 
            arParms[2].Value = progid;
            arParms[3] = new SqlParameter("@longtitle", SqlDbType.NVarChar);
            arParms[3].Value = longtitle;
            arParms[4] = new SqlParameter("@catdesc", SqlDbType.NVarChar);
            arParms[4].Value = catdesc;
            arParms[5] = new SqlParameter("@topics", SqlDbType.NVarChar);
            arParms[5].Value = topics;
            arParms[6] = new SqlParameter("@discussion", SqlDbType.NVarChar);
            arParms[6].Value = discussion;
            arParms[7] = new SqlParameter("@yearinprog", SqlDbType.NVarChar);
            arParms[7].Value = yearinprog;
            arParms[8] = new SqlParameter("@sequencenum", SqlDbType.Int);
            arParms[8].Value = sequencenum;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "UpdateCourse", arParms);
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

        //For Updating CourseOutcome
        public void UpdateCourseOutcome(int crsoutcomesid, int programid, int CourseId, string crsoutcometext, string crsshortoutcome, int crssequencenum, string crsoutcomenum, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[7];

            arParms[0] = new SqlParameter("@crsoutcomesid", SqlDbType.Int);
            arParms[0].Value = crsoutcomesid;
            
            arParms[1] = new SqlParameter("@programid", SqlDbType.Int);
            arParms[1].Value = programid;
            arParms[2] = new SqlParameter("@courseid", SqlDbType.Int);
            arParms[2].Value = CourseId;

            arParms[3] = new SqlParameter("@crsoutcometext", SqlDbType.NVarChar);
            arParms[3].Value = crsoutcometext;
            arParms[4] = new SqlParameter("@crsshortoutcome", SqlDbType.NVarChar);
            arParms[4].Value = crsshortoutcome;
            arParms[5] = new SqlParameter("@crssequencenum", SqlDbType.Int);
            arParms[5].Value = crssequencenum;
            arParms[6] = new SqlParameter("@crsoutcomenum", SqlDbType.NVarChar);
            arParms[6].Value = crsoutcomenum;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "UpdateCourseOutcomes", arParms);
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

        #region "Delete Methods"


        //For InsertingParticipating Society
        public void DeleteCourseOuctomeSubskill(string CourseShorttitle, string subskillcomb, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@CourseShorttitle", SqlDbType.NVarChar);
            arParms[0].Value = CourseShorttitle;
            arParms[1] = new SqlParameter("@subskillcomb", SqlDbType.NVarChar);
            arParms[1].Value = subskillcomb;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "DeleteCourseOuctomeSubskill", arParms);
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


        public void DeleteCourseOutcometoProgOutcome(string prgoutcomesid, string crsoutcomesid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@ProgOutcomeId", SqlDbType.Int);
            arParms[0].Value = prgoutcomesid;
            arParms[1] = new SqlParameter("@CourseOutcomeId", SqlDbType.Int);
            arParms[1].Value = crsoutcomesid;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "DeleteCourseOutcometoProgOutcome", arParms);
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
