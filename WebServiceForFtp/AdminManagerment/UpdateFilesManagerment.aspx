<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateFilesManagerment.aspx.cs"
    Inherits="WebServiceForFtp.AdminManagerment.UpdateFileManagerment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Source/CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Source/CSS/bootstrap-table.css" rel="stylesheet" type="text/css" />
    <script src="../Source/JS/jquery-1.8.1.js" type="text/javascript"></script>
    <script src="../Source/JS/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Source/JS/bootstrap-table.js" type="text/javascript"></script>
    <title>升级包管理页面</title>
    <script type="text/javascript">
        function AddRoles() {
            window.open("SubPages/UpdateRoles.aspx", "", "height=750,width=750,status=yes,toolbar=no,menubar=no,location=yes,resizable=yes");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ul class="list-group">
        <li class="list-group-item" style="text-align: right;">
            <asp:Button runat="server" ID="btnAddRole" Text="新建规则" OnClientClick="AddRoles();"
                CssClass="btn btn-primary" />&nbsp;<asp:Button runat="server" CssClass="btn btn-primary"
                    ID="btnReflash" Text="刷新列表" /></li>
        <li class="list-group-item">
            <table class="table table-bordered" style="width: 100%">
                <caption>
                    升级规则配置表</caption>
                <thead>
                    <tr>
                        <th>
                            允许升级的最低版本号
                        </th>
                        <th>
                            升级之后的版本号
                        </th>
                        <th>
                            创建日期
                        </th>
                        <th>
                            管理员
                        </th>
                        <th>
                            升级包名称
                        </th>
                        <th>
                            升级包MD5值
                        </th>
                        <th>
                            创建时间
                        </th>
                        <th>
                            描述信息
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
