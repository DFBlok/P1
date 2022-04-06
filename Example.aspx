<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Example.aspx.cs" Inherits="P1.Example" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h3>List Of The Products</h3>
        <asp:GridView ID="gvProductsData" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" BackColor="White" BorderColor="#0000CC" BorderStyle="Solid" BorderWidth="2px" CellPadding="3" CellSpacing="2" OnRowCancelingEdit="gvProductsData_RowCancelingEdit" OnRowEditing="gvProductsData_RowEditing" OnRowUpdating="gvProductsData_RowUpdating" OnSelectedIndexChanged="gvProductsData_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="Product ID">
                    <EditItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ProductID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ProductID") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Product Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtProductName" runat="server" Text='<%# Bind("ProductName") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("ProductName") %>' ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity Units">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtUnits" runat="server" Text='<%# Bind("QuantityPerUnit") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("QuantityPerUnit") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <br />
        <br />
        <asp:Button ID="btnAddProduct" runat="server" Text="Add New Product" OnClick="btnAddProduct_Click"/><br />
        <br />
        <asp:Label ID="lblResult" runat="server" Text=""/>
    </form>
</body>
</html>
