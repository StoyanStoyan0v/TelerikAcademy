<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Random.aspx.cs" Inherits="RandomGeneratorHtmlControls.Random" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="randomForm" runat="server">
        <div>
            <label for="lower">Lower bound: </label>
            <input type="number" id="Lower" runat="server"/>
            <br />
            <label for="upper">Upper bound: </label>
            <input type="number" id="Upper" runat="server"/>
            <br />
            <input type="button" value="Generate"  runat="server" onserverclick="Btn_Click" />
        </div>
    </form>
</body>
</html>
