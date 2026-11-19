package com.example.apiapp
import com.example.apiapp.Conexion.RetrofitClient

import android.content.Intent
import android.os.Bundle
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.EditText
import android.widget.ListView
import android.widget.Spinner
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.example.apiapp.Clases.Datos
import com.example.apiapp.Clases.DatosVenta
import com.example.apiapp.Clases.Venta
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext


class InsertarVenta : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_insertar_venta)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }
        var volver = findViewById<Button>(R.id.btnVolverVenta)
        var limpiar = findViewById<Button>(R.id.btnLimpiarVenta)
        var insertar : Button = findViewById(R.id.btnInsertarVenta)
        var cmbProductos = findViewById<Spinner>(R.id.cmbProductos)
        var txtCantidad = findViewById<EditText>(R.id.txtCantidadVenta)

        var listaVenta = findViewById<ListView>(R.id.lvVentasInsertadas)

        cargaProductos(cmbProductos)
        cargaVentas(listaVenta)

        volver.setOnClickListener {
            startActivity(Intent(this, MainActivity::class.java))
            finish()
        }
        insertar.setOnClickListener {
            var id = cmbProductos.selectedItem.toString()
            var separar = id.split("-")

            var codigo = separar[0]
            var cantidad = txtCantidad.text

            var mensaje = ""
            if(id.isEmpty()){
                mensaje += "Debe seleccionar un producto\n"
            }
            if(cantidad.isEmpty()){
                mensaje += "Debe ingresar una cantidad"
            }
            if(mensaje==""){
                //insertar registro
                insertarProd(codigo.toInt(), cantidad.toString().toInt(), listaVenta)
            }else{
                Toast.makeText(this,mensaje,Toast.LENGTH_SHORT).show()
            }
        }
    }
    fun cargaProductos(cmbProductos: Spinner){
        var adaptador : ArrayAdapter<*>
        var arregloListado = ArrayList<String>()
        CoroutineScope(Dispatchers.IO).launch {
            try {
                var llamada = RetrofitClient.retrofit.getDatos()
                if(llamada.isSuccessful){
                    var res : Datos? = llamada.body()!!
                    withContext(Dispatchers.Main){
                        res?.respuesta?.forEach { item->
                            arregloListado.add("${item.codProducto}-${item.nomProducto}")
                        }
                        adaptador = ArrayAdapter(this@InsertarVenta,
                            android.R.layout.simple_spinner_item,
                            arregloListado)
                        cmbProductos.adapter = adaptador

                    }
                }
            } catch (e: Exception) {
                var res = e.toString()
            }
        }
    }
    fun insertarProd(codigo: Int, cantidad: Int, listaVenta : ListView){
        CoroutineScope(Dispatchers.IO).launch {
            try {
                var enviar = Venta(codigo, cantidad)
                var llamada = RetrofitClient.retrofit.InsertarVenta(enviar)
                if(llamada.isSuccessful){
                    var carga: Datos? = llamada.body()
                    withContext(Dispatchers.Main){
                        var mensaje = carga?.mensaje
                        var retorno = carga?.retorno
                        Toast.makeText(this@InsertarVenta,
                            "$mensaje : $retorno",
                            Toast.LENGTH_SHORT).show()
                        cargaVentas(listaVenta)
                    }
                }
            }catch (ex: Exception){

            }
        }
    }

    fun cargaVentas(listaVenta : ListView){
        var adaptador : ArrayAdapter<*>
        var arregloListado = ArrayList<String>()
        CoroutineScope(Dispatchers.IO).launch {
            try {
                var llamada = RetrofitClient.retrofit.TraerVenta()
                if(llamada.isSuccessful){
                    var carga : DatosVenta? = llamada.body()
                    withContext(Dispatchers.Main){
                        var mensaje = carga?.mensaje//ok
                        var retorno = carga?.retorno
                        var respuesta = carga?.respuesta//lista

                        respuesta?.forEach { item ->
                            arregloListado.add("ID: ${item.idVenta} - Nombre: ${item.nomProducto}\n" +
                                    "Precio: ${item.precioProducto} - Cantidad: ${item.cantidad}")
                        }
                        adaptador = ArrayAdapter(this@InsertarVenta,
                            android.R.layout.simple_list_item_1,
                            arregloListado)
                        listaVenta.adapter = adaptador
                    }
                }
            }catch (ex: Exception){

            }
        }
    }
}