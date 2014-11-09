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
    // This is daProgram
    public class daProgram
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
        public DataTable GetProgramList(string connectionString,int curriculumid)
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

        public DataTable GetProgramStatusList(string connectionString)
        {
            pTransactionSuccessful = true;

            DataTable dtProgramStatus = new DataTable("ProgramStatus");

            try
            {
                DataSet dsProgramStatus = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_GetProgramStatusList");
                dtProgramStatus = dsProgramStatus.Tables[0];
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
        public DataTable GetProgramOutcomesList(int ProgramId, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@Programid", SqlDbType.Int);
            arParms[0].Value = ProgramId;
            pTransactionSuccessful = true;

            DataTable dtProgramOutcomes = new DataTable("ProgramOutcomesList");

            try
            {
                DataSet dsProgramoutcomes = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ListProgramOutComes", arParms);
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
        public DataTable GetProgramOutcome(int prgoutcomesid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@prgoutcomesid", SqlDbType.Int);
            arParms[0].Value = prgoutcomesid;

            pTransactionSuccessful = true;
            DataTable dtProgramOutcome = new DataTable("ProgramOutcome");
            try
            {
                DataSet dsProgramOutcome = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetProgramOutComes", arParms);
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
        public DataTable GetProgramoutcomesforsubskill(int ProgramOutcomeId, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@ProgramOutcomeId ", SqlDbType.Int);
            arParms[0].Value = ProgramOutcomeId;

            pTransactionSuccessful = true;
            DataTable dtProgramOutcome = new DataTable("ProgramOutcome");
            try
            {
                DataSet dsProgramOutcome = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Programoutcomesforsubskill", arParms);
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

        public DataTable Getproglist(int prgoutcomesid, string connectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@prgoutcomesid", SqlDbType.Int);
            arParms[0].Value = prgoutcomesid;


            pTransactionSuccessful = true;

            DataTable dtProgramInfo = new DataTable("ProgramInfo");

            try
            {
                DataSet dsProgramInfo = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Getproglist", arParms);
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

        public DataTable GetProgramddl(string connectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[0];



            pTransactionSuccessful = true;

            DataTable dtProgramInfo = new DataTable("ProgramInfo");

            try
            {
                DataSet dsProgramInfo = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetProgramdd", arParms);
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

        public DataTable ListSkillClass(int ProgramId, string ConnectionString) //Need to pass a parameter of ProgramID, to call
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@programid", SqlDbType.Int);
            arParms[0].Value = ProgramId;

            pTransactionSuccessful = true;

            DataTable dtSkillClass = new DataTable("SkillClassList");

            try
            {
                DataSet dsSkillClass = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ListSkillClass", arParms);

                dtSkillClass = dsSkillClass.Tables[0];

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
            return dtSkillClass;
        }

        public DataTable getskillsbyskillclassnum(int skillsclassnum, string ConnectionString)
        {
            // Set up parameters in parameter array 
            //skillsclassnum = 1;
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@skillsclassnum", SqlDbType.Int);
            arParms[0].Value = skillsclassnum;


            pTransactionSuccessful = true;

            DataTable dtSkills = new DataTable("GetSkillsBySkillClassnum");

            try
            {
                DataSet dsSkills = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetSkillsBySkillClassnum", arParms);

                dtSkills = dsSkills.Tables[0];

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
            return dtSkills;
        }

        public DataTable GetSkillClassInfo(int skillclassid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@skillclassid", SqlDbType.Int);
            arParms[0].Value = skillclassid;

            pTransactionSuccessful = true;

            DataTable dtSkillClass = new DataTable("Skillsets");

            try
            {
                DataSet dsSkillClass = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetSkillClassInfo", arParms);
                dtSkillClass = dsSkillClass.Tables[0];
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
            return dtSkillClass;
        }

        public DataTable GetSubSkillBySkillClassNum(int skillsnum, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@skillsnum", SqlDbType.Int);
            arParms[0].Value = skillsnum;


            pTransactionSuccessful = true;

            DataTable dtSubSkill = new DataTable("getsubskillbyskillclassskill");

            try
            {
                DataSet dsSubSkill = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetSubSkillBySkillClassNum", arParms);

                dtSubSkill = dsSubSkill.Tables[0];

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
            return dtSubSkill;
        }

        public DataTable GetSkillsInfo(int skillsId, string con)
        {
            // Set up parameters in parameter array 
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@skillsId", SqlDbType.Int);
            arParms[0].Value = skillsId;
            pTransactionSuccessful = true;

            DataTable dtSkills = new DataTable("GetSkills");

            try
            {
                DataSet dsSkills = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetSkillsInfo", arParms);

                dtSkills = dsSkills.Tables[0];

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
            return dtSkills;
        }

        //List of SubSkill
        public DataTable getsubskillbyskillclassskill(int skillsclassnum, int skillsnum, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@skillsclassnum", SqlDbType.Int);
            arParms[0].Value = skillsclassnum;
            arParms[1] = new SqlParameter("@skillsnum", SqlDbType.Int);
            arParms[1].Value = skillsnum;


            pTransactionSuccessful = true;

            DataTable dtSubSkill = new DataTable("getsubskillbyskillclassskill");

            try
            {
                DataSet dsSubSkill = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "getsubskillbyskillclassskill", arParms);

                dtSubSkill = dsSubSkill.Tables[0];

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
            return dtSubSkill;
        }

        //Get SubSkill info
        public DataTable GetSubSkillInfo(int subskillid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@subskillid", SqlDbType.Int);
            arParms[0].Value = subskillid;

            pTransactionSuccessful = true;
            DataTable dtSubSkill = new DataTable("SubSkill");

            try
            {
                DataSet dsSubSkill = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetSubSkillInfo", arParms);
                dtSubSkill = dsSubSkill.Tables[0];

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
            return dtSubSkill;
        }


        #endregion

        #region " Insert methods "

        //For Inserting ProgramOutcome
        public void InsertProgramOutcome(int programid, string prgoutcometext, string prgshortoutcome, String prgsequencenum, string ConnectionString)
        {
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

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Insertprogramoutcomes", arParms);
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
        public void InsertProgrOuctomeSubskill(int programOutomeID, int subSkillId, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@programOutomeID", SqlDbType.Int);
            arParms[0].Value = programOutomeID;
            arParms[1] = new SqlParameter("@subSkillId", SqlDbType.Int);
            arParms[1].Value = subSkillId;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "InsertProgrOutcomeSubskill", arParms);
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
        //For Inserting SkillClass
        public void insertskillclass(string scname, int skillsclassnum, int programid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@scname", SqlDbType.NVarChar);
            arParms[0].Value = scname;
            arParms[1] = new SqlParameter("@skillsclassnum", SqlDbType.Int);
            arParms[1].Value = skillsclassnum;
            arParms[2] = new SqlParameter("@programid", SqlDbType.Int);
            arParms[2].Value = programid;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "insertskillclass", arParms);
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

        //For Inserting Skills
        public void insertskills(int skillsclassnum, int skillsnum, string skillsname, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@skillsclassnum", SqlDbType.Int);
            arParms[0].Value = skillsclassnum;
            arParms[1] = new SqlParameter("@skillsnum", SqlDbType.Int);
            arParms[1].Value = skillsnum;
            arParms[2] = new SqlParameter("@skillsname", SqlDbType.NVarChar);
            arParms[2].Value = skillsname;

            pTransactionSuccessful = true;

            try {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "insertskills", arParms);
            } catch (SqlException InsertError) {
                pErrorMessage = InsertError.Message.ToString();
                pErrorNumber = InsertError.Number;
                pErrorClass = InsertError.Class;
                pErrorState = InsertError.State;
                pErrorLineNumber = InsertError.LineNumber;

                pTransactionSuccessful = false;
            }
        }

        //For Inserting SubSkill
        public void insertsubskill(int skillsclassnum, int skillsnum, int subskillnum, string subskilltitle, string jobadwords, string subskillcomb, string ConnectionString)
        {
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

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "insertsubskill", arParms);
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

        #region " Update methods "

        ///
        /// Update Methods Here..
        /// 

        //For Updatting ProgramOutcome
        public void UpdateProgramOutcome(int prgoutcomesid, int programid, string prgoutcometext, string prgshortoutcome, string prgsequencenum, string ConnectionString)
        {
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

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Updateprogramoutcomes", arParms);
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

        public void editskillclass(int skillclassid, int skillsclassnum, string skillsname, int programid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@skillclassid", SqlDbType.Int);
            arParms[0].Value = skillclassid;
            arParms[2] = new SqlParameter("@skillsclassnum", SqlDbType.Int);
            arParms[2].Value = skillsclassnum;
            arParms[1] = new SqlParameter("@skillsname", SqlDbType.NVarChar);
            arParms[1].Value = skillsname;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "editskillclass", arParms);
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

        //Update Method for Skills
        public void editskills(int skillsid, int skillsclassnum, int skillsnum, string skillsname, string ConnectionString)
        {
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

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "editskills", arParms);
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

        //Update method for SubSkill
        public void editsubskill(int subskillid, int skillsclassnum, int skillsnum, int subskillnum, string subskilltitle, string subskillcomb, string jobadwords, string ConnectionString)
        {
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

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "editsubskill", arParms);
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

        #endregion

        #region " Delete methods "

        ///
        /// Delete Methods Here..
        /// 

        public void DeleteProgrOuctomeSubskill(int ProgramOutcomeId, int subSkillId, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@ProgramOutcomeId", SqlDbType.Int);
            arParms[0].Value = ProgramOutcomeId;
            arParms[1] = new SqlParameter("@subSkillId", SqlDbType.Int);
            arParms[1].Value = subSkillId;



            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "DeleteProgrOutcomeSubskill", arParms);
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

        #region " Upsert methods "

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
        // Call this method with correct parameters to add or update the person and relative institutionpeople table
        public void AddEditProgramInformation(int curriculumid,int programId, string shortName, string longName, string description, int statusId, string connectionString)
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
