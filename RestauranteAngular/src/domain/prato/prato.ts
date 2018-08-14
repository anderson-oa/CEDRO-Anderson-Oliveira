import { Restaurante } from '../restaurante/restaurante';

export interface Prato {
  pratoId: number;
  nome: string;
  preco: number;
  restauranteId: number;
  restaurante: Restaurante;
}