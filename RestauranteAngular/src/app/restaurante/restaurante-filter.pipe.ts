import { Pipe, PipeTransform } from '@angular/core';
import { Restaurante } from '../../domain/restaurante/restaurante';

@Pipe({
    name: 'restauranteFilter',
    pure: false
})

export class RestauranteFilterPipe implements PipeTransform {
    transform(items: Restaurante[], filter: Restaurante): any {  
        if (!items || !filter) return items;  
        return items.filter(item => item.nome.indexOf(filter.nome) !== -1);  
    }  
}