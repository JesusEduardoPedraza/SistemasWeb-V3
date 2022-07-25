class Categorias {

    RegistrarCategoria() {
        $.post(
            "GetCategorias",
            $('.formCategoria').serialize(),
            (response) => {
                console.log(response);
            }
        );
    }
}
