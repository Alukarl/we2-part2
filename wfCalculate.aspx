<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="wfCalculate.aspx.cs" Inherits="ExportCalculate.wfCalculate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:ScriptManager runat="server"></asp:ScriptManager>
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
<h1>
            <strong>
                Calculate Form
            </strong>
        </h1>
    <asp:UpdatePanel ID="upCalculate" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel runat="server">
                 <asp:TextBox ID="txtNumber" placeholder="Number" runat="server"
                     TextMode="Number"
                     ></asp:TextBox>
                
               
                <asp:DropDownList ID="txtPlant" placeholder="Plant"
                    runat="server" DataValueField="Id" DataTextField="variant"></asp:DropDownList>
                <asp:DropDownList ID="txtContainert" placeholder="Containert"
                    runat="server" DataValueField="Id" DataTextField="depreciation"></asp:DropDownList>
                <asp:DropDownList ID="txtWay" placeholder="Ways"
                    runat="server" DataValueField="Id" DataTextField="distance"></asp:DropDownList>

               <asp:TextBox ID="txtCantContainer" placeholder="Number of Containers"
                     runat="server" TextMode="Number" ReadOnly="True"></asp:TextBox>
                
                 <asp:TextBox ID="txtTempCarry" placeholder="Temperature Carry" 
                    runat="server" TextMode="Number" ReadOnly="True"></asp:TextBox>
            </asp:Panel>
             <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" />
            <br />
            <asp:Panel ID="pnlDataView" runat="server">
                <asp:GridView ID="gvData" runat="server"></asp:GridView><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="gvData_RowCommand" OnRowDeleting="gvData_RowDeleting" OnRowEditing="gvData_RowEditing">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="number" HeaderText="Number" ReadOnly="True" />
                        <asp:BoundField DataField="m_area" HeaderText="Plant" ReadOnly="True" />
                        <asp:BoundField DataField="Containert" HeaderText="Containert" ReadOnly="True" />
                        <asp:BoundField DataField="Way" HeaderText="Ways" ReadOnly="True" />
                        <asp:BoundField DataField="Plant" HeaderText="Plant" ReadOnly="True" />
                        <asp:BoundField DataField="cant_container" HeaderText="Number of Containers" ReadOnly="True" />
                        <asp:BoundField DataField="temp_carry" HeaderText="Temperature Carry" ReadOnly="True" />
                        <asp:ButtonField Text="Edit" CommandName="edit" />
                        <asp:ButtonField Text="Delete" CommandName="delete" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
           
        </ContentTemplate>
        
    </asp:UpdatePanel>
        
   
</asp:Content>
