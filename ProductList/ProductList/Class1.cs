using System;
using System.Collections.Generic;
using System.Data;

namespace ProductList
{
    public class Product
    {
        public static Dictionary<string, object> GetList(List<Dictionary<string, object>> parameters)

        {

            var result = new Dictionary<string, object>();

            var List = new List<Dictionary<string, object>>();

            // Bu Error keyi zorunlu. Boş da olsa döndürülmelidir.
            result["Error"] = "";

            try

            {
                var category = Convert.ToInt32(parameters[0]["category"]);

                var dt = new DataTable();
                //dt.Clear();

                // Sütunları ekleyelim
                dt.Columns.Add("ProductID");
                dt.Columns.Add("ProductName");
                dt.Columns.Add("Category");
                dt.Columns.Add("Price");
                dt.Columns.Add("Amount");

                if (category == 1)
                {
                    // Verileri ekleyelim
                    // Veriler veritabanı ya da harici bir servis çağrısı ile de doldurulabilir.
                    var row = dt.NewRow();
                    row["ProductID"] = "1";
                    row["ProductName"] = "Book A";
                    row["Category"] = category;
                    row["Price"] = 67;
                    row["Amount"] = 5;

                    dt.Rows.Add(row);

                    var row1 = dt.NewRow();
                    row1["ProductID"] = "2";
                    row1["ProductName"] = "Book B";
                    row1["Category"] = category;
                    row1["Price"] = 79;
                    row1["Amount"] = 15;

                    dt.Rows.Add(row1);

                    var row2 = dt.NewRow();
                    row2["ProductID"] = "3";
                    row2["ProductName"] = "Book C";
                    row2["Category"] = category;
                    row2["Price"] = 57;
                    row2["Amount"] = 9;

                    dt.Rows.Add(row2);
                }
                else
                {
                    // Verileri ekleyelim
                    // Veriler veritabanı ya da harici bir servis çağrısı ile de doldurulabilir.
                    var row = dt.NewRow();
                    row["ProductID"] = "1";
                    row["ProductName"] = "Pen A";
                    row["Category"] = category;
                    row["Price"] = 6;
                    row["Amount"] = 58;

                    dt.Rows.Add(row);

                    var row1 = dt.NewRow();
                    row1["ProductID"] = "2";
                    row1["ProductName"] = "Pen B";
                    row1["Category"] = category;
                    row1["Price"] = 19;
                    row1["Amount"] = 43;

                    dt.Rows.Add(row1);

                    var row2 = dt.NewRow();
                    row2["ProductID"] = "3";
                    row2["ProductName"] = "Pen C";
                    row2["Category"] = category;
                    row2["Price"] = 14;
                    row2["Amount"] = 91;

                    dt.Rows.Add(row2);
                }

                foreach (DataRow dr in dt.Rows)
                {
                    //Dönüş tipimiz Dictionary olduğu için her bir satırı
                    // da bir Dictionary olarak döndürüyoruz.
                    var rows = new Dictionary<string, object>();

                    foreach (DataColumn col in dt.Columns)
                        rows.Add(col.ColumnName, dr[col.ColumnName]);

                    List.Add(rows);
                }

                //List keyi ile doldurmamız gerekiyor.
                result["List"] = List;

            }

            catch (Exception ex)

            {

                result["Error"] = ex.Message;

            }

            return result;

        }

    }
}

