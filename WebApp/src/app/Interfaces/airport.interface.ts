import { Flight } from "./flight.interface";
export interface Airport{
    id_aereo:string;
    ciudad:string;
    pais:string;
    vuelos:Flight[];
}