export interface Boarding_passpost{//Interface for saving boarding pass
    id_pasaje:number;
    puerta: string;
    asiento?: string;
    hora_salida:string;
    cedula_cliente:number;
    id_calendario:string;
}