<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebServiceForFtp.AdminManagerMent.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../Source/JS/jquery-1.8.1.js" type="text/javascript"></script>
    <script src="../Source/JS/bootstrap.min.js" type="text/javascript"></script>
    <link href="../Source/CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <title>升级包管理应用平台</title>
    <script type="text/javascript">
        function navClick(msg) {
            //    alert(msg);
            switch (msg) {
                case "index":
                    $(".active").removeClass("active");
                    $("#index").addClass('active');
                    $("#iframeworkingspace").attr("src", "Welcome.aspx");
                    break;
                case "updatefilepub":
                    $(".active").removeClass("active");
                    $("#updatefilepub").addClass('active');
                    $("#iframeworkingspace").attr("src", "UpdateFilesPub.aspx");
                    break;
                case "updatefilemanager":
                    $(".active").removeClass("active");
                    $("#updatefilemanager").addClass('active');
                    $("#iframeworkingspace").attr("src", "UpdateFilesManagerment.aspx");
                    break;
                case "updaterecorder":
                    $(".active").removeClass("active");
                    $("#updaterecorder").addClass('active');
                    $("#iframeworkingspace").attr("src", "UpdateRecord.aspx");
                    break;
                case "personInfo":
                    $(".active").removeClass("active");
                    $("#personInfo").addClass('active');
                    $("#iframeworkingspace").attr("src", "UserManagerment.aspx");
                    break;
                default:
                    break;
            }
        }
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ol class="breadcrumb" style="text-align: right;">
        <li style="margin-right: 20%; margin-left: 20%"><a id="aUser" href="#" onclick="navClick('personInfo');"
            runat="server"></a>你好!<asp:Button Text="安全退出" CssClass="btn btn-link" runat="server"
                ID="btn_logout" OnClick="btn_logout_Click" /></li>
    </ol>
    <div class="container">
        <div class="row">
            <div class="span6">
                <ul id="nav" class="nav nav-pills">
                    <li class="active" id="index"><a onclick="navClick('index')" href="#">主页</a></li>
                    <li id="updatefilepub"><a href="#" onclick="navClick('updatefilepub');">升级包</a></li>
                    <li id="updatefilemanager"><a href="#" onclick="navClick('updatefilemanager');">升级规则</a></li>
                    <li id="updaterecorder"><a href="#" onclick="navClick('updaterecorder');">查看升级记录</a></li>
                    <li id="personInfo"><a href="#" onclick="navClick('personInfo')">管理员信息</a></li>
                </ul>
            </div>
        </div>
        <div>
            <hr />
            <iframe src="Welcome.aspx" id="iframeworkingspace" frameborder="0" scrolling="auto"
                width="100%" height="800px"></iframe>
        </div>
    </div>
    </form>
    <ol class="breadcrumb" style="text-align: right; margin-bottom: 0">
        <li style="margin-right: 20%; margin-left: 20%">CopyRight@CCstar All Right Reserved</li>
    </ol>
</body>
</html>
