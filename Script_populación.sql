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

INSERT INTO vuelos (id_vuelo, hora_salida, aereo_origen, aereo_final)
values (404, '09:15:00.000', 'SJO', 'PTY');

INSERT INTO calendario_vuelo (id_calendario, fecha, precio, id_avion, id_vuelo, abierto)
VALUES ('San Jose, Panama','2023-12-15', 150,'HVM816', '404', false);

INSERT INTO color (ID_Color)
VALUES ('Negro');

INSERT INTO color (ID_Color)
VALUES ('Gris');

INSERT INTO color (ID_Color)
VALUES ('Azul');

INSERT INTO color (ID_Color)
VALUES ('Café');

INSERT INTO color (ID_Color)
VALUES ('Morado');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (1, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (2, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (3, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (4, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (5, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (6, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (7, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (8, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (9, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (10, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (11, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (12, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (13, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (14, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (15, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (16, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (17, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (18, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (19, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (20, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (21, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (22, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (23, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (24, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (25, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (26, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (27, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (28, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (29, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (30, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (31, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (32, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (33, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (34, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (35, TRUE, 'HVM816');

INSERT INTO mapa_asientos(num_asiento, disponibilidad, id_avion)
VALUES (36, TRUE, 'HVM816');