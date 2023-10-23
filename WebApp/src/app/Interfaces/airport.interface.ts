import { Flight } from "./flight.interface";

export interface Airport{//Interface for saving Airport
    id_aereo:string;
    ciudad:string;
    pais:string;
    vuelos:Flight[];
}