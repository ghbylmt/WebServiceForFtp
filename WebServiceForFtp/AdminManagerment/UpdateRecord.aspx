<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateRecord.aspx.cs" Inherits="WebServiceForFtp.AdminManagerment.UpdateRecord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Source/CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Source/CSS/bootstrap-table.css" rel="stylesheet" type="text/css" />
    <script src="../Source/JS/jquery-1.8.1.js" type="text/javascript"></script>
    <script src="../Source/JS/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Source/JS/bootstrap-table.js" type="text/javascript"></script>
    <title>升级记录页面</title>
</head>
<body>
    <form id="form1" runat="server">
    <ul class="list-group">
        <li class="list-group-item">
            <table class="table table-bordered" style="width: 100%">
                <caption>
                    升级记录</caption>
                <thead>
                    <tr>
                        <th>
                            用户编号
                        </th>
                        <th>
                            用户名称
                        </th>
                        <th>
                            用户的软件版本
                        </th>
                        <th>
                            更新后的软件版本
                        </th>
                        <th>
                            升级包
                        </th>
                        <th>
                            升级结果
                        </th>
                        <th>
                            操作
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Literal runat="server" ID="littablebody"></asp:Literal>
                </tbody>
            </table>
        </li>
    </ul>
    </form>
</body>
</html>
