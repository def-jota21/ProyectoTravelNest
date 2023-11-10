<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="prueba.aspx.cs" Inherits="ProyectoTravelNest.pages.prueba" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <html>
    <head>
        <meta charset="utf-8" />
        <title>jQuery UI Datepicker - Seleccionar un rango de fechas</title>
        <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.1/themes/base/jquery-ui.css" />
        <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
        <script src="http://code.jquery.com/ui/1.10.1/jquery-ui.js"></script>
        <script src="jquery.ui.datepicker-es.js"></script>

        <script>
            $(function () {
                $("#from").datepicker({
                    onClose: function (selectedDate) {
                        $("#to").datepicker("option", "minDate", selectedDate);
                    }
                });
                $("#to").datepicker({
                    onClose: function (selectedDate) {
                        $("#from").datepicker("option", "maxDate", selectedDate);
                    }
                });
            });
        </script>

    </head>

    <body>
        <p>
            Desde:
            <input type="text" id="from" name="from" />
            Hasta:
            <input type="text" id="to" name="to" />
        </p>
    </body>
    </html>
</asp:Content>
