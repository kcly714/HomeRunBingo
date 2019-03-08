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
    public class BingoCardService : IBingoService
    {
        private IDataProvider _dataProvider;

        public BingoCardService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
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
      

        //==================login mapper=================
        //public static UserBase LoginMapper(IDataReader reader)
        //{
        //    UserBase model = new UserBase();
        //    model.Id = reader.GetInt32(0);
        //    // changed to name from email

        //    // only returning ID and name
        //    model.Name = reader.GetString(1);
        //    return model;
        //}

      
        
    }
}
