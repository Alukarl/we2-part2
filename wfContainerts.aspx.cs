using Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExportCalculate
{
    public partial class wfContainerts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.getData();
            upContainert.Update();
        }
        protected async void getData()
        {
            Containerts oContainerts = new Containerts();
            oContainerts.RunAsync();
            List<HelperContainerts> dsorce = await oContainerts.GetsContainertsAsync();
            gvData.DataSource = dsorce;
            gvData.DataBind();
            upContainert.Update();
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDepreciation.Text) || String.IsNullOrEmpty(txtMetricArea.Text))
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error! Some fields are empty!')", true);
            }
            else
            {
                if (Session["edit"] != null)
            {
                HelperContainerts oHelper = new HelperContainerts
                {
                    Id = Session["edit"].ToString(),

                    depreciation = Convert.ToDecimal(txtDepreciation.Text),
                    m_area = Convert.ToDecimal(txtMetricArea.Text)
                };
                Session["edit"] = null;
                Containerts oPlants = new Containerts();
                oPlants.RunAsync();
                var url = oPlants.UpdateContainertsAsync(oHelper);

            }
            else
            {
                HelperContainerts oHelper = new HelperContainerts
                {

                    depreciation = Convert.ToDecimal(txtDepreciation.Text),
                    m_area = Convert.ToDecimal(txtMetricArea.Text)
                };
                Containerts oContainerts = new Containerts();
                oContainerts.RunAsync();
                var url = oContainerts.CreateContainertsAsync(oHelper);
            }
            upContainert.Update();
        }
        }

        protected void gvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            Object source = (e.CommandSource as GridView).DataSource;
            List<HelperContainerts> list = source as List<HelperContainerts>;
            HelperContainerts oHelperPlants = list[index];
            if (e.CommandName == "edit")
            {
                txtDepreciation.Text = oHelperPlants.depreciation.ToString();
                txtMetricArea.Text = oHelperPlants.m_area.ToString();
                Session["edit"] = oHelperPlants.Id;

            }
            else
            {
                this.delete(oHelperPlants.Id);
            }
            upContainert.Update();
        }

        private async void delete(string id)
        {
            Containerts oContainerts = new Containerts();
            oContainerts.RunAsync();
            System.Net.HttpStatusCode url = await oContainerts.DeleteContainertsAsync(id);
        }
        protected void gvData_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void upPanel_Load(object sender, EventArgs e)
        {
            upContainert.Update();
        }
    }
}