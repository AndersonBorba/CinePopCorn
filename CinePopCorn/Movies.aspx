<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Movies.aspx.cs" Inherits="CinePopCorn.Movies" %>

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
<body runat="server" class="container-contact100">
    <div>
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
                <input runat="server" class="contact100-form-btn" type="image" src="images/logout32x32.png" onclick="window.location.href = '/Login.aspx'" />
            </div>
        </div>
        <div class="wrap-contact100">
            <form runat="server" class="contact100-form validate-form">
                <span class="contact100-form-title">Filmes</span>

                <div style="float: left; width: 10%">
                    <asp:Button ID="btnAddMovie" runat="server" Text="+" class="contact100-form-btn" OnClick="btnAddMovie_Click" Style="font-size: 40px;"></asp:Button>
                    </br>
                </div>

                <div style="float: right; width: 30%">
                    <div class="wrap-input100 bg1">
                        <asp:TextBox id="idfind" runat="server" class="input100"></asp:TextBox>
                    </div>
                </div>


                <div class="wrap-input100 input100-select bg1">
                    <asp:GridView GridLines="None" BorderColor="#f7f7f7" ID="gvMovies"
                        runat="server" AutoGenerateColumns="False"
                        class="wrap-input100 input100-select bg1" Font-Names="Montserrat-SemiBold" Font-Size="18px"
                        ForeColor="#555555" AlternatingRowStyle-BackColor="#cccccc" DataKeyNames="id"
                        OnRowDeleting="gvMovies_RowDeleting" OnRowEditing="gvMovies_RowEditing" OnRowDataBound="gvMovies_RowDataBound" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvMovies_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="Título" ReadOnly="true" Visible="false">
                                <ItemStyle Font-Names="Montserrat-SemiBold" Font-Size="10px" ForeColor="#555555" />
                            </asp:BoundField>

                            <asp:BoundField DataField="title" HeaderText="Título" ReadOnly="true">
                                <ItemStyle Font-Names="Montserrat-SemiBold" Font-Size="10px" ForeColor="#555555" />
                            </asp:BoundField>

                            <asp:BoundField DataField="description" HeaderText="Descrição" ReadOnly="true">
                                <ItemStyle Font-Names="Montserrat-SemiBold" Font-Size="10px" ForeColor="#555555" />
                            </asp:BoundField>

                            <asp:BoundField DataField="time" HeaderText="Duração" ReadOnly="true">
                                <ItemStyle Font-Names="Montserrat-SemiBold" Font-Size="10px" ForeColor="#555555" />
                            </asp:BoundField>

                            <asp:CommandField HeaderText="Operações" ShowEditButton="true" EditImageUrl="~/images/edit24.png" ShowDeleteButton="true" DeleteImageUrl="~/images/delete.png" ControlStyle-Font-Size="20px" ButtonType="Image">
                                <ItemStyle Font-Names="Arial" Font-Size="X-Small" HorizontalAlign="center" Width="150px" />
                            </asp:CommandField>
                        </Columns>
                        <EditRowStyle CssClass="GridViewEditRow" />
                    </asp:GridView>
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


