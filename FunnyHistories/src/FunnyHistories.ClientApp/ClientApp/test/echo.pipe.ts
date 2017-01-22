import { Pipe, PipeTransform } from '@angular/core';
import { } from 'jasmine';
@Pipe({
    name: 'echo'
})
export class EchoPipe implements PipeTransform {
    transform(value: any): any {
        return value;
    }
}