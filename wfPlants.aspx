<%@ Page Title="" Async="true"  Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="wfPlants.aspx.cs" Inherits="ExportCalculate.wfPlants" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table>
        <tr>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/wfPlants.aspx">Plants</asp:HyperLink>
                <br />
                
            </td>
            <td>
           <asp:HyperLink ID="lbContainers" runat="server" NavigateUrl="~/wfContainerts.aspx">Containerts</asp:HyperLink>
                 <br />
                
                
            </td>
             <td>
           <asp:HyperLink ID="lbWays" runat="server" NavigateUrl="~/wfWay.aspx">Ways</asp:HyperLink>
                 <br />
            </td>
             <td>
           <asp:HyperLink ID="lbCalculates" runat="server" NavigateUrl="~/wfCalculate.aspx">Calculates</asp:HyperLink>
        
            </td>
        </tr>
    </table>
    <asp:ScriptManager runat="server"></asp:ScriptManager>
     <h1>
            <strong>
                Plants Form
            </strong>
        </h1>
    <asp:UpdatePanel ID="upPanel" runat="server" OnLoad="upPanel_Load" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel runat="server">
                <asp:TextBox ID="txtVaraint" placeholder="Variant" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtTemperature" placeholder="Temperature" runat="server" TextMode="Number"></asp:TextBox>
                <asp:TextBox ID="txtMetricArea" placeholder="Metric Area" runat="server" TextMode="Number"></asp:TextBox>
            </asp:Panel>
             <asp:Button ID="btnCreate" runat="server" Text="Save" OnClick="btnCreate_Click" />
            <br />
    
            <asp:Panel ID="pnlDataView" runat="server">
                <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" OnRowCommand="gvData_RowCommand" OnRowDeleting="gvData_RowDeleting" OnRowEditing="gvData_RowEditing">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="variant" HeaderText="Variant" ReadOnly="True" />
                        <asp:BoundField DataField="temperature" HeaderText="Temperature" ReadOnly="True" />
                        <asp:BoundField DataField="m_area" HeaderText="Metric Area" ReadOnly="True" />
                        <asp:ButtonField Text="Edit" CommandName="edit" />
                        <asp:ButtonField Text="Delete" CommandName="delete" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
      </ContentTemplate>
        
        <Triggers>
            <asp:PostBackTrigger ControlID="btnCreate" />
        </Triggers>
        
    </asp:UpdatePanel>
   
</asp:Content>
