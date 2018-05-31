class MailBox {
    constructor() {
        this.mailBox = [];
    }
    get messageCount() {
        return this.mailBox.length;
    }
    deleteAllMessages() {
        this.mailBox=[];
    }
    addMessage(subject, text) {
        this.mailBox.push({subject, text});
        return this;
    }
    findBySubject(substr) {
        let result=[];
        for (let elemento of this.mailBox) {
            let subject=elemento.subject;
            if(subject.includes(substr)){
                result.push(elemento);
            }
        }
        return result
    }
    toString() {
        if(this.mailBox.length==0){
            return ` * (empty mailbox)`;
        }else {
            return this.mailBox
                .map(m =>' * [' + m.subject + '] ' + m.text)
                .join("\n");
        }
    }
}
let mb = new MailBox();
console.log("Msg count: " + mb.messageCount);
console.log('Messages:\n' + mb);
mb.addMessage("meeting", "Let's meet at 17/11");
mb.addMessage("beer", "Wanna drink beer tomorrow?");
mb.addMessage("question", "How to solve this problem?");
mb.addMessage("Sofia next week", "I am in Sofia next week.");
console.log("Msg count: " + mb.messageCount);
console.log('Messages:\n' + mb);
console.log("Messages holding 'rakiya': " +
    JSON.stringify(mb.findBySubject('rakiya')));
console.log("Messages holding 'ee': " +
    JSON.stringify(mb.findBySubject('ee')));

mb.deleteAllMessages();
console.log("Msg count: " + mb.messageCount);
console.log('Messages:\n' + mb);

console.log("New mailbox:\n" +
    new MailBox()
        .addMessage("Subj 1", "Msg 1")
        .addMessage("Subj 2", "Msg 2")
        .addMessage("Subj 3", "Msg 3")
        .toString());
