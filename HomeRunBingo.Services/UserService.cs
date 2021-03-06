using HomeRunBingo.Data.Providers;
using HomeRunBingo.Models.Domain;
using HomeRunBingo.Models.Requests;
using HomeRunBingo.Services;
using HomeRunBingo.Services.Cryptography;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HomeRunBingo.Services
{
    public class UserService : IUserService
    {
        private IAuthenticationService _authenticationService;
        private ICryptographyService _cryptographyService;
        private IDataProvider _dataProvider;
        private const int HASH_ITERATION_COUNT = 1;
        private const int RAND_LENGTH = 15;

        public UserService(IAuthenticationService authService, ICryptographyService cryptographyService, IDataProvider dataProvider)
        {
            _authenticationService = authService;
            _dataProvider = dataProvider;
            _cryptographyService = cryptographyService;
        }


        private string GetSalt(string email)
        {
            //DataProvider Call to get Salt
            string _salt = "";
            UserProfileDomain model = new UserProfileDomain();
            this._dataProvider.ExecuteCmd(
                "HRB_users_select_salt_by_email",
                inputParamMapper: delegate (SqlParameterCollection paramList)
                {
                    paramList.AddWithValue("Email", email);
                },
                 singleRecordMapper: delegate (IDataReader reader, short set)
                 {
                     _salt = reader.GetString(0);
                     //model = Mapper(reader);
                 });
            return _salt;
        }

        //======================================Register====================================
        public int CreateUser(RegisterAddRequest registerAddRequest)
        {
            int id = 0;
            string password = registerAddRequest.Password;
            string salt = _cryptographyService.GenerateRandomString(RAND_LENGTH);
            string passwordHash = _cryptographyService.Hash(password, salt, HASH_ITERATION_COUNT);
            this._dataProvider.ExecuteNonQuery(
               // "Emma_User_Insert",
               "HRB_user_insert",
                inputParamMapper: delegate (SqlParameterCollection paramList)
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@Id";
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    param.Direction = System.Data.ParameterDirection.Output;
                    paramList.Add(param);

                    paramList.AddWithValue("Email", registerAddRequest.Email);
                    paramList.AddWithValue("FirstName", registerAddRequest.FirstName);
                    paramList.AddWithValue("MiddleInitial", registerAddRequest.MiddleInitial);
                    paramList.AddWithValue("LastName", registerAddRequest.LastName);
                    paramList.AddWithValue("Password", passwordHash);
                    paramList.AddWithValue("ConfirmPassword", passwordHash);
                    paramList.AddWithValue("Salt", salt);
                },
                    returnParameters: delegate (SqlParameterCollection paramList)
                    {
                        id = (int)paramList["@Id"].Value;
                    }
                );
            return id;
        }
        //==============Login ============
        public bool UserLogIn(LoginRequest loginRequest)
        {
            bool isSuccessful = false;
            string email = loginRequest.Email;
            //======get the salt from sql table======
            string salt = GetSalt(loginRequest.Email);

            if (!String.IsNullOrEmpty(salt))
            {
                //======generate the hash password with the user input password=============
                string passwordHash = _cryptographyService.Hash(loginRequest.Password, salt, HASH_ITERATION_COUNT);
                //===========pass the email and Hashpassword in to the log in=======
                UserBase response = UserLogInWithHash(email, passwordHash);

                if (response.Id != 0)
                {
                    _authenticationService.LogIn(response);
                    isSuccessful = true;
                }
            }

            return isSuccessful;
        }

        //================select by id===================
        public string UserSelectById(int id)
        {
            UserProfileDomain model = new UserProfileDomain();
            this._dataProvider.ExecuteCmd(
                //"Emma_User_SelectById",
                "HRB_user_select_by_id",
                inputParamMapper: delegate (SqlParameterCollection paramList)
                {
                    paramList.AddWithValue("Id", id);
                },
                singleRecordMapper: delegate (IDataReader reader, short set)
                {
                    model = Mapper(reader);
                }
                );
            return model.Email;
        }

        //===================Login with the hash password==========
        public UserBase UserLogInWithHash(string email, string passwordHash)
        {
            UserBase response = new UserBase();

            this._dataProvider.ExecuteCmd(
                //"Emma_Login",
                "HRB_users_select_by_email",
                inputParamMapper: delegate (SqlParameterCollection paramList)
                {
                    paramList.AddWithValue("Email", email);
                    paramList.AddWithValue("Password", passwordHash);
                },
                 singleRecordMapper: delegate (IDataReader reader, short set)
                 {
                     //int index = 0;
                     response = LoginMapper(reader);
                 });


            return response;
        }

        //==================login mapper=================
        public static UserBase LoginMapper(IDataReader reader)
        {
            UserBase model = new UserBase();
            model.Id = reader.GetInt32(0);
            // changed to name from email

            // only returning ID and name
            model.Name = reader.GetString(1);
            return model;
        }

        //==================mapper==========================
        private static UserProfileDomain Mapper(IDataReader reader)
        {
            UserProfileDomain model = new UserProfileDomain();
            int index = 0;
            model.Id = reader.GetInt32(index++);
            model.FirstName = reader.GetString(index++);
            model.MiddleInitial = reader.GetString(index++);
            model.LastName = reader.GetString(index++);
            model.Email = reader.GetString(index++);
            model.Password = reader.GetString(index++);
            model.ConfirmPassword = reader.GetString(index++);
            model.Salt = reader.GetString(index++);
            return model;
        }
    }
}
