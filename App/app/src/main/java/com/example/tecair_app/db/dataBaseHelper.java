package com.example.tecair_app.db;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.Nullable;

public class dataBaseHelper extends SQLiteOpenHelper {
    public static final String cliente = "cliente";
    public static final String cedula_cliente = "cedula";
    public static final String cedula = cedula_cliente;
    public static final String nombre = "nombre";
    public static final String apellido_1 = "apellido_1";
    public static final String apellido_2 = "apellido_2";
    public static final String telefono = "telefono";
    public static final String correo = "correo";
    public static final String usuario = "usuario";
    public static final String id_usuario = "id_usuario";
    public static final String contrasena = "contrasena";
    public static final String estudiante = "estudiante";
    public static final String carnet = "carnet";
    public static final String universidad = "universidad";
    public static final String millas = "millas";
    public static final String cedula_due = "cedula_due";
    public static final String cedula_dueno = cedula_due + "no";
    public static final String tarjeta_de_credito = "tarjeta_de_credito";
    public static final String num_tarjeta = "num_tarjeta";
    public static final String fecha = "fecha";
    public static final String fecha_exp = fecha + "_exp";
    public static final String cvv = "cvv";
    public static final String avion = "avion";
    public static final String placa = "placa";
    public static final String filas = "filas";
    public static final String columnas = "columnas";
    public static final String asiento = "asiento";
    public static final String mapa_asientos = "mapa_" + asiento + "s";
    public static final String id_mapa_asiento = "id_mapa_" + asiento;
    public static final String num_asiento = "num_" + asiento;
    public static final String disponibilidad = "disponibilidad";
    public static final String id_avion = "id_avion";
    public static final String aeropuerto = "aeropuerto";
    public static final String id_aereo = "id_aereo";
    public static final String ciudad = "ciudad";
    public static final String pais = "pais";
    public static final String vuelos = "vuelos";
    public static final String id_vuelo = "id_vuelo";
    public static final String hora_salida = "hora_salida";
    public static final String origen = "origen";
    public static final String aereo_origen = "aereo_" + origen;
    public static final String aereo_final = "aereo_final";
    public static final String calendario_vuelo = "calendario_vuelo";
    public static final String id_calendario = "id_calentadrio";
    public static final String precio = "precio";
    public static final String id_avion_cv = "id_avion_cv";
    public static final String id_vuelo_cv = "id_vuelo_cv";
    public static final String escala = "escala";
    public static final String id_escala = "id_escala";
    public static final String orden_lugares = "orden_lugares";
    public static final String destino = "destino";
    public static final String id_vuelo_escala = "id_vuelo_escala";
    public static final String pase_abordar = "pase_abordar";
    public static final String id_pasaje = "id_pasaje";
    public static final String puerta = "puerta";
    public static final String hora_salida_pase = "hora_salida_pase";
    public static final String cedula_clidue = "cedula_clidue";
    public static final String id_calendario_pase = "id_calendario_pase";
    public static final String color = "color";
    public static final String id_color = "id_color";
    public static final String maleta = "maleta";
    public static final String id_maleta = "id_maleta";
    public static final String peso = "peso";
    public static final String color_maleta = "color_maleta";
    public static final String cedula_maleta = "cedula_maleta";
    public static final String id_pasaje_maleta = "id_pasaje_maleta";
    public static final String promociones = "promociones";
    public static final String id_promo = "id_promo";
    public static final String descuento = "descuento";
    public static final String fecha_inicio = "fecha_inicio";
    public static final String fecha_final = "fecha_final";
    public static final String origen_promo = "origen_promo";
    public static final String destino_promo = "destino_promo";
    public static final String aplicado_calendario = "aplicado_calendario";
    public static final String factura = "factura";
    public static final String id_factura = "id_factura";
    public static final String cliente_factura = "cliente_factura";
    public static final String tarjeta_factura = "tarjeta_factura";
    public static final String calendario_factura = "calendario_factura";

