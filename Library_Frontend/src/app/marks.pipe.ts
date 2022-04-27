import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'marks'
})
export class MarksPipe implements PipeTransform {

  transform(value: any, ...args: any[]): any {
    return '* '+ value + ':    ' ;
  }

}

