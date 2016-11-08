function daggersAndSwords(input) {
    function daggerOrSword(length) {
        if (length > 40) {
            return `sword`;
        }
        else
            return `dagger`;
    }
    function applicationOfBlade(length) {
        if ((length - 1) % 5 == 0) {
            return `blade`;
        }if ((length - 2) % 5 == 0) {
            return `quite a blade`;
        }if ((length - 3) % 5 == 0) {
            return `pants-scraper`;
        }if ((length - 4) % 5 == 0) {
            return `frog-butcher`;
        }if ((length - 5) % 5 == 0) {
            return `*rap-poker`;
        }
    }
    let html = `<table border="1">\n<thead>\n<tr><th colspan="3">Blades</th></tr>\n<tr><th>Length [cm]</th><th>Type</th><th>Application</th></tr>\n</thead>\n<tbody>`;
    for (let element of input) {
        let length = parseInt(element);
        if (length > 10) {
            html += `\n<tr><td>${length}</td><td>${daggerOrSword(length)}</td><td>${applicationOfBlade(length)}</td></tr>`;
        }

    }
    html += `\n</tbody>\n</table>`;
    return html;
}
let input= ['17.8', '19.4', '13', '55.8', '126.96541651', '3'];
console.log(daggersAndSwords(input));
