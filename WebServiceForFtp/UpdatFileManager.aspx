<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatFileManager.aspx.cs"
    Inherits="WebServiceForFtp.UpdatFileManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>升级文件的管理</title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetUpdateFileInfo"
            TypeName="WebServiceForFtp.UpdateFileInfo"></asp:ObjectDataSource>
    </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
        EnableModelValidation="True">
        <Columns>
            <asp:BoundField DataField="FileName" HeaderText="文件名称" SortExpression="FileName" />
            <asp:BoundField DataField="FileLength" HeaderText="文件大小" SortExpression="FileLength" />
            <asp:BoundField DataField="OffSet" HeaderText="OffSet" Visible="false" SortExpression="OffSet" />
            <asp:BoundField DataField="FileMd5" HeaderText="文件的MD5" SortExpression="FileMd5" />
            <asp:BoundField DataField="FileDir" HeaderText="文件的路径" SortExpression="FileDir" />
        </Columns>
    </asp:GridView>
    </form>
</body>
</html>
