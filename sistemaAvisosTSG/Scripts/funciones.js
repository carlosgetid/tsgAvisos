
$(document).ready(function (){
    $('.seleccion').on('click', function () {
        $(this).addClass('text-danger');
        console.log(this);
    });
});