import { Injectable } from "@angular/core";
import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";



@Injectable({
  providedIn: 'root',
})
export default class HubService {
    private _connection: HubConnection

    constructor() {
        this._connection =
            new HubConnectionBuilder()
                .withUrl('http://localhost:5114/games')
                .build()
        this._connection.on(
            "ReceiveMessage",
            (username: string, message: string) => {
                console.log(`${username}: ${message}`)
            }
        )
    }
    
    public async startConnection(): Promise<void> {
        await this._connection.start();
    }

    public async sendMessage(user: string, message: string): Promise<void> {
        await this._connection.invoke("NewMessage", user, message);
    }


}