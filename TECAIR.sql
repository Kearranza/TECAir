CREATE TABLE CLIENTE(
    Cédula int
        constraint CLIENTE_pk
            primary key,
    Nombre varchar(20),
    Apellido_1 varchar(30),
    Apellido_2 varchar(30),
    Télefono varchar(15),
    Correo varchar(30)
);

CREATE TABLE USUARIO(
    ID_Usuario serial,
    Contraseña varchar(15),
    Cédula int,
    constraint USUARIO_pk
        primary key (ID_Usuario),
    constraint USUARIO_fk
        foreign key (Cédula) references CLIENTE (Cédula)
            ON UPDATE NO ACTION
            ON DELETE NO ACTION
);

CREATE TABLE ESTUDIANTE(
    Carnét int
        constraint ESTUDIANTE_pk
            primary key,
    Universidad varchar(50),
    Millas int,
    Cédula int,
    constraint ESTUDIANTE_fk
        foreign key (Cédula) references CLIENTE (Cédula)
            ON UPDATE NO ACTION
            ON DELETE NO ACTION
);

CREATE TABLE TARJETA_DE_CREDITO(
    Num_tarjeta int
        constraint TARJETA_DE_CREDITO_pk
            primary key,
    Fecha_exp varchar(5),
    CVV int,
    Cédula int,
    constraint TARJETA_DE_CREDITO_fk
        foreign key (Cédula) references CLIENTE (Cédula)
            ON UPDATE NO ACTION
            ON DELETE NO ACTION
);

CREATE TABLE AVIÓN(
    Placa varchar(10)
        constraint AVIÓN_pk
            primary key,
    Filas int,
    Columnas int
);

CREATE TABLE MAPA_ASIENTOS(
    ID_Mapa_Asiento serial
        constraint MAPA_ASIENTOS_pk
            primary key,
    Num_asiento int,
    Disponibilidad boolean,
    ID_Avión varchar(10),
    constraint MAPA_ASIENTOS_fk
        foreign key (ID_Avión) references AVIÓN (Placa)
            ON UPDATE NO ACTION
            ON DELETE NO ACTION
)

