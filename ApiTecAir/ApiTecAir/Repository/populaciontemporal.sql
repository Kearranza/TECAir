INSERT INTO aereopuerto (id_aereo, ciudad, pais) 
values ('SJO','San Jose', 'Costa Rica');

INSERT INTO aereopuerto (id_aereo, ciudad, pais)
values ('PTY','Panama', 'Panama');

INSERT INTO aereopuerto (id_aereo, ciudad, pais)
values ('SAL','San Salvador', 'El Salvador');

INSERT INTO aereopuerto (id_aereo, ciudad, pais)
values ('BDA','Saint George', 'Bermudas');

INSERT INTO aereopuerto (id_aereo, ciudad, pais)
values ('YYZ','Toronto', 'Canada');

INSERT INTO aereopuerto (id_aereo, ciudad, pais)
values ('BLI','Bellingham', 'Estados Unidos');

INSERT INTO aereopuerto (id_aereo, ciudad, pais)
values ('GOH','Nuuk', 'Groenlandia');

INSERT INTO aereopuerto (id_aereo, ciudad, pais)
values ('MEX','Ciudad de Mexico', 'Mexico');

INSERT INTO aereopuerto (id_aereo, ciudad, pais)
values ('BZE','Belmopan', 'Belice');

INSERT INTO aereopuerto (id_aereo, ciudad, pais)
values ('GUA','Ciudad de Guatemala', 'Guatemala');

INSERT INTO aereopuerto (id_aereo, ciudad, pais)
values ('TGU','Tegucigalpa', 'Honduras');

INSERT INTO aereopuerto (id_aereo, ciudad, pais)
values ('MGA','Managua', 'Nicaragua');

INSERT INTO aereopuerto (id_aereo, ciudad, pais)
values ('BRC','Bariloche', 'Argentina');

INSERT INTO aereopuerto (id_aereo, ciudad, pais)
values ('VVI','Santa Cruz', 'Bolivia');

INSERT INTO aereopuerto (id_aereo, ciudad, pais)
values ('BSB','Brasilia', 'Brasil');

INSERT INTO aereopuerto (id_aereo, ciudad, pais)
values ('ANF','Antofagasta', 'Chile');

INSERT INTO aereopuerto (id_aereo, ciudad, pais)
values ('BOG','Bogota', 'Colombia');

INSERT INTO aereopuerto (id_aereo, ciudad, pais)
values ('BLA','Barcelona', 'Venezuela');

INSERT INTO avion (placa, filas, columnas)
values ('AVC789', 6, 6);

INSERT INTO avion (placa, filas, columnas)
values ('PNK951', 12, 6);

INSERT INTO avion (placa, filas, columnas)
values ('CYI', 8, 6);

INSERT INTO avion (placa, filas, columnas)
values ('GPA312', 7,6);

INSERT INTO avion (placa, filas, columnas)
values ('WER675', 10, 6);

INSERT INTO avion (placa, filas, columnas)
values ('HVM816', 6, 6);

INSERT INTO cliente (cedula, nombre, apellido_1, telefono, correo) 
VALUES (985764213, 'Salvatore', 'Di Maria', '951684621','abc@def.com');

INSERT INTO usuario (contrasena, cedula) 
VALUES ('1234', 985764213);

INSERT INTO estudiante (carnet, universidad, cedula)
VALUES (20463143,'TEC', 985764213);

INSERT INTO vuelos (id_vuelo, hora_salida, aereo_origen, aereo_final)
values (404, '09:15:00.000', 'SJO', 'PTY');

INSERT INTO calendario_vuelo (id_calendario, fecha, precio, id_avion, id_vuelo)
VALUES ('San Jose, Panama','2023-12-15', 150,'HVM816', '404');

INSERT INTO tarjeta_de_credito (num_tarjeta, fecha_exp, cedula)
VALUES (61146194, '11/24', 985764213);