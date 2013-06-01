<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Webform.master" AutoEventWireup="true" CodeBehind="ReportPO.aspx.cs" Inherits="b.ASPX.ReportPO" %>

<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Webform.master" AutoEventWireup="true"
    CodeBehind="Products.aspx.cs" Inherits="NorthwindSales.Products" %>--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:scriptmanager id="ScriptManager1" runat="server">
    </asp:scriptmanager>
    <h2>Product Report</h2>
    <div id="searchFilter">
        <strong>Filter by :</strong> Category :
        <asp:dropdownlist id="ddlCategory" runat="server" datasourceid="odsCategories" datatextfield="CategoryName"
            datavaluefield="CategoryID" appenddatabounditems="true"
            autopostback="true" onselectedindexchanged="ddlCategory_SelectedIndexChanged">
            <asp:ListItem Text="-- All --" Value=""></asp:ListItem>
        </asp:dropdownlist>
        Supplier :
        <asp:dropdownlist id="ddlSupplier" runat="server" datasourceid="odsSuppliers" datatextfield="CompanyName"
            datavaluefield="SupplierID" appenddatabounditems="true"
            autopostback="true" onselectedindexchanged="ddlSupplier_SelectedIndexChanged">
            <asp:ListItem Text="-- All --" Value=""></asp:ListItem>
        </asp:dropdownlist>
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
    <asp:objectdatasource id="odsProducts" runat="server" selectmethod="GetProductsProjected"
        typename="NorthwindSales.Models.ProductRepository">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlSupplier" Name="supplierID" 
                PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="ddlCategory" Name="categoryID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:objectdatasource>
    <asp:objectdatasource id="odsCategories" runat="server" selectmethod="GetCategories"
        typename="NorthwindSales.Models.ProductRepository"></asp:objectdatasource>
    <asp:objectdatasource id="odsSuppliers" runat="server" selectmethod="GetSuppliers"
        typename="NorthwindSales.Models.ProductRepository"></asp:objectdatasource>
</asp:Content>
