import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appHoverButton]'
})
export class HoverButtonDirective {

    constructor(
      public el: ElementRef,
    ) { }
  
    @HostListener('mouseenter') onMouseEnter() {
      this.highlight('rgb(236, 197, 203)');
    }
  
    @HostListener('mouseleave') onMouseLeave() {
      this.highlight('');
    }
  
    private highlight(color: string) {
      this.el.nativeElement.style.backgroundColor = color;
    }
  
}
  