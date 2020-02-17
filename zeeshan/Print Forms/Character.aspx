<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Character.aspx.cs" Inherits="Future.Print_Forms.Character" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/jquery-2.1.1.js"></script>

    <script src="../ckeditor/ckeditor.js"></script>
    <script src="../ckeditor/adapters/jquery.js"></script>


    <script>
        $(function () {
            $("#<%=TextBox1.ClientID%>").ckeditor();
        })



    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>


        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" OnTextChanged="TextBox1_TextChanged" AutoPostBack="true">





        </asp:TextBox>

        <asp:Button ID="Button1" runat="server" Text="Button"  OnClick="Button1_Click"/>

        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

    </div>
    </form>
</body>
</html>
