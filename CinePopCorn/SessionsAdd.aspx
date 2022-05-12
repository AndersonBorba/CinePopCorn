<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SessionsAdd.aspx.cs" Inherits="CinePopCorn.SessionsAdd" %>

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
    <link rel="stylesheet" type="text/css" href="css/util.css">
    <link rel="stylesheet" type="text/css" href="css/main.css">
    <!--===============================================================================================-->
</head>
<body runat="server" class="container-contact100">
    <div>
        <div class="wrap-contact100">
            <form runat="server" class="contact100-form validate-form">
                <div class="wrap-input100 validate-input bg1 rs1-wrap-input100" data-validate="Insira a data da sessão">
                    <span class="label-input100">Data *</span>
                    <input id="iddate" runat="server" class="input100" type="datetime-local" name="date">
                </div>

                <div class="wrap-input100 validate-input bg1 rs1-wrap-input100" data-validate="Insira o valor da sessão">
                    <span class="label-input100">Valor *</span>
                    <input id="idvalue" runat="server" class="input100" type="number" name="value" placeholder="Insira o valor da sessão" required min="0" value="0" step=".01">
                </div>


                <div class="wrap-input100 input100-select bg1 rs1-wrap-input100 validate-input">
                    <span class="label-input100">Tipo de animação</span>
                    <div>
                        <select runat="server" id="idtypeanimation" class="js-select2" name="typeanimation">
                            <option value="0">2D</option>
                            <option value="1">3D</option>
                        </select>
                        <div class="dropDownSelect2"></div>
                    </div>
                </div>

                <div class="wrap-input100 input100-select bg1 rs1-wrap-input100 validate-input">
                    <span class="label-input100">Tipo de audio</span>
                    <div>
                        <select runat="server" id="idtypesound" class="js-select2" name="typeanimation">
                            <option value="0">Original</option>
                            <option value="1">Dublado</option>
                        </select>
                        <div class="dropDownSelect2"></div>
                    </div>
                </div>

                <div class="wrap-input100 input100-select bg1 rs1-wrap-input100 validate-input">
                    <span class="label-input100">Filmes/Min</span>
                    <div>
                        <select runat="server" id="idmovie" class="js-select2" name="movies"></select>
                        <div class="dropDownSelect2"></div>
                    </div>
                </div>

                <div class="wrap-input100 input100-select bg1 rs1-wrap-input100 validate-input">
                    <span class="label-input100">Salas</span>
                    <div>
                        <select runat="server" id="idroom" class="js-select2" name="rooms"></select>
                        <div class="dropDownSelect2"></div>
                    </div>
                </div>

                <div class="wrap-input100 bg1 rs1-wrap-input100" >
                    <span class="label-input100">Fim da sessão</span>
                    <input id="idfimsessao" runat="server" class="input100" type="datetime-local" name="fimsessao" readonly="readonly">
                </div>



                <div class="container-contact100-form-btn">
                    <asp:Button ID="btnMovie" runat="server" Text="Salvar" class="contact100-form-btn" OnClick="BtnSession_Click"></asp:Button>
                </div>
            </form>
            </br>
            <button id="Button3" runat="server" text="Filmes" class="contact100-form-btn" onclick="window.location.href='/Sessions.aspx'">Voltar</button>
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
