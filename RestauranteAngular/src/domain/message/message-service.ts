import { Injectable } from '@angular/core';
import { Router, NavigationStart } from '@angular/router';
import { Observable } from 'rxjs';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/operator/filter';

import { Message, MessageType } from '../message/message';

@Injectable()

export class MessageService {

    private subject = new Subject<Message>();
    private keepAfterRouteChange = false;

    constructor(private router: Router) {        
        router.events.subscribe(event => {
            if (event instanceof NavigationStart) {
                if (this.keepAfterRouteChange) this.keepAfterRouteChange = false;
                else this.clear();
            }
        });
    }
    
    getMessage(messageId?: string): Observable<any> {
        return this.subject.asObservable().filter((x: Message) => x && x.messageId === messageId);
    }
    
    success(text: string) {   
        var message = new Message({ text, type: MessageType.Success }); 
        this.keepAfterRouteChange = message.keepAfterRouteChange;
        this.subject.next(message);
    }

    error(text: string) {
        var message = new Message({ text, type: MessageType.Error }); 
        this.keepAfterRouteChange = message.keepAfterRouteChange;
        this.subject.next(message);    
    }        
    
    clear(messageId?: string) {
        this.subject.next(new Message({ messageId }));
    }
}