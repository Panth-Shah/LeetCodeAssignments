let arr = ["Panth", "Shah"];
let object = {
    name: "Panth",
    city: "Pittsburgh",
    getIntro: function(){
        console.log(this.name + "from" + this.city);
    }
}
//arr.__proto__ => Array.Prototype
//arr.__proto__.__proto__ => Object.Prototype => Object.__proto__
//arr.__proto__.__proto__.__proto__ => Object.__proto__.__proto__ => null 
function fun(){

}