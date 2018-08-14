import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})

export class MenuComponent implements OnInit {

  title: string = '';
  isOpen: boolean = false;
  imgRestaurante: string = '../assets/restaurante.png';
  imgPrato: string = '../assets/prato.png';

  constructor(private route: ActivatedRoute, private router: Router) {
  }

  ngOnInit() {

    this.router.events.subscribe(event => {
      if (!(event instanceof NavigationEnd)) return;
      this.title = this.route.root.firstChild.snapshot.data.title;
      this.isOpen = this.route.root.firstChild.snapshot.data.isMenuOpen;
    });
  }
  
}
