import { Student } from "./student.interface";
import { User } from "./user.interface";
import { Baggage } from "./baggage.interface";
import { Boarding_pass } from "./boarding_pass.interface";
import { Credit_card } from "./credit_card.interface";

export interface Client{
    cedula:number;
    nombre:string;
    apellido_1:string;
    apellido_2:string;
    telefono:string;
    correo:string;
    estudiantes:Student[];
    usuarios:User[];
    maletas:Baggage[];
    pases:Boarding_pass[];
    tarjetas:Credit_card[];
}
