package com.example.apiapp.Interfaz

import com.example.apiapp.Clases.Datos
import com.example.apiapp.Clases.DatosVenta
import com.example.apiapp.Clases.Producto
import com.example.apiapp.Clases.Venta
import retrofit2.Response
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.POST

interface Funciones {
    @GET("Listado")
    suspend fun getDatos(): Response<Datos>
    @POST("Insertar")
    suspend fun InsertarProducto(@Body producto: Producto): Response<Datos>
    @POST("InsertarVenta")
    suspend fun InsertarVenta(@Body venta: Venta): Response<Datos>

    @GET("TraerVenta")
    suspend fun TraerVenta(): Response<DatosVenta>
}