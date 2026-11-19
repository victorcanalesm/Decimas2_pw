package com.example.apiapp

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.example.apiapp.Clases.Datos
import com.example.apiapp.Clases.Producto
import com.example.apiapp.Conexion.RetrofitClient
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext

class InsertarProducto : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_insertar_producto)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }
        var volver = findViewById<Button>(R.id.btnVolverProducto)
        var limpiar = findViewById<Button>(R.id.btnLimpiarProducto)
        var insertar : Button = findViewById(R.id.btnInsertarProducto)

        var codigo = findViewById<EditText>(R.id.txtCodigoProducto)
        var nombre = findViewById<EditText>(R.id.txtNombreProducto)
        var precio = findViewById<EditText>(R.id.txtPrecioProducto)

        volver.setOnClickListener {
            startActivity(Intent(this@InsertarProducto, MainActivity::class.java))
            finish()
        }
        limpiar.setOnClickListener {
            codigo.text.clear()
            nombre.text.clear()
            precio.text.clear()
        }
        insertar.setOnClickListener {
            var mensaje = ""
            if(codigo.text.isEmpty()){
                mensaje += "Debe ingresar el codigo \n"
            }
            if(nombre.text.isEmpty()){
                mensaje += "Debe ingresar el nombre \n"
            }
            if(precio.text.isEmpty()){
                mensaje += "Debe ingresar el precio"
            }
            if(mensaje == ""){
                //insertar
                insertarProducto(codigo.text.toString().toInt(),
                    nombre.text.toString(),
                    precio.text.toString().toInt())
            }else{
                Toast.makeText(this, mensaje, Toast.LENGTH_SHORT).show()
            }
        }
    }
    fun insertarProducto(codigo:Int, nombre:String, precio:Int){
        CoroutineScope(Dispatchers.IO).launch {
            try{
                var contenido = Producto(codigo,
                    nombre,
                    precio)
                var llamada = RetrofitClient.retrofit.InsertarProducto(contenido)
                if(llamada.isSuccessful){
                    var carga : Datos? = llamada.body()
                    withContext(Dispatchers.Main){
                        var mensaje = carga?.mensaje
                        var retorno = carga?.retorno
                        Toast.makeText(this@InsertarProducto,
                            "$mensaje : $retorno",
                            Toast.LENGTH_SHORT).show()
                    }
                }
            }catch (ex: Exception){

            }
        }
    }
}