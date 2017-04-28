<%@ Page Title="" Language="C#" Async="true"  MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="wfWay.aspx.cs" Inherits="ExportCalculate.wfWay" %>
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
                Way Form
            </strong>
        </h1>
    <asp:UpdatePanel ID="upWay" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel runat="server">
                <asp:TextBox ID="txtDistance" placeholder="Distance" 
                    runat="server" TextMode="Number"></asp:TextBox>
                <asp:TextBox ID="txtStopes" placeholder="Stopes"
                     runat="server" TextMode="Number"></asp:TextBox>
            </asp:Panel>
             <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click"/>
            <br />
            <asp:Panel ID="pnlDataView" runat="server">
                <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" OnRowCommand="gvData_RowCommand" OnRowDeleting="gvData_RowDeleting" OnRowEditing="gvData_RowEditing">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="distance" HeaderText="Distance" ReadOnly="True" />
                        <asp:BoundField DataField="stopes" HeaderText="Stopes" ReadOnly="True" />
                        <asp:ButtonField Text="Edit" CommandName="edit" />
                        <asp:ButtonField Text="Delete" CommandName="delete" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
        
    </asp:UpdatePanel>
   
</asp:Content>
