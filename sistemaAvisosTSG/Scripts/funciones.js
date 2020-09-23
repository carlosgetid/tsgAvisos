

$(document).ready(function () {

    $('.seleccion').on('click', function () {
        $(this).addClass('text-danger');
        console.log(this);
    });

    $('.control > p').on('click', function () {
        $('.control > textarea').toggleClass('d-inline-block');
        $('.control > div > .d-inline-block').removeClass('d-inline-block').addClass("d-none");     
        
    });

    $('.control > textarea').on('keyup', function () {
        var valor = $(this).val();
        
        if (valor.length >= 5) {
            $(".control > div > p").addClass('d-inline-block');

        } else {
            $(".control > div> p").removeClass('d-inline-block');
        }
        
    });

    $('.busqueda').on('keyup', function () {
        var filtro = $(this).val();

        console.log(filtro);

        
        var listaDescripcion = null;

         

        

        $('.camposDeFiltro').children('a').remove();

        
        
    });
});