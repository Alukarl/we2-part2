using Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExportCalculate
{
    public partial class wfWay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.getData();
            upWay.Update();
        }
        protected async void getData()
        {
            Ways oWays = new Ways();
            oWays.RunAsync();
            List<HelperWays> dsorce = await oWays.GetsWaysAsync();
            gvData.DataSource = dsorce;
            gvData.DataBind();
            upWay.Update();
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDistance.Text) || String.IsNullOrEmpty(txtStopes.Text))
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error! Some fields are empty!')", true);
            }
            else
            {
                if (Session["edit"] != null)
            {
                HelperWays oHelper = new HelperWays
                {
                    Id = Session["edit"].ToString(),

                    distance = Convert.ToDecimal(txtDistance.Text),
                    stopes = Convert.ToDecimal(txtStopes.Text)
                };
                Session["edit"] = null;
                Ways oWays = new Ways();
                oWays.RunAsync();
                var url = oWays.UpdateWaysAsync(oHelper);

            }
            else
            {
                HelperWays oHelper = new HelperWays
                {

                    distance = Convert.ToDecimal(txtDistance.Text),
                    stopes = Convert.ToDecimal(txtStopes.Text)
                };
                Ways oContainerts = new Ways();
                oContainerts.RunAsync();
                var url = oContainerts.CreateWaysAsync(oHelper);
            }
            upWay.Update();
        }
        }

        protected void gvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            Object source = (e.CommandSource as GridView).DataSource;
            List<HelperWays> list = source as List<HelperWays>;
            HelperWays oHelperWays = list[index];
            if (e.CommandName == "edit")
            {
                txtDistance.Text = oHelperWays.distance.ToString();
                txtStopes.Text = oHelperWays.stopes.ToString();
                Session["edit"] = oHelperWays.Id;

            }
            else
            {
                this.delete(oHelperWays.Id);
            }
            upWay.Update();
        }

        private async void delete(string id)
        {
            Ways oWays = new Ways();
            oWays.RunAsync();
            System.Net.HttpStatusCode url = await oWays.DeleteWaysAsync(id);
        }
        protected void gvData_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void upPanel_Load(object sender, EventArgs e)
        {
            upWay.Update();
        }
    }
}