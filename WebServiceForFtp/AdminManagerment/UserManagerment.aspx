<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManagerment.aspx.cs"
    Inherits="WebServiceForFtp.AdminManagerment.UserManagerment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Source/CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Source/CSS/bootstrap-table.css" rel="stylesheet" type="text/css" />
    <script src="../Source/JS/jquery-1.8.1.js" type="text/javascript"></script>
    <script src="../Source/JS/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Source/JS/bootstrap-table.js" type="text/javascript"></script>
    <title></title>
    <script type="text/javascript">
        function createuser() {
            document.getElementById("createuser2").style.display = "block";
        }
        function changepwd() {
            document.getElementById("lichangePwd").style.display = "block";
        }
        function opt(optpara) {
            var operate = optpara.split('_')[0];
            var itemid = optpara.split('_')[1];
            switch (operate) {
                case "edit":
                    //  window.showModalDialog("SubPages/EditUser.aspx?id=" + itemid, "dialogWidth=400px;dialogHeight=400px")
                    window.open("SubPages/EditUser.aspx?id=" + itemid, "", "height=400,width=400,status=yes,toolbar=no,menubar=no,location=yes");
                    break;
                case "delete":
                    if (confirm("确定删除该操作员吗？")) {
                        $.post("../Ajax/UserManagerHandler.ashx?id=" + itemid + "&ajaxMethod=deleteUser", {},
                        function (data) {
                            if (data == "success") {
                                alert("删除成功");
                                document.getElementById("tr" + itemid + "").style.display = "none";
                            }
                        });
                    }
                    break;
                default:

            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ul class="list-group">
            <li class="list-group-item">当前登录的用户为：<label runat="server" id="labuser"></label></li>
            <li class="list-group-item" runat="server" id="createuser1"><a href="#" onclick="createuser();">
                创建用户</a></li>
            <li runat="server" class="list-group-item" style="display: none" id="createuser2">用户名：<asp:TextBox
                runat="server" required="required" ID="textboxUserId"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;登录密码：<asp:TextBox
                    required="required" ID="textboxPwd" TextMode="Password" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                        CssClass="btn btn-primary" ID="btncreateuser" runat="server" OnClick="btncreateuser_Click"
                        Text="创建" /></li>
            <li class="list-group-item">个人信息</li>
            <li class="list-group-item">姓名：性别：登录账号：</li>
            <li class="list-group-item"><a href="#" onclick="changepwd();">更改密码</a></li>
            <li class="list-group-item" style="display: none" id="lichangePwd">原始密码：<asp:TextBox
                TextMode="Password" runat="server" ID="oldpwd"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;新密码：<asp:TextBox
                    TextMode="Password" runat="server" ID="newpwd"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                        runat="server" ID="btnChangePwd" Text="确定" CssClass="btn btn-primary" OnClick="btnChangePwd_Click" /></li>
            <li class="list-group-item" id="userlisttable" runat="server">
                <table class="table table-bordered" style="width: 100%">
                    <caption>
                        管理员列表</caption>
                    <thead>
                        <tr>
                            <th>
                                姓名
                            </th>
                            <th>
                                登录ID
                            </th>
                            <th>
                                性别
                            </th>
                            <th>
                                联系电话
                            </th>
                            <th>
                                电子邮箱
                            </th>
                            <th>
                                家庭住址
                            </th>
                            <th>
                                创建时间
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
    </div>
    </form>
</body>
</html>
