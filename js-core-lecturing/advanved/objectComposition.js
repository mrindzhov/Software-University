function extensibleObject() {
    let myObj = {
        extend: function (template) {

            for (let prop in template) {
                if (typeof template[prop] === "function") {
                    Object.getPrototypeOf(myObj)[prop] = template[prop]
                } else {
                    myObj[prop] = template[prop];
                }
            }
        }
    };

    return myObj;
}


(function () {
    String.prototype.ensureStart = function (str) {
        console.log(this);
        if (!this.startsWith(str)) {
            return str + this;
        }

        return this.toString();
    };

    String.prototype.ensureEnd = function (str) {
        if (!this.endsWith(str)) {
            return this + str;
        }

        return this.toString();
    };

    String.prototype.isEmpty = function () {
        return this.toString() === '';
    };

    String.prototype.truncate = function (n) {
        if (n >= this.length) {
            return this.toString();
        }

        let substrOfThis = this.substring(0, n).trim();
        let indexOfSpace = substrOfThis.lastIndexOf(' ');
        if (indexOfSpace !== -1) {
            return substrOfThis.substring(0, indexOfSpace) + '...';
        }

        return '.'.repeat(n);
    };

    String.format = function (string, ...values) {
        let placeholderIndex = 0;
        for (let value of values) {
            string = string.replace(`{${placeholderIndex}}`, value);
            placeholderIndex++;
        }
        return string;
    }
    ;
})()

function getModule() {
    return {
        selector: undefined,
        allReports: new Map,
        id: 0,
        report: function (author, description, reproducible, severity) {
            this.allReports.set(this.id++, {
                author: author,
                description: description,
                reproducible: reproducible,
                severity: severity,
                status: 'Open'
            });
            this.output(this.selector);
        },
        setStatus: function (id, newStatus) {
            let report = this.allReports.get(id);
            report.status = newStatus;
            this.output(this.selector)
        },
        remove: function (id) {
            this.allReports.delete(id);
            this.output(this.selector)
        },
        sort: function (method) {
            method = method.toLowerCase();
            let sortedEntries = [...this.allReports.entries()]
                .sort(function (a, b) {
                    if (method === 'id') {
                        return a[0] - b[0];
                    } else if (method === 'severity') {
                        return a[1].severity - b[1].severity
                    } else if (method === 'author') {
                        return a[1].author.localeCompare(b[1].author)
                    } else {
                        return a[0] - b[0];
                    }
                });
            for (let [id, report] of sortedEntries) {
                this.allReports.delete(id);
                this.allReports.set(id, report);
            }
            this.output(this.selector)
        },
        output: function (selector) {
            $(selector).empty();
            this.selector = selector;
            for (let [id, report] of this.allReports) {
                $(selector).append($('<div>')
                    .attr('id', `report_${id}`)
                    .addClass('report')
                    .append($('<div>')
                        .addClass('body')
                        .append($('<p>')
                            .text(report.description)))
                    .append($('<div>')
                        .addClass('title')
                        .append($('<span>')
                            .addClass('author')
                            .text(`Submitted by: ${report.author}`))
                        .append($('<span>')
                            .addClass('status')
                            .text(`${report.status} | ${report.severity}`))))
            }
        }
    }
}