<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateRoles.aspx.cs" Inherits="WebServiceForFtp.AdminManagerment.SubPages.UpdateRoles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../Source/CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Source/CSS/bootstrap-table.css" rel="stylesheet" type="text/css" />
    <script src="../../Source/JS/jquery-1.8.1.js" type="text/javascript"></script>
    <script src="../../Source/JS/bootstrap.min.js" type="text/javascript"></script>
    <script src="../../Source/JS/bootstrap-table.js" type="text/javascript"></script>
    <title>升级规则</title>
    <script type="text/javascript">
        function hide() {
            document.getElementById("tr1").style.display = "none";
            document.getElementById("tr2").style.display = "none";
            document.getElementById("tr3").style.display = "none";
            $("#tr1 input").val('');
            $("#tr2 input").val('');
            $("#tr3 input").val('');
        }
        function show() {
            document.getElementById("tr1").style.display = "table-row";
            document.getElementById("tr2").style.display = "table-row";
            document.getElementById("tr3").style.display = "table-row";
        } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container" style="text-align: center;">
        <table class="table table-bordered">
            <caption>
                <asp:Label runat="server" ID="labTitle" Text="添加升级规则"></asp:Label>
            </caption>
            <tr>
                <td colspan="2">
                    升级包信息
                </td>
            </tr>
            <tr>
                <td>
                    选择升级文件：
                </td>
                <td>
                    <asp:DropDownList ID="dropFileNames" AutoPostBack="true" runat="server" OnSelectedIndexChanged="dropFileNames_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    升级包文件名称：
                </td>
                <td>
                    <asp:Label runat="server" ID="labFileName"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    升级包MD5值：
                </td>
                <td>
                    <asp:Label runat="server" ID="labFileMd5"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    升级包大小：
                </td>
                <td>
                    <asp:Label runat="server" ID="labFileLength"></asp:Label></li>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    升级规则配置
                </td>
            </tr>
            <tr>
                <td>
                    允许升级的最低版本：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="textAllowVersion"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    执行升级之后的版本：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="textNewToVersion"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    升级规则描述：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="textDescription" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    是否推送给特定用户？
                </td>
                <td>
                    <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="radioSpecial"
                        AutoPostBack="true" OnSelectedIndexChanged="radioSpecial_SelectedIndexChanged">
                        <asp:ListItem Text="是   " Value="yes"></asp:ListItem>
                        <asp:ListItem Text="否   " Value="no" Selected="True"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr id="tr1" style="display: none">
                <td>
                    用户名称：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="textCustomerName"></asp:TextBox>
                </td>
            </tr>
            <tr id="tr2" style="display: none">
                <td>
                    用户编号：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="textCustomerNum"></asp:TextBox>
                </td>
            </tr>
            <tr id="tr3" style="display: none">
                <td>
                    加密狗编号：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="textDogNum"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button Text="确定" CssClass="btn btn-primary" runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" />&nbsp;&nbsp;<asp:Button
            ID="btnCancel" Text="取消" runat="server" CssClass="btn btn-primary" OnClientClick="window.close();" />
    </div>
    </form>
</body>
</html>
