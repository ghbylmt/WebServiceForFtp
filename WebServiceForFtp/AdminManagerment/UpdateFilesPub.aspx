<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateFilesPub.aspx.cs"
    Inherits="WebServiceForFtp.AdminManagerment.UpdateFilesPub" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Source/CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Source/CSS/bootstrap-table.css" rel="stylesheet" type="text/css" />
    <script src="../Source/JS/jquery-1.8.1.js" type="text/javascript"></script>
    <script src="../Source/JS/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Source/JS/bootstrap-table.js" type="text/javascript"></script>
    <title>发布升级包</title>
    <script type="text/javascript">
        function deleteFile(ID) {
            //alert(data);
            //删除文件的操作
            if (confirm("确定删除该升级包？")) {
                $.post("../Ajax/FileHandler.ashx?ID=" + ID + "&ajaxMethod=DeleteFile", {},
                        function (data) {
                            if (data == "Success") {
                                alert("删除成功");
                                document.getElementById("tr" + ID + "").style.display = "none"; //隐藏改行
                            }
                        });
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ul class="list-group" style="margin-right: 0;">
            <li class="list-group-item" style="text-align: right; height: 50px">
                <div style="float: right; height: 100%">
                    描述信息：&nbsp;&nbsp;<asp:TextBox runat="server" ID="textDecription"></asp:TextBox><asp:Button
                        runat="server" Text="上传" ID="btnUpload" OnClick="btnUpload_Click" Width="100px"
                        CssClass="btn btn-primary" />
                </div>
                <div style="text-align: right; float: right">
                    <asp:FileUpload runat="server" ID="fileUpload" CssClass="btn" />
                </div>
            </li>
        </ul>
        <ul class="list-group-item">
            <li class="list-group-item" id="userlisttable" runat="server">
                <table class="table table-bordered" style="width: 100%">
                    <caption>
                        升级文件列表</caption>
                    <thead>
                        <tr>
                            <th>
                                文件名称
                            </th>
                            <th>
                                文件大小
                            </th>
                            <th>
                                文件的MD5值
                            </th>
                            <th>
                                上传时间
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
