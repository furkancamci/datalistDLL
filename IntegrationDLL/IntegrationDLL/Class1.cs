using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace PDMIntegration
{
    public class Product
    {
        public static Dictionary<string, object> FilterProducts(List<Dictionary<string, object>> parameters)
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
                dt.Columns.Add("Barcode");
                dt.Columns.Add("Product Name");
                dt.Columns.Add("Category");
                dt.Columns.Add("Price");
                dt.Columns.Add("Stock Amount");
                dt.Columns.Add("Description");

                if (category == 1)
                {
                    // Verileri ekleyelim
                    // Veriler veritabanı ya da harici bir servis çağrısı ile de doldurulabilir.
                    var row = dt.NewRow();
                    row["ProductID"] = "1";
                    row["Barcode"] = "A000001-XPD-0001";
                    row["Product Name"] = "Book A";
                    row["Category"] = category;
                    row["Price"] = 67;
                    row["Stock Amount"] = 5;
                    row["Description"] = "SAP Database";

                    dt.Rows.Add(row);

                    var row1 = dt.NewRow();
                    row1["ProductID"] = "2";
                    row1["Barcode"] = "A000002-XPD-0002";
                    row1["Product Name"] = "Book B";
                    row1["Category"] = category;
                    row1["Price"] = 79;
                    row1["Stock Amount"] = 15;
                    row1["Description"] = "SAP Database";

                    dt.Rows.Add(row1);

                    var row2 = dt.NewRow();
                    row2["ProductID"] = "3";
                    row2["Barcode"] = "A000003-XPD-0003";
                    row2["Product Name"] = "Book C";
                    row2["Category"] = category;
                    row2["Price"] = 57;
                    row2["Stock Amount"] = 9;
                    row2["Description"] = "SAP Database";

                    dt.Rows.Add(row2);
                }
                else
                {
                    // Verileri ekleyelim
                    // Veriler veritabanı ya da harici bir servis çağrısı ile de doldurulabilir.
                    var row = dt.NewRow();
                    row["ProductID"] = "15";
                    row["Barcode"] = "B000001-XPD-0001";
                    row["Product Name"] = "Pen A";
                    row["Category"] = category;
                    row["Price"] = 6;
                    row["Stock Amount"] = 58;
                    row["Description"] = "SAP Database";

                    dt.Rows.Add(row);

                    var row1 = dt.NewRow();
                    row1["ProductID"] = "24";
                    row1["Barcode"] = "B000002-XPD-0002";
                    row1["Product Name"] = "Pen B";
                    row1["Category"] = category;
                    row1["Price"] = 19;
                    row1["Stock Amount"] = 43;
                    row1["Description"] = "SAP Database";

                    dt.Rows.Add(row1);

                    var row2 = dt.NewRow();
                    row2["ProductID"] = "32";
                    row2["Barcode"] = "B000003-XPD-0003";
                    row2["Product Name"] = "Pen C";
                    row2["Category"] = category;
                    row2["Price"] = 14;
                    row2["Stock Amount"] = 91;
                    row2["Description"] = "SAP Database";

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

