using HomeRunBingo.Data.Providers;
using HomeRunBingo.Models.Domain;
using HomeRunBingo.Services.Security;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Principal;

namespace HomeRunBingo.Services
{
    public class BingoCardService : IBingoCardService
    {
        private IDataProvider _dataProvider;
        private IPrincipal _principal;

        public BingoCardService(IDataProvider dataProvider, IPrincipal principal)
        {
            _dataProvider = dataProvider;
            _principal = principal;
        }

        public int CreateBingoCard(BingoCardDomain BingoCardmodel)
        {
            UserBase userBase = (UserBase)_principal.Identity.GetCurrentUser();

            int id = 0;
            _dataProvider.ExecuteNonQuery(
               // "Emma_User_Insert",
               "HRB_Bingocard_insert",
                inputParamMapper: delegate (SqlParameterCollection paramList) {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@Id";
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    param.Direction = System.Data.ParameterDirection.Output;
                    paramList.Add(param);

                    //set userId by current user
                    paramList.AddWithValue("UserId", userBase.Id);

                    paramList.AddWithValue("card", BingoCardmodel.card);
                    paramList.AddWithValue("square1", BingoCardmodel.square1);
                    paramList.AddWithValue("square2", BingoCardmodel.square2);
                    paramList.AddWithValue("square3", BingoCardmodel.square3);
                    paramList.AddWithValue("square4", BingoCardmodel.square4);
                    paramList.AddWithValue("square5", BingoCardmodel.square5);
                    paramList.AddWithValue("square6", BingoCardmodel.square6);
                    paramList.AddWithValue("square7", BingoCardmodel.square7);
                    paramList.AddWithValue("square8", BingoCardmodel.square8);
                    paramList.AddWithValue("square9", BingoCardmodel.square9);
                    paramList.AddWithValue("square10", BingoCardmodel.square10);
                    paramList.AddWithValue("square11", BingoCardmodel.square11);
                    paramList.AddWithValue("square12", BingoCardmodel.square12);
                    paramList.AddWithValue("square13", BingoCardmodel.square13);
                    paramList.AddWithValue("square14", BingoCardmodel.square14);
                    paramList.AddWithValue("square15", BingoCardmodel.square15);
                    paramList.AddWithValue("square16", BingoCardmodel.square16);
                },
                    returnParameters: delegate (SqlParameterCollection paramList) {
                        id = (int)paramList["@Id"].Value;
                    }
                );
            return id;
        }


        public List<BingoCardDomain> SelectByUserId(int UserId)
        {
            List <BingoCardDomain> model = new List<BingoCardDomain>();
            _dataProvider.ExecuteCmd(
                "HRB_Bingocard_select_by_userId",
                inputParamMapper: delegate (SqlParameterCollection paramCol)
                {
                    paramCol.AddWithValue("@UserId", UserId);
                },
                singleRecordMapper: delegate (IDataReader reader, short set)
                {
                    BingoCardDomain Mapmodel = new BingoCardDomain();
                    int index = 0;
                    Mapmodel.Id = reader.GetInt32(index++);
                    Mapmodel.UserId = reader.GetInt32(index++);
                    Mapmodel.card = reader.GetString(index++);
                    Mapmodel.square1 = reader.GetString(index++);
                    Mapmodel.square2 = reader.GetString(index++);
                    Mapmodel.square3 = reader.GetString(index++);
                    Mapmodel.square4 = reader.GetString(index++);
                    Mapmodel.square5 = reader.GetString(index++);
                    Mapmodel.square6 = reader.GetString(index++);
                    Mapmodel.square7 = reader.GetString(index++);
                    Mapmodel.square8 = reader.GetString(index++);
                    Mapmodel.square9 = reader.GetString(index++);
                    Mapmodel.square10 = reader.GetString(index++);
                    Mapmodel.square11 = reader.GetString(index++);
                    Mapmodel.square12 = reader.GetString(index++);
                    Mapmodel.square13 = reader.GetString(index++);
                    Mapmodel.square14 = reader.GetString(index++);
                    Mapmodel.square15 = reader.GetString(index++);
                    Mapmodel.square16 = reader.GetString(index++);
                    model.Add(Mapmodel);
                }
            );
            return model;
        }


    }
}
