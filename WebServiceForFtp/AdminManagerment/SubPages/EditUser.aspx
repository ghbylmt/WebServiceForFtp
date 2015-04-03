<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="WebServiceForFtp.AdminManagerment.SubPages.EditUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../Source/CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Source/CSS/bootstrap-table.css" rel="stylesheet" type="text/css" />
    <script src="../../Source/JS/jquery-1.8.1.js" type="text/javascript"></script>
    <script src="../../Source/JS/bootstrap.min.js" type="text/javascript"></script>
    <script src="../../Source/JS/bootstrap-table.js" type="text/javascript"></script>
    <title>编辑用户</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container" style="text-align: center">
        <ul class="list-group">
            <li class="list-group-item-info">
                <h3>
                    编辑管理员基本信息
                </h3>
            </li>
            <li>姓 &nbsp; &nbsp; &nbsp; &nbsp; 名：<input type="text" runat="server" id="input_name" /></li>
            <li>性 &nbsp; &nbsp; &nbsp; &nbsp; 别：<input type="text" runat="server" id="input_gender" /></li>
            <li>登 &nbsp;&nbsp;录&nbsp;&nbsp; 名：<input type="text" runat="server" id="input_loginName" /></li>
            <li>员&nbsp;工&nbsp;编&nbsp;号：<input type="text" runat="server" id="input_employeeId" /></li>
            <li>联&nbsp;系&nbsp;电&nbsp;话：<input type="text" runat="server" id="input_phoneNum" /></li>
            <li>电&nbsp;子&nbsp;邮&nbsp;件：<input type="text" runat="server" id="input_mailAddress" /></li>
            <li>家&nbsp;庭&nbsp;住&nbsp;址：<input type="text" runat="server" id="input_homeAddress" /></li>
        </ul>
        <ul class="list-group">
            <li>
                <asp:Button Text="保存" runat="server" ID="btnSave" OnClick="btnSave_Click" CssClass="btn btn-primary" />
                <asp:Button Text="取消" runat="server" ID="btnCancel" OnClick="btnCancel_Click" CssClass="btn btn-primary" /></li>
        </ul>
    </div>
    </form>
</body>
</html>
