import { Component, Input } from '@angular/core';
import { Message, MessageType } from '../../domain/message/message';
import { MessageService } from '../../domain/message/message-service';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.css']
})

export class MessageComponent {

    @Input() id: string;

    messages: Message[] = [];

    constructor(private _messageService: MessageService) { 
    }

    ngOnInit() {
      this._messageService.getMessage(this.id).subscribe((message: Message) => {
          if (!message.text) {                
              this.messages = [];
              return;
          }            
          this.messages.push(message);
      });
    }

    remove(message: Message) {
      this.messages = this.messages.filter(x => x !== message);
    }

    cssClass(message: Message) {           
      switch (message.type) {
        case MessageType.Success:return 'is-success';
        case MessageType.Error:return 'is-danger';
        default: return;
      }
    }
}