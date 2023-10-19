CREATE TABLE CLIENTE(
    Cedula int
        constraint CLIENTE_pk
            primary key,
    Nombre varchar(20) not null ,
    Apellido_1 varchar(30) not null ,
    Apellido_2 varchar(30),
    Telefono varchar(15) not null ,
    Correo varchar(30) not null
);

CREATE TABLE COLOR(
    ID_Color varchar(15)
        constraint COLOR_pk
            primary key
);

CREATE TABLE AEREOPUERTO(
    ID_Aereo varchar(3)
    constraint AEREOPUERTO_pk
        primary key,
    Ciudad varchar(30) not null ,
    Pais varchar(40) not null
);

CREATE TABLE VUELOS(
    ID_Vuelo int
    constraint VUELOS_pk
        primary key,
    Hora_salida time not null ,
    Aereo_origen varchar(3) not null ,
    Aereo_final varchar(3) not null ,
    constraint VUELOS_fk
        foreign key (Aereo_origen) references AEREOPUERTO (ID_aereo)
            ON UPDATE NO ACTION
            ON DELETE NO ACTION,
        constraint VUELOS_AEREOPUERTO_fk
        foreign key (Aereo_final) references AEREOPUERTO (ID_aereo)
            ON UPDATE NO ACTION
            ON DELETE NO ACTION
);

CREATE TABLE USUARIO(
    ID_Usuario serial,
    Contrasena varchar(15) not null ,
    Cedula int not null ,
    constraint USUARIO_pk
        primary key (ID_Usuario),
    constraint USUARIO_CLIENTE_fk
        foreign key (Cedula) references CLIENTE (Cedula)
            ON UPDATE NO ACTION
            ON DELETE NO ACTION
);

CREATE TABLE ESTUDIANTE(
    Carnet int
        constraint ESTUDIANTE_pk
            primary key,
    Universidad varchar(50) not null ,
    Millas int default 0,
    Cedula int not null ,
    constraint ESTUDIANTE_CLIENTE_fk
        foreign key (Cedula) references CLIENTE (Cedula)
            ON UPDATE NO ACTION
            ON DELETE NO ACTION
);

CREATE TABLE TARJETA_DE_CREDITO(
    Num_tarjeta int
        constraint TARJETA_DE_CREDITO_pk
            primary key,
    Fecha_exp varchar(5) not null ,
    CVV int not null,
    Cedula int not null,
    constraint TARJETA_DE_CREDITO_fk
        foreign key (Cedula) references CLIENTE (Cedula)
            ON UPDATE NO ACTION
            ON DELETE NO ACTION
);

CREATE TABLE AVION(
    Placa varchar(10)
        constraint AVIÓN_pk
            primary key,
    Filas int default 1,
    Columnas int default 1
);

CREATE TABLE MAPA_ASIENTOS(
    ID_Mapa_Asiento serial
        constraint MAPA_ASIENTOS_pk
            primary key,
    Num_asiento int default 1,
    Disponibilidad boolean default TRUE,
    ID_Avion varchar(10) not null,
    constraint MAPA_ASIENTOS_AVION_fk
        foreign key (ID_Avion) references AVION (Placa)
            ON UPDATE NO ACTION
            ON DELETE NO ACTION
);

CREATE TABLE CALENDARIO_VUELO(
    ID_Calendario varchar(20)
        constraint CALENDARIO_VUELO_pk
            primary key,
    Fecha date not null ,
    Precio int not null ,
    ID_Avion varchar(10) not null,
    ID_Vuelo int,
    constraint CALENDARIO_VUELO_AVION_fk
        foreign key (ID_Avion) references AVION (Placa)
            ON UPDATE NO ACTION
            ON DELETE NO ACTION,
    constraint CALENDARIO_VUELO_VUELOS_fk
        foreign key (ID_Vuelo) references VUELOS (ID_Vuelo)
            ON UPDATE NO ACTION
            ON DELETE NO ACTION
);

CREATE TABLE ESCALA(
    ID_Escala int
        constraint ESCALA_pk
            primary key,
    Orden_lugares varchar(20) not null ,
    Origen varchar(3) not null ,
    Destino varchar(3) not null ,
    ID_Vuelo int not null ,
    constraint ESCALA_VUELOS_fk
        foreign key (ID_Vuelo) references VUELOS (ID_Vuelo)
);

CREATE TABLE PASE_ABORDAR(
    ID_Pasaje int
        constraint PASE_ABORDAR_pk
            primary key,
    Puerta varchar(3) not null,
    Asiento varchar(3) not null,
    Hora_salida time not null,
    Cedula_cliente int not null,
    ID_Calendario varchar(20),
    constraint PASE_ABORDAR_CLIENTE_fk
        foreign key (Cedula_cliente) references CLIENTE (Cedula)
            ON UPDATE NO ACTION
            ON DELETE NO ACTION,
    constraint PASE_ABORDAR_CALENDARIO_VUELO_fk
        foreign key (ID_Calendario) references CALENDARIO_VUELO (ID_Calendario)
            ON UPDATE NO ACTION
            ON DELETE NO ACTION
);

CREATE TABLE MALETA(
    ID_Maleta int
        constraint MALETA_pk
            primary key,
    Cedula_Cliente int not null,
    Peso decimal default 0,
    Color varchar(15) not null,
    ID_Pasaje int not null,
    constraint MALETA_CLIENTE_fk
        foreign key (Cedula_Cliente) references CLIENTE (Cedula)
            ON UPDATE NO ACTION
            ON DELETE NO ACTION,
    constraint MALETA_COLOR_fk
        foreign key (Color) references COLOR (ID_Color)
            ON UPDATE NO ACTION
            ON DELETE NO ACTION,
    constraint MALETA_PASE_ABORDAR_fk
        foreign key (ID_Pasaje) references PASE_ABORDAR (ID_Pasaje)
            ON UPDATE NO ACTION
            ON DELETE NO ACTION
);

CREATE TABLE PROMOCIONES(
    ID_Promo serial
        constraint PROMOCIONES_pk
            primary key,
    Descuento decimal default 0,
    Fecha_inicio date not null,
    Fecha_final date not null,
    Origen varchar(20) not null,
    Destino varchar(20) not null,
    Aplicado_calendario varchar(20),
    constraint PROMOCIONES_CALENDARIO_VUELO_fk
        foreign key (Aplicado_calendario) references CALENDARIO_VUELO (ID_Calendario)
);

CREATE TABLE FACTURA(
    ID_Factura serial
        constraint FACTURA_pk
            primary key
);