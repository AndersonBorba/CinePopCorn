<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MoviesAdd.aspx.cs" Inherits="CinePopCorn.MoviesAdd" %>

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
        <div class="wrap-contact100">
            <form runat="server" class="contact100-form validate-form">
                <%--<img src="images/movies/1.jpg" alt="Imagem não encontrada" width="10%" height="10%" id="idimage" class="center">--%>
                <asp:Image runat="server" alt="Imagem não encontrada" width="20%" height="20%" id="idimage" class="center"/>
                

                <div class="wrap-input100 validate-input bg1" data-validate="Insira o título do filme">
                    <span class="label-input100">Título *</span>
                    <input id="idtitle" runat="server" class="input100" type="text" name="title" placeholder="Forneça o título">
                </div>

                <div class="wrap-input100 validate-input bg1" data-validate="Insira uma descrição">
                    <span class="label-input100">Descrição *</span>
                    <input id="iddescription" runat="server" class="input100" type="text" name="description" placeholder="Forneça uma descrição">
                </div>

                <div class="wrap-input100 validate-input bg1 rs1-wrap-input100" data-validate="Insira a duração do filme (em minutos)">
                    <span class="label-input100">Duração *</span>
                    <input runat="server" id="idtime" class="input100" type="number" name="time" placeholder="Forneça a duração">
                </div>

                <div class="wrap-input100 bg1">
                    <span class="label-input100">Anexar imagem</span>
                    <asp:FileUpload ID="idanexararquivo" runat="server" name="anexararquivo" class="input110" />
                </div>

                <div class="container-contact100-form-btn">
                    <asp:Button ID="btnMovie" runat="server" Text="Salvar" class="contact100-form-btn" OnClick="BtnMovie_Click"></asp:Button>
                </div>
            </form>
            </br>
            <button id="Button3" runat="server" text="Filmes" class="contact100-form-btn" onclick="window.location.href='/Movies.aspx'">Voltar</button>
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
