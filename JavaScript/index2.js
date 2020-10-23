document.querySelector("#grandparent")
    .addEventListener('click', () => {
    console.log("GrandParent Clicked!");
}, true);//Capturing
document.querySelector("#parent")
    .addEventListener('click', () => {
    console.log("Parent Clicked!");
}, false);//Bubbling
document.querySelector("#child")
    .addEventListener('click', () => {
    console.log("Child Clicked!");
}, true);//Capturing
//When I will click child. All 3 will be called as event will bubble as 
//default; as if selected false
//Event Capturing: If we have all True, if we click Child. Grandparent will be called
//first and then parent and then child. This is called even trickling/capturing