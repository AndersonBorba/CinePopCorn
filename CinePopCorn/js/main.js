
(function ($) {
    "use strict";

    $(document).ready(function () {
        $('#gvMovies').DataTable();
    });

    $(document).ready(function () {
        $('#myTable').DataTable();
    });

    $("[id*=idmovie]").change(function () {
        var minutes = parseInt(document.getElementById("idmovie")[document.getElementById("idmovie").selectedIndex].text.split('/')[1]);
        var dtFim = new Date(document.getElementById("iddate").value);
        dtFim.setMinutes(dtFim.getMinutes() + minutes);
        var dia = dtFim.getDate().toString();
        var diaF = (dia.length == 1) ? '0' + dia : dia;
        var mes = (dtFim.getMonth() + 1).toString();
        var mesF = (mes.length == 1) ? '0' + mes : mes;
        var anoF = dtFim.getFullYear();
        var hour = dtFim.getHours();
        var hourF = (hour.toString().length == 1) ? '0' + hour : hour;
        var minutes = dtFim.getMinutes();
        var minutesF = (minutes.toString().length == 1) ? '0' + minutes : minutes;
        document.getElementById("idfimsessao").value = anoF + "-" + mesF + "-" + diaF + "T" + hourF + ":" + minutesF;
    });

    /* ================================================== */
    $("[id*=chkHeaderSelecionar]").on("click", function () {
        var chkHeader = $(this);
        var grid = $(this).closest("table");
        $("input[type=checkbox]", grid).each(function () {
            if (chkHeader.is(":checked")) {
                if ($(this)[0].id.indexOf('chkRowSelecionar') > -1) {
                    $(this).prop('checked', true);
                }
            } else if ($(this)[0].id.indexOf('chkRowSelecionar') > -1) {
                $(this).prop('checked', false)
            }
        });
    });

    $("[id*=chkRowSelecionar]").on("click", function () {
        var grid = $(this).closest("table");
        var chkHeader = $("[id*=chkHeader]", grid);
        if (!$(this).is(":checked")) {
            chkHeader.prop('checked', false);
        } else {
            if ($("[id*=chkRow]", grid).length == $("[id*=chkRow]:checked", grid).length) {
                chkHeader.prop('checked', 'checked');
            }
        }
    });

    /*Function no load of page*/
    //$(document).ready(function () {
    //    if ($('#HiddenFieldIdToken')[0].value === "D64E8A03-084D-4B08-9173-41E6E572D1DA" || $('#HiddenFieldIdToken')[0].value === "39598A74-DD1D-4B2F-8AB4-FDA16D69E90B" || $('#HiddenFieldIdToken')[0].value === "9D25F049-0593-4EAF-A0E8-08AE5C1D8113") {
    //        $('.OcultarDadosParaConfiguracao').show();
    //    }
    //    else {
    //        $('.OcultarDadosParaConfiguracao').remove();
    //    }

    //    if ($('#HiddenFieldIdToken')[0].value === "23F6A751-3829-4BCA-954F-033801248B28" || $('#HiddenFieldIdToken')[0].value === "034DC098-08CF-4440-90A6-BD3B3A47B59E" || $('#HiddenFieldIdToken')[0].value === "5B20CD6B-9461-4865-9920-5C19195D606F" || $('#HiddenFieldIdToken')[0].value === "AAFEDE05-4BEB-4C00-BA8E-E2904F1CD1F3") {
    //        $('.OcultarContatos').show();
    //        $('.OcultarEmail').remove();
    //    }
    //    else
    //        $('.OcultarContatos').remove();

    //    if ($('#HiddenFieldIdToken')[0].value != "F3B79B66-0853-4C7B-900F-FB9BE2E92505") {
    //        $("[id*=chkHeaderSelecionar]").prop('checked', true);
    //        $("[id*=chkRowSelecionar]").prop('checked', true);
    //    }

    //    $("#idcep").mask("99.999-999");
    //    $("#idcnpj").mask("99.999.999/9999-99");
    //    $("#cnpjempresaconjugadaid").mask("99.999.999/9999-99");
    //    $("#idtelefonecelularcontato").mask("(99) 99999-9999");

    //    if (sessionStorage.scrollTop != "undefined") {
    //        $(window).scrollTop(sessionStorage.scrollTop);
    //    }
    //});

    $(window).scroll(function () {
        sessionStorage.scrollTop = $(this).scrollTop();
    });


    /*==================================================================
    [ Validate after type ]*/
    $('.validate-input .input100').each(function () {
        $(this).on('blur', function () {
            if (validate(this) == false) {
                showValidate(this);
            }
            else {
                $(this).parent().addClass('true-validate');
            }
        })
    })

    //$('.validate-input .js-select2').each(function () {
    //    $(this).on('change', function () {
    //        if (validate(this) == false) {
    //            showValidate(this);
    //        }
    //        else {
    //            $(this).parent().addClass('true-validate');
    //        }
    //    })
    //})

    /*==================================================================
    [ Validate ]*/
    var input = $('.validate-input .input100');
    var select = $('.validate-input .js-select2');


    $('.validate-form').on('submit', function () {
        var check = true;

        for (var i = 0; i < input.length; i++) {
            if (input[i].form != null) {
                if (validate(input[i]) == false) {
                    showValidate(input[i]);
                    check = false;
                }
            }
        }

        for (var i = 0; i < select.length; i++) {
            if (select[i].form != null) {
                if (validate(select[i]) == false) {
                    showValidate(select[i]);
                    check = false;
                }
            }
        }




        return check;
    });


    $('.validate-form .input100').each(function () {
        $(this).focus(function () {
            hideValidate(this);
            $(this).parent().removeClass('true-validate');
        });
    });

    function validate(input) {

        if ($(input).attr('type') == 'idcnpj' || $(input).attr('name') == 'idcnpj') {

            if ($(input).val() == '' || $(input).val() == null) {
                $($("#dividcnpj")[0])[0].dataset.validate = 'Insira o CNPJ do cliente!'
                return false;
            }
            var b = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2], c = $(input).val();
            if ((c = c.replace(/[^\d]/g, "").split("")).length != 14) {
                $($("#dividcnpj")[0])[0].dataset.validate = 'CNPJ incorreto!!!'
                return false;
            }
            for (var i = 0, n = 0; i < 12; n += c[i] * b[++i]);
            if (c[12] != (((n %= 11) < 2) ? 0 : 11 - n)) {
                $($("#dividcnpj")[0])[0].dataset.validate = 'CNPJ incorreto!!!'
                return false;
            }
            for (var i = 0, n = 0; i <= 12; n += c[i] * b[i++]);
            if (c[13] != (((n %= 11) < 2) ? 0 : 11 - n)) {
                $($("#dividcnpj")[0])[0].dataset.validate = 'CNPJ incorreto!!!'
                return false;
            }

            return true;
        }

        if ($(input).attr('type') == 'idinscricaoestadual' || $(input).attr('name') == 'idinscricaoestadual' || $(input).attr('type') == 'idnumeroendereco' || $(input).attr('name') == 'idnumeroendereco' || $(input).attr('type') == 'idquantidade' || $(input).attr('name') == 'idquantidade') {
            return !isNaN(parseFloat($(input).val())) && isFinite($(input).val());
        }

        if ($(input).attr('name') == 'idenvionfe' || $(input).attr('name') == 'idemailjuridico' || $(input).attr('name') == 'idemail') {
            if ($(input).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
                return false;
            }
        }
        else {
            if ($(input).val().trim() == '') {
                return false;
            }
        }
    }

    function showValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).addClass('alert-validate');

        $(thisAlert).append('<span class="btn-hide-validate">&#xf136;</span>')
        $('.btn-hide-validate').each(function () {
            $(this).on('click', function () {
                hideValidate(this);
            });
        });
    }

    function hideValidate(input) {
        var thisAlert = $(input).parent();
        $(thisAlert).removeClass('alert-validate');
        $(thisAlert).find('.btn-hide-validate').remove();
    }



})(jQuery);