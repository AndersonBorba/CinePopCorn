
(function ($) {
    "use strict";

    $("[id=idfind]").on('keyup', function () {
        for (var i = 1; i < $(document.querySelector("#gvMovies > tbody"))[0].childNodes.length; i++) {
            for (var j = 1; j < 4; j++) {
                var a = $($($(document.querySelector("#gvMovies > tbody"))[0].childNodes[i])[0].childNodes[j])[0].innerHTML
                if (a.indexOf($("#idfind")[0].value) > -1) {
                    $($(document.querySelector("#gvMovies > tbody"))[0].childNodes[i]).show();
                    break;
                }
                else {
                    $($(document.querySelector("#gvMovies > tbody"))[0].childNodes[i]).hide();
                }
            }
        }
    });

    $("[id=idfind2]").on('keyup', function () {
        for (var i = 1; i < $(document.querySelector("#gvSessions > tbody"))[0].childNodes.length; i++) {
            for (var j = 1; j < 7; j++) {
                var a = ($($(document.querySelector("#gvSessions > tbody"))[0].childNodes[i])[0].childNodes)[j].innerHTML
                if (a.indexOf($("#idfind2")[0].value) > -1) {
                    $($(document.querySelector("#gvSessions > tbody"))[0].childNodes[i]).show();
                    break;
                }
                else {
                    $($(document.querySelector("#gvSessions > tbody"))[0].childNodes[i]).hide();
                }
            }
        }
    });

    $("[id*=idmovie]").change(function () {
        changeDateEnd();
    });

    $("[id*=iddate]").change(function () {
        changeDateEnd();
    });

    function changeDateEnd() {
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
    };


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