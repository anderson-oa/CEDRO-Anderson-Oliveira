import { Pipe, PipeTransform } from '@angular/core';
import { Prato } from '../../domain/prato/prato';

@Pipe({
    name: 'pratoFilter',
    pure: false
})

export class PratoFilterPipe implements PipeTransform {
    transform(items: Prato[], filter: Prato): any {  
        if (!items || !filter) return items;  
        return items.filter(item => (item.nome.indexOf(filter.nome) !== -1 
                                  || item.restaurante.nome.indexOf(filter.nome) !== -1));  
    }  
}