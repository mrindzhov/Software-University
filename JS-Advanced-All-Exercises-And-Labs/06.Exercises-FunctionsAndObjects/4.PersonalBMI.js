function PersonalBMI(input) {
    let person = {};
    let name = arguments[0];
    let age = arguments[1];
    let weight = arguments[2];
    let height = arguments[3];

    let BMI = Math.round(weight / (Math.pow((height / 100), 2)));
    let status = '';
    let recommendation = '';

    if(BMI < 18.5){
        status = 'underweight';
    }else if(BMI >= 18.5 && BMI < 25){
        status = 'normal';
    }else if(BMI >= 25 && BMI < 30) {
        status = 'overweight';
    }else{
        status = 'obese';
        recommendation = 'admission required';
    }

    person = {
        name: name, personalInfo: {
            age: age,
            weight: weight,
            height: height
        },
        BMI: BMI,
        status: status
    };

    if(recommendation != ''){
        person['recommendation'] = recommendation;
    }



    return person;
}