<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="StudentWebFinal.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                 <p>Search By</p>
                    <asp:TextBox ID="srchName" runat="server"></asp:TextBox>
                    <asp:TextBox ID="srchRoll" runat="server"></asp:TextBox>
                    <asp:DropDownList ID="GenderSrch" runat="server">
                        <asp:ListItem>Any</asp:ListItem>
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                 </asp:DropDownList>
                    <asp:TextBox ID="srchRoom" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="Button" BackColor="#0000CC" OnClick="Button1_Click"/>
            </div>
           
            <br/><br/>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" OnRowCancelingEdit="GridView1_RowCancelingEdit" DataKeyNames="roll" EmptyDataText="No Data">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Name" />
                    <asp:BoundField DataField="roll" HeaderText="Roll" ReadOnly="true"/>
                    <asp:TemplateField HeaderText="Gender">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("gender") %>'>
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                                <asp:ListItem>Other</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblGender" runat="server" Text='<%# Bind("gender") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="room" HeaderText="Room" />
                    <asp:CommandField ButtonType="Button" ShowEditButton="True" />
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                </Columns>

            </asp:GridView>
        </div>
    </form>
</body>
</html>
