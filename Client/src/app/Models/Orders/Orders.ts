export interface Order {
    id: number;
    orderDate: Date;
    numberSeat: number;
    numberCarriage: number;
    nameTrain: string;
    whereGoes: string;
    whereFrom: string;
    departure: Date;
    arrival: Date;
    price: number;
    buyerFirstName: string;
    buyerLastName: string;
}
