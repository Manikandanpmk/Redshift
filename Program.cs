using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.CData.Redshift;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redshift
{
    class Program
    {
        static void Main(string[] args)
        {
            using (RedshiftConnection connection =
            new RedshiftConnection("AuthScheme=Basic;User=awsuser;Password=nSoftware1111!;Database=dev;Server=redshift-cluster-1.czfquihghdbc.us-east-1.redshift.amazonaws.com;Port=5439"))
            {
                connection.Open();
                RedshiftCommand redshiftCommand = new RedshiftCommand("SELECT * FROM sys_tables", connection);
                RedshiftCommand cmd = redshiftCommand;
                RedshiftDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    for (int i = rdr.FieldCount - 1; i >= 0; i--)
                    {
                        Console.WriteLine(rdr.GetName(i) + ":" + rdr[i].ToString());
                    }
                    Console.ReadLine();
                    Console.ReadLine();
                }
            }
        }
        private static void AddNullAllowedColumn()
        {
            DataColumn column;
            column = new DataColumn("classID",
                System.Type.GetType("System.Int32"));
            column.AllowDBNull = true;

            // Add the column to a new DataTable.
            DataTable table;
            table = new DataTable();
            table.Columns.Add(column);
        }
    }
}

