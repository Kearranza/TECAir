create table cliente
(
    cedula     integer     not null
        constraint cliente_pk
            primary key,
    nombre     varchar(20) not null,
    apellido_1 varchar(30) not null,
    apellido_2 varchar(30),
    telefono   varchar(15) not null,
    correo     varchar(30) not null
);

alter table cliente
    owner to postgres;

create table usuario
(
    id_usuario serial
        constraint usuario_pk
            primary key,
    contrasena varchar(15) not null,
    cedula     integer     not null
        constraint usuario_fk_cedula
            references cliente
);

alter table usuario
    owner to postgres;

create table estudiante
(
    carnet      integer     not null
        constraint estudiante_pk
            primary key,
    universidad varchar(50) not null,
    millas      integer default 0,
    cedula      integer     not null
        constraint estudiante_fk_cedula
            references cliente
);

alter table estudiante
    owner to postgres;

create table tarjeta_de_credito
(
    num_tarjeta integer    not null
        constraint tarjeta_de_credito_pk
            primary key,
    fecha_exp   varchar(5) not null,
    cvv         integer default 0,
    cedula      integer    not null
        constraint tarjeta_de_credito_fk_cedula
            references cliente
);

alter table tarjeta_de_credito
    owner to postgres;

create table avion
(
    placa    varchar(10) not null
        constraint avion_pk
            primary key,
    filas    integer default 1,
    columnas integer default 1
);

alter table avion
    owner to postgres;

create table mapa_asientos
(
    id_mapa_asiento serial
        constraint mapa_asientos_pk
            primary key,
    num_asiento     integer default 1,
    disponibilidad  boolean default true,
    id_avion        varchar(10) not null
        constraint mapa_asientos_fk_avion
            references avion
);

alter table mapa_asientos
    owner to postgres;

create table aereopuerto
(
    id_aereo varchar(3)  not null
        constraint aereopuerto_pk
            primary key,
    ciudad   varchar(30) not null,
    pais     varchar(40) not null
);

alter table aereopuerto
    owner to postgres;

create table vuelos
(
    id_vuelo     integer    not null
        constraint vuelos_pk
            primary key,
    hora_salida  time       not null,
    aereo_origen varchar(3) not null
        constraint vuelos_fk_aereo_ori
            references aereopuerto,
    aereo_final  varchar(3) not null
        constraint vuelos_fk_aereo_fin
            references aereopuerto
);

alter table vuelos
    owner to postgres;

create table calendario_vuelo
(
    id_calendario varchar(20) not null
        constraint calendario_vuelo_pk
            primary key,
    fecha         date        not null,
    precio        integer default 0,
    id_avion      varchar(10) not null
        constraint calendario_vuelo_fk_avion
            references avion,
    id_vuelo      integer
        constraint calendario_vuelo_fk_vuelo
            references vuelos,
    abierto       boolean
);

alter table calendario_vuelo
    owner to postgres;

create table escala
(
    id_escala     integer     not null
        constraint escala_pk
            primary key,
    orden_lugares varchar(20) not null,
    origen        varchar(3)  not null,
    destino       varchar(3)  not null,
    id_vuelo      integer     not null
        constraint escala_fk_vuelo
            references vuelos
);

alter table escala
    owner to postgres;

create table pase_abordar
(
    id_pasaje      integer    not null
        constraint pase_abordar_pk
            primary key,
    puerta         varchar(3) not null,
    asiento        varchar(3) not null,
    hora_salida    time       not null,
    cedula_cliente integer    not null
        constraint pase_abordar_fk_cedula
            references cliente,
    id_calendario  varchar(20)
        constraint pase_abordar_fk_calendario
            references calendario_vuelo
);

alter table pase_abordar
    owner to postgres;

create table color
(
    id_color varchar(15) not null
        constraint color_pk
            primary key
);

alter table color
    owner to postgres;

create table maleta
(
    id_maleta      serial
        constraint maleta_pk
            primary key,
    cedula_cliente integer     not null
        constraint maleta_fk_cedula
            references cliente,
    peso           numeric default 0,
    color          varchar(15) not null
        constraint maleta_fk_color
            references color,
    id_pasaje      integer     not null
        constraint maleta_fk_pasaje
            references pase_abordar
);

alter table maleta
    owner to postgres;

create table promociones
(
    id_promo            serial
        constraint promociones_pk
            primary key,
    descuento           numeric default 0,
    fecha_inicio        date        not null,
    fecha_final         date        not null,
    origen              varchar(20) not null,
    destino             varchar(20) not null,
    aplicado_calendario varchar(20)
        constraint promociones_fk_vuelo
            references calendario_vuelo
);

alter table promociones
    owner to postgres;

create table factura
(
    id_factura   serial
        constraint factura_pk
            primary key,
    cliente      integer
        constraint factura_fk_cliente
            references cliente,
    tarjeta_cred integer
        constraint factura_fk_tarjeta_cred
            references tarjeta_de_credito,
    calendario   varchar(20)
        constraint factura_fk_calendario
            references calendario_vuelo
);

alter table factura
    owner to postgres;


