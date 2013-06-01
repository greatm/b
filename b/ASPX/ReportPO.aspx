<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Webform.master" AutoEventWireup="true" CodeBehind="ReportPO.aspx.cs" Inherits="b.ASPX.ReportPO" %>
<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Webform.master" AutoEventWireup="true"
    CodeBehind="Products.aspx.cs" Inherits="NorthwindSales.Products" %>--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h2>
        Product Report</h2>
    <div id="searchFilter">
        <strong>Filter by :</strong> Category :
        <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="odsCategories" DataTextField="CategoryName"
            DataValueField="CategoryID" AppendDataBoundItems="true" 
            AutoPostBack="true" onselectedindexchanged="ddlCategory_SelectedIndexChanged">
            <asp:ListItem Text="-- All --" Value=""></asp:ListItem>
        </asp:DropDownList>
        Supplier :
        <asp:DropDownList ID="ddlSupplier" runat="server" DataSourceID="odsSuppliers" DataTextField="CompanyName"
            DataValueField="SupplierID" AppendDataBoundItems="true" 
            AutoPostBack="true" onselectedindexchanged="ddlSupplier_SelectedIndexChanged">
            <asp:ListItem Text="-- All --" Value=""></asp:ListItem>
        </asp:DropDownList>
    </div>
    <rsweb:ReportViewer ID="rvProducts" runat="server" Font-Names="Verdana" Font-Size="8pt"
        InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
        Height="600px" Width="100%">
        <LocalReport ReportPath="CommonReports\Products.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="odsProducts" Name="ProductList" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="odsProducts" runat="server" SelectMethod="GetProductsProjected"
        TypeName="NorthwindSales.Models.ProductRepository">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlSupplier" Name="supplierID" 
                PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="ddlCategory" Name="categoryID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsCategories" runat="server" SelectMethod="GetCategories"
        TypeName="NorthwindSales.Models.ProductRepository"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsSuppliers" runat="server" SelectMethod="GetSuppliers"
        TypeName="NorthwindSales.Models.ProductRepository"></asp:ObjectDataSource>
</asp:Content>
