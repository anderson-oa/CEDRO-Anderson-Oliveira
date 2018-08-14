export class Message {

    private time: number=3000;
    protected text: string = '';
    protected title: string = '';    
    protected show: string = '';

    onSuccess(text: string) {
        this.text = text;
        this.title = 'Sucesso';        
        this.show = 'is-success visible';
        setTimeout(() => this.hide(), this.time);
    }

    onError(text: string) {
        this.text = text;
        this.title = 'Error';        
        this.show = 'is-danger visible';
        setTimeout(() => this.hide(), this.time);
    }

    hide() {
        this.text = '';
        this.title = '';
        this.show = '';
    }

}