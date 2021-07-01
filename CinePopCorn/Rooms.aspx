<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rooms.aspx.cs" Inherits="CinePopCorn.rooms" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>PopCorn</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="fonts/iconic/css/material-design-iconic-font.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="css/util.css">
    <link rel="stylesheet" type="text/css" href="css/main.css">
    <!--===============================================================================================-->
</head>
<body runat="server">
    <div class="container-contact100">
         <div class="wrap-contact100header">
            <div style="float: left; width: 30%">
                <button id="Button2" runat="server" text="Salas" class="contact100-form-btn" onclick="window.location.href='/Rooms.aspx'">Salas</button>
            </div>
            <div style="float: left; width: 30%">
                <button id="Button3" runat="server" text="Filmes" class="contact100-form-btn" onclick="window.location.href='/Movies.aspx'">Filmes</button>
            </div>
            <div style="float: left; width: 30%">
                <button id="Button4" runat="server" text="Sessões" class="contact100-form-btn" onclick="window.location.href='/Sessions.aspx'">Sessões</button>
            </div>
            <div style="float: right; width: 8%">
                <input runat="server" class="contact100-form-btn" type="image" src="images/logout32x32.png" onclick="window.location.href='/Login.aspx'"/>
            </div>
        </div>

        <div class="wrap-contact100">
            <form runat="server" class="contact100-form validate-form">
                <span class="contact100-form-title">Salas</span>

                <div class="wrap-input100 input100-select bg1">
                    <asp:GridView GridLines="None" BorderColor="#F7F7F7" ID="gvRooms"
                        runat="server" AutoGenerateColumns="False"
                        class="wrap-input100 input100-select bg1" Font-Names="Montserrat-SemiBold" Font-Size="18px"
                        ForeColor="#555555" AlternatingRowStyle-BackColor="#cccccc">
                        <Columns>
                            <asp:BoundField DataField="name" HeaderText="Nome" ReadOnly="true">
                                <ItemStyle Font-Names="Montserrat-SemiBold" Font-Size="10px" ForeColor="#555555" />
                            </asp:BoundField>

                            <asp:BoundField DataField="qtd" HeaderText="Quantidade de Assentos" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ApplyFormatInEditMode="true">
                                <ItemStyle Font-Names="Montserrat-SemiBold" Font-Size="10px" ForeColor="#555555" HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>

                <asp:HiddenField ID="HiddenFieldIdToken" runat="server" />
            </form>
        </div>
    </div>


    <script src="scripts/jquery-3.2.1.min.js"></script>
    <script src="scripts/jquery.mask.js"></script>
    <script>
        $(".js-select2").each(function () {
            $(this).select2({
                minimumResultsForSearch: 20,
                dropdownParent: $(this).next('.dropDownSelect2')
            });


            $(".js-select2").each(function () {
                $(this).on('select2:close', function (e) {
                    if ($(this).val() == "Please chooses") {
                        $('.js-show-service').slideUp();
                    }
                    else {
                        $('.js-show-service').slideUp();
                        $('.js-show-service').slideDown();
                    }
                });
            });
        })
    </script>
    <%--    <script>
        var filterBar = document.getElementById('filter-bar');

        noUiSlider.create(filterBar, {
            start: [1500, 3900],
            connect: true,
            range: {
                'min': 1500,
                'max': 7500
            }
        });

        var skipValues = [
            document.getElementById('value-lower'),
            document.getElementById('value-upper')
        ];

        filterBar.noUiSlider.on('update', function (values, handle) {
            skipValues[handle].innerHTML = Math.round(values[handle]);
            $('.contact100-form-range-value input[name="from-value"]').val($('#value-lower').html());
            $('.contact100-form-range-value input[name="to-value"]').val($('#value-upper').html());
        });
    </script>--%>
    <!--===============================================================================================-->
    <script src="js/CallWSMIDAS.js"></script>
    <script src="js/main.js"></script>
    <!-- Global site tag (gtag.js) - Google Analytics -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-23581568-13"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'UA-23581568-13');
    </script>
</body>
</html>


