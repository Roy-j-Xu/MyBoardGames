import { Injectable } from "@angular/core";
import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
import { appConfig } from "../app/app.config";



// @Injectable({
//   providedIn: 'root',
// })
export class HubService {
    private _connection: HubConnection
    private _subscribers: HubSubscriber[]

    constructor() {
        this._connection =
            new HubConnectionBuilder()
                .withUrl(appConfig["hubUrl"])
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

class HubSubscriber {

}