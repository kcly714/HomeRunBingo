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
        public string GetCardById(int id)
        {
            BingoCardDomain model = new BingoCardDomain();
            this._dataProvider.ExecuteCmd(
                //"Emma_User_SelectById",
                "",
                inputParamMapper: delegate (SqlParameterCollection paramList)
                {
                    paramList.AddWithValue("Id", id);
                },
                singleRecordMapper: delegate (IDataReader reader, short set)
                {
                   model = CardMapper(reader);
                }
                );
            return model;
        }


        public static BingoCardDomain CardMapper(IDataReader reader)
        {
            BingoCardDomain model = new BingoCardDomain();
            int index = 0;
            model.Id = reader.GetInt32(index++);
            model.square1 = reader.GetString(index++);
            model.square2 = reader.GetString(index++);
            model.square3 = reader.GetString(index++);
            model.square4 = reader.GetString(index++);
            model.square5 = reader.GetString(index++);
            model.square6 = reader.GetString(index++);
            model.square7 = reader.GetString(index++);
            model.square8 = reader.GetString(index++);
            model.square9 = reader.GetString(index++);
            model.square10 = reader.GetString(index++);
            model.square11 = reader.GetString(index++);
            model.square12 = reader.GetString(index++);
            model.square13 = reader.GetString(index++);
            model.square14 = reader.GetString(index++);
            model.square15 = reader.GetString(index++);
            model.square16 = reader.GetString(index++);
            // changed to name from email

            // only returning ID and name
            return model;
        }



    }
}
