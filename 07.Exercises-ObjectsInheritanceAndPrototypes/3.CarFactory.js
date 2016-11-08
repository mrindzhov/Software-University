function carFactory(){
    let car = {
        model: arguments[0].model,
        engine: {
            power: Number(arguments[0].power),
            volume: 0
        },
        carriage: {
            type: arguments[0].carriage,
            color: arguments[0].color
        },
        wheels: [] ,
        toString: function() {
            return `{ model: ${this.model},\n  power: ${this.power},\n  color: ${this.color},\n  carriage: ${this.carriage},\n  wheelsize: ${this.wheelsize} }`;
        }
    };

    let myCar = Object.create(car);
    if(myCar.engine.power <= 90){
        myCar.engine.power = 90;
        myCar.engine.volume = 1800;
    }else if(myCar.engine.power <= 120){
        myCar.engine.power = 120;
        myCar.engine.volume = 2400;
    }else{
        myCar.engine.power = 200;
        myCar.engine.volume = 3500;
    }

    if(arguments[0].wheelsize % 2 == 0){
        arguments[0].wheelsize -= 1;
    }
    myCar.wheels.push(arguments[0].wheelsize);
    myCar.wheels.push(arguments[0].wheelsize);
    myCar.wheels.push(arguments[0].wheelsize);
    myCar.wheels.push(arguments[0].wheelsize);

    return myCar;
}