using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace DataAccessTier
{
    public class daBodyOfKnowledge : daDataAccessModule
    {

        # region "Read Methods"

        /// <summary>
        /// Returns a "short listing" of BK2 records for compact display
        /// </summary>
        /// <param name="ConnectionString">Connection string to use</param>
        /// <returns>A DataTable "short listing" of BK2 records for compact display</returns>
        public DataTable GetBK2ShortList(string ConnectionString)
        {
            return this.GetTable("sp_BK2ShortList", ConnectionString, "BK2ShortList");
        }

        /// <summary>
        /// Returns a datatable of all Subskills. Records with values in the intersect table will
        /// have Checked=true.
        /// </summary>
        /// <param name="BK2ID">BK2ID to search</param>
        /// <param name="ConnectionString">Database connection string</param>
        /// <returns>DataTable of all subskills, with matching records "checked".</returns>
        public DataTable GetSubskillInBK2(int BK2ID, string ConnectionString)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@BK2ID", SqlDbType.Int);
            parameters[0].Value = BK2ID;
            return this.GetTable("sp_Listsubskillinbklevel2", ConnectionString, "SubskillInBK2", parameters);
        }

        //List of Body Of Knowledge BKLevel1
        public DataTable ListBKLevel1(int programid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@programid", SqlDbType.Int);
            arParms[0].Value = programid;

            pTransactionSuccessful = true;

            DataTable dtBKLevel1 = new DataTable("BKLevel1");

            try
            {
                DataSet dsBKLevel1 = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ListBodyOfKnowledge", arParms);

                dtBKLevel1 = dsBKLevel1.Tables[0];

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
            return dtBKLevel1;
        }

        //List Body Of Knowledge BKLevel2 based on BKLevel1ID
        public DataTable getBKLevel2byBKLevel1(int BKLevel1ID, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@BKLevel1ID", SqlDbType.Int);
            arParms[0].Value = BKLevel1ID;
            //arParms[1] = new SqlParameter("@NumberL1", SqlDbType.Int);
            //arParms[1].Value = NumberL1;


            pTransactionSuccessful = true;

            DataTable dtBKLevel2 = new DataTable("getBKLevel2byBKLevel1");

            try
            {
                DataSet dsBKLevel2 = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "getBKLevel2byBKLevel1", arParms);

                dtBKLevel2 = dsBKLevel2.Tables[0];

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
            return dtBKLevel2;
        }


        //Get BKLevel1Info for the selected BKLevel1 Value

        public DataTable GetBKLevel1Info(int BKLevel1ID, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@BKLevel1ID", SqlDbType.Int);
            arParms[0].Value = BKLevel1ID;

            pTransactionSuccessful = true;

            DataTable dtBKLevel1Info = new DataTable("BKLevel1Info");

            try
            {
                DataSet dsBKLevel1Info = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetBKLevel1Info", arParms);
                dtBKLevel1Info = dsBKLevel1Info.Tables[0];
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
            return dtBKLevel1Info;
        }

        //Get BKLevel2Info for the selected BKLevel2 Value

        public DataTable GetBKLevel2Info(int BKLevel2ID, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@BKLevel2ID", SqlDbType.Int);
            arParms[0].Value = BKLevel2ID;

            pTransactionSuccessful = true;

            DataTable dtBKLevel2Info = new DataTable("BKLevel2Info");

            try
            {
                DataSet dsBKLevel2Info = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetBKLevel2Info", arParms);
                dtBKLevel2Info = dsBKLevel2Info.Tables[0];
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
            return dtBKLevel2Info;
        }

        //Get BKLevel3Info for the selected BKLevel3 value


        #endregion

        # region "Insert Methods"

        //Insert Body OF knowledge Level1
        public void insertBKLevel1(string title, int NumberL1, int programid, int curriculumid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[4];

            arParms[0] = new SqlParameter("@title", SqlDbType.NVarChar);
            arParms[0].Value = title;
            arParms[1] = new SqlParameter("@NumberL1", SqlDbType.Int);
            arParms[1].Value = NumberL1;
            arParms[2] = new SqlParameter("@programid", SqlDbType.Int);
            arParms[2].Value = programid;
            arParms[3] = new SqlParameter("@curriculumid", SqlDbType.Int);
            arParms[3].Value = curriculumid;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "insertBKLevel1", arParms);
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

        //Insert BK Level2

        public void insertBKLevel2(int curriculumid, int programid, int BKLevel1ID, int NumberL1, int NumberL2, string title, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[6];
            arParms[0] = new SqlParameter("@curriculumid", SqlDbType.Int);
            arParms[0].Value = curriculumid;
            arParms[1] = new SqlParameter("@programID", SqlDbType.Int);
            arParms[1].Value = programid;
            arParms[2] = new SqlParameter("@BKLevel1ID", SqlDbType.Int);
            arParms[2].Value = BKLevel1ID;
            arParms[3] = new SqlParameter("@NumberL1", SqlDbType.Int);
            arParms[3].Value = NumberL1;
            arParms[4] = new SqlParameter("@NumberL2", SqlDbType.Int);
            arParms[4].Value = NumberL2;
            arParms[5] = new SqlParameter("@title", SqlDbType.NVarChar);
            arParms[5].Value = title;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "insertBKLevel2", arParms);
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

        # region "Update Methods"
        public void editBKLevel1Info(int BKLevel1ID, string title, int NumberL1, int programid, int curriculumid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@BKLevel1ID", SqlDbType.Int);
            arParms[0].Value = BKLevel1ID;
            arParms[1] = new SqlParameter("@title", SqlDbType.NVarChar);
            arParms[1].Value = title;
            arParms[2] = new SqlParameter("@NumberL1", SqlDbType.Int);
            arParms[2].Value = NumberL1;
            arParms[3] = new SqlParameter("@programid", SqlDbType.Int);
            arParms[3].Value = programid;
            arParms[4] = new SqlParameter("@curriculumid", SqlDbType.Int);
            arParms[4].Value = curriculumid;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "EditBKLevel1Info", arParms);
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

        public void editBKLevel2Info(int BKLevel2ID, int curriculumid, int programid, int BKLevel1ID, int NumberL1, int NumberL2, string title, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[7];
            arParms[0] = new SqlParameter("@BKLevel2ID", SqlDbType.Int);
            arParms[0].Value = BKLevel2ID;
            arParms[1] = new SqlParameter("@curriculumid", SqlDbType.Int);
            arParms[1].Value = BKLevel2ID;
            arParms[2] = new SqlParameter("@programID", SqlDbType.Int);
            arParms[2].Value = programid;
            arParms[3] = new SqlParameter("@BKLevel1ID", SqlDbType.Int);
            arParms[3].Value = BKLevel1ID;
            arParms[4] = new SqlParameter("@NumberL1", SqlDbType.Int);
            arParms[4].Value = NumberL1;
            arParms[5] = new SqlParameter("@NumberL2", SqlDbType.Int);
            arParms[5].Value = NumberL2;
            arParms[6] = new SqlParameter("@title", SqlDbType.NVarChar);
            arParms[6].Value = title;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "EditBKLevel2Info", arParms);
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

        //Edit BKLevel3 Info



        # endregion

        # region "Upsert Methods"

        /// <summary>
        /// Will insert or delete (toggle) intersect records between BK2 and SubSkill.
        /// </summary>
        /// <param name="BK2ID">BK2ID to search</param>
        /// <param name="SubSkillID">SubSkillID to search</param>
        /// <param name="ConnectionString">DB connection string</param>
        public void ToggleSubskillInBK2(int BK2ID, int SubSkillID, string ConnectionString)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@BK2ID", SqlDbType.Int);
            parameters[0].Value = BK2ID;
            parameters[1] = new SqlParameter("@SubskillID", SqlDbType.Int);
            parameters[1].Value = SubSkillID;
            this.ExecuteWithoutResult(parameters, "sp_ToggleSubskillInBK2", ConnectionString);
        }

        # endregion
    }
}
