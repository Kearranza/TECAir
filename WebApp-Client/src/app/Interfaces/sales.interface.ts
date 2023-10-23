export interface Sales{//Interface for saving sales/promo
    id_promo:number;
    descuento:number;
    fecha_inicio:Date;
    fecha_fin:Date;
    origen:string;
    destino:string;
    aplicado_calendario:string;

}
