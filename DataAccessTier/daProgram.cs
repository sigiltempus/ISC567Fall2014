using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;


namespace DataAccessTier {
    // This is daProgram
    public class daProgram : daDataAccessModule {

        #region " Read methods "

        public DataTable GetCurriculumList(string connectionString)
        {
            pTransactionSuccessful = true;

            DataTable dtCurriculumList = new DataTable("CurriculumList");

            try
            {
                DataSet dsProgramList = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_GetcurriculumList");
                dtCurriculumList = dsProgramList.Tables[0];
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

            return dtCurriculumList;
        }

        public DataTable GetCurriculumById(int CurriculumId, string connectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@curriculumid", SqlDbType.Int);
            arParms[0].Value = CurriculumId;


            pTransactionSuccessful = true;

            DataTable dtCurriculumInfo = new DataTable("CurriculumInfo");

            try
            {
                DataSet dsCurriculumInfo = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetcurriculumInfo", arParms);
                dtCurriculumInfo = dsCurriculumInfo.Tables[0];
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
            return dtCurriculumInfo;
        }

        public DataTable GetProgramList(string connectionString, int curriculumid)
        {
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@curriculumid", SqlDbType.Int);
            arParms[0].Value = curriculumid;
            pTransactionSuccessful = true;

            DataTable dtProgramList = new DataTable("ProgramList");

            try
            {
                DataSet dsProgramList = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_GetProgramList", arParms);
                dtProgramList = dsProgramList.Tables[0];
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

            return dtProgramList;
        }

        public DataTable GetProgramStatusList(string connectionString) {
            pTransactionSuccessful = true;

            DataTable dtProgramStatus = new DataTable("ProgramStatus");

            try {
                DataSet dsProgramStatus = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_GetProgramStatusList");
                dtProgramStatus = dsProgramStatus.Tables[0];
            } catch (SqlException ReadError) {
                pErrorMessage = ReadError.Message.ToString();
                pErrorNumber = ReadError.Number;
                pErrorClass = ReadError.Class;
                pErrorState = ReadError.State;
                pErrorLineNumber = ReadError.LineNumber;

                pTransactionSuccessful = false;
            }
            return dtProgramStatus;
        }

        public DataTable GetProgramInfoById(int programId, string connectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@programId", SqlDbType.Int);
            arParms[0].Value = programId;


            pTransactionSuccessful = true;

            DataTable dtProgramInfo = new DataTable("ProgramInfo");

            try
            {
                DataSet dsProgramInfo = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_GetProgramInfoByID", arParms);
                dtProgramInfo = dsProgramInfo.Tables[0];
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
            return dtProgramInfo;
        }

        //Get List of Program Outcome without searchargument
        public DataTable GetProgramOutcomesList(int ProgramId, string ConnectionString) {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@Programid", SqlDbType.Int);
            arParms[0].Value = ProgramId;
            pTransactionSuccessful = true;

            DataTable dtProgramOutcomes = new DataTable("ProgramOutcomesList");

            try {
                DataSet dsProgramoutcomes = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ListProgramOutComes", arParms);
                dtProgramOutcomes = dsProgramoutcomes.Tables[0];

            } catch (SqlException ReadError) {
                pErrorMessage = ReadError.Message.ToString();
                pErrorNumber = ReadError.Number;
                pErrorClass = ReadError.Class;
                pErrorState = ReadError.State;
                pErrorLineNumber = ReadError.LineNumber;
                pTransactionSuccessful = false;
            }
            return dtProgramOutcomes;
        }

        //Get List of ProgramList with searchargument
        public DataTable GetProgram(int ProgramId, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@Programid", SqlDbType.NVarChar);
            arParms[0].Value = ProgramId;


            pTransactionSuccessful = true;

            DataTable dtProgram = new DataTable("ProgramList");

            try
            {
                DataSet dsProgram = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetProgram", arParms);

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

        //Get  Program Outcome with searchargument
        public DataTable GetProgramOutcome(int prgoutcomesid, string ConnectionString) {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@prgoutcomesid", SqlDbType.Int);
            arParms[0].Value = prgoutcomesid;

            pTransactionSuccessful = true;
            DataTable dtProgramOutcome = new DataTable("ProgramOutcome");
            try {
                DataSet dsProgramOutcome = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetProgramOutComes", arParms);
                dtProgramOutcome = dsProgramOutcome.Tables[0];
            } catch (SqlException ReadError) {
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
        public DataTable GetProgramoutcomesforsubskill(int ProgramOutcomeId, string ConnectionString) {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@prgoutcomesid ", SqlDbType.Int);
            arParms[0].Value = ProgramOutcomeId;
            return this.GetTable("Listprogramoutcomestosubskill", ConnectionString, "ProgramOutcome", arParms);
        }

        public DataTable Getproglist(int prgoutcomesid, string connectionString) {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@prgoutcomesid", SqlDbType.Int);
            arParms[0].Value = prgoutcomesid;


            pTransactionSuccessful = true;

            DataTable dtProgramInfo = new DataTable("ProgramInfo");

            try {
                DataSet dsProgramInfo = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Getproglist", arParms);
                dtProgramInfo = dsProgramInfo.Tables[0];
            } catch (SqlException ReadError) {
                pErrorMessage = ReadError.Message.ToString();
                pErrorNumber = ReadError.Number;
                pErrorClass = ReadError.Class;
                pErrorState = ReadError.State;
                pErrorLineNumber = ReadError.LineNumber;

                pTransactionSuccessful = false;
            }
            return dtProgramInfo;
        }

        public DataTable GetProgramddl(string connectionString) {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[0];



            pTransactionSuccessful = true;

            DataTable dtProgramInfo = new DataTable("ProgramInfo");

            try {
                DataSet dsProgramInfo = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetProgramdd", arParms);
                dtProgramInfo = dsProgramInfo.Tables[0];
            } catch (SqlException ReadError) {
                pErrorMessage = ReadError.Message.ToString();
                pErrorNumber = ReadError.Number;
                pErrorClass = ReadError.Class;
                pErrorState = ReadError.State;
                pErrorLineNumber = ReadError.LineNumber;

                pTransactionSuccessful = false;
            }
            return dtProgramInfo;
        }

        /// <summary>
        /// Returns all skill classes under a program.
        /// </summary>
        /// <param name="ProgramId">Program ID to search</param>
        /// <param name="ConnectionString">Connection String to use</param>
        /// <returns>DataTable containing all skill classes under the program.</returns>
        public DataTable ListSkillClass(int ProgramId, string ConnectionString) {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@programid", SqlDbType.Int);
            arParms[0].Value = ProgramId;
            return this.GetTable("ListSkillClass", ConnectionString, "SkillClassList", arParms);
        }

        /// <summary>
        /// Return the skill class matching the skill class number.
        /// </summary>
        /// <param name="skillsclassnum">Skill Class number</param>
        /// <param name="ConnectionString">Connection String</param>
        /// <returns>DataTable containing the matching skill class</returns>
        public DataTable getskillsbyskillclassnum(int skillsclassnum, string ConnectionString) {
            // Set up parameters in parameter array 
            //skillsclassnum = 1;
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@skillsclassnum", SqlDbType.Int);
            arParms[0].Value = skillsclassnum;
            return this.GetTable("GetSkillsBySkillClassnum", ConnectionString, "GetSkillsBySkillClassnum", arParms);
        }

        /// <summary>
        /// Return the skill class matching the skill class ID.
        /// </summary>
        /// <param name="skillclassid">Skill Class ID to search</param>
        /// <param name="ConnectionString">Connection String</param>
        /// <returns>DataTable with skill class record matching ID.</returns>
        public DataTable GetSkillClassInfo(int skillclassid, string ConnectionString) {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@skillclassid", SqlDbType.Int);
            arParms[0].Value = skillclassid;
            return this.GetTable("GetSkillClassInfo", ConnectionString, "Skillsets", arParms);
        }

        /// <summary>
        /// Get any subskills matching the skill class number.
        /// </summary>
        /// <param name="skillsnum">Skill class number to search</param>
        /// <param name="ConnectionString">Connection String</param>
        /// <returns>DataTable with any subskills under a skill class number.</returns>
        public DataTable GetSubSkillBySkillClassNum(int skillsnum, string ConnectionString) {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@skillsnum", SqlDbType.Int);
            arParms[0].Value = skillsnum;
            return this.GetTable("GetSubSkillBySkillClassNum", ConnectionString, "getsubskillbyskillclassskill", arParms);
        }

        /// <summary>
        /// Get skill information matching the Skill ID
        /// </summary>
        /// <param name="skillsId">Skill ID to search</param>
        /// <param name="con">Connection String</param>
        /// <returns>DataTable of skill information matching the Skill ID</returns>
        public DataTable GetSkillsInfo(int skillsId, string con) {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@skillsId", SqlDbType.Int);
            arParms[0].Value = skillsId;
            pTransactionSuccessful = true;
            return this.GetTable("GetSkillsInfo", con, "GetSkills", arParms);
        }

        /// <summary>
        /// Gets subskills by skill class and skill number
        /// </summary>
        /// <param name="skillsclassnum">Skill Class Number</param>
        /// <param name="skillsnum">Skill ID</param>
        /// <param name="ConnectionString">Connection String</param>
        /// <returns>Subskills</returns>
        public DataTable getsubskillbyskillclassskill(int skillsclassnum, int skillsnum, string ConnectionString) {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@skillsclassnum", SqlDbType.Int);
            arParms[0].Value = skillsclassnum;
            arParms[1] = new SqlParameter("@skillsnum", SqlDbType.Int);
            arParms[1].Value = skillsnum;
            return this.GetTable("getsubskillbyskillclassskill", ConnectionString, "getsubskillbyskillclassskill", arParms);
        }

        /// <summary>
        /// Get Sub Skill information by Sub Skill ID
        /// </summary>
        /// <param name="subskillid">Sub Skill ID</param>
        /// <param name="ConnectionString">Connection String</param>
        /// <returns>Sub Skill matching Sub Skill ID</returns>
        public DataTable GetSubSkillInfo(int subskillid, string ConnectionString) {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@subskillid", SqlDbType.Int);
            arParms[0].Value = subskillid;
            return this.GetTable("GetSubSkillInfo", ConnectionString, "SubSkill", arParms);
        }

        #endregion

        #region " Insert methods "

        //For Inserting ProgramOutcome
        public void InsertProgramOutcome(int programid, string prgoutcometext, string prgshortoutcome, String prgsequencenum, string ConnectionString) {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[4];
            //arParms[0] = new SqlParameter("@prgoutcomesid", SqlDbType.Int);
            //arParms[0].Value = prgoutcomesid;
            arParms[0] = new SqlParameter("@programid", SqlDbType.Int);
            arParms[0].Value = programid;
            arParms[1] = new SqlParameter("@prgoutcometext", SqlDbType.NVarChar);
            arParms[1].Value = prgoutcometext;
            arParms[2] = new SqlParameter("@prgshortoutcome", SqlDbType.NVarChar);
            arParms[2].Value = prgshortoutcome;
            arParms[3] = new SqlParameter("@prgsequencenum", SqlDbType.VarChar);
            arParms[3].Value = prgsequencenum;


            pTransactionSuccessful = true;

            try {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Insertprogramoutcomes", arParms);
            } catch (SqlException InsertError) {
                pErrorMessage = InsertError.Message.ToString();
                pErrorNumber = InsertError.Number;
                pErrorClass = InsertError.Class;
                pErrorState = InsertError.State;
                pErrorLineNumber = InsertError.LineNumber;

                pTransactionSuccessful = false;
            }
        }
        public void InsertProgrOuctomeSubskill(int programOutomeID, int subSkillId, string ConnectionString) {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@programOutomeID", SqlDbType.Int);
            arParms[0].Value = programOutomeID;
            arParms[1] = new SqlParameter("@subSkillId", SqlDbType.Int);
            arParms[1].Value = subSkillId;

            pTransactionSuccessful = true;

            try {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "InsertProgrOutcomeSubskill", arParms);
            } catch (SqlException InsertError) {
                pErrorMessage = InsertError.Message.ToString();
                pErrorNumber = InsertError.Number;
                pErrorClass = InsertError.Class;
                pErrorState = InsertError.State;
                pErrorLineNumber = InsertError.LineNumber;

                pTransactionSuccessful = false;
            }
        }

        /// <summary>
        /// Will insert a skill class record.
        /// </summary>
        /// <param name="scname">Skill Class name</param>
        /// <param name="skillsclassnum">Skill Class number</param>
        /// <param name="programid">Program ID</param>
        /// <param name="ConnectionString">Connection String</param>
        public void insertskillclass(string scname, int programid, string ConnectionString) {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@scname", SqlDbType.NVarChar);
            arParms[0].Value = scname;
            arParms[1] = new SqlParameter("@programid", SqlDbType.Int);
            arParms[1].Value = programid;
            this.ExecuteWithoutResult(arParms, "insertskillclass", ConnectionString);
        }

        //For Inserting Skills
        public void insertskills(int skillsclassnum, int skillsnum, string skillsname, string ConnectionString) {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@skillsclassnum", SqlDbType.Int);
            arParms[0].Value = skillsclassnum;
            arParms[1] = new SqlParameter("@skillsnum", SqlDbType.Int);
            arParms[1].Value = skillsnum;
            arParms[2] = new SqlParameter("@skillsname", SqlDbType.NVarChar);
            arParms[2].Value = skillsname;

            this.ExecuteWithoutResult(arParms, "insertskills", ConnectionString);
        }

        //For Inserting SubSkill
        public void insertsubskill(int skillsclassnum, int skillsnum, int subskillnum, string subskilltitle, string jobadwords, string subskillcomb, string ConnectionString) {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[6];

            arParms[0] = new SqlParameter("@skillsclassnum", SqlDbType.Int);
            arParms[0].Value = skillsclassnum;
            arParms[1] = new SqlParameter("@skillsnum", SqlDbType.Int);
            arParms[1].Value = skillsnum;
            arParms[2] = new SqlParameter("@subskillnum", SqlDbType.Int);
            arParms[2].Value = subskillnum;
            arParms[3] = new SqlParameter("@subskilltitle", SqlDbType.NVarChar);
            arParms[3].Value = subskilltitle;
            arParms[4] = new SqlParameter("@subskillcomb", SqlDbType.NVarChar);
            arParms[4].Value = subskillcomb;
            arParms[5] = new SqlParameter("@jobadwords", SqlDbType.NVarChar);
            arParms[5].Value = jobadwords;
            this.ExecuteWithoutResult(arParms, "insertsubskill", ConnectionString);
        }
        #endregion

        #region " Update methods "

        ///
        /// Update Methods Here..
        /// 

        // Call this method with correct parameters to add or update the person and relative institutionpeople table
        public void EditCurriculumInformation(int CurriculumId, string shortName, string longName, string connectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@curriculumid", SqlDbType.NVarChar);
            arParms[0].Value = CurriculumId;
            arParms[1] = new SqlParameter("@curriculum_shortname", SqlDbType.NVarChar);
            arParms[1].Value = shortName;
            arParms[2] = new SqlParameter("@curriculum_longname", SqlDbType.NVarChar);
            arParms[2].Value = longName;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "EditcurriculumInfo", arParms);
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

        //For Updatting ProgramOutcome
        public void UpdateProgramOutcome(int prgoutcomesid, int programid, string prgoutcometext, string prgshortoutcome, string prgsequencenum, string ConnectionString) {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[5];

            //arParms[0] = new SqlParameter("@prgsequencenum", SqlDbType.Int);

            //arParms[0].Value = prgsequencenum;

            arParms[0] = new SqlParameter("@prgoutcomesid", SqlDbType.Int);
            arParms[0].Value = prgoutcomesid;
            arParms[1] = new SqlParameter("@programid", SqlDbType.Int);
            arParms[1].Value = programid;
            arParms[2] = new SqlParameter("@prgoutcometext", SqlDbType.NVarChar);
            arParms[2].Value = prgoutcometext;
            arParms[3] = new SqlParameter("@prgshortoutcome", SqlDbType.NVarChar);
            arParms[3].Value = prgshortoutcome;
            arParms[4] = new SqlParameter("@prgsequencenum", SqlDbType.VarChar);
            arParms[4].Value = prgsequencenum;

            pTransactionSuccessful = true;

            try {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Updateprogramoutcomes", arParms);
            } catch (SqlException InsertError) {
                pErrorMessage = InsertError.Message.ToString();
                pErrorNumber = InsertError.Number;
                pErrorClass = InsertError.Class;
                pErrorState = InsertError.State;
                pErrorLineNumber = InsertError.LineNumber;

                pTransactionSuccessful = false;
            }
        }

        /// <summary>
        /// Edit a skill class record with new values.
        /// </summary>
        /// <param name="skillclassid">Skill Class ID</param>
        /// <param name="skillsname">Name of Skill Class</param>
        /// <param name="programid">Program ID</param>
        /// <param name="ConnectionString">Connection String</param>
        public void editskillclass(int skillclassid, string skillsname, int programid, string ConnectionString) {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@skillclassid", SqlDbType.Int);
            arParms[0].Value = skillclassid;
            arParms[1] = new SqlParameter("@scname", SqlDbType.NVarChar);
            arParms[1].Value = skillsname;
            arParms[2] = new SqlParameter("@programid", SqlDbType.Int);
            arParms[2].Value = programid;
            this.ExecuteWithoutResult(arParms, "editskillclass", ConnectionString);
        }

        /// <summary>
        /// Updates a skill with new values
        /// </summary>
        /// <param name="skillsid">Skill ID to update</param>
        /// <param name="skillsclassnum">Skill Class Number</param>
        /// <param name="skillsnum">Skill Number</param>
        /// <param name="skillsname">Name of Skill</param>
        /// <param name="ConnectionString">Connection String</param>
        public void editskills(int skillsid, int skillsclassnum, int skillsnum, string skillsname, string ConnectionString) {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@skillsid", SqlDbType.Int);
            arParms[0].Value = skillsid;
            arParms[1] = new SqlParameter("@skillsclassnum", SqlDbType.Int);
            arParms[1].Value = skillsclassnum;
            arParms[2] = new SqlParameter("@skillsnum", SqlDbType.Int);
            arParms[2].Value = skillsnum;
            arParms[3] = new SqlParameter("@skillsname", SqlDbType.NVarChar);
            arParms[3].Value = skillsname;
            this.ExecuteWithoutResult(arParms, "editskills", ConnectionString);
        }

        //Update method for SubSkill
        public void editsubskill(int subskillid, int skillsclassnum, int skillsnum, int subskillnum, string subskilltitle,
                                    string subskillcomb, string jobadwords, string ConnectionString) {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[7];
            arParms[0] = new SqlParameter("@subskillid", SqlDbType.Int);
            arParms[0].Value = subskillid;
            arParms[1] = new SqlParameter("@skillsclassnum", SqlDbType.Int);
            arParms[1].Value = skillsclassnum;
            arParms[2] = new SqlParameter("@skillsnum", SqlDbType.Int);
            arParms[2].Value = skillsnum;
            arParms[3] = new SqlParameter("@subskillnum", SqlDbType.Int);
            arParms[3].Value = subskillnum;
            arParms[4] = new SqlParameter("@subskilltitle", SqlDbType.NVarChar);
            arParms[4].Value = subskilltitle;
            arParms[5] = new SqlParameter("@subskillcomb", SqlDbType.NVarChar);
            arParms[5].Value = subskillcomb;
            arParms[6] = new SqlParameter("@jobadwords", SqlDbType.NVarChar);
            arParms[6].Value = jobadwords;
            this.ExecuteWithoutResult(arParms, "editsubskill", ConnectionString);
        }
        #endregion

        #region " Delete methods "

        ///
        /// Delete Methods Here..
        /// 
        //public void deleteskillclass(int SkillClassID, string ConnectionString)
        //{
        //    // Set up parameters in parameter array 
        //    SqlParameter[] arParms = new SqlParameter[1];

        //    arParms[0] = new SqlParameter("@SkillClassID", SqlDbType.Int);
        //    arParms[0].Value = SkillClassID;

        //    //Example of an output paramter
        //    // arParms[n] = new SqlParameter("@Paramtern", SqlDbType.Bit);
        //    // arParms[n].Direction = ParameterDirection.Output;
        //    //Remember to adjust the array dimension when adding or subtracting elements.

        //    pTransactionSuccessful = true;

        //    try
        //    {
        //        SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "DeleteSkillClass", arParms);
        //    }
        //    catch (SqlException DeleteError)
        //    {
        //        pErrorMessage = DeleteError.Message.ToString();
        //        pErrorNumber = DeleteError.Number;
        //        pErrorClass = DeleteError.Class;
        //        pErrorState = DeleteError.State;
        //        pErrorLineNumber = DeleteError.LineNumber;

        //        pTransactionSuccessful = false;
        //    }

        //    //If using output paramters
        //    //pSomeParameter = (bool)arParms[n].Value;


        //}


        public void DeleteProgrOuctomeSubskill(int ProgramOutcomeId, int subSkillId, string ConnectionString) {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@ProgramOutcomeId", SqlDbType.Int);
            arParms[0].Value = ProgramOutcomeId;
            arParms[1] = new SqlParameter("@subSkillId", SqlDbType.Int);
            arParms[1].Value = subSkillId;



            pTransactionSuccessful = true;

            try {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "DeleteProgrOutcomeSubskill", arParms);
            } catch (SqlException InsertError) {
                pErrorMessage = InsertError.Message.ToString();
                pErrorNumber = InsertError.Number;
                pErrorClass = InsertError.Class;
                pErrorState = InsertError.State;
                pErrorLineNumber = InsertError.LineNumber;

                pTransactionSuccessful = false;
            }
        }


        #endregion

        #region " Insert methods "

        // Call this method with correct parameters to add or update the person and relative institutionpeople table
        public void InsertCurriculumInformation(string shortName, string longName, string connectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@curriculum_shortname", SqlDbType.NVarChar);
            arParms[0].Value = shortName;
            arParms[1] = new SqlParameter("@curriculum_longname", SqlDbType.NVarChar);
            arParms[1].Value = longName;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Insertcurriculum", arParms);
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

        // Call this method with correct parameters to add or update the person and relative institutionpeople table
        public void AddEditProgramInformation(int curriculumid, int programId, string shortName, string longName, string description, int statusId, string connectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[6];

            arParms[0] = new SqlParameter("@programId", SqlDbType.NVarChar);
            arParms[0].Value = programId;
            arParms[1] = new SqlParameter("@shortName", SqlDbType.NVarChar);
            arParms[1].Value = shortName;
            arParms[2] = new SqlParameter("@longName", SqlDbType.NVarChar);
            arParms[2].Value = longName;
            arParms[3] = new SqlParameter("@description", SqlDbType.NVarChar);
            arParms[3].Value = description;
            arParms[4] = new SqlParameter("@statusId", SqlDbType.NVarChar);
            arParms[4].Value = statusId;
            arParms[5] = new SqlParameter("@curriculumid", SqlDbType.NVarChar);
            arParms[5].Value = curriculumid;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "sp_UpsertProgramAndStatus", arParms);
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
