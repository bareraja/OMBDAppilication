<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="OMBDAppilication.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OMBD</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabelFileType" runat="server" Text="Select File type to use"></asp:Label>
            <br />
            <br />
            <asp:RadioButton ID="RadioButtonJSON" runat="server" Checked="True" GroupName="FileType" Text="JSON" />
&nbsp;<asp:RadioButton ID="RadioButtonXML" runat="server" GroupName="FileType" Text="XML" />
            <br />
            <br />
            <asp:Label ID="LabelIDorString" runat="server" Text="Select ID for known movie or movie name"></asp:Label>
&nbsp;
            <br />
            <br />
            <br />
            <asp:TextBox ID="TextBoxInput" runat="server" Width="320px"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Label ID="LabelInput" runat="server" Text="Search Input"></asp:Label>
            <br />
            <br />
            <asp:Button ID="ButtonFInd" runat="server" OnClick="ButtonFInd_Click" Text="Find Movie" />
            <br />
            <br />
            <asp:Label ID="LabelMessages" runat="server" Text="Message"></asp:Label>
            <br />
            <br />
            <asp:Label ID="LabelResult" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Image ID="ImagePoster" runat="server" ImageUrl="~/MyFiles/hqdefault.jpg" />
        </div>
    </form>
</body>
</html>
