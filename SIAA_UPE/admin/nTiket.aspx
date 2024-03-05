<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nTiket.aspx.cs" Inherits="SIAA_UPE.admin.nTiket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../src/css/siaa.css" rel="stylesheet" type="text/css" />
    <link href="../src/img/ico/upe.ico" rel="SHORTCUT ICON"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script>
        function imprimirDiv(nombreDiv) {
            var contenido = document.getElementById(nombreDiv).innerHTML;
            var contenidoOriginal = document.body.innerHTML;

            document.body.innerHTML = contenido;

            window.print();

            document.body.innerHTML = contenidoOriginal;
        }
    </script>
</head>
<body>
    <form id="fm" runat="server">
        <center>
            <div  id="divImprimir">
            <h2>Universidad Politécnica de la Energía</h2><br />
            <img src="../src/img/logo/upe.png" width="100" alt="User Icon" /><br />
            <b>COMPROBANTE DE PAGO</b>
                <table style="width:100%">
                    <tr class="medium">
                        <td colspan="2">  &nbsp; </td>
                    </tr>
                    <tr>
                        <td><b>Concepto :</b></td>
                        <td><asp:Label ID="lbConceptoR" runat="server" /></td>
                    </tr>
                    <tr>
                        <td><b>Método de pago (Se cobrará una comisión):</b></td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td><b><asp:Label ID="lbT" runat="server" >Importe total:</asp:Label></b></td>
                        <td ><asp:Label ID="lbTotalR" runat="server" /></td>
                    </tr>
                    <tr>
                        <td><b>Pagarse antes del:</b></td>
                        <td><asp:Label ID="lbFechaR" runat="server" /></td>
                    </tr>
                </table>
            </div>
            <button class="success" onclick="imprimirDiv('divImprimir')">Imprimir</button>
        </center>
    </form>
</body>
</html>
