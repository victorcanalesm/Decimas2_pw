package com.example.apiapp
import com.example.apiapp.Clases.Datos
import com.example.apiapp.Conexion.RetrofitClient

import android.content.Intent
import android.os.Bundle
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.ListView
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext


class ListadoProducto : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_listado_producto)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }
        var volver = findViewById<Button>(R.id.btnListadoVolver)
        var listView = findViewById<ListView>(R.id.lvDatosListado)

        volver.setOnClickListener {
            startActivity(Intent(this, MainActivity::class.java))
            finish()
        }
        llamarListado(listView)
        //evento del contenido del listview
        listView.setOnItemClickListener{ parent, item, pos, id ->
            var elemento = parent.getItemAtPosition(pos)
            Toast.makeText(this, "$elemento", Toast.LENGTH_SHORT).show()
        }

    }
    fun llamarListado(listView : ListView){
        var adaptador : ArrayAdapter<*>
        var arregloListado = ArrayList<String>()

        CoroutineScope(Dispatchers.IO).launch {
            try {
                var llamada = RetrofitClient.retrofit.getDatos()
                if (llamada.isSuccessful) {
                    val carga: Datos? = llamada.body()!!
                    withContext(Dispatchers.Main) {
                        var mensaje = carga?.mensaje
                        var retorno = carga?.retorno
                        var respuesta = carga?.respuesta //es una lista

                        respuesta?.forEach { item ->
                            var id = item.codProducto
                            var nombre = item.nomProducto
                            var precio = item.precioProducto

                            arregloListado.add("ID: $id - Nombre: $nombre \nPrecio: $precio")
                        }
                        adaptador = ArrayAdapter(this@ListadoProducto,
                            android.R.layout.simple_list_item_1,
                            arregloListado)
                        listView.adapter = adaptador
                    }
                }
            }catch (e: Exception) {
                var res = e.toString()
                //Toast.makeText(this@ListadoProducto, "ERROR: ${e.toString()}", Toast.LENGTH_SHORT).show()
            }
        }
    }
}