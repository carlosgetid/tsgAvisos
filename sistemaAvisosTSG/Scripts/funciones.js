

$(document).ready(function () {

    $('.seleccion').on('click', function () {
        $(this).addClass('text-danger');
        console.log(this);
    });

    $('.busqueda').on('keyup', function () {
        var filtro = $(this).val();

        console.log(filtro);

        
        var listaDescripcion = null;
            

        

        $('.camposDeFiltro').children('a').remove();

        
        
    });
});