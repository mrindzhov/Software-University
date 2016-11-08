(function solve() {
    let nextId = 0;

    class Record {
        constructor(temperature, humidity, pressure, windSpeed) {
            this.id = nextId;
            nextId++;
            this.temperature = Number(temperature);
            this.humidity = Number(humidity);
            this.pressure = Number(pressure);
            this.windSpeed = Number(windSpeed);
        }
        toString(){
            let s = '';
            if(this.temperature < 20 &&
                (this.pressure < 700 || this.pressure > 900) &&
            this.windSpeed > 25){
                s = 'Stormy';
            }else{
                s = 'Not stormy';
            }
            let result =
                'Reading ID: ' + this.id + '\nTemperature: ' + this.temperature + '*C\n' +
                'Relative Humidity: ' + this.humidity + '%\n' + 'Pressure: ' + this.pressure + 'hpa\n' +
                'Wind Speed: ' + this.windSpeed + 'm/s\n' + 'Weather: ' + s;

            return result;
        }
    }

    return Record;
 })();

let record1 = new Record(32, 66, 760, 12);
let report1 = record1.toString();
console.log(report1);
let record2 = new Record(10, 40, 680, 30);
let report2 = record2.toString();
console.log(report2);

/*
Reading ID: 0
Temperature: 32*C
Relative Humidity: 66%
Pressure: 760hpa
Wind Speed: 12m/s
Weather: Not stormy
*/
/*
•	temperature bellow 20
•	pressure bellow 700 OR above 900
•	windSpeed above 25*/

