/// <reference path="Scripts/jquery-2.1.0.min.js" />
/// <reference path="/Scripts/jquery-2.1.0.js" />
$( document ).ready(function() {
    
    getStoredDataFileNames();
    
    $("#fileSelector").change(function() 
    {
    	getDataSet(this.value);
    	$("#validationMessage").text("");
    });

    $("#solveButton").click(function() 
    {
    	var matrix = GetCurrentRows();
    	var result = solveSudoku(matrix);
    });

    $("#checkButton").click(function() 
    {
    	var matrix = GetCurrentRows();
    	var result = sudokuIsValid(matrix);
    });

    $("#resetButton").click(function() 
    {
    	getDataSet($("#fileSelector").val());
    });
    
    console.log( "ready!");
});

var host = "http://localhost:8080/"

var populateBoard = function(data) 
{
	var sudokuBoard = $("#sudokuBoard");
	sudokuBoard.empty();

	for (var i = 0; i < data.length; i++) 
	{
		var columns = "";
		for (var ii = 0; ii < data[i].length; ii++) {

			var value = data[i][ii]; 

			if(value == null) 
				value ="";

			var columns =columns+"<td><input type='text' class='inputElement' maxlength='1' value ='"+value+"'/></td>";
		};

		var row = "<tr>"+columns+"</tr>";
		sudokuBoard.append(row);
	}

	return data;
};

var getStoredDataFileNames = function() 
{
	var fileSelector = $("#fileSelector");
	$.getJSON(host + "/getstoreddatafilenames", function (data) {
		for (var i = 0; i < data.length; i++) {

			fileSelector.append("<option value='"+data[i]+"'>"+data[i]+"</option>");
		}

		getDataSet(data[0]);

	});
};

var getDataSet = function(fileName) 
{
	$.getJSON(host + "/getsodukuboard?filename="+fileName, function (data) {
		populateBoard(data);
		setCurrentFileTitle(fileName);
	});
};

var setCurrentFileTitle = function(fileName) 
{
	var sudokuBoard = $("#currentFileName").text(fileName);
};

var GetCurrentRows  = function() 
{
	var board = [];
	$("#sudokuBoard tr").each(function()
	{
		var rowArray = [];
		var row = this;
		$(row).children("td").each(function() 
		{
			var column =  $(this).find("input");
			var value = column.val();
			rowArray.push(value);
		});

		board.push(rowArray);
	});

	return board;
};

var sudokuIsValid = function(matrix) 
{
	var board = JSON.stringify({Matrix: matrix});

	$.getJSON(host + "/SodokuIsValid?board="+board, function(data) {
           
			if(data.SodokuIsValidResult == true) 
			{
				$("#validationMessage").text("So far so good!");
			}
			else 
			{
				$("#validationMessage").text("A mistake has been made!");
			}

           return data.SodokuIsValidResult;
       });	
};

var solveSudoku = function(matrix) 
{
	var board = JSON.stringify({Matrix: matrix});

	$.getJSON(host + "/SolveSudoku?board="+board, function(data) {
           populateBoard(data.SolveSudokuResult);
           return data.SolveSudokuResult;
       });
};

