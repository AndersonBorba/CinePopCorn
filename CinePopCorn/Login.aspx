<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CinePopCorn.Login" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>NDD</title>
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
<body runat="server" class="container-contact100">
    <div>

        <div class="wrap-contact100">
            <form runat="server" class="contact100-form validate-form">
                <span class="contact100-form-title">Popcorn</span>

                <div id="dividemail" class="wrap-input100 validate-input bg1" data-validate="Forneça o e-mail">
                    <span class="label-input100">E-MAIL *</span>
                    <input  runat="server" id="idemail" class="input100" type="text" name="email" placeholder="Informe o seu e-mail">
                </div>

                <div id="dividsenha" class="wrap-input100 validate-input bg1" data-validate="Forneça a senha">
                    <span class="label-input100">SENHA *</span>
                    <input  runat="server" id="idsenha" class="input100" type="password" name="senha" placeholder="Informe o sua senha">
                </div>

                <div class="container-contact100-form-btn">
                    <asp:Button ID="Button1" runat="server" Text="Entrar" class="contact100-form-btn" OnClick="btnEnviar_Click"></asp:Button>
                </div>
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

