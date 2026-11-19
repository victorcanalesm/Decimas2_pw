package com.example.apiapp.Conexion
import com.example.apiapp.Interfaz.Funciones

import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

object RetrofitClient {
    //var localhost = "10.0.2.2"
    var localhost = "192.168.56.1"
    var puerto = "5017"
    val retrofit = Retrofit.Builder()
        .baseUrl("http://$localhost:$puerto/api/Producto/")
        .addConverterFactory(GsonConverterFactory.create())
        .build()
        .create(Funciones::class.java)

    //val llamada = retrofit.create(ApiService::class.java)
}