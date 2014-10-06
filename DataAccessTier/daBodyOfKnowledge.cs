using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
namespace DataAccessTier
{
   public class daBodyOfKnowledge
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

        #endregion

        # region "Read Methods"

        //List of Body Of Knowledge BKLevel1
        public DataTable ListBKLevel1(int ISModelID,string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@ISModelID", SqlDbType.Int);
            arParms[0].Value = ISModelID;
           
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
        public DataTable getBKLevel2byBKLevel1(int ISModelID,int NumberL1, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@ISModelID", SqlDbType.Int);
            arParms[0].Value = ISModelID;
            arParms[1] = new SqlParameter("@NumberL1", SqlDbType.Int);
            arParms[1].Value = NumberL1;


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

       //List Body Of Knowledge BKLevel3 based on BKLevel2ID,BKLeveliID

        public DataTable getBKLevel3byBKLevel2(int ISModelID, int NumberL1,int NumberL2, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@ISModelID", SqlDbType.Int);
            arParms[0].Value = ISModelID;
            arParms[1] = new SqlParameter("@NumberL1", SqlDbType.Int);
            arParms[1].Value = NumberL2;
            arParms[2] = new SqlParameter("@NumberL2", SqlDbType.Int);
            arParms[2].Value = NumberL2;


            pTransactionSuccessful = true;

            DataTable dtBKLevel3 = new DataTable("getBKLevel3byBKLevel2");

            try
            {
                DataSet dsBKLevel3 = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "getBKLevel3byBKLevel2", arParms);

                dtBKLevel3 = dsBKLevel3.Tables[0];

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
            return dtBKLevel3;
        }

        //List Body Of Knowledge BKLevel4 based on BKLevel3,BKLevel2ID,BKLevel1ID

        public DataTable getBKLevel4byBKLevel3(int ISModelID, int NumberL1, int NumberL2,int NumberL3, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@ISModelID", SqlDbType.Int);
            arParms[0].Value = ISModelID;
            arParms[1] = new SqlParameter("@NumberL1", SqlDbType.Int);
            arParms[1].Value = NumberL2;
            arParms[2] = new SqlParameter("@NumberL2", SqlDbType.Int);
            arParms[2].Value = NumberL2;
            arParms[3] = new SqlParameter("@NumberL3", SqlDbType.Int);
            arParms[3].Value = NumberL3;


            pTransactionSuccessful = true;

            DataTable dtBKLevel4 = new DataTable("getBKLevel4byBKLevel3");

            try
            {
                DataSet dsBKLevel4 = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "getBKLevel4byBKLevel3", arParms);

                dtBKLevel4 = dsBKLevel4.Tables[0];

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
            return dtBKLevel4;
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

        public DataTable GetBKLevel3Info(int BKLevel3ID, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@BKLevel3ID", SqlDbType.Int);
            arParms[0].Value = BKLevel3ID;

            pTransactionSuccessful = true;

            DataTable dtBKLevel3Info = new DataTable("BKLevel3Info");

            try
            {
                DataSet dsBKLevel3Info = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetBKLevel3Info", arParms);
                dtBKLevel3Info = dsBKLevel3Info.Tables[0];
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
            return dtBKLevel3Info;
        }

       //Get BKLevel4Info for the selected BKLevel4 value

        public DataTable GetBKLevel4Info(int BKLevel4ID, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@BKLevel4ID", SqlDbType.Int);
            arParms[0].Value = BKLevel4ID;

            pTransactionSuccessful = true;

            DataTable dtBKLevel4Info = new DataTable("BKLevel4Info");

            try
            {
                DataSet dsBKLevel4Info = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetBKLevel4Info", arParms);
                dtBKLevel4Info = dsBKLevel4Info.Tables[0];
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
            return dtBKLevel4Info;
        }

        #endregion

    # region "Insert Methods"

       //Insert Body OF knowledge Level1
        public void insertBKLevel1(string title, int NumberL1, int ISModelID, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@title", SqlDbType.NVarChar);
            arParms[0].Value = title;
            arParms[1] = new SqlParameter("@NumberL1", SqlDbType.Int);
            arParms[1].Value = NumberL1;
            arParms[2] = new SqlParameter("@ISModelID", SqlDbType.Int);
            arParms[2].Value = ISModelID;

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

        public void insertBKLevel2(int ISModelID,int BKLevel1ID, int NumberL1, int NumberL2, string title, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[5];

            arParms[0] = new SqlParameter("@ISModelID", SqlDbType.Int);
            arParms[0].Value = ISModelID;
            arParms[1] = new SqlParameter("@BKLevel1ID", SqlDbType.Int);
            arParms[1].Value = BKLevel1ID;
            arParms[2] = new SqlParameter("@NumberL1", SqlDbType.Int);
            arParms[2].Value = NumberL1;
            arParms[3] = new SqlParameter("@NumberL2", SqlDbType.Int);
            arParms[3].Value = NumberL2;
            arParms[4] = new SqlParameter("@title", SqlDbType.NVarChar);
            arParms[4].Value = title;
            
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
       
       //Insert BKLevel3

        public void insertBKLevel3(int ISModelID,int BKLevel1ID,int BKLevel2ID,int NumberL1, int NumberL2,int NumberL3, string title, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[7];

                                   
            arParms[0] = new SqlParameter("@ISModelID", SqlDbType.Int);
            arParms[0].Value = ISModelID;
            arParms[1] = new SqlParameter("@BKLevel1ID", SqlDbType.Int);
            arParms[1].Value = BKLevel1ID;
            arParms[2] = new SqlParameter("@BKLevel2ID", SqlDbType.Int);
            arParms[2].Value = BKLevel2ID;
            arParms[3] = new SqlParameter("@NumberL1", SqlDbType.Int);
            arParms[3].Value = NumberL1;
            arParms[4] = new SqlParameter("@NumberL2", SqlDbType.Int);
            arParms[4].Value = NumberL2;
            arParms[5] = new SqlParameter("@NumberL3", SqlDbType.Int);
            arParms[5].Value = NumberL3;
            arParms[6] = new SqlParameter("@title", SqlDbType.NVarChar);
            arParms[6].Value = title;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "insertBKLevel3", arParms);
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

       //Insert BK Level4

        public void insertBKLevel4(int ISModelID, int BKLevel1ID, int BKLevel2ID,int BKLevel3ID, int NumberL1, int NumberL2, int NumberL3,int NumberL4, string title, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[9];

            arParms[0] = new SqlParameter("@ISModelID", SqlDbType.Int);
            arParms[0].Value = ISModelID;
            arParms[1] = new SqlParameter("@BKLevel1ID", SqlDbType.Int);
            arParms[1].Value = BKLevel1ID;
            arParms[2] = new SqlParameter("@BKLevel2ID", SqlDbType.Int);
            arParms[2].Value = BKLevel2ID;
            arParms[3] = new SqlParameter("@BKLevel3ID", SqlDbType.Int);
            arParms[3].Value = BKLevel3ID;
            arParms[4] = new SqlParameter("@NumberL1", SqlDbType.Int);
            arParms[4].Value = NumberL1;
            arParms[5] = new SqlParameter("@NumberL2", SqlDbType.Int);
            arParms[5].Value = NumberL2;
            arParms[6] = new SqlParameter("@NumberL3", SqlDbType.Int);
            arParms[6].Value = NumberL3;
            arParms[7] = new SqlParameter("@NumberL4", SqlDbType.Int);
            arParms[7].Value = NumberL3;
            arParms[8] = new SqlParameter("@title", SqlDbType.NVarChar);
            arParms[8].Value = title;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "insertBKLevel4", arParms);
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
        public void editBKLevel1Info(int BKLevel1ID, string title, int NumberL1, int programid, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@BKLevel1ID", SqlDbType.Int);
            arParms[0].Value = BKLevel1ID;
            arParms[1] = new SqlParameter("@title", SqlDbType.NVarChar);
            arParms[1].Value = title;
            arParms[2] = new SqlParameter("@NumberL1", SqlDbType.Int);
            arParms[2].Value = NumberL1;
            arParms[3] = new SqlParameter("@programid", SqlDbType.Int);
            arParms[3].Value = programid;

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

        public void editBKLevel2Info(int BKLevel2ID, int ISModelID, int BKLevel1ID, int NumberL1, int NumberL2, string title, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[6];
            arParms[0] = new SqlParameter("@BKLevel2ID", SqlDbType.Int);
            arParms[0].Value = BKLevel2ID;
            arParms[1] = new SqlParameter("@ISModelID", SqlDbType.Int);
            arParms[1].Value = ISModelID;
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

        public void editBKLevel3Info(int BKLevel3ID, int ISModelID, int BKLevel1ID,int BKLevel2ID, int NumberL1, int NumberL2,int NumberL3, string title, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[8];
            arParms[0] = new SqlParameter("@BKLevel3ID", SqlDbType.Int);
            arParms[0].Value = BKLevel3ID;
            arParms[1] = new SqlParameter("@ISModelID", SqlDbType.Int);
            arParms[1].Value = ISModelID;
            arParms[2] = new SqlParameter("@BKLevel1ID", SqlDbType.Int);
            arParms[2].Value = BKLevel1ID;
            arParms[3] = new SqlParameter("@BKLevel2ID", SqlDbType.Int);
            arParms[3].Value = BKLevel2ID;
            arParms[4] = new SqlParameter("@NumberL1", SqlDbType.Int);
            arParms[4].Value = NumberL1;
            arParms[5] = new SqlParameter("@NumberL2", SqlDbType.Int);
            arParms[5].Value = NumberL2;
            arParms[6] = new SqlParameter("@NumberL3", SqlDbType.Int);
            arParms[6].Value = NumberL3;
            arParms[7] = new SqlParameter("@title", SqlDbType.NVarChar);
            arParms[7].Value = title;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "EditBKLevel3Info", arParms);
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

       //Edit BKLevel4 Info
        public void editBKLevel4Info(int BKLevel4ID, int ISModelID, int BKLevel1ID, int BKLevel2ID,int BKLevel3ID, int NumberL1, int NumberL2, int NumberL3,int NumberL4, string title, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[10];
            arParms[0] = new SqlParameter("@BKLevel4ID", SqlDbType.Int);
            arParms[0].Value = BKLevel4ID;
            arParms[1] = new SqlParameter("@ISModelID", SqlDbType.Int);
            arParms[1].Value = ISModelID;
            arParms[2] = new SqlParameter("@BKLevel1ID", SqlDbType.Int);
            arParms[2].Value = BKLevel1ID;
            arParms[3] = new SqlParameter("@BKLevel2ID", SqlDbType.Int);
            arParms[3].Value = BKLevel2ID;
            arParms[4] = new SqlParameter("@BKLevel3ID", SqlDbType.Int);
            arParms[4].Value = BKLevel3ID;

            arParms[5] = new SqlParameter("@NumberL1", SqlDbType.Int);
            arParms[5].Value = NumberL1;
            arParms[6] = new SqlParameter("@NumberL2", SqlDbType.Int);
            arParms[6].Value = NumberL2;
            arParms[7] = new SqlParameter("@NumberL3", SqlDbType.Int);
            arParms[7].Value = NumberL3;
            arParms[8] = new SqlParameter("@NumberL3", SqlDbType.Int);
            arParms[8].Value = NumberL3;
            arParms[9] = new SqlParameter("@title", SqlDbType.NVarChar);
            arParms[9].Value = title;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "EditBKLevel4Info", arParms);
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
        

        # endregion
 # region "Upsert Methods"
       //Add or Edit BKLevel3

        public void AddEditBKLevel3Info(int BKLevel3ID, int ISModelID, int BKLevel1ID, int BKLevel2ID, int NumberL1, int NumberL2, int NumberL3, string title, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[8];
            arParms[0] = new SqlParameter("@BKLevel3ID", SqlDbType.Int);
            arParms[0].Value = BKLevel3ID;
            arParms[1] = new SqlParameter("@ISModelID", SqlDbType.Int);
            arParms[1].Value = ISModelID;
            arParms[2] = new SqlParameter("@BKLevel1ID", SqlDbType.Int);
            arParms[2].Value = BKLevel1ID;
            arParms[3] = new SqlParameter("@BKLevel2ID", SqlDbType.Int);
            arParms[3].Value = BKLevel2ID;
            arParms[4] = new SqlParameter("@NumberL1", SqlDbType.Int);
            arParms[4].Value = NumberL1;
            arParms[5] = new SqlParameter("@NumberL2", SqlDbType.Int);
            arParms[5].Value = NumberL2;
            arParms[6] = new SqlParameter("@NumberL3", SqlDbType.Int);
            arParms[6].Value = NumberL3;
            arParms[7] = new SqlParameter("@title", SqlDbType.NVarChar);
            arParms[7].Value = title;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "sp_upsertBKLevel3Info", arParms);
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
       
       //ADD EDIT BKLevel4

        public void AddEditBKLevel4Info(int BKLevel4ID, int ISModelID, int BKLevel1ID, int BKLevel2ID, int BKLevel3ID, int NumberL1, int NumberL2, int NumberL3, int NumberL4, string title, string ConnectionString)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[10];
            arParms[0] = new SqlParameter("@BKLevel4ID", SqlDbType.Int);
            arParms[0].Value = BKLevel4ID;
            
            arParms[1] = new SqlParameter("@ISModelID", SqlDbType.Int);
            arParms[1].Value = ISModelID;
            
            arParms[2] = new SqlParameter("@BKLevel1ID", SqlDbType.Int);
            arParms[2].Value = BKLevel1ID;
            
            arParms[3] = new SqlParameter("@BKLevel2ID", SqlDbType.Int);
            arParms[3].Value = BKLevel2ID;
           
            arParms[4] = new SqlParameter("@BKLevel3ID", SqlDbType.Int);
            arParms[4].Value = BKLevel3ID;

            arParms[5] = new SqlParameter("@NumberL1", SqlDbType.Int);
            arParms[5].Value = NumberL1;
            
            arParms[6] = new SqlParameter("@NumberL2", SqlDbType.Int);
            arParms[6].Value = NumberL2;
            
            arParms[7] = new SqlParameter("@NumberL3", SqlDbType.Int);
            arParms[7].Value = NumberL3;
            
            arParms[8] = new SqlParameter("@NumberL4", SqlDbType.Int);
            arParms[8].Value = NumberL4;
                        
            arParms[9] = new SqlParameter("@title", SqlDbType.NVarChar);
            arParms[9].Value = title;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "sp_upsertBKLevel4Info", arParms);
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

# endregion
   }
}
