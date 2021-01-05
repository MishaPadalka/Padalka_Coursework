import { Seat } from '../Seats/Seat';

export interface Carriage {
    id: number;
    number: number;
    type: string;
    seats: Seat[];
}
