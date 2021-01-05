export interface Train {
    id: number;
    name: string;
    whereGoes: string;
    whereFrom: string;
    departure: Date;
    arrival: Date;
    freePlaces: number;
    occcupiedPlaces: number;
    typesPlace: { [key: string]: number };
}
