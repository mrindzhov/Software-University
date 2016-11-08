function constructionCrew() {
    let person = {
        weight: Number(arguments[0].weight),
        experience: Number(arguments[0].experience),
        bloodAlcoholLevel: Number(arguments[0].bloodAlcoholLevel),
        handsShaking: arguments[0].handsShaking,
        toString: function() {
            return `{ weight: ${this.weight},\n  experience: ${this.experience},\n  bloodAlcoholLevel: ${this.bloodAlcoholLevel},\n  handsShaking: ${this.handsShaking} }`;
        }
    };
    let myPerson = Object.create(person);

    if(myPerson.handsShaking == true){
        myPerson.bloodAlcoholLevel += myPerson.weight * myPerson.experience * 0.1;
        myPerson.handsShaking = false;
    }

    return myPerson;
}