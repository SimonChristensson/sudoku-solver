requirejs.config({
    //By default load any module IDs from js/lib
    baseUrl: '/scripts/',
    paths: {
        jquery: "jquery-3.1.0.min",
        bootstrap: "bootstrap.min",
        menu: "menu",
        knockout: "knockout-3.4.0"
    },
    shim: {
        'bootstrap': {
            deps: ["jquery"]
        },
        'menu': {
            deps: ["jquery"]
        }
    }
});

// Start the main app logic.
requirejs(
    ["jquery",
    "bootstrap",
    "knockout",
    "scripts/text.js",
    "menu"],
    function ($, bootstrap, ko) {
        // Register components
        ko.components.register("board-view", { require: "Modules/boardViewModule" });

        // Register all bindings
        ko.applyBindings({});

        // Add components to view, create view
    }
 );

/*
<script src="scripts/jquery-3.1.0.min.js"></script>
<script src="scripts/bootstrap.min.js"></script>
<script src="scripts/knockout-3.4.0.js"></script>
<script src="scripts/require.js"></script>
<script src="scripts/text.js"></script>
<script src="scripts/main.js"></script>
*/
/*
$(document).ready(function () {
    // Load views and models here
  
    $.when(
        $.getScript("scripts/Views/mainView.js"),
        $.getScript("scripts/Views/boardView.js"),
        $.Deferred(function( deferred ){
            $( deferred.resolve );
        })
    ).done(function () {
        console.log("loaded scripts");

        ko.components.register("board", {
            viewModel: { require: "scripts/Views/boardView" },
            template: { require: "text!templates/board.html" }
        });

        ko.applyBindings();

        console.log("Register board");

        //place your code here, the scripts are all loaded

    });
    */

   

    // Create a main view and apply binding



    /*
    getStoredDataFileNames();

    $("#fileSelector").change(function () {
        getDataSet(this.value);
        $("#validationMessage").text("");
    });

    $("#solveButton").click(function () {
        var matrix = GetCurrentRows();
        solveSudoku(matrix);
    });

    $("#checkButton").click(function () {
        var matrix = GetCurrentRows();
        var result = sudokuIsValid(matrix);
    });

    $("#resetButton").click(function () {
        getDataSet($("#fileSelector").val());
    });

    $("#hasUniqueSolution").click(function () {
        hasUniqueSolution($("#fileSelector").val());
    });

    console.log("ready!");
});

var host = "http://localhost:8000/"

var populateBoard = function (data) {
    var sudokuBoard = $("#sudokuBoard");
    sudokuBoard.empty();

    for (var i = 0; i < data.length; i++) {
        var columns = "";
        for (var ii = 0; ii < data[i].length; ii++) {

            var value = data[i][ii];

            if (value == null)
                value = "";

            var columns = columns + "<td><input type='text' class='inputElement' maxlength='1' value ='" + value + "'/></td>";
        };

        var row = "<tr>" + columns + "</tr>";
        sudokuBoard.append(row);
    }

    return data;
};

var getStoredDataFileNames = function () {
    var fileSelector = $("#fileSelector");
    $.getJSON(host + "/getstoreddatafilenames", function (data) {
        for (var i = 0; i < data.length; i++) {

            fileSelector.append("<option value='" + data[i] + "'>" + data[i] + "</option>");
        }

        getDataSet(data[0]);

    });
};

var getDataSet = function (fileName) {
    $.getJSON(host + "/getsodukuboard?filename=" + fileName, function (data) {
        populateBoard(data);
        setCurrentFileTitle(fileName);
        $("#difficultyLabel").text("");
    });
};

var setCurrentFileTitle = function (fileName) {
    var sudokuBoard = $("#currentFileName").text(fileName);
};

var GetCurrentRows = function () {
    var board = [];
    $("#sudokuBoard tr").each(function () {
        var rowArray = [];
        var row = this;
        $(row).children("td").each(function () {
            var column = $(this).find("input");
            var value = column.val();
            rowArray.push(value);
        });

        board.push(rowArray);
    });

    return board;
};

var sudokuIsValid = function (matrix) {
    var board = JSON.stringify({ Matrix: matrix });

    $.getJSON(host + "/SodokuIsValid?board=" + board, function (data) {

        if (data.SodokuIsValidResult == true) {
            $("#validationMessage").text("So far so good!");
        }
        else {
            $("#validationMessage").text("A mistake has been made!");
        }

        return data.SodokuIsValidResult;
    });
};

var solveSudoku = function (matrix) {
    var board = JSON.stringify({ Matrix: matrix });

    $.getJSON(host + "/SolveSudoku?board=" + board, function (data) {
        var boardInfo = JSON.parse(data.SolveSudokuResult);
        populateBoard(boardInfo.Solution);
        showDifficulty(boardInfo.Difficulty)
    });
};

var showDifficulty = function (label) {
    $("#difficultyLabel").text("Difficulty: " + label);
};

var hasUniqueSolution = function (fileName) {
    $.getJSON(host + "/HasUniqueSolution?fileName=" + fileName, function (data) {
        if (data == true) {
            $("#isUnique").text("Solution is unique!");
        }
        else {
            $("#isUnique").text("Solution is not unique!");
        }
        return data;
    });

    });
    */



