using lab01.Pages.Rangsit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace lab01.Pages.Siam
{
    public class IndexModel : PageModel
    {
        public List<StockInfo_siam> liststock = new List<StockInfo_siam>();
        public void OnGet()
        {
            {
                try
                {
                    String connectionString = "Server=tcp:hw-week1.database.windows.net,1433;Initial Catalog=hw_week1;Persist Security Info=False;User ID=peerawoot;Password=ASDasd123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        String sql = "SELECT * FROM stocks WHERE storeid=2";
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
									StockInfo_siam stockInfo = new StockInfo_siam();
                                    stockInfo.itemid = "" + reader.GetInt32(0);
                                    stockInfo.item = reader.GetString(1);
                                    stockInfo.storeid = reader.GetString(2);
                                    stockInfo.supplier = reader.GetString(3);
                                    stockInfo.amount = reader.GetString(4);
                                    stockInfo.create_at = reader.GetDateTime(5).ToString();

                                    liststock.Add(stockInfo);
                                }
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.ToString());
                }
            }
        }

        public class StockInfo_siam
		{
            public string itemid;
            public string item;
            public string storeid;
            public string supplier;
            public string amount;
            public string create_at;
        }

    }
}
    
