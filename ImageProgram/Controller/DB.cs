using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ImageProgram
{
    class DB
    {
        public List<User> userList(List<User> list)
        {
            List<User> userList = new List<User>();
            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=imageProgram;Uid=root;Pwd=0000;");
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT *FROM user", connection);
            MySqlDataReader rdr = command.ExecuteReader();


            while (rdr.Read())
            {
                User user = new User();
                user.UserId = rdr["userId"].ToString();
                user.UserName = rdr["userName"].ToString();
                user.UserPassword = rdr["userPassword"].ToString();
                user.UserAddress = rdr["userAddress"].ToString();
                user.UserPhoneNumber = rdr["userPhoneNumber"].ToString();                
                user.UserRegistrationNumber = rdr["userRegistrationNumber"].ToString();
                user.UserEmail = rdr["userEmail"].ToString();
                userList.Add(user);
            }

            rdr.Close();
            connection.Close();
            return userList;
        }

        public List<Log> logList(List<Log> list)
        {
            List<Log> logList = new List<Log>();
            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=imageProgram;Uid=root;Pwd=0000;");
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT *FROM log", connection);
            MySqlDataReader rdr = command.ExecuteReader();


            while (rdr.Read())
            {
                Log log = new Log();
                log.Id = rdr["id"].ToString();
                log.Time = rdr["time"].ToString();
                log.UserName = rdr["userName"].ToString();
                log.Action = rdr["action"].ToString();
                log.SearchName= rdr["searchName"].ToString();
                logList.Add(log);
            }

            rdr.Close();
            connection.Close();
            return logList;
        }

        public void UserSave(string userID, string userName, string userPassword,  string userAddress, string userPhoneNumber, string userRegistrationNumber, string userEmail)
        {

            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=imageProgram;Uid=root;Pwd=0000;");
            connection.Open();
            string userInformationString = $"VALUES('{userID.Replace(" ", "")}', '{userName.Replace(" ", "")}', '{userPassword.Replace(" ", "")}', '{userAddress.Replace(" ", "")}','010{userPhoneNumber.Replace(" ", "")}' ,'{userRegistrationNumber.Replace(" ", "")}','{userEmail.Replace(" ", "")}')";
            //MySqlCommand command = new MySqlCommand("UPDATE userinformation, connection);
            MySqlCommand command = new MySqlCommand("INSERT INTO imageProgram.user (userID,userName,userPassword," +
                "userAddress,userPhoneNumber,userRegistrationNumber,userEmail)"
                + userInformationString, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void UserUpdate(string userID, string userPhoneNumber, string userAddress)
        {

            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=imageProgram;Uid=root;Pwd=0000;");
            connection.Open();
            MySqlCommand command;
            if (userPhoneNumber == null)
            {
                command = new MySqlCommand($"UPDATE user SET userAddress = '{userAddress}' WHERE userId = '{userID}'", connection);
            }
            else
            {
                command = new MySqlCommand($"UPDATE user SET userPhoneNumber = '{"010" + userPhoneNumber}' WHERE userId = '{userID}'", connection);
            }

            command.ExecuteNonQuery();
            connection.Close();
        }

        public void LogSave(int id, string timne, string userName, string action, string searchName)
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=imageProgram;Uid=root;Pwd=0000;");
            connection.Open();
            string logoString = $"VALUES('{id}','{timne}', '{userName}','{action}', '{searchName}')";
            MySqlCommand command = new MySqlCommand("INSERT INTO imageProgram.log (id,time,userName,action,searchName)"
                + logoString, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }


        public void UserDelete(string userID)
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=imageProgram;Uid=root;Pwd=0000;");
            connection.Open();
            MySqlCommand command = new MySqlCommand($"DELETE FROM user WHERE userId = + '{userID}'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        //    public List<LogHistoryVO> logList(List<LogHistoryVO> list)
        //    {
        //        List<LogHistoryVO> logList = new List<LogHistoryVO>();
        //        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=imageProgram;Uid=root;Pwd=0000;");
        //        connection.Open();
        //        MySqlCommand command = new MySqlCommand("SELECT *FROM logo ", connection);
        //        MySqlDataReader rdr = command.ExecuteReader();

        //        while (rdr.Read())
        //        {
        //            LogHistoryVO logHistoryVO = new LogHistoryVO();
        //            logHistoryVO.UserName = rdr["userName"].ToString();
        //            logHistoryVO.BookName = rdr["bookName"].ToString();
        //            logHistoryVO.Time = rdr["time"].ToString();
        //            logHistoryVO.Action = rdr["action"].ToString();
        //            logList.Add(logHistoryVO);
        //        }

        //        rdr.Close();
        //        connection.Close();
        //        return logList;
        //    }

    }
}
