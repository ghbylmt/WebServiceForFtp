<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebServiceForFtp.Login.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Source/CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../Source/JS/jquery-2.1.3.min.js" type="text/javascript"></script>
    <title>升级管理后台登录页面</title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div id="content" class="container">
        <div style="float: left">
            <p>
                升级管理后台登录页面
            </p>
        </div>
        <div style="float: left; width: 1px; height: 165px; background: #000;">
        </div>
        <div style="float: left">
            <div>
                登录名:<asp:TextBox ID="textbox_userId" runat="server"></asp:TextBox>
            </div>
            <br />
            <br />
            <div>
                登录密码:<asp:TextBox TextMode="Password" runat="server" ID="textbox_pwd">
                </asp:TextBox>
            </div>
            <br />
            <br />
            <div>
                <asp:Button runat="server" ID="button_login" Text="登录" OnClick="button_login_Click"
                    class="btn btn-primary" />
            </div>
        </div>
        <div style="clear">
        </div>
    </div>
    </form>
</body>
</html>
