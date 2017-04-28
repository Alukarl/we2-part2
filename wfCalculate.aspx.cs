using Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExportCalculate
{
    public partial class wfCalculate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.getData();
            upCalculate.Update();
        }
        protected async void getData()
        {
           

            Ways oWays = new Ways();
            oWays.RunAsync();
            List<HelperWays> dsWays = await oWays.GetsWaysAsync();
            txtWay.DataSource = dsWays;
            txtWay.DataBind();

            Containerts oContainerts = new Containerts();
            oContainerts.RunAsync();
            List<HelperContainerts> dsContainerts = await oContainerts.GetsContainertsAsync();
            txtContainert.DataSource = dsContainerts;
            txtContainert.DataBind();

            Plants oPlants = new Plants();
            oPlants.RunAsync();
            List<HelperPlants> dsPlants = await oPlants.GetsPlantsAsync();
            txtPlant.DataSource = dsPlants;
            txtPlant.DataBind();
            upCalculate.Update(); Claculate oClaculate = new Claculate();
            oClaculate.RunAsync();
            List<HelperClaculate> dsorce = await oClaculate.GetsClaculateAsync();
            gvData.DataSource = dsorce;
            gvData.DataBind();
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNumber.Text)|| String.IsNullOrEmpty(txtTempCarry.Text)
                || String.IsNullOrEmpty(txtCantContainer.Text))
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error! Some fields are empty!')", true);
            }
            else
            {
                 if (Session["edit"] != null)
                            {
                                HelperClaculate oHelper = new HelperClaculate
                                {
                                    Id = Session["edit"].ToString(),
                                    number = Convert.ToDecimal(txtNumber.Text),
                                    temp_carry = Convert.ToDecimal(txtTempCarry.Text),
                                    cant_container = Convert.ToDecimal(txtCantContainer.Text),
                                    Plant = txtPlant.SelectedValue ,
                                    Containert = txtContainert.SelectedValue,
                                    Way = txtWay.SelectedValue,
                    };
                                Session["edit"] = null;
                                Claculate oWays = new Claculate();
                                oWays.RunAsync();
                                var url = oWays.UpdateClaculateAsync(oHelper);

                            }
                            else
                            {
                                HelperClaculate oHelper = new HelperClaculate
                                {
                                    number = Convert.ToDecimal(0),
                                    temp_carry = Convert.ToDecimal(0),
                                    cant_container = Convert.ToDecimal(txtCantContainer.Text),
                                    Plant = txtPlant.Text,
                                    Containert = txtContainert.Text,
                                    Way = txtWay.Text,
                                };
                                Claculate oContainerts = new Claculate();
                                oContainerts.RunAsync();
                                var url = oContainerts.CreateClaculateAsync(oHelper);
                            }
                            upCalculate.Update();
            }
           
        }

        protected void gvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            Object source = (e.CommandSource as GridView).DataSource;
            List<HelperClaculate> list = source as List<HelperClaculate>;
            HelperClaculate oHelperClaculate = list[index];
            if (e.CommandName == "edit")
            {
                txtNumber.Text = oHelperClaculate.number.ToString();
                txtTempCarry.Text = oHelperClaculate.temp_carry.ToString();
                txtCantContainer.Text = oHelperClaculate.cant_container.ToString();
                txtPlant.Text = oHelperClaculate.Plant.ToString();
                txtContainert.Text = oHelperClaculate.Containert.ToString();
                txtWay.Text = oHelperClaculate.Way.ToString();
                Session["edit"] = oHelperClaculate.Id;

            }
            else
            {
                this.delete(oHelperClaculate.Id);
            }
            upCalculate.Update();
        }

        private async void delete(string id)
        {
            Claculate oWays = new Claculate();
            oWays.RunAsync();
            System.Net.HttpStatusCode url = await oWays.DeleteClaculateAsync(id);
        }
        protected void gvData_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void upPanel_Load(object sender, EventArgs e)
        {
            upCalculate.Update();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            if (ScriptManager.GetCurrent(Page).IsInAsyncPostBack)
            {
                ScriptManager.RegisterStartupScript(upCalculate, typeof(string), "redirect", "window.location = 'wfCalculate.aspx';", true);
            }
            else
            {
                Response.Redirect("wfCalculate.aspx");
            }
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("wfPlants.aspx");
        }

        protected void lbContainers_Click(object sender, EventArgs e)
        {
            Response.Redirect("wfContainerts.aspx");
        }

        protected void lbWays_Click(object sender, EventArgs e)
        {
            Response.Redirect("wfWay.aspx");
        }
    }
}