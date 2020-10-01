$(document).ready(function () {

    //$('.seleccion').on('click', function () {
    //    $(this).toggleClass('text-danger');
    //    console.log(this);
    //});

    $('.control > p').on('click', function () {
        $('.control > .txtComentario').toggleClass('d-inline-block');
        $('.control > div > .d-inline-block').removeClass('d-inline-block').addClass("d-none");
    });

    $('.txtComentario').on('keyup', function (evt) {
        var valor = $(this).val();

        if (valor.length >= 5) {
            $(".control > div > .btn").addClass('d-inline-block');

        } else {
            $(".control > div> .btn").removeClass('d-inline-block');
        }
    });

    $(".btnPublicar").on('click', function () {
        var valor = $(".txtComentario").val();
        var fakedUri = $(this).attr("href");
        var url = fakedUri.replace("xxxx", valor);
        $(".btnPublicar").attr('href', url);
    });
});