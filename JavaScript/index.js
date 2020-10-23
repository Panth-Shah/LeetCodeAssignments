let name = {
    Firstname = "Panth",
    Lastname = "Shah"
}

let printName = function (hometown, state, country) {
    console.log(this.Firstname+ " " + this.Lastname + " " + this.hometown 
    + " " + this.state + " " + this.country);
}

let printMyName = printName.bind(name, "Gandhinagar", "Gujarat");
printMyName("India");

//Polyfill function
Function.prototype.mybind = function(...args){
    let obj = this,
    params = args.slice(1);
    return function(...args2){
        obj.apply(args[0], [...parms,...args2]);
    }
}

let printMyName2 = printName.mybind(name, "Pittsburgh", "PA");
printMyName2("USA");


// let multiply = function(x ,y) {
//     console.log(x * y);
// }
//Below is the example of closure
//Creating a box in which this function and x is enclosed
let multiply = function(x){
    return function(y){
        console.log(x * y);
    }
}
//Bind will create a copy of a method and assign it to local var
//This is same as copying this multiply method and setting the '2' hardcoded
let multiplyByTwo = multiply(2);//This arg is refered to x
multiplyByTwo(3);//This arg will refer to y, if y is already passed in method invoking
//This is called function currying
//Way 1: Using Bind method
//Way2 : Uisng function enclosure

