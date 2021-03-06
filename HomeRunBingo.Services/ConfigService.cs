using HomeRunBingo.Data;
using HomeRunBingo.Data.Providers;
using HomeRunBingo.Models.Domain;
using HomeRunBingo.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Services
{
    public class ConfigService : IConfigService
    {
        private IDataProvider _dataProvider;

        public ConfigService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public ConfigDomain SelectById(int Id)
        {
            ConfigDomain model = null;

            _dataProvider.ExecuteCmd(
                "config_select_by_id",
                inputParamMapper: delegate (SqlParameterCollection paramList)
                {
                    paramList.AddWithValue("@Id", Id);
                },
                 singleRecordMapper: delegate (IDataReader reader, short set)
                 {
                     int index = 0;
                     model = MapConfig(reader, index);
                 }
                );
            return model;
        }

        public static ConfigDomain MapConfig(IDataReader reader, int index)
        {
            ConfigDomain model = new ConfigDomain();
            model.Id = reader.GetSafeInt32(index++);
            model.ApiName = reader.GetSafeString(index++);
            model.ApiKey = reader.GetSafeString(index++);
            return model;
        }


    }
}
