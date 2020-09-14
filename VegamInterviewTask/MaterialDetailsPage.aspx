<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialDetailsPage.aspx.cs" Inherits="VegamInterviewTask.MaterialDetailsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 600px;
        }

        .auto-style2 {
            width: 10px;
        }

        .auto-style3 {
            width: 168px;
        }

      

        td {
            padding: 10px;
        }

        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
        }

        .textbox {
            height: 30px;
            padding: 0 5px;
            box-shadow: inset 0 0 10px rgba(255, 255, 255, 0.5);
            font-family: 'Montserrat', sans-serif;
            text-indent: 5px;
            text-shadow: 0 1px 1px rgba(0, 0, 0, 0.3);
            font-size: 20px;
            width: 90%;
        }

       
    </style>
    <script type="text/javascript">
function isNumber(e){
    e = e || window.event;
    var charCode = e.which ? e.which : e.keyCode;
    return /\d/.test(String.fromCharCode(charCode));
}
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 100px">

            <table align="center" class="auto-style1">
                <tr>
                    <td class="auto-style4" colspan="3" style="padding-bottom: 10px; padding-top: 10px">
                       <div>
                           <h2> Save Material Information</h2>
                       </div>
                        <div>

                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="S" />

                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Material No</td>
                    <td class="auto-style2">:</td>
                    <td>
                        <asp:TextBox ID="txtMaterialNo" runat="server" CssClass="textbox" MaxLength="18"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Material No" ControlToValidate="txtMaterialNo" Display="Dynamic" ForeColor="Red" ValidationGroup="S"> *</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Material Desc</td>
                    <td class="auto-style2">:</td>
                    <td>
                        <asp:TextBox ID="txtMaterialDesc" runat="server" CssClass="textbox" MaxLength="200"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">ShelfLife</td>
                    <td class="auto-style2">:</td>
                    <td>
                        <asp:TextBox ID="txtShelfLife" runat="server" CssClass="textbox" MaxLength="5" onkeypress="return isNumber(event);"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter ShefLife" ControlToValidate="txtShelfLife" Display="Dynamic" ForeColor="Red" ValidationGroup="S"> *</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Duration</td>
                    <td class="auto-style2">:</td>
                    <td>
                        <asp:TextBox ID="txtDuration" runat="server" CssClass="textbox" MaxLength="10"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Type</td>
                    <td class="auto-style2">:</td>
                    <td>
                        <asp:DropDownList ID="ddlType" runat="server" Width="95%" Height="40px">
                            <asp:ListItem>RM</asp:ListItem>
                            <asp:ListItem>FM</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td style="padding: 10px">
                        <asp:Button ID="btnSave" runat="server" Text="Save" Width="100px" Height="40px" ValidationGroup="S" OnClick="btnSave_Click" />
                    </td>
                </tr>

            </table>

        </div>

    </form>
</body>
</html>