    public dataBaseHelper(@Nullable Context context) {
        super(context, "tecAir.db", null, 1);
    }

    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {
        String createClienteTable = "CREATE TABLE " + cliente + "(" + cedula + " INTEGER PRIMARY KEY, " + nombre + " TEXT, " + apellido_1 + " TEXT, " + apellido_2 + " TEXT, " + telefono + " TEXT, " + correo + " TEXT)";
        String createUsuarioTable = "CREATE TABLE " + usuario + "(" + id_usuario + " INTEGER PRIMARY KEY AUTOINCREMENT, " + contrasena + " TEXT, " + cedula_cliente + " int, FOREIGN KEY (" + cedula_cliente + ") REFERENCES " + cliente + "( "+ cedula + "))";
        String createEstudianteTable = "CREATE TABLE " + estudiante + "(" + carnet + " INTEGER PRIMARY KEY, " + universidad + " text, " + millas + " INT, " + cedula_dueno + " int,FOREIGN KEY (" + cedula_dueno + ") REFERENCES " + cliente + "( " + cedula + "))";
        //String createTarjeta_De_CreditoTable = "CREATE TABLE " + tarjeta_de_credito + "(" + num_tarjeta + " int PRIMARY KEY, " + fecha_exp + " text, " + cvv + " int, " + cedula_due + " int, FOREIGN KEY (" + cedula_due + ") REFERENCES " + cliente + "(" + cedula + "))";
        //String createAvionTable = "CREATE TABLE " + avion + "(" + placa + " TEXT PRIMARY KEY, " + filas + " INT, " + columnas + " INT)";
        //String createMapa_AsientosTable = "CREATE TABLE " + mapa_asientos + "(" + id_mapa_asiento + " INT PRIMARY KEY AUTOINCREMENT, " + num_asiento + " INT, " + disponibilidad + " INT, " + id_avion + " TEXT, FOREIGN KEY (" + id_avion + ") REFERENCES " + avion + "(" + placa + "))";
        //String createAeropuertoTable = "CREATE TABLE " + aeropuerto + "(" + id_aereo + " TEXT PRIMARY KEY, " + ciudad + " TEXT, " + pais + " TEXT)";
        //String createVuelosTable = "CREATE TABLE " + vuelos + "(" + id_vuelo + " INTEGER PRIMARY KEY, " + hora_salida + " TEXT, " + aereo_origen + " TEXT, " + aereo_final + " TEXT, FOREIGN KEY ( " + aereo_origen + ") REFERENCES " + aeropuerto + "(" + id_aereo + "), FOREIGN KEY ( " + aereo_final +") REFERENCES " + aeropuerto +"(" + id_aereo + "))";
        //String createCalendario_VueloTable = "CREATE TABLE " + calendario_vuelo + "(" + id_calendario + " TEXT PRIMARY KEY, " + fecha + " TEXT, " + precio + " INT, " + id_avion_cv + " TEXT, " + id_vuelo_cv + " INT, abierto INT, FOREIGN KEY ( " + id_avion_cv + ") REFERENCES " + avion + "(" + placa + "), FOREIGN KEY ( " + id_vuelo_cv + ") REFERENCES " + vuelos + "(" + id_vuelo + "))";
        //String createEscalaTable = "CREATE TABLE " + escala + "(" + id_escala + " INTEGER PRIMARY KEY, " + orden_lugares + " TEXT, " + origen + " TEXT, " + destino + " TEXT, " + id_vuelo_escala + " INT, FOREIGN KEY ( " + id_vuelo_escala + ") REFERENCES " + vuelos + "(" + id_vuelo + "))";
        String createPromocionesTable = "CREATE TABLE " + promociones + "(" + id_promo + " INTEGER PRIMARY KEY AUTOINCREMENT, " + descuento + " INT, " + fecha_inicio + " TEXT, " + fecha_final + " TEXT, " + origen_promo + " TEXT, " + destino_promo + " TEXT, "+ precio + "INT)";
        //String createFacturaTable = "CREATE TABLE " + factura + "(" + id_factura + " INTEGER PRIMARY KEY AUTOINCREMENT, " + cliente_factura + " INT, " + tarjeta_factura + " INT, " + calendario_factura + " TEXT, FOREIGN KEY ( " + cliente_factura + ") REFERENCES " + cliente + "(" + cedula + "), FOREIGN KEY ( " + tarjeta_factura + ") REFERENCES " + tarjeta_de_credito + "(" + num_tarjeta + "), FOREIGN KEY ( " + calendario_factura + ") REFERENCES " + calendario_vuelo + "(" + id_calendario + "))";


        sqLiteDatabase.execSQL(createClienteTable);
        sqLiteDatabase.execSQL(createUsuarioTable);
        sqLiteDatabase.execSQL(createEstudianteTable);
        //sqLiteDatabase.execSQL(createTarjeta_De_CreditoTable);
        //sqLiteDatabase.execSQL(createAvionTable);
        //sqLiteDatabase.execSQL(createMapa_AsientosTable);
        //sqLiteDatabase.execSQL(createAeropuertoTable);
        //sqLiteDatabase.execSQL(createVuelosTable);
        //sqLiteDatabase.execSQL(createCalendario_VueloTable);
        //sqLiteDatabase.execSQL(createEscalaTable);
        sqLiteDatabase.execSQL(createPromocionesTable);
        //sqLiteDatabase.execSQL(createFacturaTable);

    }
    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int i, int i1) {
        sqLiteDatabase.execSQL("DROP TABLE " + cliente);
        sqLiteDatabase.execSQL("DROP TABLE " + usuario);
        sqLiteDatabase.execSQL("DROP TABLE " + estudiante);
        sqLiteDatabase.execSQL("DROP TABLE " + promociones);
        onCreate(sqLiteDatabase);
    }
    public Boolean addOneRegular (comonClient client){
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues cv = new ContentValues();
        cv.put(cedula_cliente, client.getCedula());
        cv.put(contrasena, client.getPassword());
        long insert = db.insert(usuario, null, cv);
        if(insert == -1){
            return false;
        }
        return true;
    }
    public Boolean addOneStudent(studentClient client){
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues cv = new ContentValues();
        cv.put(carnet, client.getCarnet());
        cv.put(universidad, client.getUniversity());
        cv.put(cedula_dueno, client.getCedula());
        cv.put(millas, client.getMiles());
        long insert = db.insert(estudiante, null, cv);
        if(insert == -1){
            return false;
        }
        return true;
    }
    public Boolean addOneClient(basicClient client){
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues cv = new ContentValues();
        cv.put(cedula, client.getCedula());
        cv.put(nombre, client.getName());
        cv.put(apellido_1, client.getLname1());
        cv.put(apellido_2, client.getLname2());
        cv.put(telefono, client.getPhone());
        cv.put(correo, client.getEmail());
        long insert = db.insert(cliente, null, cv);
        if(insert == -1){
            return false;
        }
        return true;
    }
    public void addPromos(Integer desc, String inicio, String Final,String origen, String destino, Integer Precio){
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues cv = new ContentValues();
        cv.put(descuento, desc);
        cv.put(fecha_inicio, inicio);
        cv.put(fecha_final, Final);
        cv.put(origen_promo, origen);
        cv.put(destino_promo, destino);
        cv.put(precio, Precio);
        long insert = db.insert(promociones, null, cv);
    }
    public Boolean exist(basicClient client){
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor cursor = db.rawQuery("Select * from cliente where cedula = ?",  new String[] {String.valueOf(client.getCedula())});
        if(cursor.getCount()>1){
            return true;
        }
        return false;
    }
    public Boolean userExist(String user, String pword) {
        SQLiteDatabase db = this.getWritableDatabase();
        //Cursor cursor = db.rawQuery("Select * from estudiante where cedula_dueno = ? and carnet = ?", new String[]{user, pword});
        Cursor cursor2 = db.rawQuery("Select * from usuario where cedula = ? and contrasena = ?", new String[]{user, pword});
        if (cursor2.getCount()!=0) {
            return true;
        }
        return false;
    }
}
