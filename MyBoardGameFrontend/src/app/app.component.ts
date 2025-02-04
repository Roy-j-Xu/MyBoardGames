import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import HubService from '../core/signalr.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'MyBoardGameFrontend';
  constructor(private _hubService: HubService) { 
    this._hubService.startConnection().then(() => {
      console.log("Connection successful");
    });
  }
  
  async sendMessage() {
    await this._hubService.sendMessage("TestUser", "Hello!");
  }

}
