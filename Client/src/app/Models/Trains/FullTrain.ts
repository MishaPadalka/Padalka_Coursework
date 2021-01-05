import { Carriage } from '../Carriages/Carriage';

export interface FullTrain {
    id: number;
    name: string;
    whereGoes: string;
    whereFrom: string;
    departure: Date;
    arrival: Date;
    freePlaces: number;
    occupiedPlaces: number;
    carriages: Carriage[];
}
