using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
         {
         string[] tipPercent = { "Ten Percent", "Fifteen Percent", "Twenty Percent", "Other" };
         TipPercentsRBL.DataSource = tipPercent;
         TipPercentsRBL.DataBind();
         }
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        GetInfo();
    }

   protected void GetInfo()
    {
        Tip tip = new Tip();
        tip.MealAmount = double.Parse(MealTextBox.Text);
        if (OtherTextBox.Text == "")
        {
            foreach (ListItem item in TipPercentsRBL.Items)
            {
                tip.TipPercent = 0;
                if (item.Selected)
                {
                    if (item.Text.Equals("Ten Percent"))
                    {
                        tip.TipPercent = .1;
                    }
                    else if (item.Text.Equals("fifteen Percent"))
                    {
                        tip.TipPercent = .15;
                    }
                    else if (item.Text.Equals("Twenty Percent"))
                    {
                        tip.TipPercent = .2;
                    }
                }
            }
        }
        else
        {
            tip.TipPercent = double.Parse(OtherTextBox.Text);
        }

        ResultsLabel.Text = "Amount: " + tip.MealAmount.ToString() + "<br/>" + "Tip: "
            + tip.CalculateTip().ToString() + "<br/>" +
            "Tax: " + tip.CalculateTax().ToString() + "<br/>" +
            "Total: " + tip.CalculateTotal().ToString();
    }
}