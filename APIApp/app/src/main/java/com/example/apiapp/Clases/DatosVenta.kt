package com.example.apiapp.Clases

data class DatosVenta (
    var mensaje: String,
    var retorno: String,
    val respuesta: List<VentaProducto>
)
data class VentaProducto(
    var idVenta : Int,
    var nomProducto : String,
    var precioProducto : Int,
    var cantidad : Int
)