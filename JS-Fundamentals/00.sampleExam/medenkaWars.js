function medenkaWars(input) {

    let vitkorDealtDamage = 0;//white
    let naskorDealtDamage = 0;//dark

    let vitkorPreviousDamage = Number.NEGATIVE_INFINITY;
    let naskorPreviousDamage = Number.NEGATIVE_INFINITY;

    let vitkorConsecutiveAttacks = 0;
    let naskorConsecutiveAttacks = 0;

    let medenkaPower = 60;
    for (let i = 0; i < input.length; i++) {
        let currentInputLine = input[i].split(' ');
        let countOfMedenkas = Number(currentInputLine[0]);
        let medenkaType = currentInputLine[1];

        if (medenkaType == 'white') {
            let medenkaDamage = countOfMedenkas * medenkaPower;
            if (medenkaDamage == vitkorPreviousDamage) {
                vitkorConsecutiveAttacks++;
            }
            else {
                vitkorConsecutiveAttacks = 1;
            }
            if (vitkorConsecutiveAttacks == 2) {
                vitkorDealtDamage += medenkaDamage * 2.75;
                vitkorPreviousDamage = medenkaDamage * 2.75;
                vitkorConsecutiveAttacks = 0;
            } else {
                vitkorDealtDamage += medenkaDamage;
                vitkorPreviousDamage = medenkaDamage;
            }
        }
        else {
            let medenkaDamage = countOfMedenkas * medenkaPower;
            if (medenkaDamage == naskorPreviousDamage) {
                naskorConsecutiveAttacks++;
            }
            else {
                naskorConsecutiveAttacks = 1;
            }
            if (naskorConsecutiveAttacks == 5) {
                naskorDealtDamage += medenkaDamage * 4.5;
                naskorPreviousDamage = medenkaDamage*4.5;
                naskorConsecutiveAttacks = 1;
            } else {
                naskorDealtDamage += medenkaDamage;
                naskorPreviousDamage = medenkaDamage;
            }
        }
    }
    if (naskorDealtDamage > vitkorDealtDamage) {
        console.log(`Winner - Naskor`);
        console.log(`Damage - ` + naskorDealtDamage);
    } else {
        console.log(`Winner - Vitkor`);
        console.log(`Damage - ` + vitkorDealtDamage);
    }
}
let arr=[
    '2 dark medenkas',
    '1 white medenkas',
    '2 dark medenkas',
    '2 dark medenkas',
    '15 white medenkas',
    '2 dark medenkas',
    '2 dark medenkas'
];
medenkaWars(arr);