import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerPolje = false;

  constructor() { }

  ngOnInit(): void {
  }

  promeniRegisterMod() {
    this.registerPolje = !this.registerPolje;
  }

  otkaziRegistracijuMod(event: boolean) {
    this.registerPolje = event;
  }

}
