// private part
define(['knockout'], function (ko){
    let names = ["peter", "børge", "lars"];
    let namesObject = ko.observableArray([{name: "bob"}, {name: "bo"}, {name: "susan"}]);
    let firstName = ko.observable("peter");
    let lastName = ko.observable("Olsen");
    // If one of the above changes the computed observable changes.
    let fullName = ko.computed(function(){
        return firstName() + " " + lastName();
        });


    let clickButton = function(){
        firstName("ellen");
    }

    let clickButtonTwo = function(){
        namesObject.push({name: fullName()});
        firstName("");
        lastName("");
    }

    let deleteName = function(data) {
        namesObject.remove(data);
    }
//public part
    return {
        firstName,
        lastName,
        fullName,
        clickButton,
        names,
        namesObject,
        clickButtonTwo,
        deleteName
    }
});