import { Photo } from './photo';

export interface User {
    id: number;
    username: string;
    knownAs: string;
    created: Date;
    photoUrl: string;
    city: string;
    country: string;
    interests?: string;
    introduction?: string;
    LookingFor?: string;
    photos?: Photo[];
}
