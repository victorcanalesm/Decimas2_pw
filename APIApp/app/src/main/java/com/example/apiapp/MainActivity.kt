package com.example.apiapp

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }
        var botonListado = findViewById<Button>(R.id.btnListado)
        var botonProducto = findViewById<Button>(R.id.btnProductos)
        var botonVenta = findViewById<Button>(R.id.btnVenta)

        botonListado.setOnClickListener {
            var abrir = Intent(this, ListadoProducto::class.java)
            startActivity(abrir)
            finish()
        }
        botonProducto.setOnClickListener {
            var abrir = Intent(this, InsertarProducto::class.java)
            startActivity(abrir)
            finish()
        }
        botonVenta.setOnClickListener {
            var abrir = Intent(this, InsertarVenta::class.java)
            startActivity(abrir)
            finish()
        }
    }
}