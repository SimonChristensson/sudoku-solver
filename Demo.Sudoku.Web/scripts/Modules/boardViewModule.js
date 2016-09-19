// Recommended AMD module pattern for a Knockout component that:
//  - Can be referenced with just a single 'require' declaration
//  - Can be included in a bundle using the r.js optimizer
define(["knockout", "text!../../templates/board.html"], function(ko, htmlString) {
    
    function boardViewModel(params) {
        // Set up properties, etc.

        this.test = ko.observable("Test");

        this.testar = "Testar igen";

        //$.get();
    }
 
    // Use prototype to declare any public methods
    boardViewModel.prototype.doSomething = function() { return true; };
 
    // Return component definition
    return { viewModel: boardViewModel, template: htmlString };
});