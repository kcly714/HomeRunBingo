using Movie.Data.Providers;
using Movie.Models.Responses;
using Movie.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Services.ContactUs
{


    public class ContactUsService : IContactUsService
    {

        IDataProvider _dataProvider;

        public ContactUsService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }



        public int Insert(ContactUsModel model)
        {
            int returnVal = 0;
            _dataProvider.ExecuteNonQuery(
             "contact_us_email_insert",
             inputParamMapper: delegate (SqlParameterCollection paramCol)
             {
                 SqlParameter parm = new SqlParameter();
                 parm.ParameterName = "@Id";
                 parm.SqlDbType = System.Data.SqlDbType.Int;
                 parm.Direction = System.Data.ParameterDirection.Output;
                 paramCol.Add(parm);
                 paramCol.AddWithValue("@FullName", model.FullName);
                 paramCol.AddWithValue("@Email", model.Email);
                 paramCol.AddWithValue("@Subject", model.Subject);
                 paramCol.AddWithValue("@Body", model.Body);
             },
             returnParameters: delegate (SqlParameterCollection returnParm)
             {
                 returnVal = (int)returnParm["@Id"].Value;

             }
                );
            return returnVal;





        }

    }
}
