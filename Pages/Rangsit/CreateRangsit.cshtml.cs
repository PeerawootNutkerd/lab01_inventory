using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace lab01.Pages.Rangsit
{
    public class CreateRangsitModel : PageModel
    {
        public StockInfo stockInfo = new StockInfo();
        public String errorMessage = "";
        public String successMassage = "";

        public void OnGet()
        {
        } 

        public void OnPost() 
        { 
            stockInfo.item = Request.Form["item"];
            stockInfo.storeid = Request.Form["storeid"];
            stockInfo.supplier = Request.Form["supplier"];
            stockInfo.amount = Request.Form["amount"];

            if (stockInfo.item.Length ==0|| stockInfo.storeid.Length ==0|| 
                stockInfo.supplier.Length ==0|| stockInfo.amount.Length ==0)
            {
                errorMessage = "All the fields are required";
                return;
            }

            try
            {
                String connectionString = "Server=tcp:hw-week1.database.windows.net,1433;Initial Catalog=hw_week1;Persist Security Info=False;User ID=peerawoot;Password=ASDasd123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO stocks " +
                        "(item, storeid, supplier, amount) VALUES " +
                        "(@item, @storeid, @supplier, @amount);";
                    using (SqlCommand command = new SqlCommand(sql, connection)) 
                    { 
                        command.Parameters.AddWithValue("@item",stockInfo.item);
						command.Parameters.AddWithValue("@storeid", stockInfo.storeid);
						command.Parameters.AddWithValue("@supplier", stockInfo.supplier);
						command.Parameters.AddWithValue("@amount", stockInfo.amount);

                        command.ExecuteNonQuery();
					}

				}
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            stockInfo.item = "";
			stockInfo.storeid = "";
			stockInfo.supplier = "";
			stockInfo.amount = "";
            successMassage = "New Item Added Correctly";

            Response.Redirect("/Rangsit/IndexRangsit");
		}
	}
}
