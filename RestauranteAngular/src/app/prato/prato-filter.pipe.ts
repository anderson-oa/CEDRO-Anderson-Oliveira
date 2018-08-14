import { Pipe, PipeTransform } from '@angular/core';
import { Prato } from '../../domain/prato/prato';

@Pipe({
    name: 'pratoFilter',
    pure: false
})

export class PratoFilterPipe implements PipeTransform {
    transform(items: Prato[], filter: Prato): any {  
        if (!items || !filter) return items;
        return items.filter(item => {
            var text = `${item.restaurante.nome} ${item.nome}`;            
            return text.indexOf(filter.nome) !== -1 ? item : null;
        });
    }  
}