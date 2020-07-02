using IDTPDomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Data;

namespace IDTPDataAccessLayer.Helper
{
    public class ReportComponents
    {
        public DataTable GetDataWithSProc(string sprocName)
        {
            DataTable data = new DataTable();
            using (var context = new IDTPDBContext())
            {
                SqlConnection sqlConnection = new SqlConnection(context.Database.GetDbConnection().ConnectionString);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sprocName, sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlDataAdapter.Fill(data);
                sqlConnection.Close();
                sqlDataAdapter.Dispose();
            }
            return data;
        }
        public DataTable GetDataUsingSprocWithParam(string sprocName, string prameterName, string parameterValue, SqlDbType sqlDbType)
        {
            DataTable data = new DataTable();
            using (var context = new IDTPDBContext())
            {
                SqlConnection sqlConnection = new SqlConnection(context.Database.GetDbConnection().ConnectionString);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sprocName, sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                sqlDataAdapter.SelectCommand.CommandTimeout = 120;

                /*SqlParameter SqlParameter = new SqlParameter(prameterName, sqlDbType);
                SqlParameter.Value = parameterValue;
                sqlDataAdapter.SelectCommand.Parameters.Add(SqlParameter);
                */
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue(prameterName, Int32.Parse(parameterValue));
                sqlConnection.Open();
                sqlDataAdapter.Fill(data);
                sqlConnection.Close();
                sqlDataAdapter.Dispose();
            }
            return data;
        }


        public StringWriter GetCSVString(DataTable dataToWrite)
        {
            StringWriter stringWriter = new StringWriter();            
            int colCount = dataToWrite.Columns.Count;
            for (int i = 0; i < colCount; i++)
            {
                stringWriter.Write("\"");
                stringWriter.Write(dataToWrite.Columns[i]);
                if (i < colCount - 1)
                {
                    stringWriter.Write("\",");
                }
            }
            if (colCount > 0)
            {
                stringWriter.Write("\"");
            }
            stringWriter.Write(stringWriter.NewLine);
            foreach (DataRow dr in dataToWrite.Rows)
            {
                for (int i = 0; i < colCount; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        stringWriter.Write("\"");
                        stringWriter.Write(dr[i].ToString());
                    }
                    if (i < colCount - 1)
                    {
                        stringWriter.Write("\",");
                    }
                }
                if (colCount > 0)
                {
                    stringWriter.Write("\"");
                }
                stringWriter.Write(stringWriter.NewLine);
            }
            return stringWriter;
        }
    }
}
