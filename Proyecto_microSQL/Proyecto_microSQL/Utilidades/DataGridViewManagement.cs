using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace Proyecto_microSQL.Utilidades
{
    class DataGridViewManagement
    {
        string path;
        public void setPath(string p)
        {
            path = p;
        }

        public DataTable NewDataTable(string tableName)
        {
            DataTable csvData = new DataTable();
         
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(path + "tablas\\" + tableName + ".tabla"))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();

                    foreach (string column in colFields)
                    {
                        DataColumn serialno = new DataColumn(column);
                        serialno.AllowDBNull = true;
                        csvData.Columns.Add(serialno);
                    }

                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        DataRow dr = csvData.NewRow();
                        
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == null)
                                fieldData[i] = string.Empty;

                            dr[i] = fieldData[i];
                        }
                        csvData.Rows.Add(dr);
                    }

                }
                return csvData;
            }
            catch
            {
                return null;
            }
        }

        public bool Exporcsv(DataGridViewRowCollection Rows)
        {
            try
            {
                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = " (*.csv)|*.csv| (*.xlsx*)|*.xlsx ";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        var list = new List<string>(Rows.Count);
                        foreach (DataGridViewRow row in Rows)
                        {
                            var sb = new StringBuilder();
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                sb.Append(cell.FormattedValue + ",");
                            }
                            list.Add(sb.ToString());
                        }

                        myStream.Close();
                        using (StreamWriter file = new StreamWriter(saveFileDialog1.FileName, true))
                        {
                            for (int i = 0; i < Rows.Count; i++)
                            {
                                file.WriteLine(list[i]);
                            }
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable ToDataTable(List<string> list)
        {
            DataTable dataTable = new DataTable();
            try
            {

               // csvReader.SetDelimiters(new string[] { "," });
                //csvReader.HasFieldsEnclosedInQuotes = true;
                string[] colFields = list[0].Split(',');

                foreach (string column in colFields)
                {
                    DataColumn serialno = new DataColumn(column);
                    serialno.AllowDBNull = true;
                    dataTable.Columns.Add(serialno);
                }

                for (int j = 1; j < list.Count(); j++)
                {

                    string[] fieldData = list[j].Split(',');
                    DataRow dr = dataTable.NewRow();

                    for (int i = 0; i < fieldData.Length; i++)
                    {
                        if (fieldData[i] == null)
                            fieldData[i] = string.Empty;

                        dr[i] = fieldData[i];
                    }
                    dataTable.Rows.Add(dr);

                }

                return dataTable;
            }
            catch
            {
                return null;
            }
        }
    }
}
