using Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExportCalculate
{
    public partial class wfPlants : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.getData();
            upPanel.Update();
        }
        protected async void getData()
        {
            Plants oPlants = new Plants();
            oPlants.RunAsync();
            List<HelperPlants> dsorce = await oPlants.GetsPlantsAsync();
            gvData.DataSource = dsorce;
            gvData.DataBind();
            upPanel.Update();
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTemperature.Text) || String.IsNullOrEmpty(txtMetricArea.Text))
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error! Some fields are empty!')", true);
            }
            else
            {
                if (Session["edit"] != null)
            {
                HelperPlants oHelper = new HelperPlants
                {
                    Id = Session["edit"].ToString(),
                    variant = txtVaraint.Text,
                    temperature = Convert.ToDecimal(txtTemperature.Text),
                    m_area = Convert.ToDecimal(txtMetricArea.Text)
                };
                Session["edit"] = null;
                Plants oPlants = new Plants();
                oPlants.RunAsync();
                var url = oPlants.UpdatePlantsAsync(oHelper);
                
            }
            else
            {
                HelperPlants oHelper = new HelperPlants
                {
                    variant = txtVaraint.Text,
                    temperature = Convert.ToDecimal(txtTemperature.Text),
                    m_area = Convert.ToDecimal(txtMetricArea.Text)
                };
                Plants oPlants = new Plants();
                oPlants.RunAsync();
                var url = oPlants.CreatePlantsAsync(oHelper);
            }
            upPanel.Update();
        }
        }


        protected void gvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            Object source = (e.CommandSource as GridView).DataSource;
            List<HelperPlants> list = source as List<HelperPlants>;
            HelperPlants oHelperPlants = list[index];
            if (e.CommandName == "edit")
            {
                txtVaraint.Text = oHelperPlants.variant;
                txtTemperature.Text = oHelperPlants.temperature.ToString();
                txtMetricArea.Text = oHelperPlants.m_area.ToString();
                Session["edit"] = oHelperPlants.Id;
               
            }
            else
            {   
                this.delete(oHelperPlants.Id);
            }
            upPanel.Update();
        }
        
        private async void delete(string id)
        {
            Plants oPlants = new Plants();
            oPlants.RunAsync();
            System.Net.HttpStatusCode url = await oPlants.DeletePlantsAsync(id);
        }

        protected void gvData_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void upPanel_Load(object sender, EventArgs e)
        {
            upPanel.Update();
        }
    }
}