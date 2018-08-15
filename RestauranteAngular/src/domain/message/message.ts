export class Message {

    type: MessageType;
    text: string;
    messageId: string;
    keepAfterRouteChange: boolean;

    constructor(init?:Partial<Message>) {
        Object.assign(this, init);
    }
    
}

export enum MessageType {
    Success,
    Error
}