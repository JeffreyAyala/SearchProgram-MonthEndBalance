using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace MonthEndBalanceSearch
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string lastname = "", search, picture;
            double previousBalance = 0, payments = 0, charges = 0, newBalance = 0, financeCharge = 0, monthendBalance = 0;
            bool found = false;

            search = txtsearch.Text;

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonthEndBalanceSQLConnectionString2"].ConnectionString);
            string mySelectQuery = "SELECT LastName, PreviousBalance, Payments, Charges, Picture FROM MonthendTable";
            SqlCommand command = new SqlCommand(mySelectQuery, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                lastname = reader["LastName"].ToString();

                // Compare names ignoring case and extra spaces
                if (search.Trim().Equals(lastname.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    previousBalance = Convert.ToDouble(reader["PreviousBalance"]);
                    payments = Convert.ToDouble(reader["Payments"]);
                    charges = Convert.ToDouble(reader["Charges"]);

                    // ✅ Apply the correct Charge Account formulas
                    newBalance = previousBalance - payments + charges;
                    financeCharge = newBalance * 0.12; // 12%
                    monthendBalance = newBalance + financeCharge;

                    picture = reader["Picture"].ToString();

                    // ✅ Display the computed results
                    txtpreviousbalance.Text = previousBalance.ToString("F2");
                    txtpayments.Text = payments.ToString("F2");
                    txtcharges.Text = charges.ToString("F2");
                    txtnewbalance.Text = newBalance.ToString("F2");
                    txtfinancecharge.Text = financeCharge.ToString("F2");
                    txtmonthendbalance.Text = monthendBalance.ToString("F2");

                    Image1.ImageUrl = "~/Images/" + picture;

                    found = true;
                    break;
                }
            }

            reader.Close();
            connection.Close();

            if (!found)
            {
                txtpreviousbalance.Text = "";
                txtpayments.Text = "";
                txtcharges.Text = "";
                txtnewbalance.Text = "";
                txtfinancecharge.Text = "";
                txtmonthendbalance.Text = "";
                Image1.ImageUrl = "";
            }
        }
    }
}

