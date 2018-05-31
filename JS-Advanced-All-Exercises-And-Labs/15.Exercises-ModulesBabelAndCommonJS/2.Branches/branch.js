class Branch{
    constructor(id, branchName, companyName){
        this._id = Number(id);
        this.branchName = branchName;
        this.companyName = companyName;
        this._employees = [];
    }

    get employees(){
        return this._employees;
    }

    hire(employee){
        this._employees.push(employee);
    }

    toString(){
        let res = `@ ${this.companyName}, ${this.branchName}, ${this._id}\n`;
        res += 'Employed:\n';
        if(this.employees.length > 0){
            for (let i = 0; i < this.employees.length; i++) {
                res += `** ${this.employees[i]}\n`;
            }
        }else{
            res += 'None...';
        }

        return res.trim();
    }
}

module.exports = { Branch };